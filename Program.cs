using System;
using System.Drawing;

namespace DataStructure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            F.1. Hur fungerar stacken och heapen?
            
             - Stack (LIFO): stacken hanterar methoder och local variables.
                      när en method anropas läggs den på toppen av stacken och när methoden är klar tas den bort.
            ex.
            + lägga till stack:
            method 1
            method 2
            method 3
            ...
            + ta bort från stack:
            method 3
            method 2
            method 1
            ...
           * lägga till och ta bort från stack ska vara i ordning, och det rensas automatiskt när metoder avslutas.            
            
           ------------

           - Heap:  heapen sparar data som inte har en bestämd livscykel.
                    minnet frigörs av Garbage Collector när objekten inte längre används.
           obj 1
           obj 2
           obj 3
           heap [obj 1, obj 2, obj 3]
           alla obj är tillgängliga när det behövs.
           * när method inte används då har vi kvar objekterna till de tas bort av GC.
            
           ---------------------------------------------------------------------------
            F.2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?

            Value  Type: sparar sina värden direkt och det kan vara int, double, bool..
            
            Reference Type: sparar en plats(reference) i minnet för objekt, class eller string.(de sparar en plats i minnet inte själva värdet)
            ---------------------------------------------------------------------------
            F.3. Följande metoder genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?
           
            public int ReturnValue()
            {
                int x = new int();
                x = 3;
                int y =  new int();
                y = x;
                y = 4;
                return x;
            }
            * den här metoden manipulerar en value type och ändringen sker i metoden.

            public int ReturnValue2()
            {
                MyInt x = new MyInt();
                x.MyValue = 3;
                MyInt y = new MyInt();
                y = x;
                y.MyValue = 4;
                return x.MyValue;
            }
            *den här metoden manipulerar en reference type och ändringen sker i minnet
            --------------------------------------------------------------------------
           */

            Menu();

        }

        private static void Menu()
        {
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                Console.WriteLine("---------------------");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                Console.Write("Input: ");
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                Console.WriteLine("---------------------");

                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        static void ExamineList()
        {
            /*
            * Loop this method untill the user inputs something to exit to main menue.
            * Create a switch statement with cases '+' and '-'
            * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
            * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
            * In both cases, look at the count and capacity of the list
            * As a default case, tell them to use only + or -
            * Below you can see some inspirational code to begin working.
           */

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("To Add name to the list write + infront of the name");
            Console.WriteLine("To remove name from the list write - infront of the name");
            Console.WriteLine("To exit the program enter e");
            Console.WriteLine("--------------------------------------------------------");


            List<string> theList = new List<string>(); // create a list to hold the names
            bool programStatus = true;
            

            do
            {
                Console.Write("Input: ");
                string input = Console.ReadLine(); // user inputs the names

                char nav = input[0]; // read the first symbol of the input.
                string value = input.Substring(1); // read the rest of the input starting from the second index.

                switch (nav) // navigating based on the + and -
                {
                    case '+':
                        theList.Add(value); // adding the name to the list
                        break;

                    case '-':
                        theList.Remove(value); // removing the name from the list
                        break;

                    case 'e':
                        programStatus = false; // to exit the program
                        break;

                    default: // display wrong input message
                        Console.WriteLine("Wrong input");
                        break;
                }
                Console.WriteLine($"Item Count in the list: {theList.Count}");
                Console.WriteLine($"Capacity of the list: {theList.Capacity}");

                foreach (string names in theList) // use for-each loop to display the names in the list
                {
                    Console.WriteLine(names);
                }
                Console.WriteLine("---------------------");

            } while (programStatus);

            /*
             F.1. När ökar listans kapacitet?
             S.1. listans kapacitet öker automatiskt när användaren lägger till namn i listan.
             -
             F.2. Med hur mycket ökar kapaciteten?
             S.2. i början så är listans kapacitet null, när användaren har läggt till ett namn då blir kapaciteten 4,
                  när listan får 4 namn då öker kapaciteten till 8, -> 8 namn : kapaciteten 16.(listans kapacitet fördubblas)
             -
             F.3.  Varför ökar inte listans kapacitet i samma takt som element läggs till?
             S.3. om kapaciteten ökar med antalet element på listan, kommer programmet inte att vara snabbt och effektivt.
             - 
             F.4. Minskar kapaciteten när element tas bort ur listan?
             S.4. nej, kapaciteten minskar inte automatiskt. men om du börjar om programet då börjar kapaciteten från 4.
             -
             F.5. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
             S.5. om man vet exakt hur många element man behöver du är det bättre att använda egendefinierad array.
             */
        }

        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Queue<string> queue = new Queue<string>();
            bool programStatus = true;

            Console.WriteLine(
                "ICA Queue System\n" +
                "1. Enter the queue\n" +
                "2. Exit the queue\n" +
                "0. Exit the program");
               
            Console.WriteLine("-------------------");
            
            do
            {
                Console.Write("Input: "); 
                string choice = Console.ReadLine(); // user input to navigate the Queue system
                switch (choice)
                {
                    case "1":
                        Enqueue(queue); // add name to the queue
                        break;

                    case "2":
                        Dequeue(queue); // remove name from the queue
                        break;

                    case "0":
                        programStatus = false; // to exit the program
                        break;

                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }

                Console.WriteLine("Persons in queue: "); // show the persons that are in the queue
                foreach (string person in queue)
                {
                    Console.WriteLine(person);
                }

                Console.WriteLine("-------------------");

            }
            while (programStatus);

            static void Enqueue(Queue<string> queue) // adding to queue method
            {               
                Console.Write("Write name to enter the queue: ");
                string name = Console.ReadLine();
                queue.Enqueue(name);
            }

            static void Dequeue(Queue<string> queue) // removing name from the queue method
            {               
                queue.Dequeue();
            }
        }

        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */            
               
                Stack<string> stack = new Stack<string>();
                bool programStatus = true;

                Console.WriteLine(
                    "ICA Stack System\n" +
                    "1. Enter the queue\n" +
                    "2. Exit the queue\n" +
                    "0. Exit the program");

                Console.WriteLine("-------------------");

                do
                {
                    Console.Write("Input: "); 
                    string choice = Console.ReadLine(); // user input to navigating the stack menu
                    switch (choice)
                    {
                        case "1":
                            PushName(stack); // adding name to the stack. method
                            break;

                        case "2":
                            PopName(stack); // removing name from the stack. method
                            break;

                        case "0":
                            programStatus = false; // exiting the stack menu
                            break;

                        default:
                            Console.WriteLine("Wrong input!");
                            break;
                    }

                    Console.WriteLine("Persons in stack: "); // display the stack
                    foreach (string person in stack)
                    {
                        Console.WriteLine(person);
                    }

                    Console.WriteLine("-------------------");

                }
                while (programStatus);

                static void PushName(Stack<string> stack) // adding name to the stack
                {
                    Console.Write("Write name to enter the stack: ");
                    string name = Console.ReadLine();
                     stack.Push(name);
                }

                static void PopName(Stack<string> stack) // removing name from the stack
                {
                    stack.Pop();    
                }
            }


        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
        }
    }
}
