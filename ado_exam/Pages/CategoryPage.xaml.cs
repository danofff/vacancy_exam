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
using System.Xml.Linq;
using ado_exam.Model;

namespace ado_exam.Pages
{
    /// <summary>
    /// Interaction logic for CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        public CategoryPage()
        {
            InitializeComponent();
        }

        private void SaveCategoryToDataBase_Click(object sender, RoutedEventArgs e)
        {
            Category addCategory = new Category();
            try
            {
                addCategory.CategoryName = CategoryName.Text;
                addCategory.CategoryAdress = CategoryAdress.Text;

                MainWindow.db.Categories.Add(addCategory);

                MainWindow.db.SaveChanges();

                LoadVacancies(addCategory.CategoryAdress, MainWindow.db.Categories.ToList().Last().CategoryId);            
           
                MainWindow.db.SaveChanges();
                MessageBox.Show("Успешно добавлена новая категория", "Add data", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                CategoryName.Text = "";
                CategoryAdress.Text = "";
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);              
            }
        }

        private void LoadVacancies(string adress,int categoryId)
        {
            XDocument doc = new XDocument();
            try
            {
                doc = XDocument.Load(adress);
                List<Vacancy> vac = doc.Element("rss").Element("channel").Elements("item").
                    Select(s => new Vacancy
                    {
                        VacancyName = s.Element("title").Value,
                        Link = s.Element("link").Value,
                        Description = s.Element("description").Value,
                        PublicDate = DateTime.Parse(s.Element("pubDate").Value),
                        AuthorEmail = s.Element("author").Value,
                        CategoryId = categoryId
                    }).ToList();

                MainWindow.db.Vacancies.AddRange(vac);
            }
            catch (Exception ex)
            {               
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
