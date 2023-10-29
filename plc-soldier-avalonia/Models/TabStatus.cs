using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace plc_soldier_avalonia.Models
{
    public static class TabStatus
    {
        public static Dictionary<string, GridLength> gridLengths = new Dictionary<string, GridLength> 
        {
            {"Central_Width", new GridLength()},
            {"RightRight_Width", new GridLength()},
            {"Bottom_Height", new GridLength()},
            {"LULB_Width", new GridLength()},
            {"LeftUpper_Height", new GridLength()},
            {"LeftBottom_Height", new GridLength()},
            {"CRR_Height", new GridLength()},
            {"CRB_Width", new GridLength()},
        };
    }
}
