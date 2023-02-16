using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operations
{
    public  class Division : Operation
    {
        public override decimal Caculate(decimal leftOperand, decimal rightOperand)
        {
            if (rightOperand == 0)
            {
                throw new DivideByZeroException("Erreur");
            }

            return leftOperand / rightOperand;
        }
    }
}
