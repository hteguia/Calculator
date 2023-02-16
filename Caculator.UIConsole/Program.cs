using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using Calculator.Core.Services;

namespace Caculator.UIConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mathematicalExpression = "";
            try
            {
                Console.Write("Veuillez entrer votre expression: ");
                mathematicalExpression = Console.ReadLine();
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    mathematicalExpression = Console.ReadLine();
                }

                ICalculatorService calculatorService = new CalculateService();
                var result = calculatorService.Calculate(mathematicalExpression);
                Console.WriteLine($"{mathematicalExpression} = {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"{mathematicalExpression} = {ex.Message}");
            }
            catch (Exception ex)
            {

            }

            Console.ReadLine(); 
        }
    }
}
