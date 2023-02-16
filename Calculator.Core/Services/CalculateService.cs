using System;
using System.Collections.Generic;
using System.Globalization;
using Calculator.Core.Helpers;
using Calculator.Core.Operations;

namespace Calculator.Core.Services
{
    public class CalculateService : ICalculatorService
    {
        public decimal Calculate(string expression)
        {
            OperationFactory factory = new();
            List<string> value = ConvertStringToMathematicalExpression(expression);
            Stack<string> postFixExpress = PostFixExpression(value).Inverse();
            Stack<decimal> resultStack = new();
            while (postFixExpress.Count > 0)
            {
                string item = postFixExpress.Pop();
                if (!CustomHelpers.IsOperator(item))
                {
                    resultStack.Push(item.CustomDecimalParse());
                }
                else
                {
                    decimal rightOperand = resultStack.Pop();
                    decimal leftOperand = resultStack.Pop();
                    decimal result = factory.GetOperation(item).Caculate(leftOperand, rightOperand);
                    resultStack.Push(result);
                }
            }
            return resultStack.Peek();
        }

        private List<string> ConvertStringToMathematicalExpression(string value)
        {
            string customValue = value.Replace(" ", "");
            string sign = "";
            List<string> mathematicalExpression = new();
            for (int i = 0; i < customValue.Length; i++)
            {
                string current = customValue.Substring(i, 1);
                if (i == 0)
                {
                    if (current == "+" || current == "-")
                    {
                        sign = current;
                    }
                    else
                    {
                        mathematicalExpression.Add(current);
                    }
                    continue;
                }

                if (CustomHelpers.IsGroupOperator(current))
                {
                    mathematicalExpression.Add(current);
                    continue;
                }

                if (mathematicalExpression.Count == 0)
                {
                    if (!CustomHelpers.IsOperator(current))
                    {
                        mathematicalExpression.Add(sign + current);
                        sign = "";
                        continue;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(sign))
                        {
                            throw new ArgumentException($"Format des la chaine {value} incorrect");
                        }

                        mathematicalExpression.Add(current);
                    }
                }


                if (!CustomHelpers.IsOperator(current))
                {
                    if (CustomHelpers.IsOperator(mathematicalExpression[mathematicalExpression.Count - 1]) ||
                       CustomHelpers.IsGroupOperator(mathematicalExpression[mathematicalExpression.Count - 1]))
                    {
                        mathematicalExpression.Add(sign + current);
                        sign = "";
                    }
                    else
                    {
                        mathematicalExpression[mathematicalExpression.Count - 1] = mathematicalExpression[mathematicalExpression.Count - 1] + current;
                    }
                }
                else
                {
                    if (CustomHelpers.IsOperator(mathematicalExpression[mathematicalExpression.Count - 1]) && (current == "+" || current == "-"))
                    {
                        sign = current;
                    }
                    else
                    {
                        mathematicalExpression.Add(current);
                    }
                }
            }
            return mathematicalExpression;
        }
     
        private Stack<string> PostFixExpression(List<string> val)
        {
            Stack<string> expression = new Stack<string>();
            Stack<string> operators = new Stack<string>();
            foreach (var item in val)
            {
                if (CustomHelpers.IsGroupOperator(item))
                {
                    if (item.Equals("("))
                    {
                        operators.Push(item);
                    }
                    else
                    {
                        expression.Push(operators.Pop());
                        operators.Pop(); //Enlève parenthèses ouvrantes
                    }
                }
                else if (CustomHelpers.IsOperator(item))
                {
                    AddOperator(ref operators, ref expression, item);
                }
                else
                {
                    expression.Push(item);
                }
            }

            while (operators.Count > 0)
            {
                expression.Push(operators.Pop());
            }

            return expression;
        }

        private void AddOperator(ref Stack<string> operators, ref Stack<string> expression, string item)
        {
            if (operators.Count == 0)
            {
                operators.Push(item);
                return;
            }

            if (CustomHelpers.Priority(item) < CustomHelpers.Priority(operators.Peek()))
            {
                operators.Push(item);
                return;
            }
            else
            {
                expression.Push(operators.Pop());
                AddOperator(ref operators, ref expression, item);
            }
        }
    }
}
