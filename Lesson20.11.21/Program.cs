using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20._11._21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tasks 11.1 - 11.2");
            BankFactory.CreateAccount(BankAccount.Type.Saving);

            Console.WriteLine("\nHomework 11.1 - 11.2");
            Creator.CreateAccount(1, 1, 1, 1);
            Creator.DeleteAccount(BankFactory.CreateAccount(322));

            Console.ReadLine();
        }
    }
}
