using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    public class Vegetable : Product { public override string GetCategory() => "Овочі"; }
    public class Fruit : Product { public override string GetCategory() => "Фрукти"; }
    public class Сereals : Product { public override string GetCategory() => "Крупи"; }
    public class Seed : Product { public override string GetCategory() => "Насіння"; }
    public class Nuts : Product { public override string GetCategory() => "Горіхи"; }
    public class Sweets : Product { public override string GetCategory() => "Солодощі"; }
    public class Milk : Product { public override string GetCategory() => "Молоко"; }
    public class Bread : Product { public override string GetCategory() => "Хліб"; }
    public class Meat : Product { public override string GetCategory() => "М'ясо"; }
    public class Fish : Product { public override string GetCategory() => "Риба"; }
    public class Drink : Product { public override string GetCategory() => "Напої"; }
}