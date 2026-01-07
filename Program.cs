using System;
using System.Collections.Generic;

namespace DigitalPettyCashLedger
{
    /// <summary>
    /// Application entry point.
    /// Handles only user input and output.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method that drives the console application.
        /// </summary>
        static void Main()
        {
            Ledger<IncomeTransaction> incomeLedger =
                new Ledger<IncomeTransaction>();

            Ledger<ExpenseTransaction> expenseLedger =
                new Ledger<ExpenseTransaction>();

            Console.WriteLine("Enter income amount:");
            decimal incomeAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter income source:");
            string incomeSource = Console.ReadLine();

            incomeLedger.AddEntry(
                new IncomeTransaction(
                    1,
                    DateTime.Today,
                    incomeAmount,
                    "Income entry",
                    incomeSource
                )
            );

            Console.WriteLine("Enter expense amount:");
            decimal expenseAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter expense category:");
            string expenseCategory = Console.ReadLine();

            expenseLedger.AddEntry(
                new ExpenseTransaction(
                    2,
                    DateTime.Today,
                    expenseAmount,
                    "Expense entry",
                    expenseCategory
                )
            );

            decimal totalIncome =
                LedgerCalculator.CalculateTotal(incomeLedger);

            decimal totalExpense =
                LedgerCalculator.CalculateTotal(expenseLedger);

            decimal netBalance = totalIncome - totalExpense;

            Console.WriteLine();
            Console.WriteLine($"Total Income: {totalIncome}");
            Console.WriteLine($"Total Expenses: {totalExpense}");
            Console.WriteLine($"Net Balance: {netBalance}");
            Console.WriteLine();

            List<Transaction> allTransactions = new List<Transaction>();
            allTransactions.AddRange(incomeLedger.GetAll());
            allTransactions.AddRange(expenseLedger.GetAll());

            foreach (Transaction transaction in allTransactions)
            {
                Console.WriteLine(transaction.GetSummary());
            }
        }
    }
}

