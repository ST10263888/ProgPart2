using System;
using st10263888_PROG_POE;
using System.Collections;

namespace RecipeClass
{
	  class receipeClass
        {

        //change arrays into dictionaies so we can always find the ingredients and stepas associated with a receipe
        //public string[] Receipes;
        // public string[] recNames;
       // Dictionary<string, string> Recipe = new Dictionary<string, string>();
        ArrayList recNames = new ArrayList();
        ArrayList Recipes = new ArrayList();
           
            int indexNum;
            double ScaleNum;
            string ingred;
            string steps;
            Ingredient i1 = new Ingredient();
            //Boolean usedMethod = false;
            string newIngrd;
            string Answer;
        string ingredSteps;
        int indexes = 0;

        public void addReceipe()
            {

                //the counter that canh always cahnge everytime the addreceipe method is used

                Console.WriteLine("What is the name of the receipe?");
                string name = Console.ReadLine();
            //load into receipe array
            recNames.Add(name);
                i1.addIngred();

                //return array as a single array: https://codedamn.com/news/javascript/how-to-convert-a-javascript-array-to-a-string#
                //author: Simran Gangwan
                //accessed: 14 April 2024

                ingred = i1.returnIngred();
                steps = i1.addSteps();

            //newIngrd = i1.IngredientsList[indexes];
            //i1.stepsList[indexes] = steps;
            ingredSteps = $"\nIngredients:\n{ingred}\n{steps}";

             Recipes.Add(ingredSteps);

             //   indexes++;



            }

            public void displayReceipe()

            {

            if (Recipes.Count !=0)
            {
                
                Console.WriteLine("Here is a list of the existing receipes:\n");
                for (int i = 0; i < Recipes.Count; i++)
                {
                    //first just display the name of the receipes and then they can select which one to view
                    Console.WriteLine($"{i + 1}. {recNames[i]}");


                }

                //asking them if they want to view a specific recipe and displaying that recipe.
                    Console.WriteLine("Which recipe would you like to view?");
                
                    Answer = Console.ReadLine();
                    indexNum = FindRecipeIndex(Answer);
                    Console.WriteLine($"{indexNum}", Recipes);
                //exception handling!
            }

            else
            {
                Console.WriteLine("There are no receipes loaded!");
            }

                

            //Console.WriteLine(Answer);

            



            }

            public void ManipulateReceipe()
            {
                Console.WriteLine("Which receipe would you like to manipualte? Please enter the receipe name below:");
                string answer = Console.ReadLine();
                indexNum = FindRecipeIndex(answer);
                Console.WriteLine("How would you like to rescale your ingredients?\n 0.5 (half), 2 (double), 3 (triple)?");
                ScaleNum = Double.Parse(Console.ReadLine());
                ingred = i1.changeQuantity(ScaleNum);
                ingredSteps = $"\nIngredients (with new scale):\n{ingred}\n{steps}";
               // Receipes[indexes - 1] = $"\nIngredients:\n{ingred}\n{steps}";
            }

            public void resetManipulation()
            {
                ingred = i1.revertQuantity(ScaleNum);
                ingredSteps = $"\nIngredients (original scale):\n{ingred}\n{steps}";
            }

            public int FindRecipeIndex(string recipeName)
            {
                for (int i = 0; i < Recipes.Count; i++)
            {
                if (Recipes.Contains(recipeName))
                {
                    return i; // Return the index of the recipe if found
                    //continue statement https://www.geeksforgeeks.org/continue-in-c/
                    continue;

                } else
                {
                    Console.WriteLine("Recipe not found");
                }

            }
            return -1; // Return -1 if the recipe was not found



        }

        public void ClearRecipes()
            {
            Recipes.Clear();
            recNames.Clear();
            i1.IngredientsList.Clear();
               
                indexes = 0; // Reset the index counter
            }

        }

    }


