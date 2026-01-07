using System.Linq;

namespace DigitalPettyCashLedger
{
    /// <summary>
    /// Provides calculation utilities for ledger data.
    /// Implemented as a static class because it holds no state.
    /// </summary>
    public static class LedgerCalculator
    {
        /// <summary>
        /// Calculates the total amount of all transactions in a ledger.
        /// </summary>
        /// <typeparam name="T">Transaction type.</typeparam>
        /// <param name="ledger">Ledger containing transactions.</param>
        /// <returns>Total transaction amount.</returns>
        public static decimal CalculateTotal<T>(Ledger<T> ledger)
            where T : Transaction
        {
            return ledger.GetAll().Sum(t => t.Amount);
        }
    }
}

