using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LRN5.Models
{
    public class FunctionArgument
    {
        public FunctionArgument()
        {

        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int FunctionId { get; set; }

        public int TypeId { get; set; }

        public int ParameterIndex { get; set; }

        public virtual Function Function { get; set; }
    }
}
