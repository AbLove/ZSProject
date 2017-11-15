using NewProject.Data.IService;
using NewProject.Data.Model;
using NewProject.Data.Repository;
using System;
using System.Linq;

/// <summary>
/// 权限验证接口
/// </summary>
namespace NewProject.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ICrudService<Users> _uCurd;
        private readonly IRepo<UserDevice> _udCurd;

        public AuthenticationService(ICrudService<Users> _uCurd, IRepo<UserDevice> _udCurd)
        {
            this._uCurd = _uCurd;
            this._udCurd = _udCurd;
        }
        /// <summary>
        /// 保存登录信息
        /// </summary>
        /// <param name="existsDevice"></param>
        public void AddUserDevice(UserDevice existsDevice)
        {
            _udCurd.Insert(existsDevice);
            _udCurd.Save();
        }
        /// <summary>
        /// 获取用户信息通过id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Users GetUser(int userId)
        {
            var usercach = Common.Caching.Get("UserCach");
            if (usercach != null)
            {
                try
                {
                    return (Users)usercach;
                }
                catch (Exception e)
                {
                    throw new Exception("缓存对象有误！");
                }
            }
            var user = _uCurd.Get(userId);
            if (user != null)
            {
                Common.Caching.Set("UserCach", user, 60);
                return user;
            }
            throw new Exception("未能获取到用户");
        }
        /// <summary>
        /// 获取用户信息通过手机号
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public Users GetUserByPhone(string phone)
        {
            var user = _uCurd.Where(t => t.PhoneNumber.Equals(phone)).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            throw new Exception("未能获取到用户");
        }
        /// <summary>
        /// 取最后一次登录记录
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        public UserDevice GetUserDevice(int Uid, string sessionKey = "")
        {
            if (Uid > 0)
            {
                var user = _udCurd.Where(t => t.UserId == Uid).FirstOrDefault();
                if (user != null)
                {
                    return user;
                }
            }
            else if (!string.IsNullOrEmpty(sessionKey))
            {
                var user = _udCurd.Where(t => t.SessionKey.Equals(sessionKey)).FirstOrDefault();
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }
        /// <summary>
        /// 更新登录记录
        /// </summary>
        /// <param name="existsDevice"></param>
        public void UpdateUserDevice(UserDevice existsDevice)
        {
            _udCurd.Save();
        }
    }
}
