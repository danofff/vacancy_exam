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
using System.Data.SqlClient;
using System.Configuration;

namespace ado_exam.Pages
{
    /// <summary>
    /// Interaction logic for SetupPage.xaml
    /// </summary>
    public partial class SetupPage : Page
    {
        public SetupPage()
        {
            InitializeComponent();
            vacancies.Content = MainWindow.db.Vacancies.Count();
            categories.Content = MainWindow.db.Categories.Count();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.db.Database.ExecuteSqlCommand("delete from vacancies");
            MainWindow.db.Database.ExecuteSqlCommand("delete from categories");     
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string newConnectionString = @"Data Source=" + @ServerName.Text + ";Initial Catalog=" + DBName.Text + ";User ID=" + UserName.Text + ";Password=" + Password.Password;
            SqlConnection connection = new SqlConnection(newConnectionString);
            try
            {
                connection.Open();
                if (connection.State.ToString().ToLower() == "open")
                {
                    ConfigurationManager.ConnectionStrings["VacanciesConnection"].ConnectionString = newConnectionString;
                    MessageBox.Show("Cтрока подключения успешно изменена", "Connection string change", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                    MessageBox.Show("Не удалось подключиться к указанной базе данных, проверьте правильность введенных данных", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так!Проверьте правильность введных данных", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ServerName.Text = "";
                DBName.Text = "";
                UserName.Text = "";
                Password.Password = "";
            } 

        }
    }
}