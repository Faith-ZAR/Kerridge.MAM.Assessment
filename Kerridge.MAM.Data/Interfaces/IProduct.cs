using Kerridge.MAM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerridge.MAM.Data.Interfaces
{
    public interface IProduct
    {        
        object ProcessProducts(List<InputView> input);
    }
}
