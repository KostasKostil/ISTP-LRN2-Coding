using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LRN5.Models
{
    public class Language
    {
        public Language()
        {
            Types = new List<Type>();
            Functions = new List<Function>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Type> Types { get; set; }
       
        public virtual ICollection<Function> Functions { get; set; }
    }
}
