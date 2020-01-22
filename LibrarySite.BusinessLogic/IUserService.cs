using LibrarySite.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySite.BusinessLogic
{
    public interface IUserService
    {
        User GetOrCreate(string fullName);
    }
}
