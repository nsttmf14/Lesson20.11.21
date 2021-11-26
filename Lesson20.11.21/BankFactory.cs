using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20._11._21
{
    class BankFactory
    {
        public static HashCatalog catalog;

        static BankFactory()
        {
            catalog = new HashCatalog();
        }
        public static int CreateAccount() //Создание пустого аккаунта
        {
            BankAccount account = new BankAccount();
            catalog.Add(account);
            Console.WriteLine("Аккаунт создан.\nВыполнен метод CreateAccount()"); //Проверки...
            return account.Index;
        }

        public static int CreateAccount(int balance) //Создание по балансу счёта
        {
            BankAccount account = new BankAccount(balance);
            catalog.Add(account);
            Console.WriteLine($"Баланс аккаунта: {balance}\nВыполнен метод CreateAccount(int balance)");
            return account.Index;
        }

        public static int CreateAccount(BankAccount.Type accountType) //Создание по типу счёта
        {
            BankAccount account = new BankAccount(accountType);
            catalog.Add(account);
            Console.WriteLine($"Тип аккаунта: {accountType}\nВыполнен метод CreateAccount(BankAccount.Type accountType)");
            return account.Index;
        }

        public static int CreateAccount(int balance, BankAccount.Type accountType) //Создание по балансу и типу счёта
        {
            BankAccount account = new BankAccount(accountType, balance);
            catalog.Add(account);
            Console.WriteLine($"1.Тип аккаунта: {accountType}\n2.Баланс аккаунта: {balance}\nВыполнен метод CreateAccount(int balance, BankAccount.Type accountType)");
            return account.Index;
        }
    }
}
