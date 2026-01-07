using System;

namespace DigitalPettyCashLedger
{
    // Sealed because IncomeTransaction is a final business concept
    // We do not want further inheritance from this class
    public sealed class IncomeTransaction : Transaction
    {
        // Source of income (e.g., Main Cash, Bank)
        public string Source { get; }

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

        public override string GetSummary()
        {
            return $"[INCOME] {Date:d} | {Source} | {Amount} | {Description}";
        }
    }
}

