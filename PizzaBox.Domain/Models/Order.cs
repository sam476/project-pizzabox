
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class Order
  {
    public AStore Store { get; set; }
    public Customer Customer { get; set; }
    public APizza Pizza { get; set; }

    /*public Crust Crust { get; set; }
    public Size Size { get; set; }
    public Topping Topping { get; set; }*/

    /// <summary>
    /// 
    /// </summary>
    public void Save()
    {

    }
  }
}