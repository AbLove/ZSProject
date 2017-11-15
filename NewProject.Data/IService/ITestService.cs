using NewProject.Data.Model;
using System.Collections.Generic;

namespace NewProject.Data.IService
{
    public interface ITestService<T> where T : Entity, new()
    {
        IEnumerable<T> Get();
    }
}
