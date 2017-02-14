using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace BusinessServices
{
    public interface IUserServices
    {
        List<User> GetAllUsers();
        User CreateUser(User user);
    }
}
