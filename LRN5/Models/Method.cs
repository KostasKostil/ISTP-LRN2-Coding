using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LRN5.Models
{
    public class Method
    {
        public Method()
        {
            MethodArguments = new List<MethodArgument>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int BaseTypeId { get; set; }

        public int ResultTypeId { get; set; }

        public virtual Type BaseType { get; set; }

        //public virtual Type ResultType { get; set; }

        public virtual ICollection<MethodArgument> MethodArguments { get; set; }
    }
}
