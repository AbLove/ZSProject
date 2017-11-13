using NewProject.Data.Model;
using System.Collections.Generic;

namespace NewProject.Data.IService
{
    public interface ITestService<T> where T : new()
    {
        List<T> Get();
    }
}
