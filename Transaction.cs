using System;

namespace DigitalPettyCashLedger
{
    // Abstract base class for all transactions
    // Not sealed because it is meant to be inherited
    public abstract class Transaction : IReportable
    {
        // Read-only properties to ensure immutability after creation
        public int Id { get; }
        public DateTime Date { get; }
        public decimal Amount { get; }
        public string Description { get; }

        // Protected constructor so only derived classes can create transactions
        protected Transaction(int id, DateTime date, decimal amount, string description)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Description = description;
        }

        // Forces derived classes to implement their own summary
        public abstract string GetSummary();
    }
}

