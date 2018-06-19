using Forum.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static Forum.App.Controllers.SignUpController;

namespace Forum.App.Services
{
    public static class UserService
    {
        public static bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            ForumData forumdata = new ForumData();

            bool userExists = forumdata.Users.Any(u => u.Username == username && u.Password == password);

            return userExists;
        }

        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validUsername || !validPassword)
            {
                return SignUpStatus.DetailsError;
            }

            ForumData forumdata = new ForumData();

            bool userAlreadyExists = forumdata.Users.Any(u => u.Username == username);

            if (!userAlreadyExists)
            {
                int userId = forumdata.Users.LastOrDefault()?.Id + 1 ?? 1;
                User user = new User(userId,username,password,new List<int>());
                forumdata.Users.Add(user);
                forumdata.SaveChanges();

                return SignUpStatus.Success;
            }

            return SignUpStatus.UsernameTakenError;
        }

        internal static User GetUser(int userId)
        {
            var forumData = new ForumData();

            User user = forumData.Users.Find(x => x.Id == userId);

            return user;
        }

        internal static User GetUser(string userName)
        {
            var forumData = new ForumData();

            User user = forumData.Users.Find(x => x.Username == userName);

            return user;
        }
    }

    
}
