using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Services
{
    public interface ICalculatorService
    {
        decimal Calculate(string expression);
    }
}
