using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Kursach
{
    public partial class MainWindow : Window
    {
        public class Product
        {
            public string Name { get; set; }
            public string ImagePath { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            AddProductBox();
        }
        public List<Product> Products = new List<Product>
        {
            new Product { Name = "Картопля", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\potato.webp"},
            new Product { Name = "Капуста", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\kapusta.jpg"},
            new Product { Name = "Броколі", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\broccoli.jpg"},
            new Product { Name = "Шпинат", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\spinach.jpg"},
            new Product { Name = "Салат Айсберг", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\salat.webp"},
            new Product { Name = "Рукола", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\rukola.png"},
            new Product { Name = "Огірок", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\cucumber.jpg"},
            new Product { Name = "Помідори", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\pomidor.jpg"},
            new Product { Name = "Морква", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\carrot.webp"},
            new Product { Name = "Спаржа", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\sparzha.jpg"},
            new Product { Name = "Печериці", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\mushrooms.webp"},
            new Product { Name = "Кабачок", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\zucchini.jpg"},
            new Product { Name = "Кукурудза", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\kukurudza.jpg"},
            new Product { Name = "Авокадо", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\avokado.jpg"},
            new Product { Name = "Банани", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\banana.jpg"},
            new Product { Name = "Яблука", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\apple.jpg"},
            new Product { Name = "Полуниця", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\strawberry.jpg"},
            new Product { Name = "Апельсини", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\orange.jpeg"},
            new Product { Name = "Грейпфрут", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\grapefruit.jpg"},
            new Product { Name = "Лимони", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\lemon.jpeg"},
            new Product { Name = "Кіноа", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\quinoa.jpg"},
            new Product { Name = "Рис", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\rice.jpeg"},
            new Product { Name = "Крупа гречана", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\krupa-grechnevaya.jpg"},
            new Product { Name = "Вівсянка", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\ovsyanka-plyushchena.jpg"},
            new Product { Name = "Булгур", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\bulgur.png"},
            new Product { Name = "Квасоля", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\kvasolya.jpeg"},
            new Product { Name = "Сочевиця", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\sochevitsya-chervona.png"},
            new Product { Name = "Насіння чіа", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\chia.jpg"},
            new Product { Name = "Лляне насіння", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\linen.webp"},
            new Product { Name = "Мигдаль смажений", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\mindal.jpeg"},
            new Product { Name = "Арахіс", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\araxis.jpeg"},
            new Product { Name = "Фундук смажений", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\unnamed.jpg"},
            new Product { Name = "Кеш'ю", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\kesyu.jpeg"},
            new Product { Name = "Арахісова паста", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\arahisova-pasta.jpg"},
            new Product { Name = "Шоколад молочний", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\milk_chokolate.jpeg"},
            new Product { Name = "Шоколад чорний", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\dark_chokolate.jpg"},
            new Product { Name = "Протеїнові батончики", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\protein.webp"},
            new Product { Name = "Безлактозне молоко 1л.", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\milk3.jpeg"},
            new Product { Name = "Молоко 1л.", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\milk.webp"},
            new Product { Name = "Безлактозний кефір 1л.", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\kefir.png"},
            new Product { Name = "Сметана 15%", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\sourcream.webp"},
            new Product { Name = "Грецький йогурт", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\yogurt.webp"},
            new Product { Name = "Питний йогурт", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\yogurtp.jpg"},
            new Product { Name = "Мигдальне молоко 1л.", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\almond_milk.jpg"},
            new Product { Name = "Вівсяне молоко 1л.", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\moloko-vivsyane.webp"},
            new Product { Name = "Кисломолочний сир", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\tvorog-kislomolochnyj.jpg"},
            new Product { Name = "Яйця 10шт.", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\eggs.jpg"},
            new Product { Name = "Сир Філадельфія", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\philadelfia.webp"},
            new Product { Name = "Сир Фета", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\feta.jpg"},
            new Product { Name = "Сир Гауда", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\gauda.jpg"},
            new Product { Name = "Вершкове масло", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\maslo.jpg"},
            new Product { Name = "Оливкова олія", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\oil.png"},
            new Product { Name = "Гречаний хліб", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\khleb-grechnevyj.jpg"},
            new Product { Name = "Цільнозерновий Хліб", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\czelnozernovoj.webp"},
            new Product { Name = "Куряче філе", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\fillet.png"},
            new Product { Name = "Курячі стегна", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\hips.png"},
            new Product { Name = "Печінка куряча", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\liver.png"},
            new Product { Name = "Курячі гомілки", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\shins.png"},
            new Product { Name = "Курячий фарш", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\farsh.png"},
            new Product { Name = "Свинний фарш", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\farsh2.png"},
            new Product { Name = "Ошийок свинний", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\collar.png"},
            new Product { Name = "Вирізка теляча", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\tenderloin.png"},
            new Product { Name = "Стейк телячий", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\steak.png"},
            new Product { Name = "Оселедець", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\herring1.png"},
            new Product { Name = "Дорадо", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\dorado.png"},
            new Product { Name = "Сібас", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\sibas.png"},
            new Product { Name = "Креветки", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\krevetku.png"},
            new Product { Name = "Стейки форелі", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\forel.png"},
            new Product { Name = "Філе тунця", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\tuna.png"},
            new Product { Name = "Сік 1л", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\soksandoramultivitamin.jpg"},
            new Product { Name = "Солодкі напої 1л", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\pepsi.webp"},
            new Product { Name = "Вода мін. нег. 1л", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\negaz2.webp"},
            new Product { Name = "Вода мін. газ. 1л", ImagePath = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\Images\\gaz.png"},
        };
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
                ItemsSource = Products,
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
    }
}


