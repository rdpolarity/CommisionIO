using MaterialDesignColors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace COMMISSION.io_WPF_add
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class WindowSettings : Page
    {
        public WindowSettings()
        {
            InitializeComponent();
        }

        //Methods from the MaterialDesign PaletteHelper.cs 
        public ICommand ToggleBaseCommand { get; } = new AnotherCommandImplementation(o => ApplyBase((bool)o));

        private static void ApplyBase(bool isDark)
        {
            new PaletteHelper().SetLightDark(isDark);
        }

        public IEnumerable<Swatch> Swatches { get; }

        private static void ApplyPrimary(String swatch)
        {
            new PaletteHelper().ReplacePrimaryColor(swatch);
        }

        private static void ApplyAccent(String swatch)
        {
            new PaletteHelper().ReplaceAccentColor(swatch);
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            //WindowSet.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4C000000"));
            ApplyBase(true);
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            //WindowSet.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#05000000"));
            ApplyBase(false);
        }

        //Apply primary and accent colours on click
        private void Green_Click(object sender, RoutedEventArgs e)
        {
            ApplyPrimary("Green");
            ApplyAccent("Green");
        }
        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            ApplyPrimary("Blue");
            ApplyAccent("Blue");
        }
        private void Purple_Click(object sender, RoutedEventArgs e)
        {
            ApplyPrimary("Purple");
            ApplyAccent("Purple");
        }
        private void Yellow_Click(object sender, RoutedEventArgs e)
        {
            ApplyPrimary("Yellow");
            ApplyAccent("Yellow");
        }
        private void Orange_Click(object sender, RoutedEventArgs e)
        {
            ApplyPrimary("Orange");
            ApplyAccent("Orange");
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            ApplyPrimary("Red");
            ApplyAccent("Red");
        }
    }
}
