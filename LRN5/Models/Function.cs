using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LRN5.Models
{
    public class Function
    {
        public Function()
        {
            FunctionArguments = new List<FunctionArgument>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int LanguageId { get; set; }

        public int ResultTypeId { get; set; }

        public virtual Language Language { get; set; }

        public Type ResultType { get; set; }

        public virtual ICollection<FunctionArgument> FunctionArguments { get; set; }
    }
}
