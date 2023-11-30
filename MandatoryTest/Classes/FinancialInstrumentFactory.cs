using MandatoryTest.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryTest.Classes
{
    public static class FinancialInstrumentFactory
    {
        public static double low = 1000000;
        public static double high = 5000000;

        public static IFinancialInstrument Create(double value, string type)
        {
            if (value < low)
                return new FinancialInstrumentLow() { MarketValue = value, Type = type };
            else if (value >= low && value <= high)
                return new FinancialInstrumentMedium() { MarketValue = value, Type = type };
            else if (value > high)
                return new FinancialInstrumentHigh() { MarketValue = value, Type = type };

            throw new Exception("Valor inválido");
        }
    }
}
