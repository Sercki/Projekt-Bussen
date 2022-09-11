using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussen 
{
    class Passenger
    {
        private string sex;
        private int age;
        private string status;
        private int smallKid = 5;
        private int kid = 20;
        private int youngAdult = 40;                                            //Skapade max värde till olika steg i livet. Man behöver dessa variabler i 'Reaction' metod. Sista steg - "late adulthood" var inte skapats eftersom man behöver inte det. 
        private int middleAdult = 60;                                           //Man kan skriva bara "else" efter andra if och if else statements.        

        public Passenger(string _sex, int _age, string _status)                 //konstruktor till Klass Passagerare 
        {
            this.Sex = _sex;                                                                       
            this.Age = _age;
            this.Status = _status;
        }

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public int Age                                                          //eftersom sex,age,status är privata variabler, jag använde "get, set' metod för att få tillstand till dessa variabler
        {
            get { return age; }
            set { age = value; }
        }
        public string Status                                                    //obs! Jag skapade inga metoder för att skriva ut eller göra något med passagerarnas "status". Det blir nästan samma metod som t.ex. skriv ut åldern, sök åldern eller skriv ut hela bussen.
        {
            get { return status; }
            set { status = value; }
        }

        public void Reaction()                                                  //metod som är kopplad till 'poke' metoden. Efter anrop man ser reaktion av en passagerare som beror på kön och åldern
        {
            if (age < smallKid)
            {
                if (Sex == "Male")
                {
                    Console.WriteLine("Mommy?");                                //text som dyker upp när passagerare är under 5 år och  är kille (kön:man)
                }
                else
                {
                    Console.WriteLine("Daddy?");                                //text som dyker upp när passagerare är under 5 år och  är tjej (kön:kvinna)
                }
            }
            else if (age < kid)
            {
                if (Sex == "Male")
                {
                    Console.WriteLine("Hi! Would you like to see my pokemon cards collection?");
                }
                else
                {
                    Console.WriteLine("Hi! In future I would like to be like Marie Sklodowska Curie!");
                }
            }
            else if (age < youngAdult)
            {
                if (Sex == "Male")
                {
                    Console.WriteLine("I'm not going to show you a bus ticket.");
                }
                else
                {
                    Console.WriteLine("Sorry! I have a boyfriend!");
                }
            }
            else if (age < middleAdult)
            {
                if (Sex == "Male")
                {
                    Console.WriteLine("When I was younger, the life was better.");
                }
                else
                {
                    Console.WriteLine("Should I buy red or blue handbag?");
                }
            }
            else                                                                            //här är sista steg i livet - late adulthood som man behöver inte skriva här. Annars skulle jag skriva else if (age < lateAdult) med deklarering av variabeln lateAdult
            {
                if (Sex == "Male")
                {
                    Console.WriteLine("Stop poking me, I want to sleep...");
                }
                else
                {
                    Console.WriteLine("Welcome! You look like one of my kids!");
                }
            }
        }

    }

    class Buss
    {
        public Passenger[] bus = new Passenger[25];
        public Passenger[] occupied = new Passenger[0];
        public Passenger[] newpassenger = new Passenger[0];

        public void Run()                                                                   //här finns huvudmenu
        {
            while (true)
            {
                try                                                                         //Jag skapade här ett "try-catch" block eftersom utan blocket program crashar när man trycker t.ex. enter, mellanslag.
                {
                    int menu = 0;
                    do
                    {
                        Console.WriteLine("Welcome to the awesome Bus-simulator!");
                        Console.WriteLine("Please choose an option:");
                        Console.WriteLine(" 1. Add passenger.");
                        Console.WriteLine(" 2. Show info about all passengers in the buss.");
                        Console.WriteLine(" 3. Calculate total age of all passengers.");
                        Console.WriteLine(" 4. Calculate average age of all passengers.");
                        Console.WriteLine(" 5. Show age of the oldest passenger.");
                        Console.WriteLine(" 6. Find passengers with specific age.");
                        Console.WriteLine(" 7. Show which seats are occupied by male and female passengers.");
                        Console.WriteLine(" 8. Sort all passengers by age (from lowest age to highest).");
                        Console.WriteLine(" 9. Remove a passenger from the buss.");
                        Console.WriteLine("10. Poke a passenger.");
                        Console.WriteLine(" 0. Exit program.");
                        menu = int.Parse(Console.ReadLine());
                        switch (menu)                                                       //switch case för att välja olika alternativ i programmet
                        {
                            case 1:
                                Add_passenger();
                                break;

                            case 2:
                                PrintPassengers();
                                break;

                            case 3:
                                Calc_total_age();
                                break;

                            case 4:
                                Calc_average_age();
                                break;

                            case 5:
                                Max_age();
                                break;

                            case 6:
                                Find_age();
                                break;

                            case 7:
                                Print_sex();
                                break;

                            case 8:
                                Sort_buss();
                                break;

                            case 9:
                                Getting_off();
                                break;

                            case 10:
                                Poke();
                                break;


                            case 0:
                                Console.WriteLine("Shutting down...");
                                break;

                            default:
                                Console.WriteLine("Wrong choice. Please press numbers 1 - 10. Try again!");
                                break;
                        }
                    } while (menu != 0);
                    break;
                }
                catch
                {
                    Console.Clear();                                                   //Städar konsolen för att göra programmen snyggare
                    Console.WriteLine("Wrong key. Try pressing numbers. Try again!\n");
                }
            }
        }
        //Metoder för betyget E

        public void Add_passenger()                                                     //Lägg till passagerare. Här skriver man då in ålder men eventuell annan information.
        {                                                                               //Om bussen är full kan inte någon passagerare stiga på
            Passenger[] freeSeats = new Passenger[bus.Length - occupied.Length];
            while (true)                                                                //allt i while loopen eftersom om bussen är full, metoden ska komma tillbaka till huvudmenu 
            {
                Console.Clear();
                string sex;
                int age;
                string status;
                if (freeSeats.Length > 1)                                               //if else för att kolla om det finns lediga platser i bussen
                {
                    Console.WriteLine($"There are {freeSeats.Length} free seats left.");
                }
                else if (freeSeats.Length == 1)
                {
                    Console.WriteLine($"There is {freeSeats.Length} free seat left.");
                }
                else if (freeSeats.Length == 0)
                {
                    Console.WriteLine($"Bus is full, sorry");
                    break;
                }
                Console.WriteLine("How much passengers will you add?");
                int number;
                while (true)
                {
                    try                                                                 // try catch metoden eftersom jag litar inte på användaren. I detta fall undviker man felet om användaren skriver en bokstav, trycker på mellanslag eller enter
                    {
                        while (true)
                        {
                            string str = Console.ReadLine();
                            number = Convert.ToInt32(str);
                            newpassenger = new Passenger[number];                                                     //användaren skriver här hur många passagerarna ska komma i bussen
                            if (occupied.Length + newpassenger.Length > bus.Length)
                            {
                                Console.WriteLine("You are trying to add more passengers than number of free seats. Please add less passengers.");
                            }
                            else if (newpassenger.Length == 0)
                            {
                                Console.WriteLine($"You added {newpassenger.Length} passengers!");                  //här känns lite förvirring men texten visar bara att man har lagt till 0 passagerare. Jag kunde skriva siffra 0 istället för vektor.lenght, men 
                                break;                                                                              //det var också test för mig för att visa om min programm skapade rätt storlek på en vektor
                            }
                            else
                            {
                                break;                                                                                //skriv ut ingenting om anvndaren skrev rätt siffra, avsluta while loop
                            }
                        }
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Please write whole numbers only. Thank you!");
                    }
                }
                for (int i = 0; i < newpassenger.Length; i++)
                {
                    Console.Clear();
                    Console.WriteLine("Because of the GDPR we won't ask you to give us names of the passengers. It is fully anonymous questionnaire! We just need sex, age and the passengers status.");
                    Console.WriteLine("\nPlease write sex of the passenger. Press M for Male or F for Female:");

                    while (true)
                    {
                        ConsoleKeyInfo userInput = Console.ReadKey(true);                               //jag bestämde att ge till användaren bara två väl istället för att skriva hela male eller female. Annars användaren kan göra massor misstag. 
                        sex = userInput.Key.ToString();
                        if (sex == "F" || sex == "M")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("try again");
                        }

                    }
                    if (sex == "F")
                    {
                        Console.WriteLine("\nFemale");                                              //skriv ut rätt kön för att användaren ska se vad han/hon välde
                        sex = "Female";

                    }
                    else
                    {
                        Console.WriteLine("\nMale");
                        sex = "Male";
                    }

                    Console.WriteLine("\nPlease write age of the passenger:");
                    while (true)
                    {
                        try                                                 // try catch metoden eftersom jag litar inte på användaren. I detta fall undviker man felet om användaren skriver en bokstav, trycker på mellanslag eller enter
                        {
                            while (true)
                            {
                                Console.WriteLine("");
                                string nr = Console.ReadLine();                                                                                         //här skriver användaren åldern av en passagerare
                                age = Convert.ToInt32(nr);
                                if (age == 0)
                                {
                                    Console.WriteLine("Newborn on a bus? Tell its parents that we give to the newborn free buscard forever!");
                                    break;
                                }
                                else if (age < 0)
                                {
                                    Console.WriteLine("It is not possible that an age is minus value. Try again!");
                                }
                                else if (age > 123)
                                {
                                    Console.WriteLine("It is not possible that any human is more than 123 years old. Try again");                    
                                }
                                else
                                {
                                    break;
                                }
                            }
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Please write whole numbers only");
                        }
                    }
                    Console.WriteLine("\nPlease choose one of the following status that is appropriate to the passenger: \n\nS for student, \nW for active worker, \nU for unemployed/retired person");

                    while (true)                                                                //jag bestämde att ge till användaren bara tre väl istället för att skriva själv passagerarnas status. Annars användaren kan göra massor misstag.
                    {
                        ConsoleKeyInfo userInput = Console.ReadKey(true);
                        status = userInput.Key.ToString();
                        if (status == "S" || status == "W" || status == "U")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("try again");
                        }
                    }
                    if (status == "S")
                    {
                        Console.WriteLine("\nStudent");
                        status = "Student";
                    }
                    else if (status == "W")                                 //extra info om en passagerare. Finns inga metod för att skriva ut eller sortera status, eftersom det skulle se nästan samma ut som metoder som gör något med åldern eller kön
                    {
                        Console.WriteLine("\nActive worker");
                        status = "Worker";
                    }
                    else if (status == "U")
                    {
                        Console.WriteLine("\nUnemployed");
                        status = "Unemployed";
                    }
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey(true);
                    newpassenger[i] = new Passenger(sex, age, status);                              //här alla information om passagerare blir kopplad till våra objekt
                    Console.Clear();
                }

                Passenger[] temporary = new Passenger[occupied.Length + newpassenger.Length];                                       //ny vektor temp för att skapa storer vektorn 
                Array.Copy(occupied, temporary, occupied.Length);                                                                   //array copy för att kopiera innehåll av en vektor till den andra
                Array.Copy(newpassenger, 0, temporary, occupied.Length, newpassenger.Length);                                       //Array.copy består av: Array.Copy(ursprungs vektor, start index i ursprungs vektorn, 
                occupied = new Passenger[temporary.Length];                                                                         // destination vektor, start index i destination array, hur många element ska kopieras)
                for (int i = 0; i < occupied.Length; i++)
                {
                    occupied[i] = temporary[i];                                                                                     //här finns storer vektorn som innehåller info om gamla passagerarna och de nya
                }
                break;
            }
            freeSeats = new Passenger[bus.Length - occupied.Length];                                                                //vektorn freeSeats visar hur många platser finns kvar i bussen 
            Console.WriteLine($"Available seats left: {freeSeats.Length}");
            Buss.MethodEnd();                                                                                                       //liten metod med text eftersom alla metoder slutar på samma sätt - från "press any key to continue" till Console.Clear ()
        }

        private void PrintPassengers()                                                                                              //skriv ut alla passagerarna
        {
            int nr = 0;
            Console.Clear();
            if (occupied.Length == 0)
            {
                Console.WriteLine("Bus is empty. Waiting for new passengers...");
            }
            else
            {
                Console.WriteLine("Passengers onboard:");
            }
            foreach (Passenger person in occupied)
            {
                nr++;
                Console.WriteLine($"Seatnr {nr}:{person.Sex}, {person.Age}, {person.Status}");                                      //tack för "get,set" metoden, programmet har tillstånd till privata variabler i klassen passenger
            }
            Buss.MethodEnd();
        }

        public void Calc_total_age()                                    //Beräkna den totala åldern. 
        {
            Console.Clear();
            int age = 0;
            foreach (Passenger person in occupied)
            {
                age += person.Age;                                      //loopa igenom alla passagerarna och summera alla åldrar
            }
            if (occupied.Length == 0)
            {
                Console.WriteLine($"No passengers in the bus yet. Please add passengers!");
            }
            else
            {
                Console.WriteLine($"Sum of all passengers age is {age} years.");
            }
            Buss.MethodEnd();
        }

        public void Calc_average_age()
        {                                                                                    //Beräkna den genomsnittliga åldern. 
            Console.Clear();
            float age = 0;
            float average;                                                                   //float for att medelldern ska visa decimaler om resultatet blir inte heltal
            foreach (Passenger person in occupied)
            {
                age += person.Age;                                                          //samma del av instruktion som i Calc_total_age() för att summera åldern
            }
            if (occupied.Length == 0)
            {
                Console.WriteLine($"No passengers in the bus yet. Please add passengers!");
            }
            else
            {
                average = age / occupied.Length;                                            //beräkna medelåldern genom att dela summa av alla åldrar med antal av passagerarna
                Console.WriteLine($"Average age of all passengers is {average} years.");
            }
            Buss.MethodEnd();
        }

        public void Max_age()
        {                                                                               //ta fram en passagerare med högst ålder.                                                                            
            Console.Clear();
            int max = 0;
            foreach (Passenger person in occupied)
            {
                if (person.Age > max)
                {
                    max = person.Age;                                                   //loopa igenom alla passagerarna och spara högst åldern 
                }
            }
            if (occupied.Length == 0)
            {
                Console.WriteLine($"No passengers in the bus yet. Please add passengers!");
            }
            else
            {
                int nr = 0;
                int seat = 0;
                foreach (Passenger person in occupied)
                {
                    if (person.Age == max)
                    {
                        nr++;
                    }
                }
                if (nr == 1)
                {
                    Console.WriteLine($"The oldest passenger on the bus is:");           //jag skapade en instruktion som visar olika text beroende av antalet av gamla passagerare
                }
                else
                {
                    Console.WriteLine($"The oldest passengers on the bus are:");
                }
                foreach (Passenger person in occupied)
                {

                    seat++;
                    if (person.Age == max)
                    {
                        if (person.Sex == "Male")
                        {
                            Console.WriteLine($"Seatnr {seat}: {person.Sex}, {max} years old, he is {person.Status}");                  //olika form av text beroende av kön
                        }
                        else
                        {
                            Console.WriteLine($"Seatnr {seat}: {person.Sex}, {max} years old, she is {person.Status}");
                        }
                    }
                }

            }
            Buss.MethodEnd();
        }

        public void Find_age()                                                                          //Visa alla positioner med passagerare med en viss ålder
        {                                                                                               //Man kan söka efter åldersgränser - exempelvis 55 till 67
            Console.Clear();
            if (occupied.Length == 0)
            {
                Console.WriteLine($"No passengers in the bus yet. Please add passengers!");
            }
            else
            {
                int nr = 0;
                int min;
                int max;
                bool check = true;
                Console.WriteLine("Please select minimal and maximal age to limit search of passengers");
                while (true)
                {
                    try                                                                                 // try catch metoden eftersom jag litar inte på användaren. I detta fall undviker man felet om användaren skriver en bokstav, trycker på mellanslag eller enter
                    {
                        Console.WriteLine("Please write the lowest age you want to be searched:");
                        string low = Console.ReadLine();
                        min = Convert.ToInt32(low);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Please write only whole numbers! Thank you.");
                    }
                }
                Console.Clear();
                Console.WriteLine("Please write the highest age you want to be searched:");
                while (true)
                {
                    try                                                                                 // try catch metoden eftersom jag litar inte på användaren. I detta fall undviker man felet om användaren skriver en bokstav, trycker på mellanslag eller enter
                    {
                        while (true)
                        {
                            string high = Console.ReadLine();
                            max = Convert.ToInt32(high);
                            if (min > max)
                            {
                                Console.WriteLine("Sorry, highest age cannot be smaller than lowest age. Try again and write highest age you want to be searched!");
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Please write only whole numbers! Thank you.");
                    }
                }
                Console.Clear();
                Console.WriteLine($"You choose to show passengers between ages: {min} to {max}");
                foreach (Passenger person in occupied)
                {
                    nr++;
                    if (person.Age >= min && person.Age <= max)
                    {
                        Console.WriteLine($"Seatnr {nr}:{person.Sex}, {person.Age}, {person.Status}");      //hår programmet skriver ut en eller fler passagerare med viss åldern
                        check = false;
                    }

                }
                if (check == true)
                {
                    Console.WriteLine("Sorry! There are no passengers that fit your age limits");           //om anvåndaren lyckas inte att hitta passagerare med viss åldern
                }
            }
            Buss.MethodEnd();
        }

        public void Sort_buss()                                         //Sortera bussen efter ålder från lägst till högst.
        {
            Console.Clear();
            if (occupied.Length == 0)
            {
                Console.WriteLine($"No passengers in the bus yet. Please add passengers!");
            }
            else
            {
                bool unsorted = true;                                           //här skapade jag en bubble sort sökalgoritm
                for (int i = 0; i < occupied.Length - 1 && unsorted; i++)
                {
                    unsorted = false;
                    for (int j = 0; j < occupied.Length - 1 - i; j++)
                    {
                        if (occupied[j].Age > occupied[j + 1].Age)
                        {
                            unsorted = true;
                            Passenger temp = occupied[j + 1];
                            occupied[j + 1] = occupied[j];
                            occupied[j] = temp;
                        }
                    }
                }
            }
            Console.WriteLine("Done.\n");
            Buss.MethodEnd();
        }

        public void Print_sex()                                                                        
        {                                                                                               //jag bestämde att göra så här metoden, eftersom jag vill inte kopiera Print passengers metoden som också visar kön och position av passagerarna. Den här metoden
            Console.Clear();                                                                            // visar hur många maliga och kvinliga passagerarna finns i bussen och på vilka positioner 
            int seat = 0;
            int man = 0;
            int woman = 0;
            if (occupied.Length == 0)
            {
                Console.WriteLine($"No passengers in the bus yet. Please add passengers!");
            }
            else
            {
                foreach (Passenger person in occupied)
                {
                    if (person.Sex == "Male")
                    {
                        man++;                                                                          //instruktion för att beräkna hur många manliga och kvinliga passagerarna finns i bussen
                    }
                    else
                    {
                        woman++;
                    }
                }
                Console.Write($"There are {man} male passengers occupying seats:");
                foreach (Passenger person in occupied)
                {
                    seat++;
                    if (person.Sex == "Male")                                                           //instruktion för att visa positioner på manliga passagerarna
                    {
                        Console.Write($" {seat},");
                    }
                }
                Console.Write($" and {woman} female passengers occupying seats:");
                seat = 0;
                foreach (Passenger person in occupied)
                {
                    seat++;
                    if (person.Sex == "Female")                                                         //instruktion för att visa positioner på kvinliga passagerarna
                    {
                        Console.Write($" {seat},");
                    }
                }
            }
            Console.WriteLine(" ");
            Buss.MethodEnd();
        }

        public void Poke()                                                                  //Vilken passagerare ska vi peta på?
        {                                                                                   //Denna metod ska anropa en passagerares metod för hur de reagerar om man petar på dom -
            Console.Clear();                                                                //detta beteende baserar på ålder och kön.
            if (occupied.Length == 0)
            {
                Console.WriteLine($"No passengers in the bus yet. Please add passengers!");
            }
            else
            {
                Console.WriteLine("Which passenger would you like to poke?");
                int position;
                while (true)
                {
                    try                                                                         // try catch metoden eftersom jag litar inte på användaren. I detta fall undviker man felet om användaren skriver en bokstav, trycker på mellanslag eller enter
                    {
                        while (true)
                        {
                            string str = Console.ReadLine();
                            position = Convert.ToInt32(str);

                            if (position > bus.Length)
                            {
                                Console.WriteLine("There is no such seat number in the bus. Try lower number");
                            }
                            else if (position > occupied.Length && position <= bus.Length)
                            {
                                Console.WriteLine("There is no passenger seated at this seat. Try lower number.");
                            }
                            else if (position < 1)
                            {
                                Console.WriteLine("There is no such seat number in the bus. Try higher number");
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Write whole numbers only");
                    }
                }
                Console.WriteLine($"You chose to poke a {occupied[position - 1].Sex},{occupied[position - 1].Age} years old who is {occupied[position - 1].Status}. Person says to you: ");     //Jag skrev position -1 eftersom användaren vet inte att vektorn börjar med 0 och inte 1. Användaren tycker att man ska skriva siffror från 1-25
                occupied[position - 1].Reaction();                                                                                                                                              //anrop av metoden i klassen passenger som visar beteende av passagerare som beror på av kön och åldern
            }
            Buss.MethodEnd();
        }

        public void Getting_off()                                                                               //En passagerare kan stiga av i denna metod
        {
            Console.Clear();
            if (occupied.Length == 0)
            {
                Console.WriteLine($"No passengers in the bus yet. Please add passengers!");
            }
            else
            {
                int index;
                Console.WriteLine("Please select which passenger got off the bus ");
                while (true)
                {
                    try                                                                                         // try catch metoden eftersom jag litar inte på användaren. I detta fall undviker man felet om användaren skriver en bokstav, trycker på mellanslag eller enter
                    {
                        while (true)
                        {
                            string str = Console.ReadLine();
                            index = Convert.ToInt32(str);
                            if (index > bus.Length)
                            {
                                Console.WriteLine("There is no such seat number in the bus. Try lower number");
                            }
                            else if (index > occupied.Length && index <= bus.Length)
                            {                                                                                               //samma instruktioner som i poke metoden för att välja rätt passagerare
                                Console.WriteLine("There is no passenger seated at this seat. Try lower number.");
                            }
                            else if (index < 1)
                            {
                                Console.WriteLine("There is no such seat number in the bus. Try higher number");
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Write whole numbers only");
                    }
                }
                for (int i = index - 1; i < occupied.Length - 1; i++)
                {
                    occupied[i] = occupied[i + 1];                                                  // Jag bestämde att jag skriver över indexer med värde från nästa indexer. Start index i instruktionen är våra passagerare som ska stiga av, t.ex
                }                                                                                   // om vi väljer den tredje passagerare, nästa index (4) byter till index 3, 5 index blir nu index 4 etc...  
                Array.Resize(ref occupied, occupied.Length - 1);                                    //här Array.resize minskar våra ursprungliga vektorn med 1. I detta fall vektor innehåller inte tomma platser
                
            }
            Console.WriteLine("Done.\n");
            Buss.MethodEnd();
        }

        static void MethodEnd()   //liten metod med text eftersom  alla metoder slutar på samma sätt - från "press any key to continue" till Console.Clear ()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();                    //städar console
        }

        class Program
        {
            public static void Main(string[] args)
            {
                //Skapar ett objekt av klassen Buss som heter minbuss                
                var minbuss = new Buss();
                minbuss.Run();
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }
        }
    }
}
