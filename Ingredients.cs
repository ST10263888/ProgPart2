using System;
using System.Collections;
namespace st10263888_PROG_POE
{
    class Ingredient
    {
        double scaleNum { get; set; }

        
        ArrayList Name = new ArrayList();
        ArrayList Quantity = new ArrayList();
        ArrayList UnitOfMeasurement = new ArrayList();
       public ArrayList IngredientsList = new ArrayList() ;
        ArrayList newIngredList = new ArrayList();
        ArrayList stepsList = new ArrayList();

        int ingredientCount = 0;
        string temp;
        int i = 0;

        //return an entire array https://www.codeproject.com/Questions/1194815/Csharp-returning-an-array-from-method
        //author:George Swan
        //accessed: 14 April 2024
        public void collectInfo(string name, double quantity, string uOfMeasure)
        {


            Name.Add(name);
            Quantity.Add(quantity) ;
            UnitOfMeasurement.Add(uOfMeasure);
            IngredientsList.Add($"{Quantity[i]} {UnitOfMeasurement[i]} of {Name[i]}");

            i++;


        }

        public string changeQuantity(double scalNum)
        {
            string newTemp = "";
           
            for (int i = 0; i < IngredientsList.Count; i++)
            {
                
                newIngredList.Add($"{(double)Quantity[i] * scaleNum} {UnitOfMeasurement[i]} of {Name[i]}\n") ;
                newTemp += newIngredList[i];
            }
            return newTemp;

        }

        public string revertQuantity(double scalNum)
        {
            string newTemp = "";
            for (int i = 0; i < IngredientsList.Count; i++)
            {
                newIngredList[i] = $"{(double)Quantity[i]/ scaleNum} {UnitOfMeasurement[i]} of {Name[i]}\n";
                newTemp += newIngredList[i];
            }
            return newTemp;

        }

        public string returnIngred()
        {

            for (int i = 0; i < IngredientsList.Count; i++)
            {
                temp += $"{IngredientsList[i]}\n";
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

            //originalQuantities = new string[numIngre];
            //IngredientsList = new string[numIngre];
            //newIngredList = new string[numIngre];
            //Name = new string[numIngre];
            //Quantity = new double[numIngre];
            //UnitOfMeasurement = new string[numIngre];




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

            //stepsList = new string[numSteps];
            int count = 0;

            string placeholder = "\nSteps:\n";
            //populate ingredient array for the receipe
            for (int i = 0; i < numSteps; i++)
            {

                Console.WriteLine("Please enter the step (please enter one step at a time)");
                placeholder += $"{i + 1}. {Console.ReadLine()}\n";


            }
            //load all the steps into the one index of steps
            stepsList.Add(placeholder);       
            count++;
            return placeholder;

        }

        
    }

}

