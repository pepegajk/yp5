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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        private readonly App _context;

        public AdminWindow()
        {
            InitializeComponent();
            _context = new App();  // Инициализация контекста
            LoadData();
        }

        private void LoadData()
        {
            ItemsDataGrid.ItemsSource = _context.Items.ToList();
            CategoriesDataGrid.ItemsSource = _context.CategoryNameTextBox.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newItem = new Item
            {
                Name = ItemNameTextBox.Text,
                Price = decimal.Parse(ItemPriceTextBox.Text)
            };
            _context.Items.Add(newItem);
            _context.SaveChanges();
            LoadData();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsDataGrid.SelectedItem is Item selectedItem)
            {
                selectedItem.Name = ItemNameTextBox.Text;
                selectedItem.Price = decimal.Parse(ItemPriceTextBox.Text);
                _context.SaveChanges();
                LoadData();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите элемент для обновления.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsDataGrid.SelectedItem is Item selectedItem)
            {
                _context.Items.Remove(selectedItem);
                _context.SaveChanges();
                LoadData();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите элемент для удаления.");
            }
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var newCategory = new Category
            {
                Name = CategoryNameTextBox.Text
            };
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            LoadData();
        }

        private void UpdateCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesDataGrid.SelectedItem is Category selectedCategory)
            {
                selectedCategory.Name = CategoryNameTextBox.Text;
                _context.SaveChanges();
                LoadData();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите категорию для обновления.");
            }
        }

        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesDataGrid.SelectedItem is Category selectedCategory)
            {
                _context.Categories.Remove(selectedCategory);
                _context.SaveChanges();
                LoadData();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите категорию для удаления.");
            }
        }

        private void ItemsDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ItemsDataGrid.SelectedItem is Item selectedItem)
            {
                ItemNameTextBox.Text = selectedItem.Name;
                ItemPriceTextBox.Text = selectedItem.Price.ToString();
            }
        }

        private void CategoriesDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (CategoriesDataGrid.SelectedItem is Category selectedCategory)
            {
                CategoryNameTextBox.Text = selectedCategory.Name;
            }
        }
    }
}
