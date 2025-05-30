using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    public abstract class Product
    {
        public abstract string Category { get;}
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbs { get; set; }
        public double Price { get; set; }
        public List<DietType> AllowedDiets { get; set; } = new List<DietType> { DietType.None };
        public string ImagePath { get; set; }
        public double SelectedWeight { get; set; }
    }
}
