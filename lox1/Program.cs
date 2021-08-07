using System;
using System.IO;
using System.Text;

namespace lox1
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length > 1)
			{
				Console.WriteLine("Usage: csharplox [script]");
				return;
			} 
			else if (args.Length == 1)
			{
				RunFile(args[0]);
			}
			else
			{
				RunPrompt();
			}
		}

		private static void RunFile(string path)
		{
			if (!File.Exists(path))
			{
				Console.WriteLine("file does not exist");
			}

			string source = File.ReadAllText(path);
			Run(source);
		}

		private static void RunPrompt()
		{
			while (true)
			{
				Console.Write("> ");
				string line = Console.ReadLine();
				if (line == null) break;
				Run(line);
			}
		}

		private static void Run(string source)
		{
			Console.WriteLine(source);
		}
	}
}
