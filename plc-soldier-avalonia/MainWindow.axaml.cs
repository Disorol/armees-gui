using Avalonia.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using plc_soldier_avalonia.Models;
using System.Diagnostics;
using Avalonia.Platform.Storage;
using System.Threading.Tasks;
using Avalonia.Input;
using SkiaSharp;
using Classes;
using Avalonia.Platform;
using plc_soldier_avalonia.Classes;

namespace plc_soldier_avalonia
{
    public partial class MainWindow : Window
    {
        // List of content for bottom space TabItems
        Dictionary<string, BottomTabItem> bottomItems = new Dictionary<string, BottomTabItem>()
        {
            {"Errors", new BottomTabItem(){Content = "какой-то текст", Header = "Ошибки", isVisible = false }},
            {"Search results", new BottomTabItem(){Content = "какой-то текст", Header = "Поиск результатов", isVisible = false }},
            {"Watch", new BottomTabItem(){Content = "какой-то текст", Header = "Просмотр", isVisible = true }},
        };

        // List of content for left upper space TabItems
        Dictionary<string, LeftUpperTabItem> leftUpperItems = new Dictionary<string, LeftUpperTabItem>()
        {
            {"Logical organizer", new LeftUpperTabItem(){Header = "Логический органайзер", TreeViewContent = null } },
        };

        // List of content for left bottom space TabItems
        Dictionary<string, LeftBottomTabItem> leftBottomItems = new Dictionary<string, LeftBottomTabItem>()
        {
            {"Hardware organizer", new LeftBottomTabItem(){Header = "Аппаратный органайзер", Content = "какой-то текст" } },
        };

        // List of content for far right space TabItems
        Dictionary<string, FarRightTabItem> farRightItems = new Dictionary<string, FarRightTabItem>()
        {
            {"Property", new FarRightTabItem(){Content = "какой-то текст", Header = "Свойства" } },
        };

        // List of content for central space TabItems
        Dictionary<string, CentralTabItem> centralItems = new Dictionary<string, CentralTabItem>()
        {
            {"Workspace", new CentralTabItem(){Content = "какой-то текст", Header = "Рабочая область" } },
            {"Variable editor", new CentralTabItem(){Header = "Редактор переменных" } },
        };

        // A list containing bottom space Tabitems
        public ObservableCollection<BottomTabItem> BottomContent { get; set; }

        // A list containing left upper space Tabitems
        public ObservableCollection<LeftUpperTabItem> LeftUpperContent { get; set; }

        // A list containing left bottom space Tabitems
        public ObservableCollection<LeftBottomTabItem> LeftBottomContent { get; set; }

        // A list containing far right space Tabitems
        public ObservableCollection<FarRightTabItem> FarRightContent { get; set; }

        // A list containing central space Tabitems
        public ObservableCollection<CentralTabItem> CentralContent { get; set; }

        // Tooltips for the tool menu
        public ToolToolTip toolToolTips { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            BottomContent = new ObservableCollection<BottomTabItem>();
            LeftUpperContent = new ObservableCollection<LeftUpperTabItem>();
            LeftBottomContent = new ObservableCollection<LeftBottomTabItem>();
            FarRightContent = new ObservableCollection<FarRightTabItem>();
            CentralContent = new ObservableCollection<CentralTabItem>();

            AddingTabItemsAtStartup(new List<LeftUpperTabItem>() { leftUpperItems["Logical organizer"] }, 
                                    new List<BottomTabItem>() { bottomItems["Errors"], bottomItems["Search results"], bottomItems["Watch"] },
                                    new List<LeftBottomTabItem>() { leftBottomItems["Hardware organizer"] },
                                    new List<FarRightTabItem>() { farRightItems["Property"] },
                                    new List<CentralTabItem>() { centralItems["Workspace"] });

            toolToolTips = new ToolToolTip()
            {
                TooltipA = "Всплывающая подсказка 1",
                TooltipB = "Всплывающая подсказка 2",
                TooltipC = "Всплывающая подсказка 3",
                TooltipD = "Всплывающая подсказка 4",
                TooltipE = "Всплывающая подсказка 5",
                TooltipF = "Всплывающая подсказка 6",
                TooltipG = "Всплывающая подсказка 7",
                TooltipH = "Всплывающая подсказка 8",
                TooltipI = "Всплывающая подсказка 9"
            };  

            BottomSpace.ItemsSource = BottomContent;
            LeftUpperSpace.ItemsSource = LeftUpperContent;
            LeftBottomSpace.ItemsSource = LeftBottomContent;
            FarRightSpace.ItemsSource = FarRightContent;
            CentralSpace.ItemsSource = CentralContent;

            ToolsMenu.DataContext = toolToolTips;

            // Adding Mouse click Event tracking
            this.AddHandler(PointerPressedEvent, MouseDownHandler, handledEventsToo: true);
        }

