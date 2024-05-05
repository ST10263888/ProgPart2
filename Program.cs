using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;


namespace st10263888_PROG_POE
{

    class receipeClass
    {
        public string[] Receipes;
        public string[] recNames;
        int indexNum;
        double ScaleNum;
        string ingred;
        string steps;
        Ingredient i1 = new Ingredient();
        Boolean usedMethod =false;
        string newIngrd;

        int indexes = 0;
        public void addReceipe()
        {

            //the counter that canh always cahnge everytime the addreceipe method is used

            Console.WriteLine("What is the name of the receipe?");
            string name = Console.ReadLine();
//load into receipe array
            recNames[indexes] = name;
            i1.addIngred();

            //return array as a single array: https://codedamn.com/news/javascript/how-to-convert-a-javascript-array-to-a-string#
            //author: Simran Gangwan
            //accessed: 14 April 2024

            ingred = i1.returnIngred();
            steps = i1.addSteps();
            //newIngrd = i1.IngredientsList[indexes];
            //i1.stepsList[indexes] = steps;
            Receipes[indexes] = $"\nIngredients:\n{ingred}\n{steps}";
           
            indexes++;



        }

        public void displayReceipe()

        {
           
            if (Receipes != null)
            {
                  for (int i = 0; i < Receipes.Length; i++)
                    {

                        Console.WriteLine($"Receipe {i + 1}: \nName: {recNames[i]} \n{Receipes[i]} ");


                    }
                
                
            }
            else 
            {
                Console.WriteLine("There are no receipes loaded!");
            }
            

            


        }
        
        public void ManipulateReceipe()
        {
            Console.WriteLine("Which receipe would you like to manipualte? Please enter the receipe name below:");
            string answer = Console.ReadLine();
            indexNum = FindRecipeIndex(answer);
            Console.WriteLine("How would you like to rescale your ingredients?\n 0.5 (half), 2 (double), 3 (triple)?");
            ScaleNum = Double.Parse(Console.ReadLine());
            ingred = i1.changeQuantity(ScaleNum);
            Receipes[indexes-1] = $"\nIngredients:\n{ingred}\n{steps}";




        }

        public void resetManipulation()
        {
            ingred = i1.revertQuantity(ScaleNum);
            Receipes[indexes - 1] = $"\nIngredients:\n{ingred}\n{steps}";
        }

        public int FindRecipeIndex(string recipeName)
        {
            for (int i = 0; i < recNames.Length; i++)
            {
                if (recNames[i] == recipeName)
                {
                    return i; // Return the index of the recipe if found
                   
                }
            }
            Console.WriteLine("Receipe not found");
            return -1; // Return -1 if the recipe was not found
            
        }

        public void ClearRecipes()
        {
            Receipes = new string[0];
            recNames = new string[0];
            i1.IngredientsList = new string[0];
            indexes = 0; // Reset the index counter
        }

    }


    // stack overflow error: https://www.techtarget.com/whatis/definition/stack-overflow#:~:text=What%20is%20stack%20overflow%3F,been%20allocated%20to%20that%20stack.
    //author: Robert Sheldon
    //accessed: 15 April 2024

    class MenuClass
    {
        private receipeClass r1 = new receipeClass();
        //private IngredientStepsClass i1 = new IngredientStepsClass();
       
        int counter = 0;

        public void MenuClassStart()
        {

            Console.WriteLine("Welcome to Sanele's cooking hub!");


            Console.WriteLine($"Please choose from the following options: \n\n1. Create a receipe.\n2.View receipe list.\n3.Manipulate the scale of the receipe.\n4.Reset the quanities to it's original.\n5.Clear all data.\n6.Quit Program\n");
            string index = Console.ReadLine();
            int option = int.Parse(index);

            if (option == 1)
            {
                counter++;
                //we need to make the receipe array expandable because they can add another receipe at anytime
                r1.Receipes = new string[counter];
                r1.recNames = new string[counter];
              r1.addReceipe();
              this.MenuClassStart();



            }
            else if (option == 2)
            {
                if(r1.Receipes ==null)
                {
                    Console.WriteLine("There are no receipes stored\n");
                }
                else
                {
                    r1.displayReceipe();
                }
               

               this.MenuClassStart();
            }
            else if (option == 3)
            {
                r1.ManipulateReceipe();
                this.MenuClassStart();

            }
            else if (option == 4)
            {
                r1.resetManipulation();
                this.MenuClassStart();
            }

            else if (option == 5)
            {
                r1.ClearRecipes();
                Console.WriteLine("Receipes have been cleared");

                this.MenuClassStart();
            }
            else {

                Environment.Exit(0);
            }








        }



    }




    class Ingredient
    {
        //MenuClass m1 = new MenuClass();
       // receipeClass r1 = new receipeClass();
       double scaleNum { get; set; }

