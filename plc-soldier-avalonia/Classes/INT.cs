using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plc_soldier_avalonia.Classes
{
    public class INT : IVariable
    {
        public string Name { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsList { get; set; }
        public int? Value { get; set; }
        public List<INT>? INTs { get; set; }

        public INT(string name, bool isReadOnly, bool isList)
        {
            Name = name;
            IsReadOnly = isReadOnly;
            IsList = isList;

            if (!isList)
            {
                INTs = null;
            }
            else
            {
                Value = null;
            }
        }
    }
}
