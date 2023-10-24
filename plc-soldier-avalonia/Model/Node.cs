using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plc_soldier_avalonia.Model
{
    /*
        A class with a recursive overloaded constructor for traversing through all directories
        and creating a hierarchy of directories and files using ObservableCollection.
        !!! Files and directories are considered different concepts !!!
    */
    public class Node
    {
        // Collection of child files for this directory. Can be Null for storing files.
        public ObservableCollection<Node>? Subnodes { get; set; }

        // File or directory title. Maybe Null so that empty folders can be opened.
        public string? NodeTitle { get; set; }

        // The path to this file. Maybe Null so that empty folders can be opened.
        public string? PathString { get; set; }

        // Overloaded Constructor for the directory path.
        public Node(string path)
        {
            PathString = path;

            NodeTitle = System.IO.Path.GetFileName(path);

            Subnodes = new ObservableCollection<Node>();

            if (Directory.GetFileSystemEntries(path, "*", SearchOption.TopDirectoryOnly).Length > 0)
            {
                if (Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly).Length > 0)
                {
                    foreach (string subpath in Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly))
                    {
                        Node node = new Node(subpath);

                        Subnodes.Add(node);
                    }
                }

                if (Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Length > 0)
                {
                    foreach (string subpath in Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly))
                    {
                        Node node = new Node(subpath, true);

                        Subnodes.Add(node);
                    }
                }
            }
            else
            {
                // Creating an empty directory

                Node node = new Node(true);

                Subnodes.Add(node);
            }
        }

        // Overloaded Constructor for the file path.
        public Node(string path, bool isFile)
        {
            PathString = path;

            NodeTitle = System.IO.Path.GetFileName(path);
        }

        // Overloaded constructor for opening empty directories
        public Node(bool isEmpty) {}
    }
}
