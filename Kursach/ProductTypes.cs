using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    public class Vegetables : Product { public override string Category => "Овочі"; }
    public class Fruits : Product { public override string Category => "Фрукти"; }
    public class Сereals : Product { public override string Category => "Крупи"; }
    public class Seed : Product { public override string Category => "Насіння"; }
    public class Nuts : Product { public override string Category => "Горіхи"; }
    public class Sweets : Product { public override string Category => "Солодощі"; }
    public class Milk : Product { public override string Category => "Молоко"; }
    public class Bread : Product { public override string Category => "Хліб"; }
    public class Meat : Product { public override string Category => "М'ясо"; }
    public class Fish : Product { public override string Category => "Риба"; }
    public class Drink : Product { public override string Category => "Напої"; }
}

