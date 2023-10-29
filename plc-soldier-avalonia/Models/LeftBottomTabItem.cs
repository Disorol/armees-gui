using plc_soldier_avalonia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plc_soldier_avalonia.Models
{
    public class LeftBottomTabItem : ITabItem
    {
        public string Header { get; set; }
        public string Content { get; set; }
    }
}
