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
using ado_exam.Model;


namespace ado_exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame MainFrame;
        public static VacancyDB db;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame = CentralFrame;
            MainFrame.Source = new Uri(@"Pages\CategoryPage.xaml", UriKind.RelativeOrAbsolute);
            db = new VacancyDB();
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri(@"Pages\CategoryPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri(@"Pages\SearchPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Setup_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri(@"Pages\SetupPage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
