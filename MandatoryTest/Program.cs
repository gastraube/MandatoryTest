using MandatoryTest.Classes;
using System;
using MandatoryTest.Services;

namespace MandatoryTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var financialInstrumentList = new List<IFinancialInstrument>();

            string line;
            while (!String.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                try
                {
                   financialInstrumentList.Add(FinancialInstrumentFactory.Create(FinancialService.GetMarketValue(line), FinancialService.GetType(line)));
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Formato de entrada inválido.");
                }catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }  
 
            }

            Console.WriteLine(FinancialService.CreateOutput(financialInstrumentList));
        }
    }
}