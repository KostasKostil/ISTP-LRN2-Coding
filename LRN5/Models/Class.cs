using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LRN5.Models
{
    public class Class
    {
        public Class()
        {
            Methods = new List<Method>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }

        public virtual ICollection<Method> Methods { get; set; }
    }
}
