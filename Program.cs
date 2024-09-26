using System;
using System.ComponentModel.Design;
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

            Value Type: sparar sina värden direkt och det kan vara int, double, bool..
            
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
            * den här metoden manipulerar en reference type och ändringen sker i minnet
            --------------------------------------------------------------------------
           */

            Menu();
        }

        private static void Menu()
        {
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 6, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. Recursive Method"
                    + "\n6. Iterative Method"
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
                    case '5':
                        RecursiveMethod();
                        break;
                    case '6':
                        IterativeMethod();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5, 6)");
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
                string choice = Console.ReadLine(); // user input to navigate the Queue menu
                switch (choice)
                {
                    case "1":
                        Enqueue(queue); // add name to the queue. method
                        break;
                    case "2":
                        Dequeue(queue); // remove name from the queue. method
                        break;
                    case "0":
                        programStatus = false; // to exit the queue menu
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }

                Console.WriteLine("Persons in queue: "); // show the queue
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

            // it is not usual to use Stack for Queue system because stack uses first in last out methods. 
        }

        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and poping to see how it behaves
            */

            Stack<string> stack = new Stack<string>();
            bool programStatus = true;

            Console.WriteLine(
                "ICA Queue System (using stack)\n" +
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
                Console.Write("Write name to enter the queue: ");
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

            Console.WriteLine("Paranthesis Program");
            Console.WriteLine("-----------------");

            // Correct format paranthesis
            string par = "{()}[]";
            Console.WriteLine($"paranthesis: {par}");

            if (IsPair(par))
                Console.WriteLine("Correct format");
            else
                Console.WriteLine("Wrong format");

            // Wrong format paranthesis
            string par2 = "{([)}]";
            Console.WriteLine($"paranthesis: {par2}");

            if (IsPair(par2))
                Console.WriteLine("Correct format");
            else
                Console.WriteLine("Wrong format");

            Console.WriteLine("-----------------");

            static bool IsPair(string p)
            {
                Stack<char> stack = new Stack<char>();

                for (int i = 0; i < p.Length; i++)
                {
                    if (p[i] == '(' || p[i] == '{' || p[i] == '[') // check to see if the string is starting with open paranthesis and pushes it to the stack
                    {
                        stack.Push(p[i]);
                    }
                    else
                    {
                        if (stack.Count > 0 && // to check if the stack is not empty
                            (
                            (stack.Peek() == '(' && p[i] == ')') || // Peek() is used to look for the next item in the stack.
                            (stack.Peek() == '{' && p[i] == '}') ||
                            (stack.Peek() == '[' && p[i] == ']') ))
                        {
                            stack.Pop();
                        }
                        else
                        {
                            return false;  // returns false if the paranthesis is in wrong format
                        }
                    }
                }
                return stack.Count == 0;
            }
        }

        static void RecursiveMethod()
        {
            Console.WriteLine("Recursiv Program");
            Console.WriteLine("-----------------");

            Console.WriteLine(
                "Recursive Odd: \n" +
                RecursiveOdd(1) + "\n" +
                RecursiveOdd(3) + "\n" +
                RecursiveOdd(5)
                );
            //Console.WriteLine(RecursiveOdd(1));
            //Console.WriteLine(RecursiveOdd(3));
            //Console.WriteLine(RecursiveOdd(5));

            Console.WriteLine(
                "Recursive Even: \n" +
                RecursiveEven(0) + "\n" +
                RecursiveEven(1) + "\n" +
                RecursiveEven(6)
                );
            //Console.WriteLine(RecursiveEven(0));
            //Console.WriteLine(RecursiveEven(1));
            //Console.WriteLine(RecursiveEven(6));

            Console.WriteLine("Recursiv Fibonacci: ");
            Console.WriteLine(RecursivFibonacci(5));
            Console.WriteLine(RecursivFibonacci(7));
            Console.WriteLine(RecursivFibonacci(8));

            Console.WriteLine("-------------------");

            static int RecursivFibonacci(int n) // this method calculates the n Fibonacci number recursively.
            {
                if (n <= 1)
                    return n;
                else
                    return RecursivFibonacci(n - 1) + RecursivFibonacci(n - 2);
            }

            static int RecursiveOdd(int n) // this method calculates the sum of the odd number up to n. ex/ n = 5 -> 1+3+5 = 9
            {
                if (n == 1)
                    return 1;
                else
                    return RecursiveOdd(n - 2) + n;
            }

            static int RecursiveEven(int n)// this method calculates the sum of the even number up to n. ex/ n = 6 -> 2+4+6 = 12
            {
                if (n == 0)
                    return 0;
                else
                    return RecursiveEven(n - 1) + 2;
            }
        }

        private static void IterativeMethod()
        {
            Console.WriteLine("Iterative Program");
            Console.WriteLine("-----------------");

            Console.WriteLine(
                "Iterative Odd: \n" +
                IterativeOdd(1) + "\n" +
                IterativeOdd(3) + "\n" +
                IterativeOdd(5));

            Console.WriteLine(
                "Iterative Odd: \n" +
                IterativeEven(0) + "\n" +
                IterativeEven(1) + "\n" +
                IterativeEven(6));

            Console.WriteLine("Iterative Fibonacci: ");
            Console.WriteLine(IterativeFibonacci(5));
            Console.WriteLine(IterativeFibonacci(7));
            Console.WriteLine(IterativeFibonacci(8));

            Console.WriteLine("-------------------");

            static int IterativeFibonacci(int n) // this method calculates the n Fibonacci series Iterativly.
            {
                if (n == 0) return 0;
                if (n == 1) return 1;

                int x = 0;
                int y = 1;
                int temp = 0;

                for (int i = 2; i <= n; i++)
                {
                    temp = x + y;
                    x = y;
                    y = temp;
                }
                return temp;
            }

            static int IterativeOdd(int n) // this method calculates the odd number by multiplying the n with 2 and decrease it by 1.
            {
                return 2 * n - 1;
            }

            static int IterativeEven(int n)// this method calculates the even number by multiplying the n with 2
            {
                return 2 * n;
            }
        }
    }
}