        public string [] Name { get; set; }
        public double [] Quantity { get; set; }
        public string [] UnitOfMeasurement { get; set; }
      
        public string[] IngredientsList;
        public string[] newIngredList;
        public string[] originalQuantities;
        public string[] stepsList;
        int ingredientCount = 0;
        string temp;
        // string ingred;
        int i = 0;

        //return an entire array https://www.codeproject.com/Questions/1194815/Csharp-returning-an-array-from-method
        //author:George Swan
        //accessed: 14 April 2024
        public void collectInfo(string name, double quantity, string uOfMeasure)
        {

            
                Name[i] = name;
                Quantity[i] = quantity;
                UnitOfMeasurement[i] = uOfMeasure;
                IngredientsList[i] = $"{Quantity[i]} {UnitOfMeasurement[i]} of {Name[i]}";

            i++;
            

        }

        public string changeQuantity(double scalNum)
        {
            string newTemp = "";
            for (int i = 0; i < IngredientsList.Length; i++)
            {
                newIngredList[i] = $"{Quantity[i] * scalNum} {UnitOfMeasurement[i]} of {Name[i]}\n";
                newTemp += newIngredList[i];
            }
            return newTemp;

        }

        public string revertQuantity(double scalNum)
        {
            string newTemp = "";
            for (int i = 0; i < IngredientsList.Length; i++)
            {
                newIngredList[i] = $"{Quantity[i]} {UnitOfMeasurement[i]} of {Name[i]}\n";
                newTemp += newIngredList[i];
            }
            return newTemp;

        }

        public string  returnIngred()
        {
            
            for(int i=0; i < IngredientsList.Length; i++)
            {
                temp += $"{IngredientsList[i].ToString()}\n";
            }
            return temp;
        }
        //public void LoadArray(string name, double quantity, string uOMeasurement)
        //{
        //    Name = name;
        //    UnitOfMeasurement = uOMeasurement;
        //    Quantity = quantity;
        //    originalQuantities[ingredientCount] = $"{Quantity} {UnitOfMeasurement} of {Name}\n";







        public void addIngred()
        {
            //add ingredients
            Console.WriteLine("How many ingredients are there in recipe");
            string answer2 = Console.ReadLine();
            int numIngre = int.Parse(answer2);

            originalQuantities = new string[numIngre];
            IngredientsList = new string [numIngre];
            newIngredList = new string[numIngre];
            Name= new string[numIngre];
            Quantity = new double[numIngre];
            UnitOfMeasurement = new string[numIngre];



           
            for (int count = 0; count < numIngre; count++)
            {
                
                Console.WriteLine("Please enter the name of the ingredient");
                
                string ingrName = Console.ReadLine();

                Console.WriteLine($"Please enter the quantity of {ingrName}");
                 double ingrQuantity = Double.Parse(Console.ReadLine());
                //Quantity[count] = double.Parse(Console.ReadLine());

                Console.WriteLine($"Please enter the unit of measurement of {ingrName}");
                string ingrUnitOfMeasurement = Console.ReadLine();
                //[count] = Console.ReadLine();

                collectInfo(ingrName, ingrQuantity, ingrUnitOfMeasurement);
               // temp +=  $"{ingrQuantity} {ingrUnitOfMeasurement} of {ingrName}\n";


                //LoadArray(ingrName, ingrQuantity, ingrUnitOfMeasurement);

            }


        }

        

        public string addSteps()
        {
            //add steps
            Console.WriteLine("How many steps are there in recipe");
            string answer2 = Console.ReadLine();
            int numSteps = int.Parse(answer2);

            stepsList = new string[numSteps];
            int count = 0;

            string placeholder = "\nSteps:\n";
            //populate ingredient array for the receipe
            for (int i = 0; i < numSteps; i++)
            {

                Console.WriteLine("Please enter the step (please enter one step at a time)");
                placeholder += $"{i + 1}. {Console.ReadLine()}\n";


            }
            //load all the steps into the one index of steps
            stepsList[count] = placeholder;


            //load steps in to receipe array
           // r1.Receipes[count] += stepsList[count];
            count++;
            return placeholder;

        }
        
        //for (int i = 0; i < ingredientCount; i++)
        //{
        //    string[] parts = IngredientsList[i].Split(' ');//broken up by spaces
        //    double currentQuantity = double.Parse(parts[0]);

        //    double change = currentQuantity / scaleNum;
        //    // Update each ingredient quantity in the recipe
        //    IngredientsList[i] = $"{change} {parts[1]} of {parts[3]}";

        //}
    }

    

    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            //colour: https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
            //author:GeeksforGeeks
            //accessed: 14 April 2024
            var m1 = new MenuClass();
            m1.MenuClassStart();
            Console.ReadLine();
        }
    }



}