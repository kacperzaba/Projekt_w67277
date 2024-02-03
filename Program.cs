using Newtonsoft.Json;
using System.Net.Sockets;

namespace Projekt_w67277
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int SelectedMode = 0;
            int SelectedTemp = 0;
            int SelectedTime = 0;
            string SelectedFood = "";
            int userChoice;
            bool foodChosen = false;
            bool modChosen = false;
            string jsonFilePath = "product.json";
            while (true)
            {
                Console.WriteLine("Wybierz opcję: ");
                Console.WriteLine("1. Podaj potrawę: ");
                Console.WriteLine("2. Wybierz program, podaj temperaturę i czas: ");
                Console.WriteLine("3. Wyjmij jedzenie.");
                Console.WriteLine("4. Dodaj potrawe do zbioru.");
                Console.WriteLine("5. Usun potrawe z zbioru.");
                Console.WriteLine("6. Modyfikuj potrawe z zbioru.");
                Console.WriteLine("7. Pokaż zbiór potraw.");



                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch(userChoice)
                    {
                        case 1:
                            Console.WriteLine(" Napisz nazwę potrawy: ");
                            SelectedFood = Console.ReadLine();
                            foodChosen = true;
                            break;

                        case 2:
                            if(!foodChosen)
                            {
                                Console.WriteLine(" Musisz najpierw podać potrawę.");
                                Console.WriteLine("--------------------------------");
                                break;
                            }
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine(" Wybierz program: ");
                            Console.WriteLine("1. Odmrażanie");
                            Console.WriteLine("2. Duszenie");
                            Console.WriteLine("3. Gotowanie");
                            Console.WriteLine("4. Smażenie");
                            Console.WriteLine("5. Grilowanie");


                            if (int.TryParse(Console.ReadLine(), out SelectedMode))
                            
                                switch(SelectedMode)
                                {

                                    case 1:
                                        Console.WriteLine(" Wybrano odmrażanie, podaj temperature: ");
                                        SelectedTemp = int.Parse(Console.ReadLine());
                                        Console.WriteLine(" Temperatura wybrana, podaj czas (w sekundach)");
                                        SelectedTime = int.Parse(Console.ReadLine());
                                        Melting meltFood = new Melting(SelectedTemp, SelectedTime);
                                        meltFood.Print();
                                        Console.WriteLine("--------------------------------");
                                        break;

                                    case 2:
                                        Console.WriteLine(" Wybrano dusznie, podaj temperature: ");
                                        SelectedTemp = int.Parse(Console.ReadLine());
                                        Console.WriteLine(" Temperatura wybrana, podaj czas (w sekundach)");
                                        SelectedTime = int.Parse(Console.ReadLine());
                                        Stewing StewFood = new Stewing(SelectedTemp, SelectedTime);
                                        StewFood.Print();
                                        Console.WriteLine("--------------------------------");
                                        break;

                                    case 3:
                                        Console.WriteLine(" Wybrano gotowanie, podaj temperature: ");
                                        SelectedTemp = int.Parse(Console.ReadLine());
                                        Console.WriteLine(" Temperatura wybrana, podaj czas (w sekundach)");
                                        SelectedTime = int.Parse(Console.ReadLine());
                                        Boiling BoilFood = new Boiling(SelectedTemp, SelectedTime);
                                        BoilFood.Print();
                                        Console.WriteLine("--------------------------------");
                                        break;

                                    case 4:
                                        Console.WriteLine(" Wybrano smażenie, podaj temperature: ");
                                        SelectedTemp = int.Parse(Console.ReadLine());
                                        Console.WriteLine(" Temperatura wybrana, podaj czas (w sekundach)");
                                        SelectedTime = int.Parse(Console.ReadLine());
                                        Frying FryFood = new Frying(SelectedTemp, SelectedTime);
                                        FryFood.Print();
                                        Console.WriteLine("--------------------------------");
                                        break;

                                    case 5:
                                        Console.WriteLine(" Wybrano grilowanie, podaj temperature: ");
                                        SelectedTemp = int.Parse(Console.ReadLine());
                                        Console.WriteLine(" Temperatura wybrana, podaj czas (w sekundach)");
                                        SelectedTime = int.Parse(Console.ReadLine());
                                        Grilling GrillFood = new Grilling(SelectedTemp, SelectedTime);
                                        GrillFood.Print();
                                        Console.WriteLine("--------------------------------");
                                        break;
                                }
                                

                            modChosen = true;
                            break;
                            
                        case 3:
                            if(!foodChosen | !modChosen)
                            {
                                Console.WriteLine(" Musisz najpierw wybrać potrawe i program");
                                break;
                            }
                            CheckUserChoice w = new CheckUserChoice();
                            w.UserInput(SelectedFood, SelectedTemp, SelectedTime, SelectedMode);
                            return;


                        case 4:
                            Product[] productsAdd = JsonConvert.DeserializeObject<Product[]>(File.ReadAllText(jsonFilePath));

                            Console.WriteLine("Podaj nazwę potrawy: ");
                            string foodName = Console.ReadLine();

                            Console.WriteLine("Podaj temperaturę: ");
                            int temp = int.Parse(Console.ReadLine());

                            Console.WriteLine("Podaj czas: ");
                            int time = int.Parse(Console.ReadLine());

                            Console.WriteLine("Wybierz jeden z poniższych programów");
                            Console.WriteLine("1. Odmrażanie");
                            Console.WriteLine("2. Duszenie");
                            Console.WriteLine("3. Gotowanie");
                            Console.WriteLine("4. Smażenie");
                            Console.WriteLine("5. Grilowanie");
                            int mode = int.Parse(Console.ReadLine());

                            Product newProduct = new Product(foodName, temp, time, mode);

                            Array.Resize(ref productsAdd, productsAdd.Length + 1);

                            productsAdd[productsAdd.Length - 1] = newProduct;

                            string jsonWithNewElem = JsonConvert.SerializeObject(productsAdd, Formatting.Indented);
                            File.WriteAllText(jsonFilePath, jsonWithNewElem);
                            Console.WriteLine("Nowy produkt został dodany do pliku JSON.");
                            break;

                        case 5:
                            Product[] productsDel = JsonConvert.DeserializeObject<Product[]>(File.ReadAllText(jsonFilePath));

                            Console.WriteLine("Podaj nazwe potrawy którą chcesz usunąć: ");
                            string deleteFood = Console.ReadLine();

                            List<Product> jsonAfterDelete = new List<Product>();
                            foreach (var product in productsDel)
                            {
                                if (product.FoodName != deleteFood)
                                {
                                    jsonAfterDelete.Add(product);
                                }
                            }

                            string deleteJson = JsonConvert.SerializeObject(jsonAfterDelete, Formatting.Indented);
                            File.WriteAllText(jsonFilePath, deleteJson);

                            Console.WriteLine($"Potrawa o nazwie {deleteFood} została usunięta");
                            break;


                        case 6:
                            Product[] productsModify = JsonConvert.DeserializeObject<Product[]>(File.ReadAllText(jsonFilePath));

                            Console.WriteLine("Podaj nazwe potrawy którą chcesz modyfikowac: ");
                            string updateFood = Console.ReadLine();

                            Console.WriteLine("Podaj nową temperature: ");
                            int updateTemp = int.Parse(Console.ReadLine());

                            Console.WriteLine("Podaj nowy czas: ");
                            int updateTime = int.Parse(Console.ReadLine());

                            Console.WriteLine("Wbierz jeden z poniższych programów");
                            Console.WriteLine("1. Odmrażanie");
                            Console.WriteLine("2. Duszenie");
                            Console.WriteLine("3. Gotowanie");
                            Console.WriteLine("4. Smażenie");
                            Console.WriteLine("5. Grilowanie");
                            int updateMode = int.Parse(Console.ReadLine());

                            int modifyIndex = -1;
                            for (int i = 0; i < productsModify.Length; i++)
                            {
                                if (productsModify[i].FoodName == updateFood)
                                {
                                    modifyIndex = i;
                                    break;
                                }
                            }

                            if (modifyIndex != -1)
                            {
                                productsModify[modifyIndex].Temperature = updateTemp;
                                productsModify[modifyIndex].Time = updateTime;
                                productsModify[modifyIndex].MicrowaveMode = updateMode;

                                string modifyJson = JsonConvert.SerializeObject(productsModify, Formatting.Indented);
                                File.WriteAllText(jsonFilePath, modifyJson);

                                Console.WriteLine($"Potrawa {updateFood} został zaktualizowana");
                            }

                            break;

                        case 7:
                            Product[] productsRead = JsonConvert.DeserializeObject<Product[]>(File.ReadAllText(jsonFilePath));

                            for (int i = 0; i < productsRead.Length; i++)
                            {
                                Console.WriteLine($"Nazwa potrawy: {productsRead[i].FoodName}");
                                Console.WriteLine($"Temparatura: {productsRead[i].Temperature}");
                                Console.WriteLine($"Czas: {productsRead[i].Time}");
                                Console.WriteLine($"Nr programu: {productsRead[i].MicrowaveMode}");
                                Console.WriteLine("");
                            }
                            break;

                        default:
                            {
                                Console.WriteLine(" Nie ma takiej opcji");
                            }
                            break;      
                    }
                }
            }
        }
    }
}