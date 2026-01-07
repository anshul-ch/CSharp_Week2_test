using System.Linq;

namespace DigitalPettyCashLedger
{
    // Static class because it only performs calculations
    public static class LedgerCalculator
    {
        // Calculates total amount for a given ledger
        public static decimal CalculateTotal<T>(Ledger<T> ledger)
            where T : Transaction
        {
            return ledger.GetAll().Sum(t => t.Amount);
        }
    }
}

