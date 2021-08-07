using System;
using System.IO;
using System.Collections.Generic;

namespace lox1
{
	class Program
	{
		static bool HadError = false;
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
				return;
			}

			string source = File.ReadAllText(path);
			Run(source);

			if (HadError)
			{
				// what's the windows way to indicate error on terminate?
			}
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
			Scanner scanner = new Scanner(source);
			List<Token> tokens = scanner.ScanTokens();

			foreach (Token token in tokens)
			{
				Console.WriteLine(token);
			}
		}

		public static void Error(int line, string message)
		{
			report(line, "", message);
		}

		private static void Report(int line, string where, string message)
		{
			Console.WriteLine("[line " + line + "] Error" + where + ": " + message);
			HadError = true;
		}
	}
}
