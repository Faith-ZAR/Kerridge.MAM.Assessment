using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerridge.MAM.Data.Interfaces
{
    internal interface IBasicTax
    {
        double CalculateBasicTax(double taxPercentage, double price);
    }
}
