﻿using System.Collections;
using System.Collections.Generic;

public class Post   
{
    public Post(int id, string title, string content, int categoryId, int authorId, IEnumerable<int> replyIds)
    {
        Id = id;
        Title = title;
        Content = content;
        CategoryId = categoryId;
        AuthorId = authorId;
        ReplyIds = new List<int>(replyIds);
    }

    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public int CategoryId { get; set; }

    public int AuthorId { get; set; }

    public ICollection<int> ReplyIds { get; set; }

}
