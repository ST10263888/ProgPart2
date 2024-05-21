using System;
using System.Collections;

    public enum FoodGroup
{
    Dairy,
    Protein,
    Fruit,
    Vegetable,
    Grain,
    Other
}
   public class Ingredient
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public int Calories { get; set; }
    public FoodGroup FoodGroup { get; set; }
  
     

    // Constructor
    
   

    // Method to display ingredient details
    public void DisplayIngredient()
    {
        Console.WriteLine($"- {Name}, {Quantity} {Unit}");
        Console.WriteLine($"  Calories: {Calories}, Food Group: {FoodGroup}");
    }

    // Method to scale the quantity of the ingredient
    public void ScaleQuantity(double factor)
    {
        Quantity *= factor;
    }

       
        public void UpdateCalories()
        {
                        Console.BackgroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Total calories exceed 300. Please re-enter the calories for ingredients.");
            foreach (var ingredient in Ingredient)
            {
                Console.Write($"Enter calories for {ingredient.name}: ");
                ingredient.Calories = int.Parse(Console.ReadLine());
            }
        }
    }










