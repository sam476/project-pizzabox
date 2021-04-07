using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;

namespace PizzaBox.Client
{
  /// <summary>
  /// 
  /// </summary>
  internal class Program
  {
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
      Run();
    }

    /// <summary>
    /// 
    /// </summary>
    private static void Run()
    {
      var order = new Order();

      Console.WriteLine("Welcome to PizzaBox");
      DisplayStoreMenu();

      order.Customer = new Customer();
      order.Store = SelectStore();
      order.Pizza = SelectPizza();
      //var crust = listCrusts();
      //var crustPrice = getCrustPrice(crust);
      //var size = listSizes();
      //var sizePrice = getSizePrice(size);


      order.Save();
    }

    /// <summary>
    /// 
    /// </summary>
    private static void DisplayOrder(APizza pizza)
    {
      Console.WriteLine($"Your order is: {pizza}");
    }

    /// <summary>
    /// 
    /// </summary>
    private static void DisplayPizzaMenu()
    {
      var index = 0;

      foreach (var item in _pizzaSingleton.Pizzas)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private static void DisplayStoreMenu()
    {
      var index = 0;

      foreach (var item in _storeSingleton.Stores)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static APizza SelectPizza()
    {
      var input = int.Parse(Console.ReadLine());
      var pizza = _pizzaSingleton.Pizzas[input - 1];

      DisplayOrder(pizza);

      return pizza;
    }

    /// <summary>
    /// after you select a store then a menu is displayed
    /// </summary>
    /// <returns></returns>
    private static AStore SelectStore()
    {
      var input = int.Parse(Console.ReadLine()); // be careful (think execpetion/error handling)

      DisplayPizzaMenu();

      return _storeSingleton.Stores[input - 1];
    }
  }
}

public static string listCrusts()
{
  System.Console.WriteLine("Please choose a crust");
  int choiceNum = 0; // list the corresponding number to the crust choices in list
  string[] list = { "soft", "cheesy", "handtossed", "deepdish" };
  foreach (var crust in list)
  {
    System.Console.WriteLine(choiceNum + " - " + crust);
    choiceNum++;
  }

  string crustChoice = " ";
  int crustSwitch = int.Parse(Console.ReadLine());
  switch (crustSwitch)
  {
    case 0:
      crustChoice = list[0];
      System.Console.WriteLine("crust is " + list[0]);
      break;

    case 1:
      crustChoice = list[1];
      System.Console.WriteLine("crust is " + list[1]);
      break;

    case 2:
      crustChoice = list[2];
      System.Console.WriteLine("crust is " + list[2]);
      break;

    case 3:
      crustChoice = list[3];
      System.Console.WriteLine("crust is " + list[3]);
      break;

    default:
      System.Console.WriteLine("Crust number was not selected. Please choose a crust : 0 soft, 1 cheesy, 2 handtossed, 3 deepdish");
      listCrusts();
      break;
  }

  return crustChoice;

}

public static double getCrustPrice(string crustChoice)
{
  double price = 0.0;
  if (crustChoice == "soft")
  {
    price = 1.50;
    System.Console.WriteLine($"soft ${price}");
  }
  else if (crustChoice == "cheesy")
  {
    price = 3.00;
    System.Console.WriteLine($"cheesy ${price}");
  }
  else if (crustChoice == "handtossed")
  {
    price = 4.00;
    System.Console.WriteLine($"handtossed ${price}");
  }
  else
  {
    price = 5.50;
    System.Console.WriteLine($"deepdish ${price}");
  }
  return price;
}

public static string listSizes()
{
  System.Console.WriteLine("Please choose a size");
  int choiceNum = 0; // list the corresponding number to the size choices in list
  string[] list = { "small-10-inch", "medium-12-inch", "large-14-inch", "extra-large-16-inch" };
  foreach (var size in list)
  {
    System.Console.WriteLine(choiceNum + " - " + size);
    choiceNum++;
  }

  string sizeChoice = " ";
  int sizeSwitch = int.Parse(Console.ReadLine());
  switch (sizeSwitch)
  {
    case 0:
      sizeChoice = list[0];
      System.Console.WriteLine("size is " + list[0]);
      break;

    case 1:
      sizeChoice = list[1];
      System.Console.WriteLine("size is " + list[1]);
      break;

    case 2:
      sizeChoice = list[2];
      System.Console.WriteLine("size is " + list[2]);
      break;

    case 3:
      sizeChoice = list[3];
      System.Console.WriteLine("size is " + list[3]);
      break;

    default:
      System.Console.WriteLine("size number was not selected. Please choose a size : 0 small-10-inch  1 medium-12-inch  2 large-14-inch  3 extra-large-16-inch");
      listCrusts();
      break;
  }

  return sizeChoice;

}


public static double getSizePrice(string sizeChoice)
{
  double price = 0.0;
  if (sizeChoice == "small-10-inch")
  {
    price = 5.50;
    System.Console.WriteLine($"small-10-inch ${price}");
  }
  else if (sizeChoice == "medium-12-inch")
  {
    price = 7.00;
    System.Console.WriteLine($"medium-12-inch ${price}");
  }
  else if (sizeChoice == "large-14-inch")
  {
    price = 8.00;
    System.Console.WriteLine($"large-14-inch ${price}");
  }
  else
  {
    price = 9.50;
    System.Console.WriteLine($"extra-large-16-inch ${price}");
  }
  return price;
}

public static int getNumberToppings()
{

  int toppingTypeNum = 0;
  int toppingAdds = 0;
  System.Console.WriteLine("Enter how many toppings you would like. You can have up to five. Enter 0 for no toppings, 1 for one topping, 2 for two, 3 for three, 4 for four or 5 for five.");
  toppingTypeNum = int.Parse(Console.ReadLine());
  if (toppingTypeNum == 0)
  {
    toppingAdds = 0;
    System.Console.WriteLine("No toppings added.");
  }
  else if (toppingTypeNum == 1)
  {
    toppingAdds = 1;
  }
  else if (toppingTypeNum == 2)
  {
    toppingAdds = 2;
  }
  else if (toppingTypeNum == 3)
  {
    toppingAdds = 3;
  }
  else if (toppingTypeNum == 4)
  {
    toppingAdds = 4;
  }
  else if (toppingTypeNum == 5)
  {
    toppingAdds = 5;
  }
  else
  {
    System.Console.WriteLine("You did not enter a number for the amount of toppings.");
    getNumberToppings();
  }

  return toppingAdds;

}

public static int[] getToppingChoice(int toppingAdds)
{
  int[] toppingArray = new int[0];
  int toppingType1 = 0;
  int toppingType2 = 0;
  int toppingType3 = 0;
  int toppingType4 = 0;
  int toppingType5 = 0;
  // one topping
  if (toppingAdds == 1)
  {
    System.Console.WriteLine("Enter the type of topping you would like: 1 for pepporoni, 2 for saugsage, 3 for olives, 4 for peppers, 5 for cheese");
    toppingType1 = int.Parse(Console.ReadLine());
    if (toppingType1 == 1)
    {
      System.Console.WriteLine("You chose pepporoni.");
      toppingArray = new int[1];
      toppingArray[0] = 1;
    }
    else if (toppingType1 == 2)
    {
      System.Console.WriteLine("You chose saugsage.");
      toppingArray = new int[1];
      toppingArray[0] = 2;
    }
    else if (toppingType1 == 3)
    {
      System.Console.WriteLine("You chose olives.");
      toppingArray = new int[1];
      toppingArray[0] = 3;
    }
    else if (toppingType1 == 4)
    {
      System.Console.WriteLine("You choose peppers.");
      toppingArray = new int[1];
      toppingArray[0] = 4;
    }
    else if (toppingType1 == 5)
    {
      System.Console.WriteLine("You choose peppers.");
      toppingArray = new int[1];
      toppingArray[0] = 5;
    }
    else
    {
      System.Console.WriteLine("You did not enter a number for the topping choice.");
      getToppingChoice(toppingAdds);
    }
    return toppingArray;
  }
  //two toppings
  if (toppingAdds == 2)
  {
    System.Console.WriteLine("Enter the type of topping you would like for the first topping: 1 for pepporoni, 2 for saugsage, 3 for olives, 4 for peppers, 5 for cheese");
    toppingType1 = int.Parse(Console.ReadLine());
    System.Console.WriteLine("Enter the type of topping you would like for the second topping: 1 for pepporoni, 2 for saugsage, 3 for olives, 4 for peppers, 5 for cheese");
    toppingType2 = int.Parse(Console.ReadLine());
    if (toppingType1 == 1)
    {
      System.Console.WriteLine("You chose pepporoni.");
      toppingArray = new int[2];
      toppingArray[0] = 1;
    }
    else if (toppingType1 == 2)
    {
      System.Console.WriteLine("You chose saugsage.");
      toppingArray = new int[2];
      toppingArray[0] = 2;
    }
    else if (toppingType1 == 3)
    {
      System.Console.WriteLine("You chose olives.");
      toppingArray = new int[2];
      toppingArray[0] = 3;
    }
    else if (toppingType1 == 4)
    {
      System.Console.WriteLine("You choose peppers.");
      toppingArray = new int[2];
      toppingArray[0] = 4;
    }
    else if (toppingType1 == 5)
    {
      System.Console.WriteLine("You choose cheese.");
      toppingArray = new int[2];
      toppingArray[0] = 5;
    }
    else
    {
      System.Console.WriteLine("You did not enter a number for the first topping choice.");
      getToppingChoice(toppingAdds);
    }
    // check second topping
    if (toppingType2 == 1)
    {
      System.Console.WriteLine("You chose pepporoni.");
      toppingArray = new int[2];
      toppingArray[1] = 1;
    }
    else if (toppingType2 == 2)
    {
      System.Console.WriteLine("You chose saugsage.");
      toppingArray = new int[2];
      toppingArray[1] = 2;
    }
    else if (toppingType2 == 3)
    {
      System.Console.WriteLine("You chose olives.");
      toppingArray = new int[2];
      toppingArray[1] = 3;
    }
    else if (toppingType2 == 4)
    {
      System.Console.WriteLine("You choose peppers.");
      toppingArray = new int[2];
      toppingArray[1] = 4;
    }
    else if (toppingType2 == 5)
    {
      System.Console.WriteLine("You choose cheese.");
      toppingArray = new int[2];
      toppingArray[1] = 5;
    }
    else
    {
      System.Console.WriteLine("You did not enter a number for the second topping choice.");
      getToppingChoice(toppingAdds);
    }
    return toppingArray;
  }
  //three toppings
  if (toppingAdds == 3)
  {
    System.Console.WriteLine("Enter the type of topping you would like for the first topping: 1 for pepporoni, 2 for saugsage, 3 for olives, 4 for peppers, 5 for cheese");
    toppingType1 = int.Parse(Console.ReadLine());
    System.Console.WriteLine("Enter the type of topping you would like for the second topping: 1 for pepporoni, 2 for saugsage, 3 for olives, 4 for peppers, 5 for cheese");
    toppingType2 = int.Parse(Console.ReadLine());
    System.Console.WriteLine("Enter the type of topping you would like for the third topping: 1 for pepporoni, 2 for saugsage, 3 for olives, 4 for peppers, 5 for cheese");
    toppingType3 = int.Parse(Console.ReadLine());
    if (toppingType1 == 1)
    {
      System.Console.WriteLine("You chose pepporoni.");
      toppingArray = new int[3];
      toppingArray[0] = 1;
    }
    else if (toppingType1 == 2)
    {
      System.Console.WriteLine("You chose saugsage.");
      toppingArray = new int[3];
      toppingArray[0] = 2;
    }
    else if (toppingType1 == 3)
    {
      System.Console.WriteLine("You chose olives.");
      toppingArray = new int[3];
      toppingArray[0] = 3;
    }
    else if (toppingType1 == 4)
    {
      System.Console.WriteLine("You choose peppers.");
      toppingArray = new int[3];
      toppingArray[0] = 4;
    }
    else if (toppingType1 == 5)
    {
      System.Console.WriteLine("You choose cheese.");
      toppingArray = new int[3];
      toppingArray[0] = 5;
    }
    else
    {
      System.Console.WriteLine("You did not enter a number for the first topping choice.");
      getToppingChoice(toppingAdds);
    }
    // check second topping
    if (toppingType2 == 1)
    {
      System.Console.WriteLine("You chose pepporoni.");
      toppingArray = new int[3];
      toppingArray[1] = 1;
    }
    else if (toppingType2 == 2)
    {
      System.Console.WriteLine("You chose saugsage.");
      toppingArray = new int[3];
      toppingArray[1] = 2;
    }
    else if (toppingType2 == 3)
    {
      System.Console.WriteLine("You chose olives.");
      toppingArray = new int[3];
      toppingArray[1] = 3;
    }
    else if (toppingType2 == 4)
    {
      System.Console.WriteLine("You choose peppers.");
      toppingArray = new int[3];
      toppingArray[1] = 4;
    }
    else if (toppingType2 == 5)
    {
      System.Console.WriteLine("You choose cheese.");
      toppingArray = new int[3];
      toppingArray[1] = 5;
    }
    else
    {
      System.Console.WriteLine("You did not enter a number for the second topping choice.");
      getToppingChoice(toppingAdds);
    }
    // check third topping
    if (toppingType3 == 1)
    {
      System.Console.WriteLine("You chose pepporoni.");
      toppingArray = new int[3];
      toppingArray[2] = 1;
    }
    else if (toppingType3 == 2)
    {
      System.Console.WriteLine("You chose saugsage.");
      toppingArray = new int[3];
      toppingArray[2] = 2;
    }
    else if (toppingType3 == 3)
    {
      System.Console.WriteLine("You chose olives.");
      toppingArray = new int[3];
      toppingArray[2] = 3;
    }
    else if (toppingType3 == 4)
    {
      System.Console.WriteLine("You choose peppers.");
      toppingArray = new int[3];
      toppingArray[2] = 4;
    }
    else if (toppingType3 == 5)
    {
      System.Console.WriteLine("You choose cheese.");
      toppingArray = new int[3];
      toppingArray[2] = 5;
    }
    else
    {
      System.Console.WriteLine("You did not enter a number for the third topping choice.");
      getToppingChoice(toppingAdds);
    }
    return toppingArray;
  }
  // four toppings
  if (toppingAdds == 4)
  {
    System.Console.WriteLine("Enter the type of topping you would like for the first topping: 1 for pepporoni, 2 for saugsage, 3 for olives, 4 for peppers, 5 for cheese");
    toppingType1 = int.Parse(Console.ReadLine());
    System.Console.WriteLine("Enter the type of topping you would like for the second topping: 1 for pepporoni, 2 for saugsage, 3 for olives, 4 for peppers, 5 for cheese");
    toppingType2 = int.Parse(Console.ReadLine());
    System.Console.WriteLine("Enter the type of topping you would like for the third topping: 1 for pepporoni, 2 for saugsage, 3 for olives, 4 for peppers, 5 for cheese");
    toppingType3 = int.Parse(Console.ReadLine());
    System.Console.WriteLine("Enter the type of topping you would like for the fourth topping: 1 for pepporoni, 2 for saugsage, 3 for olives, 4 for peppers, 5 for cheese");
    toppingType4 = int.Parse(Console.ReadLine());
    if (toppingType1 == 1)
    {
      System.Console.WriteLine("You chose pepporoni.");
      toppingArray = new int[4];
      toppingArray[0] = 1;
    }
    else if (toppingType1 == 2)
    {
      System.Console.WriteLine("You chose saugsage.");
      toppingArray = new int[4];
      toppingArray[0] = 2;
    }
    else if (toppingType1 == 3)
    {
      System.Console.WriteLine("You chose olives.");
      toppingArray = new int[4];
      toppingArray[0] = 3;
    }
    else if (toppingType1 == 4)
    {
      System.Console.WriteLine("You choose peppers.");
      toppingArray = new int[4];
      toppingArray[0] = 4;
    }
    else if (toppingType1 == 5)
    {
      System.Console.WriteLine("You choose cheese.");
      toppingArray = new int[4];
      toppingArray[0] = 5;
    }
    else
    {
      System.Console.WriteLine("You did not enter a number for the first topping choice.");
      getToppingChoice(toppingAdds);
    }
    // check second topping
    if (toppingType2 == 1)
    {
      System.Console.WriteLine("You chose pepporoni.");
      toppingArray = new int[4];
      toppingArray[1] = 1;
    }
    else if (toppingType2 == 2)
    {
      System.Console.WriteLine("You chose saugsage.");
      toppingArray = new int[4];
      toppingArray[1] = 2;
    }
    else if (toppingType2 == 3)
    {
      System.Console.WriteLine("You chose olives.");
      toppingArray = new int[4];
      toppingArray[1] = 3;
    }
    else if (toppingType2 == 4)
    {
      System.Console.WriteLine("You choose peppers.");
      toppingArray = new int[4];
      toppingArray[1] = 4;
    }
    else if (toppingType2 == 5)
    {
      System.Console.WriteLine("You choose cheese.");
      toppingArray = new int[4];
      toppingArray[1] = 5;
    }
    else
    {
      System.Console.WriteLine("You did not enter a number for the second topping choice.");
      getToppingChoice(toppingAdds);
    }
    // check third topping
    if (toppingType3 == 1)
    {
      System.Console.WriteLine("You chose pepporoni.");
      toppingArray = new int[4];
      toppingArray[2] = 1;
    }
    else if (toppingType3 == 2)
    {
      System.Console.WriteLine("You chose saugsage.");
      toppingArray = new int[4];
      toppingArray[2] = 2;
    }
    else if (toppingType3 == 3)
    {
      System.Console.WriteLine("You chose olives.");
      toppingArray = new int[4];
      toppingArray[2] = 3;
    }
    else if (toppingType3 == 4)
    {
      System.Console.WriteLine("You choose peppers.");
      toppingArray = new int[4];
      toppingArray[2] = 4;
    }
    else if (toppingType3 == 5)
    {
      System.Console.WriteLine("You choose cheese.");
      toppingArray = new int[4];
      toppingArray[2] = 5;
    }
    else
    {
      System.Console.WriteLine("You did not enter a number for the third topping choice.");
      getToppingChoice(toppingAdds);
    }
    //check fourth topping 
    if (toppingType4 == 1)
    {
      System.Console.WriteLine("You chose pepporoni.");
      toppingArray = new int[4];
      toppingArray[3] = 1;
    }
    else if (toppingType4 == 2)
    {
      System.Console.WriteLine("You chose saugsage.");
      toppingArray = new int[4];
      toppingArray[3] = 2;
    }
    else if (toppingType4 == 3)
    {
      System.Console.WriteLine("You chose olives.");
      toppingArray = new int[4];
      toppingArray[3] = 3;
    }
    else if (toppingType4 == 4)
    {
      System.Console.WriteLine("You choose peppers.");
      toppingArray = new int[4];
      toppingArray[3] = 4;
    }
    else if (toppingType4 == 5)
    {
      System.Console.WriteLine("You choose cheese.");
      toppingArray = new int[4];
      toppingArray[3] = 5;
    }
    else
    {
      System.Console.WriteLine("You did not enter a number for the fourth topping choice.");
      getToppingChoice(toppingAdds);
    }
    return toppingArray;
  }
  //five toppings 
  if (toppingAdds == 5)
  {
    System.Console.WriteLine("Enter the type of topping you would like for the first topping: 1 for pepporoni, 2 for saugsage, 3 for olives, 4 for peppers, 5 for cheese");
    toppingType1 = int.Parse(Console.ReadLine());
    System.Console.WriteLine("Enter the type of topping you would like for the second topping: 1 for pepporoni, 2 for saugsage, 3 for olives, 4 for peppers, 5 for cheese");
    toppingType2 = int.Parse(Console.ReadLine());
    System.Console.WriteLine("Enter the type of topping you would like for the third topping: 1 for pepporoni, 2 for saugsage, 3 for olives, 4 for peppers, 5 for cheese");
    toppingType3 = int.Parse(Console.ReadLine());
    System.Console.WriteLine("Enter the type of topping you would like for the fourth topping: 1 for pepporoni, 2 for saugsage, 3 for olives, 4 for peppers, 5 for cheese");
    toppingType4 = int.Parse(Console.ReadLine());
    System.Console.WriteLine("Enter the type of topping you would like for the fifth topping: 1 for pepporoni, 2 for saugsage, 3 for olives, 4 for peppers, 5 for cheese");
    toppingType5 = int.Parse(Console.ReadLine());
    if (toppingType1 == 1)
    {
      System.Console.WriteLine("You chose pepporoni.");
      toppingArray = new int[5];
      toppingArray[0] = 1;
    }
    else if (toppingType1 == 2)
    {
      System.Console.WriteLine("You chose saugsage.");
      toppingArray = new int[5];
      toppingArray[0] = 2;
    }
    else if (toppingType1 == 3)
    {
      System.Console.WriteLine("You chose olives.");
      toppingArray = new int[5];
      toppingArray[0] = 3;
    }
    else if (toppingType1 == 4)
    {
      System.Console.WriteLine("You choose peppers.");
      toppingArray = new int[5];
      toppingArray[0] = 4;
    }
    else if (toppingType1 == 5)
    {
      System.Console.WriteLine("You choose cheese.");
      toppingArray = new int[5];
      toppingArray[0] = 5;
    }
    else
    {
      System.Console.WriteLine("You did not enter a number for the first topping choice.");
      getToppingChoice(toppingAdds);
    }
    // check second topping
    if (toppingType2 == 1)
    {
      System.Console.WriteLine("You chose pepporoni.");
      toppingArray = new int[5];
      toppingArray[1] = 1;
    }
    else if (toppingType2 == 2)
    {
      System.Console.WriteLine("You chose saugsage.");
      toppingArray = new int[5];
      toppingArray[1] = 2;
    }
    else if (toppingType2 == 3)
    {
      System.Console.WriteLine("You chose olives.");
      toppingArray = new int[5];
      toppingArray[1] = 3;
    }
    else if (toppingType2 == 4)
    {
      System.Console.WriteLine("You choose peppers.");
      toppingArray = new int[5];
      toppingArray[1] = 4;
    }
    else if (toppingType2 == 5)
    {
      System.Console.WriteLine("You choose cheese.");
      toppingArray = new int[5];
      toppingArray[1] = 5;
    }
    else
    {
      System.Console.WriteLine("You did not enter a number for the second topping choice.");
      getToppingChoice(toppingAdds);
    }
    // check third topping
    if (toppingType3 == 1)
    {
      System.Console.WriteLine("You chose pepporoni.");
      toppingArray = new int[5];
      toppingArray[2] = 1;
    }
    else if (toppingType3 == 2)
    {
      System.Console.WriteLine("You chose saugsage.");
      toppingArray = new int[5];
      toppingArray[2] = 2;
    }
    else if (toppingType3 == 3)
    {
      System.Console.WriteLine("You chose olives.");
      toppingArray = new int[5];
      toppingArray[2] = 3;
    }
    else if (toppingType3 == 4)
    {
      System.Console.WriteLine("You choose peppers.");
      toppingArray = new int[5];
      toppingArray[2] = 4;
    }
    else if (toppingType3 == 5)
    {
      System.Console.WriteLine("You choose cheese.");
      toppingArray = new int[5];
      toppingArray[2] = 5;
    }
    else
    {
      System.Console.WriteLine("You did not enter a number for the third topping choice.");
      getToppingChoice(toppingAdds);
    }
    //check fourth topping 
    if (toppingType4 == 1)
    {
      System.Console.WriteLine("You chose pepporoni.");
      toppingArray = new int[5];
      toppingArray[3] = 1;
    }
    else if (toppingType4 == 2)
    {
      System.Console.WriteLine("You chose saugsage.");
      toppingArray = new int[5];
      toppingArray[3] = 2;
    }
    else if (toppingType4 == 3)
    {
      System.Console.WriteLine("You chose olives.");
      toppingArray = new int[5];
      toppingArray[3] = 3;
    }
    else if (toppingType4 == 4)
    {
      System.Console.WriteLine("You choose peppers.");
      toppingArray = new int[5];
      toppingArray[3] = 4;
    }
    else if (toppingType4 == 5)
    {
      System.Console.WriteLine("You choose cheese.");
      toppingArray = new int[5];
      toppingArray[3] = 5;
    }
    else
    {
      System.Console.WriteLine("You did not enter a number for the fourth topping choice.");
      getToppingChoice(toppingAdds);
    }
    //check fifth topping 
    if (toppingType5 == 1)
    {
      System.Console.WriteLine("You chose pepporoni.");
      toppingArray = new int[5];
      toppingArray[4] = 1;
    }
    else if (toppingType5 == 2)
    {
      System.Console.WriteLine("You chose saugsage.");
      toppingArray = new int[5];
      toppingArray[4] = 2;
    }
    else if (toppingType5 == 3)
    {
      System.Console.WriteLine("You chose olives.");
      toppingArray = new int[5];
      toppingArray[4] = 3;
    }
    else if (toppingType5 == 4)
    {
      System.Console.WriteLine("You choose peppers.");
      toppingArray = new int[5];
      toppingArray[4] = 4;
    }
    else if (toppingType5 == 5)
    {
      System.Console.WriteLine("You choose cheese.");
      toppingArray = new int[5];
      toppingArray[4] = 5;
    }
    else
    {
      System.Console.WriteLine("You did not enter a number for the fifth topping choice.");
      getToppingChoice(toppingAdds);
    }
    return toppingArray;
  }
  return toppingArray;
}

//askForExtra checks the amount of the toppings (array size) then loops to store in the correct variables.
//if the size is not 5 then ask the user if they would like extra specific toppings. 
public static double[] askForExtra(int[] toppingArray)
{
  double[] PriceAndNumberOfExtras = new double[2];
  double totalToppingPrice = 0.0;
  double totalExtras = 0.0;

  int topping1Extra = 0;
  double topping1Price = 0.0; //pepporoni

  int topping2Extra = 0;
  double topping2Price = 0.0; // saugsage

  int topping3Extra = 0;
  double topping3Price = 0.0; // olives

  int topping4Extra = 0;
  double topping4Price = 0.0; // peppers

  int topping5Extra = 0;
  double topping5Price = 0.0; // cheese 

  int topping1 = 0; // first topping
  int topping2 = 0; // second topping 
  int topping3 = 0; // third topping
  int topping4 = 0; // fourth topping
  int topping5 = 0; // fifth topping
  if (toppingArray.Length == 1)
  {
    topping1 = toppingArray[0];
  }
  if (topping1 == 1)
  {
    System.Console.WriteLine("would you like extra toppings of pepporoni? 0 for no extras, 1 for one extra topping, 2 for two extra toppings, 3 for three extra toppings or 4 for four extra toppings.");
    topping1Extra = int.Parse(System.Console.ReadLine());
    if (topping1Extra == 0)
    {
      topping1Price = 0.0;
    }
    else if (topping1Extra == 1)
    {
      topping1Price = 1.50;
      topping1Price *= topping1Extra;
    }
    else if (topping1Extra == 2)
    {
      topping1Price = 1.50;
      topping1Price *= topping1Extra;
    }
    else if (topping1Extra == 3)
    {
      topping1Price = 1.50;
      topping1Price *= topping1Extra;
    }
    else if (topping1Extra == 4)
    {
      topping1Price = 1.50;
      topping1Price *= topping1Extra;
    }
    else if (topping1Extra == 5)
    {
      topping1Price = 1.50;
      topping1Price *= topping1Extra;
    }
    else
    {
      System.Console.WriteLine("You did not enter a number for the extra topping.");
      askForExtra(toppingArray);
    }

    if (topping1 == 2)
    {
      System.Console.WriteLine("would you like extra toppings of saugsage? 0 for no extras, 1 for one extra topping, 2 for two extra toppings, 3 for three extra toppings or 4 for four extra toppings.");
      topping2Extra = int.Parse(System.Console.ReadLine());
      if (topping2Extra == 0)
      {
        topping2Price = 0.0;
      }
      else if (topping2Extra == 1)
      {
        topping1Price = 1.50;
        topping2Price *= topping2Extra;
      }
      else if (topping2Extra == 2)
      {
        topping1Price = 1.50;
        topping2Price *= topping2Extra;
      }
      else if (topping2Extra == 3)
      {
        topping1Price = 1.50;
        topping2Price *= topping2Extra;
      }
      else if (topping2Extra == 4)
      {
        topping1Price = 1.50;
        topping2Price *= topping2Extra;
      }
      else if (topping2Extra == 5)
      {
        topping1Price = 1.50;
        topping2Price *= topping2Extra;
      }
      else
      {
        System.Console.WriteLine("You did not enter a number for the extra topping.");
        askForExtra(toppingArray);
      }

    }

    if (topping1 == 3)
    {
      System.Console.WriteLine("would you like extra toppings of olives? 0 for no extras, 1 for one extra topping, 2 for two extra toppings, 3 for three extra toppings or 4 for four extra toppings.");
      topping3Extra = int.Parse(System.Console.ReadLine());
      if (topping3Extra == 0)
      {
        topping3Price = 0.0;
      }
      else if (topping3Extra == 1)
      {
        topping1Price = 1.50;
        topping3Price *= topping3Extra;
      }
      else if (topping3Extra == 2)
      {
        topping1Price = 1.50;
        topping3Price *= topping3Extra;
      }
      else if (topping3Extra == 3)
      {
        topping1Price = 1.50;
        topping3Price *= topping3Extra;
      }
      else if (topping3Extra == 4)
      {
        topping1Price = 1.50;
        topping3Price *= topping3Extra;
      }
      else if (topping3Extra == 5)
      {
        topping1Price = 1.50;
        topping3Price *= topping3Extra;
      }
      else
      {
        System.Console.WriteLine("You did not enter a number for the extra topping.");
        askForExtra(toppingArray);
      }

      if (topping1 == 4)
      {
        System.Console.WriteLine("would you like extra toppings of peppers? 0 for no extras, 1 for one extra topping, 2 for two extra toppings, 3 for three extra toppings or 4 for four extra toppings.");
        topping4Extra = int.Parse(System.Console.ReadLine());
        if (topping4Extra == 0)
        {
          topping4Price = 0.0;
        }
        else if (topping4Extra == 1)
        {
          topping1Price = 1.50;
          topping4Price *= topping4Extra;
        }
        else if (topping4Extra == 2)
        {
          topping1Price = 1.50;
          topping4Price *= topping4Extra;
        }
        else if (topping4Extra == 3)
        {
          topping1Price = 1.50;
          topping4Price *= topping4Extra;
        }
        else if (topping4Extra == 4)
        {
          topping1Price = 1.50;
          topping4Price *= topping4Extra;
        }
        else if (topping4Extra == 5)
        {
          topping1Price = 1.50;
          topping4Price *= topping4Extra;
        }
        else
        {
          System.Console.WriteLine("You did not enter a number for the extra topping.");
          askForExtra(toppingArray);
        }

        if (topping1 == 5)
        {
          System.Console.WriteLine("would you like extra toppings of cheese? 0 for no extras, 1 for one extra topping, 2 for two extra toppings, 3 for three extra toppings or 4 for four extra toppings.");
          topping5Extra = int.Parse(System.Console.ReadLine());
          if (topping5Extra == 0)
          {
            topping5Price = 0.0;
          }
          else if (topping5Extra == 1)
          {
            topping1Price = 1.50;
            topping5Price *= topping5Extra;
          }
          else if (topping5Extra == 2)
          {
            topping1Price = 1.50;
            topping5Price *= topping5Extra;
          }
          else if (topping5Extra == 3)
          {
            topping1Price = 1.50;
            topping5Price *= topping5Extra;
          }
          else if (topping5Extra == 4)
          {
            topping1Price = 1.50;
            topping5Price *= topping5Extra;
          }
          else if (topping5Extra == 5)
          {
            topping1Price = 1.50;
            topping5Price *= topping5Extra;
          }
          else
          {
            System.Console.WriteLine("You did not enter a number for the extra topping.");
            askForExtra(toppingArray);
          }
          totalExtras = topping1Extra + topping2Extra + topping3Extra + topping4Extra;
          totalToppingPrice = topping1Price + topping2Price + topping3Price + topping4Price;
          PriceAndNumberOfExtras[0] = totalExtras; //index 0 will store the extra toppings ordered
          PriceAndNumberOfExtras[1] = totalToppingPrice; // index 1 will store the total price of the toppings
          return PriceAndNumberOfExtras;
        }
        if (toppingArray.Length == 2)
        {
          topping1 = toppingArray[0];
          topping2 = toppingArray[1];
        }

        // two toppings asked for extra
        //
        if (topping1 == 1)
        {
          System.Console.WriteLine("would you like extra toppings of pepporoni? 0 for no extras, 1 for one extra topping, 2 for two extra toppings or 3 for three extra toppings.");
          topping1Extra = int.Parse(System.Console.ReadLine());
          if (topping1Extra == 0)
          {
            topping1Price = 0.0;
          }
          else if (topping1Extra == 1)
          {
            topping1Price = 1.50;
            topping1Price *= topping1Extra;
          }
          else if (topping1Extra == 2)
          {
            topping1Price = 1.50;
            topping1Price *= topping1Extra;
          }
          else if (topping1Extra == 3)
          {
            topping1Price = 1.50;
            topping1Price *= topping1Extra;
          }
          else
          {
            System.Console.WriteLine("You did not enter a number for the extra topping.");
            askForExtra(toppingArray);
          }

          if (topping1 == 2)
          {
            System.Console.WriteLine("would you like extra toppings of saugsage? 0 for no extras, 1 for one extra topping, 2 for two extra toppings or 3 for three extra toppings.");
            topping2Extra = int.Parse(System.Console.ReadLine());
            if (topping2Extra == 0)
            {
              topping2Price = 0.0;
            }
            else if (topping2Extra == 1)
            {
              topping1Price = 1.50;
              topping2Price *= topping2Extra;
            }
            else if (topping2Extra == 2)
            {
              topping1Price = 1.50;
              topping2Price *= topping2Extra;
            }
            else if (topping2Extra == 3)
            {
              topping1Price = 1.50;
              topping2Price *= topping2Extra;
            }
            else
            {
              System.Console.WriteLine("You did not enter a number for the extra topping.");
              askForExtra(toppingArray);
            }

          }

          if (topping1 == 3)
          {
            System.Console.WriteLine("would you like extra toppings of olives? 0 for no extras, 1 for one extra topping, 2 for two extra toppings, or 3 for three extra toppings.");
            topping3Extra = int.Parse(System.Console.ReadLine());
            if (topping3Extra == 0)
            {
              topping3Price = 0.0;
            }
            else if (topping3Extra == 1)
            {
              topping1Price = 1.50;
              topping3Price *= topping3Extra;
            }
            else if (topping3Extra == 2)
            {
              topping1Price = 1.50;
              topping3Price *= topping3Extra;
            }
            else if (topping3Extra == 3)
            {
              topping1Price = 1.50;
              topping3Price *= topping3Extra;
            }
            else
            {
              System.Console.WriteLine("You did not enter a number for the extra topping.");
              askForExtra(toppingArray);
            }

            if (topping1 == 4)
            {
              System.Console.WriteLine("would you like extra toppings of peppers? 0 for no extras, 1 for one extra topping, 2 for two extra toppings or 3 for three extra toppings.");
              topping4Extra = int.Parse(System.Console.ReadLine());
              if (topping4Extra == 0)
              {
                topping4Price = 0.0;
              }
              else if (topping4Extra == 1)
              {
                topping1Price = 1.50;
                topping4Price *= topping4Extra;
              }
              else if (topping4Extra == 2)
              {
                topping1Price = 1.50;
                topping4Price *= topping4Extra;
              }
              else if (topping4Extra == 3)
              {
                topping1Price = 1.50;
                topping4Price *= topping4Extra;
              }
              else
              {
                System.Console.WriteLine("You did not enter a number for the extra topping.");
                askForExtra(toppingArray);
              }

              if (topping1 == 5)
              {
                System.Console.WriteLine("would you like extra toppings of cheese? 0 for no extras, 1 for one extra topping, 2 for two extra toppings or 3 for three extra toppings.");
                topping5Extra = int.Parse(System.Console.ReadLine());
                if (topping5Extra == 0)
                {
                  topping5Price = 0.0;
                }
                else if (topping5Extra == 1)
                {
                  topping1Price = 1.50;
                  topping5Price *= topping5Extra;
                }
                else if (topping5Extra == 2)
                {
                  topping1Price = 1.50;
                  topping5Price *= topping5Extra;
                }
                else if (topping5Extra == 3)
                {
                  topping1Price = 1.50;
                  topping5Price *= topping5Extra;
                }
                else if (topping5Extra == 4)
                {
                  topping1Price = 1.50;
                  topping5Price *= topping5Extra;
                }
                else if (topping5Extra == 5)
                {
                  topping1Price = 1.50;
                  topping5Price *= topping5Extra;
                }
                else
                {
                  System.Console.WriteLine("You did not enter a number for the extra topping.");
                  askForExtra(toppingArray);
                }

                //second topping 
                // variables for storing the second topping need to be different 
                if (topping2 == 2)
                {
                  System.Console.WriteLine("would you like extra toppings of pepporoni? 0 for no extras, 1 for one extra topping, 2 for two extra toppings.");
                  topping1Extra = int.Parse(System.Console.ReadLine());
                  if (topping1Extra == 0)
                  {
                    topping1Price = 0.0;
                  }
                  else if (topping1Extra == 1)
                  {
                    topping1Price = 1.50;
                    topping1Price *= topping1Extra;
                  }
                  else if (topping1Extra == 2)
                  {
                    topping1Price = 1.50;
                    topping1Price *= topping1Extra;
                  }
                  else
                  {
                    System.Console.WriteLine("You did not enter a number for the extra topping.");
                    askForExtra(toppingArray);
                  }

                  if (topping2 == 2)
                  {
                    System.Console.WriteLine("would you like extra toppings of saugsage? 0 for no extras, 1 for one extra topping, 2 for two extra toppings.");
                    topping2Extra = int.Parse(System.Console.ReadLine());
                    if (topping2Extra == 0)
                    {
                      topping2Price = 0.0;
                    }
                    else if (topping2Extra == 1)
                    {
                      topping1Price = 1.50;
                      topping2Price *= topping2Extra;
                    }
                    else if (topping2Extra == 2)
                    {
                      topping1Price = 1.50;
                      topping2Price *= topping2Extra;
                    }
                    else
                    {
                      System.Console.WriteLine("You did not enter a number for the extra topping.");
                      askForExtra(toppingArray);
                    }

                  }

                  if (topping2 == 3)
                  {
                    System.Console.WriteLine("would you like extra toppings of olives? 0 for no extras, 1 for one extra topping, 2 for two extra toppings.");
                    topping3Extra = int.Parse(System.Console.ReadLine());
                    if (topping3Extra == 0)
                    {
                      topping3Price = 0.0;
                    }
                    else if (topping3Extra == 1)
                    {
                      topping1Price = 1.50;
                      topping3Price *= topping3Extra;
                    }
                    else if (topping3Extra == 2)
                    {
                      topping1Price = 1.50;
                      topping3Price *= topping3Extra;
                    }
                    else
                    {
                      System.Console.WriteLine("You did not enter a number for the extra topping.");
                      askForExtra(toppingArray);
                    }

                    if (topping2 == 4)
                    {
                      System.Console.WriteLine("would you like extra toppings of peppers? 0 for no extras, 1 for one extra topping, 2 for two extra toppings.");
                      topping4Extra = int.Parse(System.Console.ReadLine());
                      if (topping4Extra == 0)
                      {
                        topping4Price = 0.0;
                      }
                      else if (topping4Extra == 1)
                      {
                        topping1Price = 1.50;
                        topping4Price *= topping4Extra;
                      }
                      else if (topping4Extra == 2)
                      {
                        topping1Price = 1.50;
                        topping4Price *= topping4Extra;
                      }
                      else
                      {
                        System.Console.WriteLine("You did not enter a number for the extra topping.");
                        askForExtra(toppingArray);
                      }

                      if (topping2 == 5)
                      {
                        System.Console.WriteLine("would you like extra toppings of cheese? 0 for no extras, 1 for one extra topping, 2 for two extra toppings.");
                        topping5Extra = int.Parse(System.Console.ReadLine());
                        if (topping5Extra == 0)
                        {
                          topping5Price = 0.0;
                        }
                        else if (topping5Extra == 1)
                        {
                          topping1Price = 1.50;
                          topping5Price *= topping5Extra;
                        }
                        else if (topping5Extra == 2)
                        {
                          topping1Price = 1.50;
                          topping5Price *= topping5Extra;
                        }
                        else if (topping5Extra == 3)
                        {
                          topping1Price = 1.50;
                          topping5Price *= topping5Extra;
                        }
                        else
                        {
                          System.Console.WriteLine("You did not enter a number for the extra topping.");
                          askForExtra(toppingArray);
                        }
                      }
                    }
                  }
                }
              }
              */

