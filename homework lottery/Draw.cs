using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_lottery
{
    internal class Draw
    {
        public string Name;
        public int Tickets;
        public Stack<int> Winners;

        public Draw(string name, int tickets, Stack<int> winner)
        {
            Name = name;
            Tickets = tickets;
            Winners = winner;
        }
        public override string ToString()
        {
            string sout = "";
            foreach (int index in Winners)
            {
                sout += Program.data[index] + "\n";
            }
            return $"Описание: {Name}, количествр разыгранных билетов: {Tickets}\n{Console.ForegroundColor = ConsoleColor.Yellow}Победители:\n{sout}";
        }
    }
}
