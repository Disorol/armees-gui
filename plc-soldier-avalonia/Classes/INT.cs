using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plc_soldier_avalonia.Classes
{
    public class INT : IVariable
    {
        public string Name { get; }
        public string Type { get; }
        public bool isReadOnly { get; }
        public bool isList { get; }
        public int? Value { get; }
        public List<INT>? INTs { get; }
    }
}
