using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Model
{
    public abstract  class BaseClass
    {
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string CreateBy { get; set; }
    }
}
