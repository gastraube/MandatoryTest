using MandatoryTest.Classes;
using MandatoryTest.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryTest.Services
{
    public static class FinancialService
    {
        public static double GetMarketValue(string line)
        {
            var parse = double.TryParse((line.Substring(line.IndexOf("= ") + 1, line.IndexOf(";") - (line.IndexOf("= ") + 1)).Trim()), out var result);

            if (!parse)
                throw new Exception("Valor numérico inválido!");

            return result;
        }

        public static string GetType(string line)
        {
            return line.Substring(line.IndexOf("= ") + 1, line.IndexOf(";") - (line.IndexOf("= ") + 1)).Trim();
        }

        public static string CreateOutput(List<IFinancialInstrument> financialInstrumentList)
        {
            var output = "instrumentCategories = {";

            var last = financialInstrumentList.Last();
            foreach (var item in financialInstrumentList)
            {
                output += "\"" + item.GetCategory() + (item.Equals(last) ? "\"" : "\",");
            }
            output += "}";

            return output;
        }
    }
}
