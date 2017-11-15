using NewProject.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Data.IService
{
    public interface IAuthenticationService
    {
        Users GetUserByPhone(string phone);
        UserDevice GetUserDevice(int uid = 0, string sessionKey = "");

        void AddUserDevice(UserDevice existsDevice);
        void UpdateUserDevice(UserDevice existsDevice);
        Users GetUser(int userId);
    }
}
