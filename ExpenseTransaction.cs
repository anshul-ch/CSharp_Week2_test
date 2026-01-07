using System;

namespace DigitalPettyCashLedger
{
    /// <summary>
    /// Represents an expense transaction.
    /// This class is sealed to prevent further inheritance.
    /// </summary>
    public sealed class ExpenseTransaction : Transaction
    {
        /// <summary>
        /// Gets the category of the expense.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Initializes a new expense transaction.
        /// </summary>
        public ExpenseTransaction(
            int id,
            DateTime date,
            decimal amount,
            string description,
            string category)
            : base(id, date, amount, description)
        {
            Category = category;
        }

        /// <summary>
        /// Returns a formatted summary specific to expense transactions.
        /// </summary>
        public override string GetSummary()
        {
            return $"[EXPENSE] {Date:d} | {Category} | {Amount} | {Description}";
        }
    }
}

