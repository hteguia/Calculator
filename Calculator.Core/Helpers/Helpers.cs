using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace Calculator.Core.Helpers
{
    public static class CustomHelpers
    {
        /// <summary>
        /// Renvoi la priorité de l'opérateur. Plus il est petit, plus sa priorité est importante
        /// </summary>
        /// <param name="operators"></param>
        /// <returns></returns>      
        public static int Priority(string operators)
        {
            int priority;
            switch (operators)
            {
                case "/":
                case "*":
                    priority = 0;
                    break;
                case "+":
                case "-":
                    priority = 1;
                    break;
                default:
                    priority = 10000;
                    break;
            }
            return priority;
        }

        /// <summary>
        /// Vérifie si la valeur passé en paramètre est opérateur
        /// </summary>
        /// <param name="val"></param>
        /// <returns>true si c'est un opérateur et false sinon</returns>
        public static bool IsOperator(string val)
        {
            return val == "+" || val == "-" || val == "*" || val == "/";
        }

        /// <summary>
        /// Vérifie si la valeur passé en paramètre est opérateur de regroupement
        /// </summary>
        /// <param name="val"></param>
        /// <returns>true si c'est un opérateur de regroupement et false sinon</returns> 
        public static bool IsGroupOperator(string val)
        {
            return val == "(" || val == ")";
        }

        /// <summary>
        /// Inverse les object de la Stack<![CDATA[<T>]]>
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        public static Stack<string> Inverse(this Stack<string> stack)
        {
            Stack<string> result = new();
            while (stack.Count > 0)
            {
                result.Push(stack.Pop());
            }
            return result;
        }

        /// <summary>
        /// Convertir une chaine de caractères en nombre décimal
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static decimal CustomDecimalParse(this string val)
        {
            CultureInfo myCulture = CultureInfo.GetCultureInfo("en-GB");
            string pattern = @"^-?(\d*\.)?\d+$";
            Regex rg = new(pattern);
            if (rg.IsMatch(val))
            {
                return decimal.Parse(val, myCulture);
            }

            string[] tab = val.Split("^");
            if(tab.Length == 2)
            {
                return (decimal)Math.Pow(double.Parse(tab[0], myCulture), double.Parse(tab[1]));
            }

            throw new ArgumentNullException($"{val} n'est pas un nombre décimal");
        }
    }
}
