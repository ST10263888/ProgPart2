using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace st10263888_PROG_POE
{

    class Ingredient
    {
        public string name { get; set; }
        public double quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        //arraylists for c# https://www.geeksforgeeks.org/c-sharp-arraylist-class/

    }

    class steps
    {
        public string description { get; set; }
        public ArrayList stepsList;
    }

    class receipeClass
    {
        public string name { get; set; }

        public int scale { get; set; }

        public receipeClass(string name)

        {
            this.name = name;
        }


    }

    class menu
    {

        Ingredient i1 = new Ingredient();




        public void menuStart()
        {

            //create menu options
            Console.WriteLine("Welcome to Sanele's cooking hub!");
            Console.WriteLine("Please choose from the following options: \n\n1. Create a receipe.\n2.View receipe list.\n3.Manipulate the scale of the receipe.\n4.Reset the quanities to it's original.\n5.Clear all data.\n6.Quit Program");
            string index = Console.ReadLine();
            int option = int.Parse(index);
            int count = 0;
            if (option == 1)
            {
                count++;
                addReceipe();

            }
            else if (option == 2)
            {
                displayReceipe();
            }

        }


        //get input from user and convert to interger https://www.freecodecamp.org/news/how-to-convert-a-string-to-an-integer-in-c-sharp/#:~:text=ToInt32()%20is%20a%20static,%22%3B%20int%20num%20%3D%20Convert.


        int counter = 0;
        string[] receipe;
        //adding a receipe
        public void addReceipe()
        {
            //we need to make the receipe array expandable because they can add another receipe at anytime so we use
            //the counter that canh always cahnge everytime the addreceipe method is used
            receipe[counter] = "Name: ";
            Console.WriteLine("What is the name of the receipe?");
            string name = Console.ReadLine();
            receipeClass r1 = new receipeClass(name);
            receipe[counter] += name;
            counter++;

            addIngred();
            //have an add steps or combine with the ingredients input
        }
        public void addIngred()
        {
            //add ingredients
            Console.WriteLine("How many ingredients are there in recipe");
            string answer2 = Console.ReadLine();
            int numIngre = int.Parse(answer2);

            string[] Ingredients = new string[numIngre];
            //nandi
            for (int w = 0; w < numIngre; w++)
            {
                //populate ingredient array for the receipe
                for (int i = 0; i < numIngre; i++)
                {

                    Console.WriteLine("Please enter the name of the ingredient");
                    i1.name = Console.ReadLine();
                    Console.WriteLine($"Please enter the quantity of {i1.name}");
                    double quan = double.Parse(Console.ReadLine());
                    i1.quantity = quan;
                    Console.WriteLine($"Please enter the unit of measurement of {i1.name}");
                    string unit = Console.ReadLine();
                    i1.UnitOfMeasurement = unit;
                    Ingredients[i] = $"[i+1]. {i1.quantity} {i1.UnitOfMeasurement} of {i1.name}\n";
                }
                //load all the ingredients into one index of the receipe array
                receipe[counter] += Ingredients[w];

            }



        }


        //populate receipe array




        public void displayReceipe()
        {
            for (int i = 0; i < receipe.Length; i++)
            {
                Console.WriteLine(receipe[i]);
            }
        }

    }

        
            



        

        
        
    


    class Program
    {






        static void Main(string[] args)
        {
            menu m1= new menu();
        m1.menuStart();
           // m1.displayIngredients();
        }
    }

}