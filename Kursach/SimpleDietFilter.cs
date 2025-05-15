using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    public class SimpleDietFilter : IDietFilter
    {
        public bool IsAllowed(Product product, DietType diet)
        {
            return diet == DietType.None || product.AllowedDiets.Contains(diet);
        }
    }
}