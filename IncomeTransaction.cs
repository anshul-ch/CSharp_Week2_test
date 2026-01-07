using System;

namespace DigitalPettyCashLedger
{
    /// <summary>
    /// Represents an income transaction.
    /// This class is sealed to prevent further inheritance.
    /// </summary>
    public sealed class IncomeTransaction : Transaction
    {
        /// <summary>
        /// Gets the source of the income.
        /// </summary>
        public string Source { get; }

        /// <summary>
        /// Initializes a new income transaction.
        /// </summary>
        public IncomeTransaction(
            int id,
            DateTime date,
            decimal amount,
            string description,
            string source)
            : base(id, date, amount, description)
        {
            Source = source;
        }

        /// <summary>
        /// Returns a formatted summary specific to income transactions.
        /// </summary>
        public override string GetSummary()
        {
            return $"[INCOME] {Date:d} | {Source} | {Amount} | {Description}";
        }
    }
}

