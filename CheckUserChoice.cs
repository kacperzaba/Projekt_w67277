using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_w67277
{
    internal class CheckUserChoice
    {
        
        public CheckUserChoice() 
        {
            
        }
        public void UserInput(string inputFood, int inputTemp, int inputTime, int inputMode)
        {
            string jsonFilePath = "product.json";

            string jsonContent = File.ReadAllText(jsonFilePath);

            Product[] products = JsonConvert.DeserializeObject<Product[]>(jsonContent);
            bool food = false;
            for (int i = 0; i < products.Length; i++)
            {
                if (inputFood == products[i].FoodName & inputTemp == products[i].Temperature & inputTime == products[i].Time & inputMode == products[i].MicrowaveMode) 
                {
                    Console.WriteLine("Jedzenie gotowe, możesz wyjąć je z mikrofalówki.");
                    Console.WriteLine("-----------------------------------");
                    food = true;
                }

            }
            if(!food) 
            {
                Console.WriteLine("Wprowadzono niepoprawne parametry - jedzenie się spaliło.");
                Console.WriteLine("-----------------------------------");
            }


        }
    }
}
