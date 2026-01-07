using System;

namespace DigitalPettyCashLedger
{
    // Sealed because ExpenseTransaction is also a final business concept
    public sealed class ExpenseTransaction : Transaction
    {
        // Expense category (e.g., Food, Stationery)
        public string Category { get; }

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

        public override string GetSummary()
        {
            return $"[EXPENSE] {Date:d} | {Category} | {Amount} | {Description}";
        }
    }
}

