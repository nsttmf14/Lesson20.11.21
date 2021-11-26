using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20._11._21
{
    class BankAccount : Creation
    {
		public enum Type
		{
			Current,
			Saving
		}

		private Type accountType;
		private int balance;

		static byte indexer = 0;

		internal BankAccount()
		{
			index = indexer++;
		}

		internal BankAccount(int balance)
		{
			index = indexer++;
			this.balance = balance;
		}

		internal BankAccount(Type accountType)
		{
			index = indexer++;
			this.accountType = accountType;
		}

		internal BankAccount(Type accountType, int balance) : this(accountType)
		{
			this.balance = balance;
		}
	}
}
