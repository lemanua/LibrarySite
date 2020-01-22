using LibrarySite.BusinessLogic.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySite.BusinessLogic
{
    public class UserService : IUserService
    {
        private static List<User> _users = new List<User>();

        public User GetOrCreate(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                throw new System.ArgumentNullException();
            }

            var user = _users.FirstOrDefault(x => x.FullName == fullName);

            if (user == null)
            {
                user = new User { FullName = fullName };
                _users.Add(user);
            }

            return user;
        }
    }
}
