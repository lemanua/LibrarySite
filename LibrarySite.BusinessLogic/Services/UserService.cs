using LibrarySite.BusinessLogic.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySite.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private static List<User> _users = new List<User>();

        public User GetOrCreate(string fullName)
        {
            var sanitizedName = fullName.Trim();

            if (string.IsNullOrEmpty(sanitizedName))
            {
                throw new System.ArgumentNullException();
            }

            var user = _users.FirstOrDefault(x => x.FullName == sanitizedName);

            if (user == null)
            {
                user = new User { FullName = sanitizedName };
                _users.Add(user);
            }

            return user;
        }
    }
}
