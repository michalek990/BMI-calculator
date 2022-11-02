using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Service;

namespace MyProject.Tests.Service
{
    public class ResultRepository : IResultRepository
    {
        public Task SaveResultAsync(BmiResult result)
        {
            throw new NotImplementedException();
        }
    }
}
