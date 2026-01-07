using System;

namespace DigitalPettyCashLedger
{
    /// <summary>
    /// Abstract base class representing a financial transaction.
    /// Contains common properties shared by all transaction types.
    /// </summary>
    public abstract class Transaction : IReportable
    {
        /// <summary>
        /// Gets the unique identifier of the transaction.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the date on which the transaction occurred.
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Gets the transaction amount.
        /// This value is immutable after creation.
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// Gets the description of the transaction.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Initializes common transaction properties.
        /// Constructor is protected to prevent direct instantiation.
        /// </summary>
        protected Transaction(int id, DateTime date, decimal amount, string description)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Description = description;
        }

        /// <summary>
        /// Generates a transaction-specific summary.
        /// Must be implemented by derived classes.
        /// </summary>
        public abstract string GetSummary();
    }
}

