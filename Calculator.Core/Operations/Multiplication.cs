using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operations
{
    public class Multiplication : Operation
    {
        public override decimal Caculate(decimal leftOperand, decimal rightOperand)
        {
            return leftOperand * rightOperand;
        }
    }
}
