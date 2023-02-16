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





            //Console.WriteLine("Calculatrice");
            //string pattern = @"^\-?[0-9](([-+/*][0-9]+)?([.,][0-9]+)?)*?$";
            //Regex rg = new Regex(pattern);
            //bool test = rg.IsMatch("1+2");
            //List<string> vals = new List<string>
            //{
            //    "(2+5)*3",
            //    "1+1",
            //    "1 + 2",
            //    "1 + -1",
            //    "-1 - -1",
            //    "5-4",
            //    "5*2",
            //    "(2+5)*3",
            //    "10/2",
            //    "2+2*5+5",
            //    "2.8*3-1",
            //    "2^8",
            //    //"2^8*5-1",
            //    //"sqrt(4)",
            //    "1/0"
            //};



            //ICalculatorService calculatorService = new CalculateService();
            //foreach(string val in vals)
            //{
            //    try
            //    {
            //        var mathematicalExpression = calculatorService.ConvertStringToMathematicalExpression(val);
            //        var result = calculatorService.Calculate(mathematicalExpression);
            //        Console.WriteLine($"{val} = {result}");
            //    }
            //    catch(DivideByZeroException ex)
            //    {
            //        Console.WriteLine($"{val} = {ex.Message}");
            //    }
            //    catch(Exception ex)
            //    {

            //    }

            //}
            //Console.ReadLine(); 
        }
    }
}
