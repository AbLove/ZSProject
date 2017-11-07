using NewMYYT.Core.Model;
using NewMYYT.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewMYYT.Service
{
    public class TestUserService<T> : ITestUserService<T>
    {
        private ITestService s;
        public TestUserService(ITestService s)
        {
            this.s = s;
        }
        public List<T> Get()
        {

            if (typeof(T) == typeof(int))
            {
                return new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 } as List<T>;
            }
            else if (typeof(T) == typeof(User))
            {
                return new List<User> { } as List<T>;
            }
            else
            {
                return s.Get() as List<T>;
            }

        }
    }
}
