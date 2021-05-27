using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LRN5.Models
{
    public class MethodArgument
    {
        public MethodArgument()
        {

        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int MethodId { get; set; }

        public int TypeId { get; set; }

        public int ParameterIndex;

        public virtual Method Method { get; set; }
    }
}
