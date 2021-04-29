using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LRN5.Models
{
    public class Type
    {
        public Type()
        {
            FunctionResults = new List<Function>();
            MethodBases = new List<Method>();
            MethodResults = new List<Method>();
            FunctionArguments = new List<FunctionArgument>();
            MethodArguments = new List<MethodArgument>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }

        public virtual ICollection<Function> FunctionResults { get; set; }
        
        public virtual ICollection<Method> MethodBases { get; set; }

        public virtual ICollection<Method> MethodResults { get; set; }
        
        public virtual ICollection<FunctionArgument> FunctionArguments { get; set; }
        
        public virtual ICollection<MethodArgument> MethodArguments { get; set; }
    }
}
