using NewMYYT.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewMYYT.Core.Service
{
    public interface ITestUserService<T>
    {
        List<T> Get();
    }
}
