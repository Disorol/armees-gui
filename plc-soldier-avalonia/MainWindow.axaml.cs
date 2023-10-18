using Avalonia.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace plc_soldier_avalonia
{
    public partial class MainWindow : Window
    {
        List<TabItemExample> items = new List<TabItemExample>()
        {
            new TabItemExample(){Content = "какой то текст", Title = "Шапка" },
            new TabItemExample(){Content = "ЕЩЁ какой то текст", Title = "Другая шапка" },
        };

        public ObservableCollection<TabItemExample> TabItemsContent { get; set; }
        public ObservableCollection<TabItemExample> TabItemsContent2 { get; set; }

        public MainWindow()
        {
            TabItemsContent = new ObservableCollection<TabItemExample>();
            TabItemsContent2 = new ObservableCollection<TabItemExample>();
            InitializeComponent();
            asdsad.ItemsSource = TabItemsContent;
            gagaga.ItemsSource = TabItemsContent2;
        }

        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (sender is Button b && b.DataContext is TabItemExample example)
            {
                TabItemsContent.Remove(example);
            }
        }

        private void Solution_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (!TabItemsContent2.Contains(items[0])) TabItemsContent2.Add(items[0]);
        }
        private void Console_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (!TabItemsContent.Contains(items[1])) TabItemsContent.Add(items[1]);
        }

        private void Exit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class TabItemExample
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}