using System;
using System.Linq;

using System.Collections.Generic;
using NewProject.Data.Model;
using NewProject.EntityFramework;

namespace NewProject.NetWEBAPI.Utils
{
    public class Worker
    {
        public void Start()
        {
            var t = new System.Timers.Timer();
            t.Elapsed += Execute;
            t.Interval = 120 * 60 * 1000;
            t.Enabled = true;
            t.AutoReset = true;
            t.Start();
        }

        protected void Execute(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                using (var r = new Db())
                {
                    if (r.Users.Count() == 0)
                    {

                        var us = r.Users.AddRange(new List<User> {
                                                        new User { Login = "admin", Password = "123", Roles = new List<Role> { new Role { Name = "administrator" } } }
                                                      , new User { Login = "guest", Password = "123", Roles = new List<Role> { new Role { Name = "guest" } } }
                                                                   }
                                                        );
                        r.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }
    }
}