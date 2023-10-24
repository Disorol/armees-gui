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
            new BottomTabItem(){Content = "какой-то текст", Header = "Ошибки" },
            new BottomTabItem(){Content = "какой-то текст", Header = "Поиск результатов" },
            new BottomTabItem(){Content = "какой-то текст", Header = "Просмотр" },
        };

        // List of content for left space TabItems
        List<LeftUpperTabItem> leftItems = new List<LeftUpperTabItem>()
        {
            new LeftUpperTabItem(){Header = "Логический органайзер", TreeViewContent = new ObservableCollection<Node> { new Node(@"C:\Users\T\source\repos\plc-soldier-wpf") } },
            new LeftUpperTabItem(){Header = "Контроллер-органайзер", TreeViewContent = null },
        };

        // A list containing bottom space Tabitems
        public ObservableCollection<BottomTabItem> BottomContent { get; set; }
        // A list containing left space Tabitems
        public ObservableCollection<LeftUpperTabItem> LeftContent { get; set; }

        public MainWindow()
        {
            BottomContent = new ObservableCollection<BottomTabItem>();
            LeftContent = new ObservableCollection<LeftUpperTabItem>();

            AddingTabItemsAtStartup(new List<LeftUpperTabItem>() { leftItems[0] }, 
                                    new List<BottomTabItem>() { bottomItems[0] });

            InitializeComponent();

            BottomSpace.ItemsSource = BottomContent;
            LeftSpace.ItemsSource = LeftContent;
        }

        // Adding TabItems to TabControl at the startup
        private void AddingTabItemsAtStartup(List<LeftUpperTabItem> leftItemsStartup, List<BottomTabItem> bottomItemsStartup)
        {
            foreach (var leftItem in leftItemsStartup)
            { 
                LeftContent.Add(leftItem);
            }

            foreach (var bottomItem in bottomItemsStartup)
            {
                BottomContent.Add(bottomItem);
            }
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
                else if (b.DataContext is LeftUpperTabItem leftExample)
                {
                    LeftContent.Remove(leftExample);
                }
            }
        }

        // Creating the Logical Organizer TabItem
        private void LogicalOrganizer_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (!LeftContent.Contains(leftItems[0])) LeftContent.Add(leftItems[0]);
        }

        // Creating the Control Organizer TabItem
        private void ControllerOrganizer_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (!LeftContent.Contains(leftItems[1])) LeftContent.Add(leftItems[1]);
        }

        // Creating the Errors TabItem
        private void Errors_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (!BottomContent.Contains(bottomItems[0])) BottomContent.Add(bottomItems[0]);
        }

        // Creating the SearchResults TabItem
        private void SearchResults_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (!BottomContent.Contains(bottomItems[1])) BottomContent.Add(bottomItems[1]);
        }

        // Creating the Watch TabItem
        private void Watch_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (!BottomContent.Contains(bottomItems[2])) BottomContent.Add(bottomItems[2]);
        }

        private void Exit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}