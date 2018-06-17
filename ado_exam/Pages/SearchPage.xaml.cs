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
using System.Configuration;

namespace ado_exam.Pages
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public static ComboBox category;
        public static ListView view;
        public static DatePicker date;
        public static TextBox email;
        public static TextBox phrase;
       
        public SearchPage()
        {
            InitializeComponent();
            category = CategoryName;
            view = VacanciesList;
            date = DateOfVacancy;
            email = Email;
            phrase = Phrase;
            
            
            CategoryName.ItemsSource = MainWindow.db.Categories.Select(s => s.CategoryName).ToList();           

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(CategoryName.Text))
            {
                SearchByCategoryName();
            }

            else if (!String.IsNullOrEmpty(DateOfVacancy.Text))
            {
                SearchByPublicationDate();
            }
            else if (!String.IsNullOrEmpty(email.Text))
            {
                SearchByEmail();
            }

            else if (!String.IsNullOrWhiteSpace(phrase.Text))
            {
                SearchByPhrase();
            }

            else
            {
                MessageBox.Show("Вы не ввели данные для поиска","No data",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
        }

        private static void SearchByCategoryName()
        {
            List<Vacancy> list = MainWindow.db.Vacancies.Where(w => w.Category.CategoryName == category.Text).ToList();
            if (list.Count == 0)
            {
                MessageBox.Show("К сожаления, по заданным параметрам вакансии не найдены","No result",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            else
                view.ItemsSource = list;
            
        }
        private static void SearchByPublicationDate()
        {
            List<Vacancy> list1 = MainWindow.db.Vacancies.ToList();
            List<Vacancy> list2 = list1.Where(w => w.PublicDate.Date == date.SelectedDate.Value).ToList();
            if (list2.Count == 0)
            {
                MessageBox.Show("К сожаления, по заданным параметрам вакансии не найдены", "No result", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
                view.ItemsSource = list2;
        }

        private static void SearchByEmail()
        {
            List<Vacancy> list = MainWindow.db.Vacancies.Where(w => w.AuthorEmail == email.Text).ToList();
            if (list.Count == 0)
            {
                MessageBox.Show("К сожаления, по заданным параметрам вакансии не найдены", "No result", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
                view.ItemsSource = list;
        }

        private static void SearchByPhrase()
        {
            List<Vacancy> list = MainWindow.db.Vacancies.Where(w => w.Description.Contains(phrase.Text)).ToList();
            if (list.Count == 0)
            {
                MessageBox.Show("К сожаления, по заданным параметрам вакансии не найдены", "No result", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
                view.ItemsSource = list;
        }


    }
}
