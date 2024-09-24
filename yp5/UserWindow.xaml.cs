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
using System.Windows.Shapes;

namespace yp5
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
       
public UserWindow()
        {
            InitializeComponent();
        }

        private void ItemsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обработка изменения выбора в ItemsDataGrid
            var selectedItem = ItemsDataGrid.SelectedItem as YourItemType;
            if (selectedItem != null)
            {
                // Действия с выбранным элементом
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            YourDbContext context = new YourDbContext();
            var newItem = new YourItemType
            {
                // Инициализация новых значений
            };
            context.YourItems.Add(newItem);
            context.SaveChanges();
            LoadItems(); // Метод для загрузки обновленных данных
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ItemsDataGrid.SelectedItem as YourItemType;
            if (selectedItem != null)
            {
                using (YourDbContext context = new YourDbContext())
                {
                    var itemToUpdate = context.YourItems.Find(selectedItem.Id);
                    if (itemToUpdate != null)
                    {
                        // Обновление значений
                        context.SaveChanges();
                        LoadItems();
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ItemsDataGrid.SelectedItem as YourItemType;
            if (selectedItem != null)
            {
                using (YourDbContext context = new YourDbContext())
                {
                    context.YourItems.Remove(selectedItem);
                    context.SaveChanges();
                    LoadItems();
                }
            }
        }

        private void CategoriesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = CategoriesDataGrid.SelectedItem as YourCategoryType;
            if (selectedCategory != null)
            {
                // Действия с выбранной категорией
            }
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            YourDbContext context = new YourDbContext();
            var newCategory = new YourCategoryType
            {
                // Инициализация новых значений
            };
            context.YourCategories.Add(newCategory);
            context.SaveChanges();
            LoadCategories(); // Метод для загрузки обновленных данных
        }

        private void UpdateCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedCategory = CategoriesDataGrid.SelectedItem as YourCategoryType;
            if (selectedCategory != null)
            {
                using (YourDbContext context = new YourDbContext())
                {
                    var categoryToUpdate = context.YourCategories.Find(selectedCategory.Id);
                    if (categoryToUpdate != null)
                    {
                        // Обновление значений
                        context.SaveChanges();
                        LoadCategories();
                    }
                }
            }
        }

        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedCategory = CategoriesDataGrid.SelectedItem as YourCategoryType;
            if (selectedCategory != null)
            {
                using (YourDbContext context = new YourDbContext())
                {
                    context.YourCategories.Remove(selectedCategory);
                    context.SaveChanges();
                    LoadCategories();
                }
            }
        }

        
private void LoadItems()
        {
            using (YourDbContext context = new YourDbContext())
            {
                ItemsDataGrid.ItemsSource = context.YourItems.ToList();
            }
        }

        private void LoadCategories()
        {
            using (YourDbContext context = new YourDbContext())
            {
                CategoriesDataGrid.ItemsSource = context.YourCategories.ToList();
            }
        }
    }
}
