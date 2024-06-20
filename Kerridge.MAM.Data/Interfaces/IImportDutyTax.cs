using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerridge.MAM.Data.Interfaces
{
    internal interface IImportDutyTax
    {
        double CalculateImportDutyTax(double taxPercentage, double price);
    }
}