        // Adding TabItems to TabControl at the startup
        private void AddingTabItemsAtStartup(List<LeftUpperTabItem> leftUpperTabItemsStartup, List<BottomTabItem> bottomTabItemsStartup, 
                                             List<LeftBottomTabItem> leftBottomTabItemsStartup, List<FarRightTabItem> farRightTabItemsStartup,
                                             List<CentralTabItem> centralTabItemsStartup)
        {
            /*
                Checking for adding tabs to spaces. 
                If added, the corresponding buttons in the "view" menu item are disabled.
            */
            if (leftUpperTabItemsStartup.Contains(leftUpperItems["Logical organizer"]))
                LogicalOrganizer_MenuItem.IsEnabled = false;

            if (leftBottomTabItemsStartup.Contains(leftBottomItems["Hardware organizer"]))
                HardwareOrganizer_MenuItem.IsEnabled = false;

            if (bottomTabItemsStartup.Contains(bottomItems["Errors"]))
                Errors_MenuItem.IsEnabled = false;

            if (bottomTabItemsStartup.Contains(bottomItems["Search results"]))
                SearchResults_MenuItem.IsEnabled = false;

            if (bottomTabItemsStartup.Contains(bottomItems["Watch"]))
                Watch_MenuItem.IsEnabled = false;

            if (centralTabItemsStartup.Contains(centralItems["Workspace"]))
                WorkSpace_MenuItem.IsEnabled = false;

            if (farRightTabItemsStartup.Contains(farRightItems["Property"]))
                Property_MenuItem.IsEnabled = false;

            foreach (var item in leftUpperTabItemsStartup)
            { 
                LeftUpperContent.Add(item);
            }

            foreach (var item in bottomTabItemsStartup)
            {
                BottomContent.Add(item);
            }

            foreach (var item in leftBottomTabItemsStartup)
            {
                LeftBottomContent.Add(item);
            }

            foreach (var item in farRightTabItemsStartup)
            {
                FarRightContent.Add(item);
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
                if (b.DataContext is BottomTabItem bottomExample) // Removing BottomTabItem
                {
                    if (bottomExample == bottomItems["Errors"] || bottomExample == bottomItems["Search results"] || bottomExample == bottomItems["Watch"])
                    {
                        BottomContent.Remove(bottomItems["Errors"]);
                        BottomContent.Remove(bottomItems["Search results"]);
                        BottomContent.Remove(bottomItems["Watch"]);
                        Errors_MenuItem.IsEnabled = true;
                        SearchResults_MenuItem.IsEnabled = true;
                        Watch_MenuItem.IsEnabled = true;
                    }
                    
                    if (BottomContent.Count == 0 ) 
                    {
                        /* 
                            Checking for an attempt to write values of 1 Star or 0 Pixel to TabStatus.
                            It is necessary to record only the initial pixel values.
                        */
                        if (CRB_Grid.RowDefinitions[2].Height != new GridLength(1, GridUnitType.Star) && CRB_Grid.RowDefinitions[2].Height != new GridLength(0, GridUnitType.Pixel))
                            TabStatus.gridLengths["Bottom_Height"] = CRB_Grid.RowDefinitions[2].Height;

                        if ((CentralContent.Count > 0)||(FarRightContent.Count > 0))  
                        {
                            CRB_Grid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                            CRB_Grid.RowDefinitions[2].Height = new GridLength(0, GridUnitType.Pixel);

                            CRB_Splitter.IsVisible = false;
                        }
                        else
                        {
                            /* 
                                Checking for an attempt to write values of 1 Star or 0 Pixel to TabStatus.
                                It is necessary to record only the initial pixel values.
                            */
                            if (LR_Grid.ColumnDefinitions[0].Width != new GridLength(1, GridUnitType.Star) && LR_Grid.ColumnDefinitions[0].Width != new GridLength(0, GridUnitType.Pixel))
                                TabStatus.gridLengths["LULB_Width"] = LR_Grid.ColumnDefinitions[0].Width;

                            LR_Grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                            LR_Grid.ColumnDefinitions[2].Width = new GridLength(0, GridUnitType.Pixel);

                            LR_Splitter.IsVisible = false;
                        }
                    }
                } 
                else if (b.DataContext is LeftUpperTabItem leftUpperExample) // Removing LeftUpperTabItem
                {
                    if (leftUpperExample == leftUpperItems["Logical organizer"])
                    {
                        LeftUpperContent.Remove(leftUpperItems["Logical organizer"]);
                        LogicalOrganizer_MenuItem.IsEnabled = true;
                    }

                    if (LeftUpperContent.Count == 0)
                    {
                        /* 
                            Checking for an attempt to write values of 1 Star or 0 Pixel to TabStatus.
                            It is necessary to record only the initial pixel values.
                        */
                        if (LULB_Grid.RowDefinitions[2].Height != new GridLength(1, GridUnitType.Star) && LULB_Grid.RowDefinitions[2].Height != new GridLength(0, GridUnitType.Pixel))
                            TabStatus.gridLengths["LeftBottom_Height"] = LULB_Grid.RowDefinitions[2].Height;

                        if (LeftBottomContent.Count == 0)
                        {
                            /* 
                                Checking for an attempt to write values of 1 Star or 0 Pixel to TabStatus.
                                It is necessary to record only the initial pixel values.
                            */
                            if (LR_Grid.ColumnDefinitions[0].Width != new GridLength(1, GridUnitType.Star) && LR_Grid.ColumnDefinitions[0].Width != new GridLength(0, GridUnitType.Pixel))
                                TabStatus.gridLengths["LULB_Width"] = LR_Grid.ColumnDefinitions[0].Width;

                            LR_Grid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Pixel);
                            LR_Grid.ColumnDefinitions[2].Width = new GridLength(1, GridUnitType.Star);

                            LR_Splitter.IsVisible = false;
                        }
                        else
                        {
                            LULB_Grid.RowDefinitions[0].Height = new GridLength(0, GridUnitType.Pixel);
                            LULB_Grid.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);

                            LULB_Splitter.IsVisible = false;
                        }
                    }
                }
                else if (b.DataContext is LeftBottomTabItem leftBottomExample) // Removing LeftBottomTabItem
                {
                    if (leftBottomExample == leftBottomItems["Hardware organizer"])
                    {
                        LeftBottomContent.Remove(leftBottomItems["Hardware organizer"]);
                        HardwareOrganizer_MenuItem.IsEnabled = true;
                    }

                    if (LeftBottomContent.Count == 0)
                    {
                        /* 
                            Checking for an attempt to write values of 1 Star or 0 Pixel to TabStatus.
                            It is necessary to record only the initial pixel values.
                        */
                        if (LULB_Grid.RowDefinitions[2].Height != new GridLength(1, GridUnitType.Star) && LULB_Grid.RowDefinitions[2].Height != new GridLength(0, GridUnitType.Pixel))
                            TabStatus.gridLengths["LeftBottom_Height"] = LULB_Grid.RowDefinitions[2].Height;

                        if (LeftUpperContent.Count == 0)
                        {
                            /* 
                                Checking for an attempt to write values of 1 Star or 0 Pixel to TabStatus.
                                It is necessary to record only the initial pixel values.
                            */
                            if (LR_Grid.ColumnDefinitions[0].Width != new GridLength(1, GridUnitType.Star) && LR_Grid.ColumnDefinitions[0].Width != new GridLength(0, GridUnitType.Pixel))
                                TabStatus.gridLengths["LULB_Width"] = LR_Grid.ColumnDefinitions[0].Width;

                            LR_Grid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Pixel);
                            LR_Grid.ColumnDefinitions[2].Width = new GridLength(1, GridUnitType.Star);

                            LR_Splitter.IsVisible = false;
                        }
                        else
                        {
                            LULB_Grid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                            LULB_Grid.RowDefinitions[2].Height = new GridLength(0, GridUnitType.Pixel);

                            LULB_Splitter.IsVisible = false;
                        }
                    }  
                }
                else if (b.DataContext is FarRightTabItem farRightExample) // Removing FarRightTabItem
                {
                    if (farRightExample == farRightItems["Property"])
                    {
                        FarRightContent.Remove(farRightItems["Property"]);
                        Property_MenuItem.IsEnabled = true;
                    }
                    

                    if (FarRightContent.Count == 0)
                    {
                        /* 
                            Checking for an attempt to write values of 1 Star or 0 Pixel to TabStatus.
                            It is necessary to record only the initial pixel values.
                        */
                        if (CRR_Grid.ColumnDefinitions[2].Width != new GridLength(1, GridUnitType.Star) && CRR_Grid.ColumnDefinitions[2].Width != new GridLength(0, GridUnitType.Pixel))
                            TabStatus.gridLengths["FarRight_Width"] = CRR_Grid.ColumnDefinitions[2].Width;

                        if (BottomContent.Count == 0 && CentralContent.Count == 0)
                        {
                            /* 
                                Checking for an attempt to write values of 1 Star or 0 Pixel to TabStatus.
                                It is necessary to record only the initial pixel values.
                            */
                            if (LR_Grid.ColumnDefinitions[0].Width != new GridLength(1, GridUnitType.Star) && LR_Grid.ColumnDefinitions[0].Width != new GridLength(0, GridUnitType.Pixel))
                                TabStatus.gridLengths["LULB_Width"] = LR_Grid.ColumnDefinitions[0].Width;

                            LR_Grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                            LR_Grid.ColumnDefinitions[2].Width = new GridLength(0, GridUnitType.Pixel);

                            LR_Splitter.IsVisible = false;
                        }
                        else if (CentralContent.Count == 0)
                        {
                            /* 
                                Checking for an attempt to write values of 1 Star or 0 Pixel to TabStatus.
                                It is necessary to record only the initial pixel values.
                            */
                            if (CRB_Grid.RowDefinitions[2].Height != new GridLength(1, GridUnitType.Star) && CRB_Grid.RowDefinitions[2].Height != new GridLength(0, GridUnitType.Pixel))
                                TabStatus.gridLengths["Bottom_Height"] = CRB_Grid.RowDefinitions[2].Height;

                            CRB_Grid.RowDefinitions[0].Height = new GridLength(0, GridUnitType.Pixel);
                            CRB_Grid.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);

                            CRB_Splitter.IsVisible = false;
                        }
                        else
                        {
                            CRR_Grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                            CRR_Grid.ColumnDefinitions[2].Width = new GridLength(0, GridUnitType.Pixel);

                            CRR_Splitter.IsVisible = false;
                        }    
                    }
                }
                else if (b.DataContext is CentralTabItem centralExample) // Removing CentralTabItem
                {
                    if (centralExample == centralItems["Workspace"])
                    {
                        CentralContent.Remove(centralItems["Workspace"]);
                        WorkSpace_MenuItem.IsEnabled = true;
                    }
                    else if (centralExample == centralItems["Variable editor"])
                    {
                        CentralContent.Remove(centralItems["Variable editor"]);
                        VariableEditor_MenuItem.IsEnabled = true;
                    }

                    if (CentralContent.Count == 0)
                    {
                        /* 
                            Checking for an attempt to write values of 1 Star or 0 Pixel to TabStatus.
                            It is necessary to record only the initial pixel values.
                        */
                        if (CRR_Grid.ColumnDefinitions[0].Width != new GridLength(1, GridUnitType.Star) && CRR_Grid.ColumnDefinitions[0].Width != new GridLength(0, GridUnitType.Pixel))
                            TabStatus.gridLengths["RightRight_Width"] = CRR_Grid.ColumnDefinitions[0].Width;

                        if (BottomContent.Count == 0 && FarRightContent.Count == 0)
                        {
                            /* 
                                Checking for an attempt to write values of 1 Star or 0 Pixel to TabStatus.
                                It is necessary to record only the initial pixel values.
                            */
                            if (LR_Grid.ColumnDefinitions[0].Width != new GridLength(1, GridUnitType.Star) && LR_Grid.ColumnDefinitions[0].Width != new GridLength(0, GridUnitType.Pixel))
                                TabStatus.gridLengths["LULB_Width"] = LR_Grid.ColumnDefinitions[0].Width;

                            LR_Grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                            LR_Grid.ColumnDefinitions[2].Width = new GridLength(0, GridUnitType.Pixel);

                            LR_Splitter.IsVisible = false;
                        }
                        else if (FarRightContent.Count == 0)
                        {
                            /* 
                                Checking for an attempt to write values of 1 Star or 0 Pixel to TabStatus.
                                It is necessary to record only the initial pixel values.
                            */
                            if (CRB_Grid.RowDefinitions[2].Height != new GridLength(1, GridUnitType.Star) && CRB_Grid.RowDefinitions[2].Height != new GridLength(0, GridUnitType.Pixel))
                                TabStatus.gridLengths["Bottom_Height"] = CRB_Grid.RowDefinitions[2].Height;

                            CRB_Grid.RowDefinitions[0].Height = new GridLength(0, GridUnitType.Pixel);
                            CRB_Grid.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);

                            CRB_Splitter.IsVisible = false;
                        }
                        else
                        {
                            CRR_Grid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Pixel);
                            CRR_Grid.ColumnDefinitions[2].Width = new GridLength(1, GridUnitType.Star);

                            CRR_Splitter.IsVisible = false;
                        }
                    }
                }
            }
        }

        // Creating the Logical organizer TabItem
        private void LogicalOrganizer_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            LeftUpperExpansion();
            LULBExpansion();

            if (!LeftUpperContent.Contains(leftUpperItems["Logical organizer"]))
            {
                LeftUpperContent.Add(leftUpperItems["Logical organizer"]);
                LogicalOrganizer_MenuItem.IsEnabled = false;
            }        
        }

        // Creating the Control organizer TabItem
        private void HardwareOrganizer_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            LeftBottomExpansion();
            LULBExpansion();

            if (!LeftBottomContent.Contains(leftBottomItems["Hardware organizer"]))
            {
                LeftBottomContent.Add(leftBottomItems["Hardware organizer"]);
                HardwareOrganizer_MenuItem.IsEnabled = false;
            }
        }

        // Creating the Errors TabItem
        private void Errors_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            BottomExpansion();
            CRBExpansion();

            if (!BottomContent.Contains(bottomItems["Errors"]))
            {
                BottomContent.Add(bottomItems["Errors"]);
                Errors_MenuItem.IsEnabled = false;
            }
            if (!BottomContent.Contains(bottomItems["Search results"]))
            {
                BottomContent.Add(bottomItems["Search results"]);
                SearchResults_MenuItem.IsEnabled = false;
            }
            if (!BottomContent.Contains(bottomItems["Watch"]))
            {
                BottomContent.Add(bottomItems["Watch"]);
                Watch_MenuItem.IsEnabled = false;
            }
        }

        // Creating the Search results TabItem
        private void SearchResults_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            BottomExpansion();
            CRBExpansion();

            if (!BottomContent.Contains(bottomItems["Errors"]))
            {
                BottomContent.Add(bottomItems["Errors"]);
                Errors_MenuItem.IsEnabled = false;
            }
            if (!BottomContent.Contains(bottomItems["Search results"]))
            {
                BottomContent.Add(bottomItems["Search results"]);
                SearchResults_MenuItem.IsEnabled = false;
            }
            if (!BottomContent.Contains(bottomItems["Watch"]))
            {
                BottomContent.Add(bottomItems["Watch"]);
                Watch_MenuItem.IsEnabled = false;
            }
        }

        // Creating the Watch TabItem
        private void Watch_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            BottomExpansion();
            CRBExpansion();

            if (!BottomContent.Contains(bottomItems["Errors"]))
            {
                BottomContent.Add(bottomItems["Errors"]);
                Errors_MenuItem.IsEnabled = false;
            }
            if (!BottomContent.Contains(bottomItems["Search results"]))
            {
                BottomContent.Add(bottomItems["Search results"]);
                SearchResults_MenuItem.IsEnabled = false;
            }
            if (!BottomContent.Contains(bottomItems["Watch"]))
            {
                BottomContent.Add(bottomItems["Watch"]);
                Watch_MenuItem.IsEnabled = false;
            }
        }

        // Creating the Workpace TabItem
        private void Work_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            CRBExpansion();
            CRRExpansion();
            CentralExpansion();

            if (!CentralContent.Contains(centralItems["Workspace"]))
            {
                CentralContent.Add(centralItems["Workspace"]);
                WorkSpace_MenuItem.IsEnabled = false;
            }
        }

        private void VariableEditor_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            CRBExpansion();
            CRRExpansion();
            CentralExpansion();

            if (!CentralContent.Contains(centralItems["Variable editor"]))
            {
                CentralContent.Add(centralItems["Variable editor"]);
                VariableEditor_MenuItem.IsEnabled = false;
            }
        }

        // Creating the Property TabItem
        private void Property_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            FarRightExpansion();
            CRRExpansion();
            CRBExpansion();

            if (!FarRightContent.Contains(farRightItems["Property"]))
            {
                FarRightContent.Add(farRightItems["Property"]);
                Property_MenuItem.IsEnabled = false;
            } 
        }

        public void BottomExpansion()
        {
            if (BottomContent.Count == 0) 
            {
                if ((CentralContent.Count == 0) && (FarRightContent.Count == 0))
                {
                    CRB_Grid.RowDefinitions[0].Height = new GridLength(0, GridUnitType.Pixel);
                    CRB_Grid.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);
                }
                else
                {
                    CRB_Grid.RowDefinitions[2].Height = TabStatus.gridLengths["Bottom_Height"];
                    CRB_Grid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);

                    CRB_Splitter.IsVisible = true;
                }
            }
        }

        public void CRBExpansion() 
        {
            if (CentralContent.Count == 0 && FarRightContent.Count == 0 && BottomContent.Count == 0) 
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

                    LR_Splitter.IsVisible = true;
                }
            }
        }

        public void CentralExpansion()
        {
            if (CentralContent.Count == 0)
            {
                if (FarRightContent.Count == 0)
                {
                    CRR_Grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                    CRR_Grid.ColumnDefinitions[2].Width = new GridLength(0, GridUnitType.Pixel);
                }
                else
                {
                    CRR_Grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                    CRR_Grid.ColumnDefinitions[2].Width = TabStatus.gridLengths["FarRight_Width"];

                    CRR_Splitter.IsVisible = true;
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

                    LULB_Splitter.IsVisible = true;
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

                    LULB_Splitter.IsVisible = true;
                }
            }
        }

        public void LULBExpansion()
        {
            if (LeftUpperContent.Count == 0 && LeftBottomContent.Count == 0)
            {
                if (BottomContent.Count == 0 && CentralContent.Count == 0 && FarRightContent.Count == 0) 
                {
                    LR_Grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                    LR_Grid.ColumnDefinitions[2].Width = new GridLength(0, GridUnitType.Pixel);
                }
                else
                {
                    LR_Grid.ColumnDefinitions[0].Width = TabStatus.gridLengths["LULB_Width"];
                    LR_Grid.ColumnDefinitions[2].Width = new GridLength(1, GridUnitType.Star);

                    LR_Splitter.IsVisible = true;
                }
            }
        }

        public void FarRightExpansion()
        {
            if (FarRightContent.Count == 0)
            {
                if (CentralContent.Count == 0)
                {
                    CRR_Grid.ColumnDefinitions[2].Width = new GridLength(1, GridUnitType.Star);
                    CRR_Grid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Pixel);
                }
                else
                {
                    CRR_Grid.ColumnDefinitions[2].Width = TabStatus.gridLengths["FarRight_Width"];
                    CRR_Grid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);

                    CRR_Splitter.IsVisible = true;
                }
            }
        }

        public void CRRExpansion()
        {
            if (CentralContent.Count == 0 && FarRightContent.Count == 0)
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

                    CRB_Splitter.IsVisible = true;
                }
            }
        }

        // Translation of the application into the language depending on the input parameter
        public void ApplicationTranslation(string language)
        {
            int languageIndex = ApplicationLocalozation.GetLanguageIndex(language);

            this.Title = ApplicationLocalozation.ApplicationTitle[languageIndex];

            File_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["File"][languageIndex];
            NewProject_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["New project"][languageIndex];
            OpenProject_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Open project"][languageIndex];
            Settings_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Settings"][languageIndex];
            Language_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Language"][languageIndex];
            Russian_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Russian"][languageIndex];
            English_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["English"][languageIndex];
            Exit_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Exit"][languageIndex];
            Edit_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Edit"][languageIndex];
            View_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["View"][languageIndex];
            LogicalOrganizer_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Logical organizer"][languageIndex];
            HardwareOrganizer_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Hardware organizer"][languageIndex];
            Errors_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Errors"][languageIndex];
            SearchResults_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Search results"][languageIndex];
            Watch_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Watch"][languageIndex];
            WorkSpace_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Workspace"][languageIndex];
            Property_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Property"][languageIndex];
            Search_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Search"][languageIndex];
            Logic_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Logic"][languageIndex];
            Communications_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Communications"][languageIndex];
            Tools_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Tools"][languageIndex];
            Window_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Window"][languageIndex];
            Help_MenuItem.Header = ApplicationLocalozation.TopMenuTranslations["Help"][languageIndex];

            bottomItems["Errors"].Header = ApplicationLocalozation.BottomItemsTranslations[0][languageIndex].Header;
            bottomItems["Errors"].Content = ApplicationLocalozation.BottomItemsTranslations[0][languageIndex].Content;
            bottomItems["Search results"].Header = ApplicationLocalozation.BottomItemsTranslations[1][languageIndex].Header;
            bottomItems["Search results"].Content = ApplicationLocalozation.BottomItemsTranslations[1][languageIndex].Content;
            bottomItems["Watch"].Header = ApplicationLocalozation.BottomItemsTranslations[2][languageIndex].Header;
            bottomItems["Watch"].Content = ApplicationLocalozation.BottomItemsTranslations[2][languageIndex].Content;

            leftUpperItems["Logical organizer"].Header = ApplicationLocalozation.LeftUpperItemsTranslations[0][languageIndex].Header;

            leftBottomItems["Hardware organizer"].Header = ApplicationLocalozation.LeftBottomItemsTranslations[0][languageIndex].Header;
            leftBottomItems["Hardware organizer"].Content = ApplicationLocalozation.LeftBottomItemsTranslations[0][languageIndex].Content;

            farRightItems["Property"].Header = ApplicationLocalozation.FarRightItemsTranslations[0][languageIndex].Header;
            farRightItems["Property"].Content = ApplicationLocalozation.FarRightItemsTranslations[0][languageIndex].Content;

            centralItems["Workspace"].Header = ApplicationLocalozation.CentralItemsTranslations[0][languageIndex].Header;
            centralItems["Workspace"].Content = ApplicationLocalozation.CentralItemsTranslations[0][languageIndex].Content;

            centralItems["Variable editor"].Header = ApplicationLocalozation.CentralItemsTranslations[1][languageIndex].Header;

            toolToolTips = ApplicationLocalozation.ToolToolTipTranslations[languageIndex];

            // Clearing and repopulating ItemsSource and DataContext. This is necessary to update the data.

            BottomSpace.ItemsSource = null;
            LeftUpperSpace.ItemsSource = null;
            LeftBottomSpace.ItemsSource = null;
            FarRightSpace.ItemsSource = null;
            CentralSpace.ItemsSource = null;

            BottomSpace.ItemsSource = BottomContent;
            LeftUpperSpace.ItemsSource = LeftUpperContent;
            LeftBottomSpace.ItemsSource = LeftBottomContent;
            FarRightSpace.ItemsSource = FarRightContent;
            CentralSpace.ItemsSource = CentralContent;

            ToolsMenu.DataContext = null;

            ToolsMenu.DataContext = toolToolTips;
        }

        // Translation of the application into Russian
        private void Russian_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            ApplicationTranslation("russian");
        }

        // Translation of the application into English
        private void English_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            ApplicationTranslation("english");
        }

        // Opening the project folder and displaying it in the logical organizer
        private async void OpenProject_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var dialog = new OpenFolderDialog();

            var result = await dialog.ShowAsync(this);

            if (result != null)
            {
                leftUpperItems["Logical organizer"].TreeViewContent = new ObservableCollection<Node> { new Node(result) };

                LeftUpperSpace.ItemsSource = null;

                LeftUpperSpace.ItemsSource = LeftUpperContent;
            }
        }

        // The event of clicking down the mouse button
        private void MouseDownHandler(object sender, PointerPressedEventArgs e)
        {
            var point = e.GetCurrentPoint(sender as Control);

            var xCursor = point.Position.X;
            var yCursor = point.Position.Y;

            var yTop_LeftUpperSpace = Main_Grid.RowDefinitions[0].Height.Value + Main_Grid.RowDefinitions[1].Height.Value + Main_Grid.RowDefinitions[2].Height.Value;
            var yBottom_LeftUpperSpace = this.Height - LULB_Grid.RowDefinitions[1].Height.Value - LULB_Grid.RowDefinitions[2].Height.Value;
            var xRight_LeftUpperSpace = LR_Grid.ColumnDefinitions[0].Width.Value;

            if (xCursor <= xRight_LeftUpperSpace && yCursor >= yTop_LeftUpperSpace && yCursor <= yBottom_LeftUpperSpace)
            {
                // functional
            }

            // var k = point.Pointer.Captured;

            // var i = LeftUpperSpace.DataContext as ObservableCollection<Node>;
        }

        private void Exit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            BottomSpace.ItemsSource = null;
            LeftUpperSpace.ItemsSource = null;
            LeftBottomSpace.ItemsSource = null;
            FarRightSpace.ItemsSource = null;
            CentralSpace.ItemsSource = null;

            this.Close();
        }
    }
}