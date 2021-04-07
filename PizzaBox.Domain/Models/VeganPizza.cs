using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class VeganPizza : APizza
  {



    public override void AddCrust()
    {
      Crust = null;
    }

    public override void AddSize()
    {
      Size = null;
    }

    public override void AddToppings()
    {
      Toppings.AddRange(new Topping[] { new Topping(), new Topping() });
    }
  }
}