using Microsoft.EntityFrameworkCore;
using NewMYYT.Core.Model;
using NewMYYT.Core.Service;
using NewMYYT.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewMYYT.Service
{
    public class TestService : ITestService
    {
        private readonly Db dbContext= new Db();
        private DbSet<User> table = null;
        public TestService()
        {
            this.table = dbContext.Set<User>();
        }

        public List<User> Get()
        {
            return this.table.Where(t => true).ToList();
            //return new List<string> { "1", "2", "3", "4", "5" };
        }
    }
}
