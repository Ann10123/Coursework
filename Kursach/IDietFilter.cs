using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBasket
{
    public interface IDietFilter
    {
        bool IsAllowed(Product product, DietType diet);
    }
}
