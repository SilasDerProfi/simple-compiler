﻿using System;
using System.IO;

namespace CalculatorCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type 'BUILD' to compile");
            Console.WriteLine("One command per Line");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(Properties.Resources.Grammar);
            Console.WriteLine("------------------------------------------------");

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            for (string nextLine;(nextLine = Console.ReadLine()) != "BUILD";)
                writer.Write($"{nextLine.Replace(" ", "")};");

            writer.Flush();
            stream.Position = 0;
            new Compiler.CompilerEnvironment().Compile(stream);
        }
    }
}