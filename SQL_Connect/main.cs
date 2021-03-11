using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQL_Connect
{
    class main_class
    {
        public static void Main(String[] args)
        {
            // Simple applications that interact with C# and MySQL
            Console.WriteLine("Hello World!");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("1. INSERT");
            Console.WriteLine("This is member table");

            mysql userDB = new mysql(); // Create MySQL DB Generators
            Console.Write("Your name : "); // Input Data
            string name = Console.ReadLine();
            Console.Write("Your age : ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Your address : ");
            string address = Console.ReadLine();

            // Run SQL
            Boolean check = userDB.Sql("Insert into member(name, age, address) Values('" + name + "'," + age + ",'" + address + "')");

            if (check) // If check value is true
                Console.WriteLine("Success");
            else
                Console.WriteLine("Fail");


            Console.WriteLine("------------------------------------");
            Console.WriteLine("2. UPDATE");
            Console.WriteLine("This is member table");

            Console.Write("Change name : ");
            name = Console.ReadLine();
            Console.Write("New name : ");
            string new_name = Console.ReadLine();

            // Run SQL
            check = userDB.Sql("Update member Set name = '" + new_name + "' Where name = '" + name + "'");

            if (check) // If check value is true
                Console.WriteLine("Success");
            else
                Console.WriteLine("Fail");


            Console.WriteLine("------------------------------------");
            Console.WriteLine("3. SELECT (Single Value)");
            Console.WriteLine("This is member table");

            Console.Write("Your name : "); // If check value is true
            name = Console.ReadLine();

            // Run SQL
            string result = userDB.Select_Sql("Select address From member Where name = '" + name + "'");

            if (result != null) // If result value is not null
                Console.WriteLine("Your Address are " + result);
            else
                Console.WriteLine("Fail");


            Console.WriteLine("------------------------------------");
            Console.WriteLine("4. SELECT (Multi Values)");
            Console.WriteLine("This is member table");

            Console.Write("Your name : "); // If check value is true
            name = Console.ReadLine();

            string[] result2 = new string[2];
            string[] parameter = new string[2] { "address", "age" };

            // Run SQL
            result2 = userDB.Select_Sql("Select address, age From member Where name = '" + name + "'", parameter);

            if (result2[0] != null) // If result2[0] value is not null
            {
                for (int i = 0; i < result2.Length; i++)
                    Console.WriteLine(result2[i]);
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }
    }
}
