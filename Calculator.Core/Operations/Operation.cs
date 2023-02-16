using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operations
{
    public abstract class Operation
    {
        public abstract decimal Caculate(decimal leftOperand, decimal rightOperand);
    }
}
