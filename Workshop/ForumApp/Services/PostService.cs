using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forum.App.UserInterface.ViewModels;
using Forum.Data;

namespace Forum.App.Services
{
    public static class PostService
    {
        internal static Category GetCategory(int categoryId)
        {

            var forumData = new ForumData();

            Category category = forumData.Categories.Find(x => x.Id == categoryId);

            return category;
        }

        internal static IList<ReplyViewModel> GetPostReplies(int postId)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(p => p.Id == postId);

            IList<ReplyViewModel> replies = new List<ReplyViewModel>();

            foreach (var replyId in post.ReplyIds)
            {
                var reply = forumData.Replies.Find(r => r.Id == replyId);
                replies.Add(new ReplyViewModel(reply));
            }

            return replies;
        }

        internal static string[] GetAllCategoryNames()
        {
            ForumData forumDate = new ForumData();

            var allCategories = forumDate.Categories.Select(x => x.Name).ToArray();

            return allCategories;
        }

        internal static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            ForumData forumDate = new ForumData();

            var postIds = forumDate.Categories.Find(c => c.Id == categoryId).PostIds;

            IEnumerable<Post> posts = forumDate.Posts.Where(p => postIds.Contains(p.Id));

            return posts;
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(p => p.Id == postId);

            PostViewModel pvm = new PostViewModel(post);

            return pvm;
        }

        private static Category EnsureCategory(PostViewModel postView, ForumData forumData)
        {
            var categoryName = postView.Category;
            Category category = forumData.Categories.FirstOrDefault(x => x.Name == categoryName);
            if (category == null)
            {
                var categories = forumData.Categories;
                int categoryId = categories.Any() ? categories.Last().Id + 1 : 1;
                category = new Category(categoryId,categoryName,new List<int>());
                forumData.Categories.Add(category);
            }

            return category;
        }

        public static bool TrySavePosts(PostViewModel postView)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(postView.Category);
            bool emptyTitle = string.IsNullOrWhiteSpace(postView.Title);
            bool emptyContent = !postView.Content.Any();

            if (emptyCategory || emptyContent || emptyTitle)
            {
                return false;
            }

            ForumData forumData = new ForumData();

            Category category = EnsureCategory(postView, forumData);

            
            int postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;

            User author = UserService.GetUser(postView.Author);

            int authorId = author.Id;
            string content = string.Join("", postView.Content);

            Post post = new Post(postId,postView.Title,content,category.Id,authorId,new List<int>());

            forumData.Posts.Add(post);
            author.PostIds.Add(post.Id);
            category.PostIds.Add(post.Id);
            forumData.SaveChanges();

            postView.PostId = postId;

            return true;

        }


    }
}
