using MandatoryTest.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryTest.Classes
{
    internal class FinancialInstrumentHigh : IFinancialInstrument
    {
        public double MarketValue { get; set; }
        public string? Type { get; set; }

        public string GetCategory()
        {
            return "High Value";
        }
    }
}
