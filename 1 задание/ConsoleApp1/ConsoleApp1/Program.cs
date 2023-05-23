using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			if (File.Exists("formula.txt"))
			{
				if (new FileInfo("formula.txt").Length == 0)
				{
					Console.WriteLine("Файл пуст!");
				}
				else
				{
					string formula = File.ReadAllText("formula.txt");
					int result = Calculator(formula);
					Console.WriteLine($"Значение формулы {formula} = {result}");
				}
			}
			else Console.WriteLine("Ошибка! Файла нет!");

			Console.ReadKey();
		}
		static int Calculator(string formula)
		{
			Stack<int> nums = new Stack<int>();
			Stack<char> oper = new Stack<char>();

			foreach (char c in formula)
			{
				if (Char.IsDigit(c))
				{
					nums.Push(c - '0');
				}
				else if (c == 'm' || c == 'p')
				{
					oper.Push(c);
				}
				else if (c == ',')
				{
					continue;
				}
				else if (c == ')')
				{
					int b = nums.Pop();
					int a = nums.Pop();
					char op = oper.Pop();

					int res = 0;
					if (op == 'm')
					{
						res = (a - b) % 10;
					}
					else if (op == 'p')
					{
						res = (a + b) % 10;
					}

					nums.Push(res);
				}
			}

			return nums.Pop();

		}
	}
}
