using System;

using System.Collections;
using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;

namespace RecipeClass
{
	  class RecipeClass 
        {
            public string Name { get; set; }
             public List<string> Steps { get; set; }
       // public Ingredient Ingredient { get;  set; }

        public static SortedList<string, System.Collections.Generic.List<Ingredient>> Recipes ;
            
            public static SortedList<string,string> RecipesSteps;
           

       
        //change receipe to sorted list- https://www.tutorialsteacher.com/csharp/csharp-sortedlist
       // ArrayList Recipes = new ArrayList();
       //i wanted to make it take a string and an ingredientstep obj
     //   SortedList<string,Ingredient >Recipes = new SortedList<string, Ingredient>();
           
            int indexNum;
            double ScaleNum;
            string ingred;
            string steps;
      
           
            //Boolean usedMethod = false;
            string newIngrd;
            string Answer;
        string ingredSteps;
        int indexes = 0;
    public List<Ingredient> IngredientsList { get; set; }
        public  RecipeClass(string name)
    {
        Name = name;
        IngredientsList = new List<Ingredient>();
    }

       
public void addRecipe(){
    Recipes = new SortedList<string, System.Collections.Generic.List<Ingredient>>();
    Console.WriteLine("What is the name of the receipe?");
                Name = Console.ReadLine();
                 RecipeClass recipe = new RecipeClass(Name);
                 Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("How many ingredients are there in recipe");
            string answer2 = Console.ReadLine();
            int numIngre = int.Parse(answer2);
            // add ingredients
            AddIngredient(numIngre);
       Recipes.Add(Name, IngredientsList);
       //add steps
       string steps = AddSteps();

       RecipesSteps.Add(Name, steps);
    
            
}
public  void AddIngredient( int numOfIngred)
            {
           string temp = "";
           string tempSteps ="";
           
            Console.BackgroundColor = ConsoleColor.DarkRed;

            
            for (int count = 0; count < numOfIngred; count++)
            {

Ingredient ingred = new Ingredient();
                Console.WriteLine("Please enter the name of the ingredient");

              ingred.Name = Console.ReadLine();
                

                Console.WriteLine($"Please enter the quantity of {ingred.Name}");
                ingred.Quantity = Double.Parse(Console.ReadLine());
                //Quantity[count] = double.Parse(Console.ReadLine());

                Console.WriteLine($"Please enter the unit of measurement of {ingred.Name}");
                ingred.Unit = Console.ReadLine();
// Get calories
                Console.WriteLine($"Please enter the amount of Calories {ingred.Name} has");
                ingred.Calories = int.Parse(Console.ReadLine());

                // Get food group
        Console.WriteLine("Select food group:\n1. Dairy\n2. Protein\n3. Fruit\n4. Vegetable\n5. Grain");
        Console.WriteLine("6. Other");
        Console.Write("Enter food group number: ");
       
        int choice = int.Parse(Console.ReadLine());
        if (choice== 1){
           ingred.FoodGroup = FoodGroup.Dairy;
        } else if (choice == 2){
            ingred.FoodGroup = FoodGroup.Protein;
        } else if (choice == 3){
            ingred.FoodGroup= FoodGroup.Fruit;
        } else if (choice == 4){
            ingred.FoodGroup = FoodGroup.Vegetable;
        } else if (choice == 5){
            ingred.FoodGroup = FoodGroup.Grain;
        } else if (choice == 6){
            ingred.FoodGroup = FoodGroup.Other;
        } 
        // creating an instance of ingredients
        //https://learn.microsoft.com/en-us/dotnet/api/system.activator.createinstance?view=net-8.0
         //need to save into  list of ingredients
         
         IngredientsList.Add(ingred);
            }
            }
         

        //addSteps
                public string AddSteps()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            //add steps
            Console.WriteLine("How many steps are there in recipe");
            string answer2 = Console.ReadLine();
            int numSteps = int.Parse(answer2);
            string placeholder = "";

       
            for (int i = 0; i < numSteps; i++)
            {

                Console.WriteLine("Please enter the step (please enter one step at a time)");
                placeholder += $"{i + 1}. {Console.ReadLine()}\n";
                
                
            }
            return placeholder;

        }
        //method to add ingredient
        

        
    

            
             public void DisplayRecipe(string recipeName)
    {

        if (Recipes.ContainsKey(recipeName))
        {
              Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine($"Ingredients:");
            //retrieving the recipe from 
           
            foreach (var value in Recipes.Values)
{
    Console.WriteLine(value);
} foreach(var valuesteps in RecipesSteps.Values){
    Console.WriteLine(valuesteps);
}
        }
        else
        {
            Console.WriteLine($"Recipe '{recipeName}' not found.");
        }

    }


//Choose which one and then display
            public void displayReceipe()

            {

            if (Recipes != null)
            {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine("Here is a list of the existing receipes:\n");
                for (int i = 0; i < Recipes.Count; i++)
                {
                    //first just display the name of the receipes and then they can select which one to view
                    Console.WriteLine($"{i + 1}.  {Recipes.Keys[i]} ");
                    


                }

                //asking them if they want to view a specific recipe and displaying that recipe.
                    Console.WriteLine("Which recipe would you like to view? Please enter the name of the recipe");
                
                    Answer = Console.ReadLine();
                   DisplayRecipe(Answer);
                    } else {Console.WriteLine("This recipe does not exist please try again");}
                        
                
                //exception handling!
            }

            
                

            //Console.WriteLine(Answer);

            



            

            public void ManipulateReceipe()
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Which receipe would you like to manipualte? Please enter the receipe name below:");
                string answer = Console.ReadLine();

                if (Recipes.ContainsKey(answer)){
                Console.WriteLine("How would you like to rescale your ingredients?\n 0.5 (half), 2 (double), 3 (triple)?");
                ScaleNum = Double.Parse(Console.ReadLine());
                ScaleRecipe(answer);
                Console.WriteLine("Scale sucessful");
                }
                else {
                    Console.WriteLine("The recipe name you entered is invalid");
                }
          
               
                
            }
           
            public void ScaleRecipe( string name)
    {
        var recipe = Recipes[name];
        foreach (var amount in recipe)
        {
            amount.Quantity *= ScaleNum;
        }
         Console.WriteLine($"Recipe '{name}' scaled successfully.");
    }

            public void resetManipulation()
            {
               foreach (var amount in Recipes[Name])
        {
            amount.Quantity /= ScaleNum;
        }
         Console.WriteLine($"Recipe scale reverted successfully.");
    }
            

            
        public void ClearRecipes()
        //https://stackoverflow.com/questions/45814389/how-to-write-the-clear-method-in-the-list-data-structure
            {
Recipes.Clear();               
                indexes = 0; // Reset the index counter
            }

        }}
       

