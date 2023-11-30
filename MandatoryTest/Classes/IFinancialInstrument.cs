using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryTest.Classes
{
    public interface IFinancialInstrument
    {
        double MarketValue { get; }
        string Type { get; }

        public string GetCategory();
    }
}
