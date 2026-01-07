using System;
using System.Collections.Generic;
using System.Linq;

namespace CashLedger
{
    /// <summary>
    /// Defines a interface for generating a summary of a transaction.
    /// </summary>
    public interface IReportable
    {
        /// <summary>
        /// Returns a summary describing the transaction.
        /// </summary>
        /// <returns>A string containing transaction details.</returns>

        string GetSummary();
    }

    /// <summary>
    /// Represents the abstract base class for all financial transactions.
    /// This class encapsulates common properties such as Id, Date, Amount,
    /// and Description, and enforces implementation of summary reporting.
    /// </summary>

    public abstract class Transaction : IReportable
    {
        /// <summary>
        /// Gets the unique identifier for the transaction.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the date on which the transaction occurred.
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Gets the monetary value of the transaction.
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// Gets a short description explaining the transaction.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Initializes the common properties of a transaction.
        /// </summary>
        /// <param name="id">Unique transaction identifier.</param>
        /// <param name="date">Date of the transaction.</param>
        /// <param name="amount">Transaction amount.</param>
        /// <param name="description">Description of the transaction.</param>
        protected Transaction(int id, DateTime date, decimal amount, string description)
        {
            // Assign common transaction values
            Id = id;
            Date = date;
            Amount = amount;
            Description = description;
        }

        /// <summary>
        /// Generates a transaction-specific summary.
        /// Must be implemented by derived classes.
        /// </summary>
        /// <returns>A formatted transaction summary.</returns>
        public abstract string GetSummary();
    }

    /// <summary>
    /// Represents an expense transaction.
    /// Extends the Transaction class by adding an expense category.
    /// </summary>
    public class ExpenseTransaction : Transaction
    {
        /// <summary>
        /// Gets the category of the expense (e.g., Stationery, Food).
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Initializes a new expense transaction.
        /// </summary>
        /// <param name="id">Id of the transaction.</param>
        /// <param name="date">Date of the expense.</param>
        /// <param name="amount">Expense amount.</param>
        /// <param name="description">Expense description.</param>
        /// <param name="category">Expense category.</param>
        public ExpenseTransaction(int id, DateTime date, decimal amount, string description, string category)
            : base(id, date, amount, description)
        {
            // Assign expense-specific data
            Category = category;
        }

        /// <summary>
        /// Returns a formatted summary of the expense transaction.
        /// </summary>
        public override string GetSummary()
        {
            return $"[EXPENSE] {Date:d} || {Category} || ${Amount} || {Description}";
        }
    }

    /// <summary>
    /// Represents an income transaction.
    /// Extends the Transaction class by adding a source of income.
    /// </summary>

    public class IncomeTransaction : Transaction
    {
        /// <summary>
        /// Gets the source of the income (e.g., Cash, Bank Transfer).
        /// </summary>

        public string Source { get; }

        /// <summary>
        /// Initializes a new income transaction.
        /// </summary>
        /// <param name="id">Id of the transaction.</param>
        /// <param name="date">Date income was revieved.</param>
        /// <param name="amount">Income amount.</param>
        /// <param name="description">Income description.</param>
        /// <param name="source">Source of income.</param>

        public IncomeTransaction(int id, DateTime date, decimal amount, string description, string source)
            : base(id, date, amount, description)
        {
            // Assign income-specific data
            Source = source;
        }

        /// <summary>
        /// Returns a  summary of the income transaction.
        /// </summary>
        public override string GetSummary()
        {
            return $"[INCOME] {Date:d} || {Source} || ${Amount} ||{Description}";
        }
    }

    /// <summary>
    /// Generic ledger class used to store and manage transactions.
    /// </summary>
    /// <typeparam name="T">A type derived from Transaction.</typeparam>

    public class Ledger<T> where T : Transaction
    {
        // Internal collection that stores ledger entries in memory
        private readonly List<T> data_entries = new List<T>();

        /// <summary>
        /// Adds a transaction entry to the ledger.
        /// </summary>
        /// <param name="entry">The transaction to be added.</param>
        public void AddEntry(T entry)
        {
            data_entries.Add(entry);
        }

        /// <summary>
        /// Retrieves all transactions that occurred on a specific date.
        /// </summary>
        /// <param name="date">Date used to filter transactions.</param>
        /// <returns>A list of transactions for the given date.</returns>

        public List<T> GetTransactionsByDate(DateTime date)
        {
            return data_entries.Where(e => e.Date.Date == date.Date).ToList();
        }

        /// <summary>
        /// Calculates the total amount of all transactions in the ledger.
        /// </summary>
        /// <returns>The sum of transaction amounts.</returns>

        public decimal CalculateTotal()
        {
            return data_entries.Sum(e => e.Amount);
        }

        /// <summary>
        /// Retrieves all transactions stored in the ledger.
        /// </summary>
        /// <returns>A list of all transactions.</returns>
        public List<T> GetAll()
        {
            return new List<T>(data_entries);
        }
    }

    /// <summary>
    /// Entry point of the Digital Petty Cash Ledger application.
    /// Implements  ledger initialization, thransaction recording,
    /// calculations, and display of records..
    /// </summary>

    public class Program
    {
        /// <summary>
        /// Main method that controls the execution flow of the program.
        /// </summary>
        public static void Main()
        {

            // Ledger for tracking income transactions
            Ledger<IncomeTransaction> incomeLedger = new Ledger<IncomeTransaction>();

            // Record petty cash replenishment
            incomeLedger.AddEntry(
                new IncomeTransaction(
                    id: 1,
                    date: DateTime.Today,
                    amount: 500m,
                    description: "Initial Amount",
                    source: "Main Cash"
                )
            );

            // Ledger for tracking expense transactions
            Ledger<ExpenseTransaction> expenseLedger = new Ledger<ExpenseTransaction>();

            // Record stationery expense
            expenseLedger.AddEntry(
                new ExpenseTransaction(
                    id: 2,
                    date: DateTime.Today,
                    amount: 20m,
                    description: "Office stationery",
                    category: "Stationery"
                )
            );

            // Record snack expense
            expenseLedger.AddEntry(
                new ExpenseTransaction(
                    id: 3,
                    date: DateTime.Today,
                    amount: 15m,
                    description: "Snacks for team",
                    category: "Food"
                )
            );

            // Calculate the total Expenses 
            decimal totalIncome = incomeLedger.CalculateTotal();
            decimal totalExpenses = expenseLedger.CalculateTotal();
            decimal netBalance = totalIncome - totalExpenses;

            // Display calculated results
            Console.WriteLine($"Total Income: ${totalIncome}");
            Console.WriteLine($"Total Expenses: ${totalExpenses}");
            Console.WriteLine($"Net Balance: ${netBalance}");
            Console.WriteLine();

            // Combine all transactions into a single list
            List<Transaction> allTransactions = new List<Transaction>();
            allTransactions.AddRange(incomeLedger.GetAll());
            allTransactions.AddRange(expenseLedger.GetAll());

            // Display transaction summaries
            foreach (Transaction transaction in allTransactions)
            {
                Console.WriteLine(transaction.GetSummary());
            }
        }
    }
}

