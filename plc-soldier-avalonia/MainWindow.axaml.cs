using Avalonia.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using plc_soldier_avalonia.Models;

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

        // List of content for left upper space TabItems
        List<LeftUpperTabItem> leftUpperItems = new List<LeftUpperTabItem>()
        {
            new LeftUpperTabItem(){Header = "Логический органайзер", TreeViewContent = new ObservableCollection<Node> { new Node(@"C:\Users\T\source\repos\plc-soldier-wpf") } },
            new LeftUpperTabItem(){Header = "Контроллер-органайзер", TreeViewContent = null },
        };

        // List of content for left bottom space TabItems
        List<LeftBottomTabItem> leftBottomItems = new List<LeftBottomTabItem>()
        {
            new LeftBottomTabItem(){Content = "какой-то текст", Header = "Left-bottom-space" },
        };

        // List of content for right right space TabItems
        List<RightRightTabItem> rightRightItems = new List<RightRightTabItem>()
        {
            new RightRightTabItem(){Content = "какой-то текст", Header = "Right-right-space" },
        };

        // List of content for central space TabItems
        List<CentralTabItem> centralItems = new List<CentralTabItem>()
        {
            new CentralTabItem(){Content = "какой-то текст", Header = "Central-space" },
        };

        // A list containing bottom space Tabitems
        public ObservableCollection<BottomTabItem> BottomContent { get; set; }

        // A list containing left upper space Tabitems
        public ObservableCollection<LeftUpperTabItem> LeftUpperContent { get; set; }

        // A list containing left bottom space Tabitems
        public ObservableCollection<LeftBottomTabItem> LeftBottomContent { get; set; }

        // A list containing right right space Tabitems
        public ObservableCollection<RightRightTabItem> RightRightContent { get; set; }

        // A list containing central space Tabitems
        public ObservableCollection<CentralTabItem> CentralContent { get; set; }

        public MainWindow()
        {
            BottomContent = new ObservableCollection<BottomTabItem>();
            LeftUpperContent = new ObservableCollection<LeftUpperTabItem>();
            LeftBottomContent = new ObservableCollection<LeftBottomTabItem>();
            RightRightContent = new ObservableCollection<RightRightTabItem>();
            CentralContent = new ObservableCollection<CentralTabItem>();

            AddingTabItemsAtStartup(new List<LeftUpperTabItem>() { leftUpperItems[0] }, 
                                    new List<BottomTabItem>() { bottomItems[0] },
                                    new List<LeftBottomTabItem>() { leftBottomItems[0] },
                                    new List<RightRightTabItem>() { rightRightItems[0] },
                                    new List<CentralTabItem>() { centralItems[0] });

            InitializeComponent();
            
            BottomSpace.ItemsSource = BottomContent;
            LeftUpperSpace.ItemsSource = LeftUpperContent;
            LeftBottomSpace.ItemsSource = LeftBottomContent;
            RightRightSpace.ItemsSource = RightRightContent;
            CentralSpace.ItemsSource = CentralContent;
        }

        // Adding TabItems to TabControl at the startup
        private void AddingTabItemsAtStartup(List<LeftUpperTabItem> leftUpperItemsStartup, List<BottomTabItem> bottomItemsStartup, 
                                             List<LeftBottomTabItem> leftBottomTabItemsStartup, List<RightRightTabItem> rightRightTabItemsStartup,
                                             List<CentralTabItem> centralTabItemsStartup)
        {
            foreach (var item in leftUpperItemsStartup)
            { 
                LeftUpperContent.Add(item);
            }

            foreach (var item in bottomItemsStartup)
            {
                BottomContent.Add(item);
            }

            foreach (var item in leftBottomTabItemsStartup)
            {
                LeftBottomContent.Add(item);
            }

            foreach (var item in rightRightTabItemsStartup)
            {
                RightRightContent.Add(item);
            }

            foreach (var item in centralTabItemsStartup)
            {
                CentralContent.Add(item);
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

                    if (BottomContent.Count == 0 ) 
                    {
                        if (CRB_Grid.RowDefinitions[2].Height != new GridLength(1, GridUnitType.Star) && CRB_Grid.RowDefinitions[2].Height != new GridLength(0, GridUnitType.Pixel))
                            TabStatus.gridLengths["Bottom_Height"] = CRB_Grid.RowDefinitions[2].Height;

                        if ((CentralContent.Count > 0)||(RightRightContent.Count > 0))  
                        {
                            CRB_Grid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                            CRB_Grid.RowDefinitions[2].Height = new GridLength(0, GridUnitType.Pixel);
                        }
                        else
                        {
                            if (LR_Grid.ColumnDefinitions[0].Width != new GridLength(1, GridUnitType.Star) && LR_Grid.ColumnDefinitions[0].Width != new GridLength(0, GridUnitType.Pixel))
                                TabStatus.gridLengths["LULB_Width"] = LR_Grid.ColumnDefinitions[0].Width;

                            LR_Grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                            LR_Grid.ColumnDefinitions[2].Width = new GridLength(0, GridUnitType.Pixel);
                        }
                    }
                } 
                else if (b.DataContext is LeftUpperTabItem leftExample)
                {
                    LeftUpperContent.Remove(leftExample);

                    if (LeftUpperContent.Count == 0)
                    {
                        if (LULB_Grid.RowDefinitions[2].Height != new GridLength(1, GridUnitType.Star) && LULB_Grid.RowDefinitions[2].Height != new GridLength(0, GridUnitType.Pixel))
                            TabStatus.gridLengths["LeftBottom_Height"] = LULB_Grid.RowDefinitions[2].Height;

                        if (LeftBottomContent.Count == 0)
                        {
                            if (LR_Grid.ColumnDefinitions[0].Width != new GridLength(1, GridUnitType.Star) && LR_Grid.ColumnDefinitions[0].Width != new GridLength(0, GridUnitType.Pixel))
                                TabStatus.gridLengths["LULB_Width"] = LR_Grid.ColumnDefinitions[0].Width;

                            LR_Grid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Pixel);
                            LR_Grid.ColumnDefinitions[2].Width = new GridLength(1, GridUnitType.Star);
                        }
                        else
                        {
                            LULB_Grid.RowDefinitions[0].Height = new GridLength(0, GridUnitType.Pixel);
                            LULB_Grid.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);
                        }
                    }
                }
                else if (b.DataContext is LeftBottomTabItem leftBottomExample)
                {
                    LeftBottomContent.Remove(leftBottomExample);

                    if (LeftBottomContent.Count == 0)
                    {
                        if (LULB_Grid.RowDefinitions[2].Height != new GridLength(1, GridUnitType.Star) && LULB_Grid.RowDefinitions[2].Height != new GridLength(0, GridUnitType.Pixel))
                            TabStatus.gridLengths["LeftBottom_Height"] = LULB_Grid.RowDefinitions[2].Height;

                        if (LeftUpperContent.Count == 0)
                        {
                            if (LR_Grid.ColumnDefinitions[0].Width != new GridLength(1, GridUnitType.Star) && LR_Grid.ColumnDefinitions[0].Width != new GridLength(0, GridUnitType.Pixel))
                                TabStatus.gridLengths["LULB_Width"] = LR_Grid.ColumnDefinitions[0].Width;

                            LR_Grid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Pixel);
                            LR_Grid.ColumnDefinitions[2].Width = new GridLength(1, GridUnitType.Star);
                        }
                        else
                        {
                            LULB_Grid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                            LULB_Grid.RowDefinitions[2].Height = new GridLength(0, GridUnitType.Pixel);
                        }
                    }  
                }
                else if (b.DataContext is RightRightTabItem rightRightExample)
                {
                    RightRightContent.Remove(rightRightExample);

                    if (RightRightContent.Count == 0)
                    {
                        if (CRR_Grid.ColumnDefinitions[2].Width != new GridLength(1, GridUnitType.Star) && CRR_Grid.ColumnDefinitions[2].Width != new GridLength(0, GridUnitType.Pixel))
                            TabStatus.gridLengths["RightRight_Width"] = CRR_Grid.ColumnDefinitions[2].Width;

                        if (CentralContent.Count == 0)
                        {
                            if (CRB_Grid.RowDefinitions[2].Height != new GridLength(1, GridUnitType.Star) && CRB_Grid.RowDefinitions[2].Height != new GridLength(0, GridUnitType.Pixel))
                                TabStatus.gridLengths["Bottom_Height"] = CRB_Grid.RowDefinitions[2].Height;

                            CRB_Grid.RowDefinitions[0].Height = new GridLength(0, GridUnitType.Pixel);
                            CRB_Grid.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);
                        }
                        else
                        {
                            CRR_Grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                            CRR_Grid.ColumnDefinitions[2].Width = new GridLength(0, GridUnitType.Pixel);
                        }

                        if (BottomContent.Count == 0 && CentralContent.Count == 0)
                        {
                            if (LR_Grid.ColumnDefinitions[0].Width != new GridLength(1, GridUnitType.Star) && LR_Grid.ColumnDefinitions[0].Width != new GridLength(0, GridUnitType.Pixel))
                                TabStatus.gridLengths["LULB_Width"] = LR_Grid.ColumnDefinitions[0].Width;

                            LR_Grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                            LR_Grid.ColumnDefinitions[2].Width = new GridLength(0, GridUnitType.Pixel);
                        }
                    }
                }
                else if (b.DataContext is CentralTabItem centralExample)
                {
                    CentralContent.Remove(centralExample);

                    if (CentralContent.Count == 0)
                    {
                        if (CRR_Grid.ColumnDefinitions[0].Width != new GridLength(1, GridUnitType.Star) && CRR_Grid.ColumnDefinitions[0].Width != new GridLength(0, GridUnitType.Pixel))
                            TabStatus.gridLengths["RightRight_Width"] = CRR_Grid.ColumnDefinitions[0].Width;

                        if (RightRightContent.Count == 0)
                        {
                            if (CRB_Grid.RowDefinitions[2].Height != new GridLength(1, GridUnitType.Star) && CRB_Grid.RowDefinitions[2].Height != new GridLength(0, GridUnitType.Pixel))
                                TabStatus.gridLengths["Bottom_Height"] = CRB_Grid.RowDefinitions[2].Height;

                            CRB_Grid.RowDefinitions[0].Height = new GridLength(0, GridUnitType.Pixel);
                            CRB_Grid.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);
                        }
                        else
                        {
                            CRR_Grid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Pixel);
                            CRR_Grid.ColumnDefinitions[2].Width = new GridLength(1, GridUnitType.Star);
                        }

                        if (BottomContent.Count == 0 && RightRightContent.Count == 0)
                        {
                            if (LR_Grid.ColumnDefinitions[0].Width != new GridLength(1, GridUnitType.Star) && LR_Grid.ColumnDefinitions[0].Width != new GridLength(0, GridUnitType.Pixel))
                                TabStatus.gridLengths["LULB_Width"] = LR_Grid.ColumnDefinitions[0].Width;

                            LR_Grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                            LR_Grid.ColumnDefinitions[2].Width = new GridLength(0, GridUnitType.Pixel);
                        }
                    }
                }
            }
        }

        // Creating the Logical Organizer TabItem
        private void LogicalOrganizer_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            LeftUpperExpansion();
            LULBExpansion();

            if (!LeftUpperContent.Contains(leftUpperItems[0])) LeftUpperContent.Add(leftUpperItems[0]);
        }

        // Creating the Control Organizer TabItem
        private void ControllerOrganizer_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            LeftUpperExpansion();
            LULBExpansion();

            if (!LeftUpperContent.Contains(leftUpperItems[1])) LeftUpperContent.Add(leftUpperItems[1]);
        }

        // Creating the Errors TabItem
        private void Errors_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            BottomExpansion();
            CRBExpansion();

            if (!BottomContent.Contains(bottomItems[0])) BottomContent.Add(bottomItems[0]);
        }

        // Creating the SearchResults TabItem
        private void SearchResults_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            BottomExpansion();
            CRBExpansion();

            if (!BottomContent.Contains(bottomItems[1])) BottomContent.Add(bottomItems[1]);
        }

        // Creating the Watch TabItem
        private void Watch_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            BottomExpansion();
            CRBExpansion();

            if (!BottomContent.Contains(bottomItems[2])) BottomContent.Add(bottomItems[2]);
        }

        // Creating the [Central-space] TabItem
        private void Central_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            CRBExpansion();
            CRRExpansion();
            CentralExpansion();

            if (!CentralContent.Contains(centralItems[0])) CentralContent.Add(centralItems[0]);
        }

        // Creating the [Right-right-space] TabItem
        private void RightRight_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            RightRightExpansion();
            CRRExpansion();
            CRBExpansion();

            if (!RightRightContent.Contains(rightRightItems[0])) RightRightContent.Add(rightRightItems[0]);
        }

        // Creating the [Left-bottom-space] TabItem
        private void LeftBottom_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            LULBExpansion();
            LeftBottomExpansion();

            if (!LeftBottomContent.Contains(leftBottomItems[0])) LeftBottomContent.Add(leftBottomItems[0]);
        }

        public void BottomExpansion()
        {
            if (BottomContent.Count == 0) 
            {
                if ((CentralContent.Count == 0) && (RightRightContent.Count == 0))
                {
                    CRB_Grid.RowDefinitions[0].Height = new GridLength(0, GridUnitType.Pixel);
                    CRB_Grid.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);
                }
                else
                {
                    CRB_Grid.RowDefinitions[2].Height = TabStatus.gridLengths["Bottom_Height"];
                    CRB_Grid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                }
            }
        }

        public void CRBExpansion() 
        {
            if (CentralContent.Count == 0 && RightRightContent.Count == 0 && BottomContent.Count == 0) 
            { 
                if (LeftUpperContent.Count == 0 && LeftBottomContent.Count == 0)
                {
                    LR_Grid.ColumnDefinitions[2].Width = new GridLength(1, GridUnitType.Star);
                    LR_Grid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Pixel);
                }
                else
                {
                    LR_Grid.ColumnDefinitions[0].Width = TabStatus.gridLengths["LULB_Width"];
                    LR_Grid.ColumnDefinitions[2].Width = new GridLength(1, GridUnitType.Star);
                }
            }
        }

        public void CentralExpansion()
        {
            if (CentralContent.Count == 0)
            {
                if (RightRightContent.Count == 0)
                {
                    CRR_Grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                    CRR_Grid.ColumnDefinitions[2].Width = new GridLength(0, GridUnitType.Pixel);
                }
                else
                {
                    CRR_Grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                    CRR_Grid.ColumnDefinitions[2].Width = TabStatus.gridLengths["RightRight_Width"];
                }
            }
        }

        public void LeftUpperExpansion()
        {
            if (LeftUpperContent.Count == 0)
            {
                if (LeftBottomContent.Count == 0)
                {
                    LULB_Grid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                    LULB_Grid.RowDefinitions[2].Height = new GridLength(0, GridUnitType.Pixel);
                }
                else
                {
                    LULB_Grid.RowDefinitions[2].Height = TabStatus.gridLengths["LeftBottom_Height"];
                    LULB_Grid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                }
            }
        }

        public void LeftBottomExpansion()
        {
            if (LeftBottomContent.Count == 0)
            {
                if (LeftUpperContent.Count == 0)
                {
                    LULB_Grid.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);
                    LULB_Grid.RowDefinitions[0].Height = new GridLength(0, GridUnitType.Pixel);
                }
                else
                {
                    LULB_Grid.RowDefinitions[2].Height = TabStatus.gridLengths["LeftBottom_Height"];
                    LULB_Grid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                }
            }
        }

        public void LULBExpansion()
        {
            if (LeftUpperContent.Count == 0 && LeftBottomContent.Count == 0)
            {
                if (BottomContent.Count == 0 && CentralContent.Count == 0 && RightRightContent.Count == 0) 
                {
                    LR_Grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                    LR_Grid.ColumnDefinitions[2].Width = new GridLength(0, GridUnitType.Pixel);
                }
                else
                {
                    LR_Grid.ColumnDefinitions[0].Width = TabStatus.gridLengths["LULB_Width"];
                    LR_Grid.ColumnDefinitions[2].Width = new GridLength(1, GridUnitType.Star);
                }
            }
        }

        public void RightRightExpansion()
        {
            if (RightRightContent.Count == 0)
            {
                if (CentralContent.Count == 0)
                {
                    CRR_Grid.ColumnDefinitions[2].Width = new GridLength(1, GridUnitType.Star);
                    CRR_Grid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Pixel);
                }
                else
                {
                    CRR_Grid.ColumnDefinitions[2].Width = TabStatus.gridLengths["RightRight_Width"];
                    CRR_Grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                }
            }
        }

        public void CRRExpansion()
        {
            if (CentralContent.Count == 0 && RightRightContent.Count == 0)
            {
                if (BottomContent.Count == 0)
                {
                    CRB_Grid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                    CRB_Grid.RowDefinitions[2].Height = new GridLength(0, GridUnitType.Pixel);
                }
                else
                {
                    CRB_Grid.RowDefinitions[2].Height = TabStatus.gridLengths["Bottom_Height"];
                    CRB_Grid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                }
            }
        }

        private void Exit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}