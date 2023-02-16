using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operations
{
    public class OperationFactory
    {
        public Operation GetOperation(string operators)
        {
            if (operators.Equals("+")) return new Addition();

            if (operators.Equals("-")) return new Soustraction();

            if (operators.Equals("*")) return new Multiplication();

            return new Division();
        }
    }
}
