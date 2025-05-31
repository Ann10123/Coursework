using System.IO;
using Google.OrTools.LinearSolver;
using Kursach;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kursach
{
    public partial class MainWindow : Window
    {
        public List<Product> _products;
        public List<ProductSelection> _selectedProducts = new();
        public DietType _selectedDietType = DietType.None;
        public IDietFilter _dietFilter = new SimpleDietFilter();

        public void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Дозволяє на введення лише цифр і коми
            Regex regex = new Regex("[^0-9,]");
            var textBox = sender as TextBox;
            string currentText = textBox?.Text ?? "";

            if (regex.IsMatch(e.Text))
            {
                e.Handled = true;
                return;
            }
            // Перевірка на наявність коми
            if (e.Text == ",")
            {
                if (currentText.Contains(","))
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        //перевірка на порожні поля
        public bool AreAllTextBoxesFilled(DependencyObject parent)
        {
            bool allFilled = true;

            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        textBox.BorderBrush = Brushes.Red;
                        textBox.BorderThickness = new Thickness(2);
                        allFilled = false;
                    }
                    else
                    {
                        textBox.ClearValue(TextBox.BorderBrushProperty);
                        textBox.ClearValue(TextBox.BorderThicknessProperty);
                    }
                }
                if (!AreAllTextBoxesFilled(child))
                {
                    allFilled = false;
                }
            }
            return allFilled;
        }
        //додавання полів для обов'язкових продуктів
        public void AddProductBox_Click(object sender, RoutedEventArgs e)
        {
            var row = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };

            var collectionView = new ListCollectionView(_products);
            collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Category"));

            var comboBox = new ComboBox
            {
                Width = 280,
                Height = 75,
                Margin = new Thickness(0, 0, 0, 0),
                Background = Brushes.White,
                Foreground = Brushes.Black,
                FontStyle = FontStyles.Italic,
                BorderBrush = Brushes.Gray,
                ItemsSource = collectionView,
                ItemTemplate = FindResource("ProductTemplate") as DataTemplate
            };
            // Додаємо стиль заголовків категорій
            var borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.BorderBrushProperty, Brushes.Black);
            borderFactory.SetValue(Border.BorderThicknessProperty, new Thickness(1));
            var headerFactory = new FrameworkElementFactory(typeof(TextBlock));
            headerFactory.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
            headerFactory.SetValue(TextBlock.ForegroundProperty, Brushes.Black);
            headerFactory.SetValue(TextBlock.PaddingProperty, new Thickness(5));
            headerFactory.SetBinding(TextBlock.TextProperty, new Binding("Name"));
            headerFactory.SetValue(TextBlock.FontSizeProperty, 20.0);

            borderFactory.AppendChild(headerFactory);

            var groupStyle = new GroupStyle
            {
                HeaderTemplate = new DataTemplate
                {
                    VisualTree = borderFactory
                }
            };

            comboBox.GroupStyle.Add(groupStyle);
            var minText = new TextBox
            {
                Width = 100, Height = 25, BorderThickness = new Thickness(2),
                BorderBrush = Brushes.Gray,
                FontStyle = FontStyles.Italic, Margin = new Thickness(50, 0, 0, 0),
            };
            minText.PreviewTextInput += NumberOnly_PreviewTextInput;
            var maxText = new TextBox
            {
                Width = 100, Height = 25, BorderThickness = new Thickness(2),
                BorderBrush = Brushes.Gray,
                FontStyle = FontStyles.Italic, Margin = new Thickness(100, 0, 0, 0),
            };
            maxText.PreviewTextInput += NumberOnly_PreviewTextInput;
            var deleteButton = new Button
            {
                Content = "❌", Width = 25, Height = 25, Background = Brushes.White, BorderBrush=Brushes.Red,
                BorderThickness = new Thickness(2), Foreground= Brushes.Red, Margin = new Thickness(50, 0, 0, 0)

            };
            deleteButton.Click += (s, ev) => ProductListPanel.Children.Remove(row);

            row.Children.Add(comboBox);
            row.Children.Add(minText);
            row.Children.Add(maxText);
            row.Children.Add(deleteButton);

            ProductListPanel.Children.Add(row);
        }
        public void MyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (ComboBoxItem)myComboBox.SelectedItem;
            switch (selectedItem.Content.ToString().ToLower())
            {
                case "без обмежень":
                    _selectedDietType = DietType.None; break;
                case "кетодієта":
                    _selectedDietType = DietType.Keto; break;
                case "вегетеріанська":
                    _selectedDietType = DietType.Vegetarian; break;
                case "інтервальне":
                    _selectedDietType = DietType.Interval; break;
                case "безглютенова":
                    _selectedDietType = DietType.Glutenfree; break;
                case "рослинна":
                    _selectedDietType = DietType.Plant; break;
                case "веганська":
                    _selectedDietType = DietType.Vegan; break;
                case "діабетична":
                    _selectedDietType = DietType.Diet; break;
                case "білкова":
                    _selectedDietType = DietType.Protein; break;
            }
        }
        public List<Product> GenerateWeeklyBasket()
        {
            List<Product> finalBasket = new();
            double totalPrice = 0;
            double totalCalories = 0;
            double totalProteins = 0;
            double totalFats = 0;
            double totalCarbs = 0;

            double minCal = double.Parse(MinCalories.Text) * 7;
            double maxCal = double.Parse(MaxCalories.Text) * 7;
            double minProt = double.Parse(MinProteins.Text) * 7;
            double maxProt = double.Parse(MaxProteins.Text) * 7;
            double minFats = double.Parse(MinFats.Text) * 7;
            double maxFats = double.Parse(MaxFats.Text) * 7;
            double minCarbs = double.Parse(MinCarbohydrates.Text) * 7;
            double maxCarbs = double.Parse(MaxCarbohydrates.Text) * 7;
            double maxCost = double.Parse(MaxCost.Text);
            if (maxCal < minCal || maxProt < minProt || maxFats < minFats || maxCarbs < minCarbs)
            {
                MessageBox.Show($"Некоректні межі значень для КБЖВ. Введіть коректні значення!");
                return new List<Product>();
            }

            if (minCal == 0 && minProt == 0 && minFats == 0 && minCarbs == 0 && _selectedProducts.Count == 0)
            {
                var result = MessageBox.Show(
                    "Ви не задали жодних мінімальних значень КБЖУ.\n" +
                    "Можливий результат - порожній кошик. Бажаєте продовжити?",
                    "Попередження",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );
                if (result == MessageBoxResult.No)
                {
                    return new List<Product>();
                }
            }

            string productList = "Включає такі продукти:\n";

            //обрахунок обов'язкових продуктів
            foreach (var selection in _selectedProducts)
            {
                var product = selection.Product;

                if (_dietFilter.IsAllowed(product, _selectedDietType) &&
                    selection.MinGramsPerDay >= 0 &&
                    selection.MaxGramsPerDay >= selection.MinGramsPerDay)
                {
                    // Залишки КБЖВ
                    double calLeft = maxCal - totalCalories;
                    double protLeft = maxProt - totalProteins;
                    double fatsLeft = maxFats - totalFats;
                    double carbsLeft = maxCarbs - totalCarbs;

                    // Пропонуємо середню вагу
                    double avgGrams = (selection.MinGramsPerDay + selection.MaxGramsPerDay) / 2.0;

                    double selectedGrams;
                    if (product.Unit == UnitProduct.Pieces)
                    {
                        // Округлення до найближчого цілого у межах
                        int min = (int)Math.Ceiling(selection.MinGramsPerDay);
                        int max = (int)Math.Floor(selection.MaxGramsPerDay);

                        int avg = (int)Math.Round((selection.MinGramsPerDay + selection.MaxGramsPerDay) / 2.0);

                        selectedGrams = Math.Clamp(avg, min, max);

                        // Враховуємо КБЖУ
                        double calImpact = product.Calories * selectedGrams;
                        double protImpact = product.Proteins * selectedGrams;
                        double fatsImpact = product.Fats * selectedGrams;
                        double carbsImpact = product.Carbs * selectedGrams;

                        bool fits = calImpact <= calLeft &&
                                    protImpact <= protLeft &&
                                    fatsImpact <= fatsLeft &&
                                    carbsImpact <= carbsLeft;
                        if (!fits)
                        {
                            // Спробувати знайти менше ціле значення, яке вписується
                            bool found = false;
                            for (int val = (int)selectedGrams - 1; val >= min; val--)
                            {
                                calImpact = product.Calories * val;
                                protImpact = product.Proteins * val;
                                fatsImpact = product.Fats * val;
                                carbsImpact = product.Carbs * val;

                                if (calImpact <= calLeft &&
                                    protImpact <= protLeft &&
                                    fatsImpact <= fatsLeft &&
                                    carbsImpact <= carbsLeft)
                                {
                                    selectedGrams = val;
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                            {
                                MessageBox.Show(
                                    $"Продукт {product.Name} не може бути доданий у кількості цілих одиниць у межах КБЖУ.",
                                    "⚠️ Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                                continue;
                            }
                        }
                    }
                    else
                    {
                        // Вибрати максимально можливу вагу, що не перевищує залишки
                        double maxByCal = product.Calories > 0 ? calLeft / product.Calories * 100 : selection.MaxGramsPerDay;
                        double maxByProt = product.Proteins > 0 ? protLeft / product.Proteins * 100 : selection.MaxGramsPerDay;
                        double maxByFats = product.Fats > 0 ? fatsLeft / product.Fats * 100 : selection.MaxGramsPerDay;
                        double maxByCarbs = product.Carbs > 0 ? carbsLeft / product.Carbs * 100 : selection.MaxGramsPerDay;

                        selectedGrams = Math.Min(Math.Min(maxByCal, maxByProt), Math.Min(maxByFats, maxByCarbs));
                        selectedGrams = Math.Max(selection.MinGramsPerDay, Math.Min(selectedGrams, selection.MaxGramsPerDay)); // clamp
                    }

                    // Якщо не влазить навіть мінімум
                    if (selectedGrams < selection.MinGramsPerDay)
                    {
                        MessageBox.Show(
                            $"Продукт {product.Name} не може бути доданий, оскільки його мінімальна кількість перевищує залишки КБЖУ.",
                            "⚠️ Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                        continue;
                    }

                    double multiplier = product.Unit == UnitProduct.Grams ? selectedGrams / 100.0 : selectedGrams;

                    totalPrice += product.Price * multiplier;
                    totalCalories += product.Calories * multiplier;
                    totalProteins += product.Proteins * multiplier;
                    totalFats += product.Fats * multiplier;
                    totalCarbs += product.Carbs * multiplier;

                    string unit = product.Unit == UnitProduct.Grams ? "г" : "шт";
                    productList += $"- {product.Name} — {selectedGrams:F1} {unit}/тижд\n";
                    finalBasket.Add(product);
                }
            }
            // Обчислення залишків для LP
            double minCalLeft = Math.Max(0, minCal - totalCalories);
            double maxCalLeft = Math.Max(0, maxCal - totalCalories);

            double minProtLeft = Math.Max(0, minProt - totalProteins);
            double maxProtLeft = Math.Max(0, maxProt - totalProteins);

            double minFatsLeft = Math.Max(0, minFats - totalFats);
            double maxFatsLeft = Math.Max(0, maxFats - totalFats);

            double minCarbsLeft = Math.Max(0, minCarbs - totalCarbs);
            double maxCarbsLeft = Math.Max(0, maxCarbs - totalCarbs);

            double maxCostLeft = Math.Max(0, maxCost - totalPrice);

            var optionalProducts = _products
                .Where(p => _dietFilter.IsAllowed(p, _selectedDietType) && !_selectedProducts.Any(sel => sel.Product == p))
                .ToList();

            var lpProducts = SolveWithLinearProgramming(optionalProducts, minCalLeft, maxCalLeft, minProtLeft,
                maxProtLeft, minFatsLeft, maxFatsLeft, minCarbsLeft, maxCarbsLeft, maxCostLeft);

            foreach (var product in lpProducts)
            {
                double multiplier = product.Unit == UnitProduct.Grams ? product.SelectedWeight / 100.0 : product.SelectedWeight;
                totalPrice += product.Price * multiplier;
                totalCalories += product.Calories * multiplier;
                totalProteins += product.Proteins * multiplier;
                totalFats += product.Fats * multiplier;
                totalCarbs += product.Carbs * multiplier;

                string unit = product.Unit == UnitProduct.Grams ? "г" : "шт";
                productList += $"- {product.Name} — {product.SelectedWeight:F0} {unit}/тижд\n";
                finalBasket.Add(product);
            }
            productList += $"\n📊 Загальні показники на тиждень:\n";
            productList += $"- Калорій: {totalCalories:F1} ккал\n";
            productList += $"- Білків: {totalProteins:F1} г\n";
            productList += $"- Жирів: {totalFats:F1} г\n";
            productList += $"- Вуглеводів: {totalCarbs:F1} г\n";
            productList += $"\n💵 Загальна ціна: {totalPrice:F2} грн.";

            MessageBox.Show(productList, "🛍️ Сформований кошик:");
            return finalBasket;
        }
        public void AddMinConstraint(Solver solver, Dictionary<Product, Variable> variables, Func<Product, double> selector, double min)
        {
            if (min < 0) return;

            LinearExpr expr = null;
            foreach (var kvp in variables)
            {
                double factor = kvp.Key.Unit == UnitProduct.Grams ? selector(kvp.Key) / 100.0 : selector(kvp.Key);
                var term = kvp.Value * factor;
                expr = expr == null ? term : expr + term;
            }

            if (expr != null)
            {
                solver.Add(expr >= min);
            }
        }
        public void AddMaxConstraint(Solver solver, Dictionary<Product, Variable> variables, Func<Product, double> selector, double max)
        {
            if (max < 0) return;

            LinearExpr expr = null;
            foreach (var kvp in variables)
            {
                double factor = kvp.Key.Unit == UnitProduct.Grams ? selector(kvp.Key) / 100.0 : selector(kvp.Key);
                var term = kvp.Value * factor;
                expr = expr == null ? term : expr + term;
            }

            if (expr != null)
            {
                solver.Add(expr <= max);
            }
        }
        public List<Product> SolveWithLinearProgramming(List<Product> products,
            double minCalLeft, double maxCalLeft,
            double minProtLeft, double maxProtLeft,
            double minFatsLeft, double maxFatsLeft,
            double minCarbsLeft, double maxCarbsLeft,
            double maxCostLeft)
        {
            Solver solver = Solver.CreateSolver("CBC_MIXED_INTEGER_PROGRAMMING");
            if (solver == null)
            {
                MessageBox.Show("Не вдалося ініціалізувати OR-Tools солвер.");
                return new List<Product>();
            }

            Dictionary<Product, Variable> variables = new();

            // Кожен продукт — змінна: скільки грамів додати

            foreach (var product in products)
            {
                Variable variable;
                if (product.Unit == UnitProduct.Pieces)
                {
                    variable = solver.MakeIntVar(0.0, double.PositiveInfinity, product.Name);
                }
                else
                {
                    variable = solver.MakeNumVar(0.0, double.PositiveInfinity, product.Name);
                }
                variables[product] = variable;
            }

            // Всі обмеження
            AddMinConstraint(solver, variables, p => p.Calories, minCalLeft);
            AddMaxConstraint(solver, variables, p => p.Calories, maxCalLeft);

            AddMinConstraint(solver, variables, p => p.Proteins, minProtLeft);
            AddMaxConstraint(solver, variables, p => p.Proteins, maxProtLeft);

            AddMinConstraint(solver, variables, p => p.Fats, minFatsLeft);
            AddMaxConstraint(solver, variables, p => p.Fats, maxFatsLeft);

            AddMinConstraint(solver, variables, p => p.Carbs, minCarbsLeft);
            AddMaxConstraint(solver, variables, p => p.Carbs, maxCarbsLeft);

            AddMaxConstraint(solver, variables, p => p.Price, maxCostLeft);

            // Мінімізація вартості
            Objective objective = solver.Objective();
            foreach (var (product, variable) in variables)
            {
                objective.SetCoefficient(variable, product.Price);
            }
            objective.SetMinimization();

            Solver.ResultStatus resultStatus = solver.Solve();
            List<Product> result = new();

            if (resultStatus == Solver.ResultStatus.OPTIMAL)
            {
                foreach (var (product, variable) in variables)
                {
                    double grams = variable.SolutionValue();
                    if (grams >= 0.1)
                    {
                        product.SelectedWeight = grams;
                        result.Add(product);
                    }
                }
            }
            else
            {
                MessageBox.Show($"Додаткових продуктів не знайдено! Задля іншого результату збільшіть межі значень.");
            }
            return result;
        }
        public void Result_Click(object sender, RoutedEventArgs e)
        {
            if (!AreAllTextBoxesFilled(this))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля!");
                return;
            }

            if (myComboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть обмеження по дієті!");
                myComboBox.BorderBrush = Brushes.Red;
                myComboBox.BorderThickness = new Thickness(2);
                return;
            }
            else
            {
                myComboBox.ClearValue(TextBox.BorderBrushProperty);
                myComboBox.ClearValue(TextBox.BorderThicknessProperty);
            }

            _selectedProducts.Clear();

            foreach (var child in ProductListPanel.Children)
            {
                if (child is StackPanel panel && panel.Children.Count >= 3)
                {
                    var comboBox = panel.Children[0] as ComboBox;
                    var minText = panel.Children[1] as TextBox;
                    var maxText = panel.Children[2] as TextBox;

                    if (comboBox?.SelectedItem is Product product)
                    {
                        double.TryParse(minText.Text, out var min);
                        double.TryParse(maxText.Text, out var max);
                        if (max < min)
                        {
                            MessageBox.Show($"Некоректні межі грамів для продукту {product.Name}. Введіть коректні межі!");
                            return;
                        }
                        _selectedProducts.Add(new ProductSelection
                        {
                            Product = product,
                            MinGramsPerDay = min,
                            MaxGramsPerDay = max
                        });
                    }
                    
                }
            }
            GenerateWeeklyBasket();
        }
        public List<Product> Product(string file)
        {
            var json = File.ReadAllText(file);
            var productList = new List<Product>();

            // Завантаження JSON
            var items = JsonConvert.DeserializeObject<List<JObject>>(json);

            foreach (var item in items)
            {
                string category = item["Category"]?.ToString();
                Product product = category switch
                {
                    "Vegetables" => new Vegetables(), "Fruits" => new Fruits(),
                    "Сereals" => new Сereals(), "Seed" => new Seed(),
                    "Nuts" => new Nuts(), "Sweets" => new Sweets(),
                    "Milk" => new Milk(), "Bread" => new Bread(),
                    "Meat" => new Meat(), "Fish" => new Fish(),
                    "Drink" => new Drink(),
                    _ => null
                };
                if (product != null)
                {
                    product.Name = item["Name"]?.ToString();
                    product.Calories = item["Calories"]?.ToObject<double>() ?? 0;
                    product.Proteins = item["Proteins"]?.ToObject<double>() ?? 0;
                    product.Fats = item["Fats"]?.ToObject<double>() ?? 0;
                    product.Carbs = item["Carbs"]?.ToObject<double>() ?? 0;
                    product.Price = item["Price"]?.ToObject<double>() ?? 0;
                    product.ImagePath = item["ImagePath"]?.ToString();
                    product.AllowedDiets = item["AllowedDiets"]?.ToObject<List<DietType>>() ?? new List<DietType>();
                    product.Unit = item["Unit"]?.ToString()?.ToLower() switch
                    {
                        "pieces" or "piece" or "шт" => UnitProduct.Pieces,
                        _ => UnitProduct.Grams
                    };
                    product.SelectedWeight = 0;

                    productList.Add(product);
                }
            }
            return productList;
        }
        public MainWindow()
        {
            InitializeComponent();

            string file = "C:\\Users\\06028\\source\\repos\\Kursach\\Kursach\\_products.json";
            _products = Product(file);
        }
    }
}





