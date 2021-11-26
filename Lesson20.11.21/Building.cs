using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20._11._21
{
    class Building : Creation
    {
		private double height;
		private int floors;
		private int apartments;
		private int entrances;

		static byte indexer = 0;

		public Building()
		{
			index = indexer++;
		}

		public Building(double height, int floors, int apartments, int entrances) //Создание здания
		{
			index = indexer++;
			this.height = height;
			Console.WriteLine($"Высота здания: {this.height}");
			this.floors = floors;
			Console.WriteLine($"Количество этажей: {this.floors}");
			this.apartments = apartments;
			Console.WriteLine($"Количество квартир: {this.apartments}");
			this.entrances = entrances;
			Console.WriteLine($"Количество подъездов: {this.entrances}");
		}
	}
}
