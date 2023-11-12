using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public static class ExtensionToIcon
    {
        // Dictionary of extensions and paths to icons.
        public static Dictionary<string, Uri> Icons = new Dictionary<string, Uri>()
        {
            {".txt", new Uri("avares://plc-soldier-avalonia/assets/images/icons/txt.png")},
        };

        // Getting an icon by path.
        public static Uri GetIcon(string extension)
        {
            if (Icons.TryGetValue(extension, out var icon))
                return icon;
            else
                return new Uri("avares://plc-soldier-avalonia/assets/images/icons/unknown-file.png");
        }
    }
}
