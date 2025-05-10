using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Kursach
{
    public partial class MainWindow : Window
    {
        public abstract class Product
        {
            public string Name { get; set; }
            public double Calories { get; set; }
            public double Proteins { get; set; }
            public double Fats { get; set; }
            public double Carbs { get; set; }
            public double Price { get; set; }
            public string ImagePath { get; set; }
            public List<DietType> AllowedDiets { get; set; } = new List<DietType> {DietType.None};
        }
        public enum DietType
        {
            None, Keto, Vegetarian, Interval, Glutenfree, Plant, Vegan, Diet, Protein
        }

        public class Vegetable: Product { }
        public class Fruit: Product { }
        public class Сereals : Product { }
        public class Seed : Product { }
        public class Nuts : Product { }
        public class Sweets : Product { }
        public class Milk : Product { }
        public class Bread : Product { }
        public class Meat: Product { }
        public class Fish: Product { }
        public class Drink: Product { }

        private List<Product> _products;
        private List<Product> _selectedProducts = new();
        private DietType _selectedDietType = DietType.None;

        private void AddProductBox()
        {
            var row = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };
            var comboBox = new ComboBox
            {
                Width = 260,
                Height = 75,
                Margin = new Thickness(0,0,0,0),
                Background = Brushes.White,
                Foreground = Brushes.Black,
                ItemsSource = _products,
                SelectedIndex = -1,
                ItemTemplate = FindResource("ProductTemplate") as DataTemplate
            };
            var minText = new TextBox
            {
                Width = 100,
                Height = 25,
                Margin = new Thickness(55, 0, 0, 0),
            };
            var maxText = new TextBox
            {
                Width = 100,
                Height = 25,
                Margin = new Thickness(110, 0, 0, 0),
            };

            row.Children.Add(comboBox);
            row.Children.Add(minText);
            row.Children.Add(maxText);

            ProductListPanel.Children.Add(row);
        }

        private void AddProductBox_Click(object sender, RoutedEventArgs e)
        {
            AddProductBox();
        }
        private void myComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (ComboBoxItem)myComboBox.SelectedItem;
            switch (selectedItem.Content.ToString().ToLower())
            {
                case "без обмежень":
                    _selectedDietType = DietType.None;
                    break;
                case "кетодієта":
                    _selectedDietType = DietType.Keto;
                    break;
                case "вегетеріанська":
                    _selectedDietType = DietType.Vegetarian;
                    break;
                case "інтервальне":
                    _selectedDietType = DietType.Interval;
                    break;
                case "безглютенова":
                    _selectedDietType = DietType.Glutenfree;
                    break;
                case "рослинна":
                    _selectedDietType = DietType.Plant;
                    break;
                case "веганська":
                    _selectedDietType = DietType.Vegan;
                    break;
                case "діабетична":
                    _selectedDietType = DietType.Diet;
                    break;
                case "білкова":
                    _selectedDietType = DietType.Protein;
                    break;
            }
        }
        private void InitializeProducts()
        {
            _products = new List<Product>
            {
                new Vegetable { Name = "Картопля", Calories = 83, Proteins = 2, Fats = 0.1, Carbs = 19.7, Price = 2.9, AllowedDiets = new List<DietType> {DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None}, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\potato.webp"},
                new Vegetable { Name = "Капуста", Calories = 57, Proteins = 2.2, Fats = 0.3, Carbs = 12.5, Price = 7.9, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\kapusta.jpg"},
                new Vegetable { Name = "Броколі", Calories = 28, Proteins = 3, Fats = 0.4, Carbs = 5, Price = 40, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\broccoli.jpg"},
                new Vegetable { Name = "Шпинат", Calories = 22, Proteins = 2.5, Fats = 0, Carbs = 2.6, Price = 73, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\spinach.jpg"},
                new Vegetable { Name = "Салат Айсберг", Calories = 14, Proteins = 1.3, Fats = 0, Carbs = 2.2, Price = 39.7, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None },ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\salat.webp"},
                new Vegetable { Name = "Рукола", Calories = 25, Proteins = 2.6, Fats = 0.7, Carbs = 2.1, Price = 78.7, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None },ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\rukola.png"},
                new Vegetable { Name = "Огірок", Calories = 15, Proteins = 0.7, Fats = 0, Carbs = 3.1, Price = 9.9, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None },ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\cucumber.jpg"},
                new Vegetable { Name = "Помідори", Calories = 19, Proteins = 0.7, Fats = 0, Carbs = 4.1, Price = 12.9, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\pomidor.jpg"},
                new Vegetable { Name = "Морква", Calories = 29, Proteins = 1.3, Fats = 0.1, Carbs = 6.3, Price = 3.5, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\carrot.webp"},
                new Vegetable { Name = "Спаржа", Calories = 21, Proteins = 1.9, Fats = 0.1, Carbs = 3.1, Price = 71.6, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None },ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\sparzha.jpg"},
                new Vegetable { Name = "Печериці", Calories = 29, Proteins = 4.3, Fats = 0.9, Carbs = 1.4, Price = 13.5, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None },ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\mushrooms.webp"},
                new Vegetable { Name = "Кабачок", Calories = 27, Proteins = 0.6, Fats = 0.3, Carbs = 5.7, Price = 10.9, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\zucchini.jpg"},
                new Vegetable { Name = "Кукурудза", Calories = 97, Proteins = 3, Fats = 1.2, Carbs = 18.2, Price = 9.9, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None },ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\kukurudza.jpg"},
                new Fruit { Name = "Авокадо", Calories = 223, Proteins = 1.9, Fats = 23.5, Carbs = 6.7, Price = 16, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Diet, DietType.None },ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\avokado.jpg"},
                new Fruit { Name = "Банани", Calories = 87, Proteins = 1.7, Fats = 0, Carbs = 22.4, Price = 7.7, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\banana.jpg"},
                new Fruit { Name = "Яблука", Calories = 46, Proteins = 0.4, Fats = 0, Carbs = 11.3, Price = 5.4, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\apple.jpg"},
                new Fruit { Name = "Полуниця", Calories = 32, Proteins = 0.7, Fats = 0.3, Carbs = 7.7, Price = 19.9, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\strawberry.jpg"},
                new Fruit { Name = "Апельсини", Calories = 38, Proteins = 0.9, Fats = 0, Carbs = 8.4, Price = 7.2, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\orange.jpeg"},
                new Fruit { Name = "Грейпфрут", Calories = 35, Proteins = 0.9, Fats = 0, Carbs = 7.3, Price = 11.5, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\grapefruit.jpg"},
                new Fruit { Name = "Лимони", Calories = 31, Proteins = 0.9, Fats = 0, Carbs = 3.6, Price = 9.9, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\lemon.jpeg"},
                new Сereals { Name = "Кіноа", Calories = 368, Proteins = 14.12, Fats = 6.1, Carbs = 64.1, Price = 38.8, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Interval, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\quinoa.jpg"},
                new Сereals { Name = "Рис", Calories = 324, Proteins = 7, Fats = 0.6, Carbs = 71.3, Price = 5.5, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Interval, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\rice.jpeg"},
                new Сereals { Name = "Крупа гречана", Calories = 343, Proteins = 13.3, Fats = 3.4, Carbs = 72.5, Price = 4.6, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Interval, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\krupa-grechnevaya.jpg"},
                new Сereals { Name = "Вівсянка", Calories = 383, Proteins = 13.2, Fats = 7, Carbs = 65.9, Price = 6.8, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Interval, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\ovsyanka-plyushchena.jpg"},
                new Сereals { Name = "Булгур", Calories = 360, Proteins = 12.3, Fats = 1.3, Carbs = 75.9, Price = 7.1, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Interval, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\bulgur.png"},
                new Сereals { Name = "Квасоля", Calories = 309, Proteins = 22.3, Fats = 1.7, Carbs = 54.5, Price = 15, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Interval, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\kvasolya.jpeg"},
                new Сereals { Name = "Сочевиця", Calories = 310, Proteins = 24.8, Fats = 1.1, Carbs = 53.7, Price = 14, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Interval, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\sochevitsya-chervona.png"},
                new Seed { Name = "Насіння чіа", Calories = 379, Proteins = 23.1, Fats = 32, Carbs = 10.1, Price = 46.8, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\chia.jpg"},
                new Seed { Name = "Лляне насіння", Calories = 534, Proteins = 18, Fats = 42, Carbs = 29, Price = 11.6, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\linen.webp"},
                new Nuts { Name = "Мигдаль смажений", Calories = 643, Proteins = 18.6, Fats = 57.7, Carbs = 13.6, Price = 92.6, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\mindal.jpeg"},
                new Nuts  { Name = "Арахіс", Calories = 551, Proteins = 26.3, Fats = 45.2, Carbs = 9.8, Price = 28.8, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\araxis.jpeg"},
                new Nuts  { Name = "Фундук смажений", Calories = 701, Proteins = 16.1, Fats = 66.9, Carbs = 9.9, Price = 81.3, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\unnamed.jpg"},
                new Nuts  { Name = "Кеш'ю", Calories = 647, Proteins = 25.8, Fats = 54.3, Carbs = 13.3, Price = 109.3, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\kesyu.jpeg"},
                new Sweets { Name = "Арахісова паста", Calories = 611, Proteins = 29.2, Fats = 50.2, Carbs = 10.8, Price = 34.8, AllowedDiets = new List<DietType> { DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\arahisova-pasta.jpg"},
                new Sweets { Name = "Шоколад молочний", Calories = 552, Proteins = 6.7, Fats = 35.6, Carbs = 52.4, Price = 95, AllowedDiets = new List<DietType> { DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\milk_chokolate.jpeg"},
                new Sweets { Name = "Шоколад чорний", Calories = 546, Proteins = 5.2, Fats = 35.6, Carbs = 52.4, Price = 95, AllowedDiets = new List<DietType> { DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\dark_chokolate.jpg"},
                new Milk { Name = "Безлактозне молоко 1.5%", Calories = 44, Proteins = 3.1, Fats = 1.5, Carbs = 4.6, Price = 8.5, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Protein, DietType.Glutenfree, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\milk3.jpeg"},
                new Milk { Name = "Молоко 3.2%", Calories = 58, Proteins = 2.8, Fats = 3.2, Carbs = 4.7, Price = 6.4, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Protein, DietType.Glutenfree, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\milk.webp"},
                new Milk { Name = "Безлактозний кефір 2.5%", Calories = 51, Proteins = 3, Fats = 2.5, Carbs = 4, Price = 8.1, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Protein, DietType.Glutenfree, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\kefir.png"},
                new Milk { Name = "Сметана 15%", Calories = 163, Proteins = 3.5, Fats = 15, Carbs = 3.4, Price = 16, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Protein, DietType.Glutenfree, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\sourcream.webp"},
                new Milk { Name = "Грецький йогурт 2.5%", Calories = 69, Proteins = 5, Fats = 2.5, Carbs = 6.5, Price = 16.4, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Protein, DietType.Glutenfree, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\yogurt.webp"},
                new Milk { Name = "Питний йогурт", Calories = 71, Proteins = 2.8, Fats = 1.5, Carbs = 11.5, Price = 12.6, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Protein, DietType.Glutenfree, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\yogurtp.jpg"},
                new Milk { Name = "Мигдальне молоко", Calories = 24, Proteins = 0.5, Fats = 1.2, Carbs = 2.6, Price = 16.9, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Protein, DietType.Glutenfree, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\almond_milk.jpg"},
                new Milk { Name = "Вівсяне молоко", Calories = 44, Proteins = 0.3, Fats = 1.5, Carbs = 6.8, Price = 14.9, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Protein, DietType.Glutenfree, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\moloko-vivsyane.webp"},
                new Milk { Name = "Кисломолочний сир 5%", Calories = 84, Proteins = 18, Fats = 0.6, Carbs = 1.8, Price = 26.8, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Protein, DietType.Glutenfree, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\tvorog-kislomolochnyj.jpg"},
                new Milk { Name = "Яйця 10шт.", Calories = 83, Proteins = 6.8, Fats = 6, Carbs = 0.5, Price = 14.6, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Protein, DietType.Glutenfree, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\eggs.jpg"},
                new Milk { Name = "Сир Філадельфія", Calories = 342, Proteins = 5.9, Fats = 34.2, Carbs = 4.1, Price = 36, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Protein, DietType.Glutenfree, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\philadelfia.webp"},
                new Milk { Name = "Сир Фета", Calories = 290, Proteins = 17, Fats = 24, Carbs = 2.9, Price = 44.6, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Protein, DietType.Glutenfree, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\feta.jpg"},
                new Milk { Name = "Сир Гауда", Calories = 344, Proteins = 26, Fats = 26, Carbs = 1.4, Price = 52.9, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Protein, DietType.Glutenfree, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\gauda.jpg"},
                new Milk { Name = "Вершкове масло 73%", Calories = 665, Proteins = 0.8, Fats = 73, Carbs = 1.3, Price = 60, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Protein, DietType.Glutenfree, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\maslo.jpg"},
                new Bread { Name = "Гречаний хліб", Calories = 248, Proteins = 10, Fats = 3.4, Carbs = 49, Price = 12.9, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Interval, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\khleb-grechnevyj.jpg"},
                new Bread { Name = "Цільнозерновий Хліб", Calories = 237, Proteins = 13, Fats = 3.3, Carbs = 41, Price = 10.8, AllowedDiets = new List<DietType> { DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Interval, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\czelnozernovoj.webp"},
                new Meat { Name = "Куряче філе", Calories = 113, Proteins = 24, Fats = 2, Carbs = 0.4, Price = 20.9, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\fillet.png"},
                new Meat { Name = "Курячі стегна", Calories = 183, Proteins = 10.7, Fats = 16.3, Carbs = 0.1, Price = 14.1, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\hips.png"},
                new Meat { Name = "Печінка куряча", Calories = 119, Proteins = 20.1, Fats = 4.2, Carbs = 0.2, Price = 12.4, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\liver.png"},
                new Meat { Name = "Курячі гомілки", Calories = 198, Proteins = 18.2, Fats = 18.4, Carbs = 0, Price = 10.4,  AllowedDiets = new List<DietType> { DietType.Keto, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\shins.png"},
                new Meat { Name = "Курячий фарш", Calories = 143, Proteins = 17.4, Fats = 8, Carbs = 0, Price = 19.9, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\farsh.png"},
                new Meat { Name = "Свинний фарш", Calories = 263, Proteins = 16.9, Fats = 21.2, Carbs = 0, Price = 17.9, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\farsh2.png"},
                new Meat { Name = "Ошийок свинний", Calories = 243, Proteins = 16.1, Fats = 22.8, Carbs = 0, Price = 34.9, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\collar.png"},
                new Meat { Name = "Вирізка теляча", Calories = 166, Proteins = 20.8, Fats = 9.1, Carbs = 0.1, Price = 70.9, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\tenderloin.png"},
                new Fish { Name = "Стейк телячий", Calories = 110, Proteins = 18, Fats = 0.1, Carbs = 0, Price = 40.8, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\steak.png"},
                new Fish { Name = "Оселедець", Calories = 248, Proteins = 17.7, Fats = 19.5, Carbs = 0, Price = 16.4, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\herring1.png"},
                new Fish { Name = "Дорадо", Calories = 85, Proteins = 18, Fats = 1, Carbs = 0, Price = 48.9, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\dorado.png"},
                new Fish { Name = "Сібас", Calories = 99, Proteins = 18, Fats = 3, Carbs = 0, Price = 52.9, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\sibas.png"},
                new Fish { Name = "Креветки", Calories = 83, Proteins = 18, Fats = 0.8, Carbs = 0, Price = 39.9, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\krevetku.png"},
                new Fish { Name = "Стейки форелі", Calories = 99, Proteins = 19.6, Fats = 2.1, Carbs = 0, Price = 87.9, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\forel.png"},
                new Fish { Name = "Філе тунця", Calories = 96, Proteins = 22.7, Fats = 0.7, Carbs = 0, Price = 71.9, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\tuna.png"},
                new Drink { Name = "Сік 1л", Calories = 54, Proteins = 1.1, Fats = 0.1, Carbs = 10, Price = 9.4, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\soksandoramultivitamin.jpg"},
                new Drink { Name = "Солодкі напої 1л", Calories = 42, Proteins = 0, Fats = 0, Carbs = 10.6, Price = 5.4, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\pepsi.webp"},
                new Drink { Name = "Вода мін. нег. 1л", Calories = 1, Proteins = 0, Fats = 0, Carbs = 0.1, Price = 2.3, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\negaz2.webp"},
                new Drink { Name = "Вода мін. газ. 1л", Calories = 0.1, Proteins = 0, Fats = 0, Carbs = 0, Price = 2.5, AllowedDiets = new List<DietType> { DietType.Keto, DietType.Vegetarian, DietType.Vegan, DietType.Plant, DietType.Glutenfree, DietType.Interval, DietType.Protein, DietType.Diet, DietType.None }, ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\gaz.png"},
            };
        }
        public MainWindow()
        {

            InitializeComponent();
            InitializeProducts();
        }
    }
}


