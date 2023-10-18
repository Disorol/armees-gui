using Avalonia.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using plc_soldier_avalonia.Model;

namespace plc_soldier_avalonia
{
    public partial class MainWindow : Window
    {
        // List of content for bottom space TabItems
        List<BottomTabItem> bottomItems = new List<BottomTabItem>()
        {
            new BottomTabItem(){Content = "какой то текст", Title = "Консоль" },

        };

        // List of content for left space TabItems
        List<LeftTabItem> leftItems = new List<LeftTabItem>()
        {
            new LeftTabItem(){Content = "какой то текст", Title = "Обозреватель решений" },
        };

        // A list containing bottom space Tabitems
        public ObservableCollection<BottomTabItem> BottomContent { get; set; }
        // A list containing left space Tabitems
        public ObservableCollection<LeftTabItem> LeftContent { get; set; }

        public MainWindow()
        {
            BottomContent = new ObservableCollection<BottomTabItem>();
            LeftContent = new ObservableCollection<LeftTabItem>();

            InitializeComponent();

            BottomSpace.ItemsSource = BottomContent;
            LeftSpace.ItemsSource = LeftContent;
        }

        // Removing TabItem
        private void Delete_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                if (b.DataContext is BottomTabItem bottomExample) 
                {
                    BottomContent.Remove(bottomExample);
                } 
                else if (b.DataContext is LeftTabItem leftExample)
                {
                    LeftContent.Remove(leftExample);
                }
            }
        }

        // Creating the Solution Explorer TabItem
        private void Solution_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (!LeftContent.Contains(leftItems[0])) LeftContent.Add(leftItems[0]);
        }

        // Creating the Console TabItem
        private void Console_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (!BottomContent.Contains(bottomItems[0])) BottomContent.Add(bottomItems[0]);
        }

        private void Exit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}