using System;
using System.Collections.Generic;

namespace DigitalPettyCashLedger
{
    class Program
    {
      ///<summary>
      ///
      ///</summary>
    
        static void Main()
        {
            // Create separate ledgers for income and expenses
            Ledger<IncomeTransaction> incomeLedger =
                new Ledger<IncomeTransaction>();

            Ledger<ExpenseTransaction> expenseLedger =
                new Ledger<ExpenseTransaction>();

            // -------- INCOME INPUT --------
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

            // -------- EXPENSE INPUT --------
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

            // -------- CALCULATIONS --------
            decimal totalIncome =
                LedgerCalculator.CalculateTotal(incomeLedger);

            decimal totalExpense =
                LedgerCalculator.CalculateTotal(expenseLedger);

            decimal netBalance = totalIncome - totalExpense;

            // -------- OUTPUT --------
            Console.WriteLine();
            Console.WriteLine($"Total Income: {totalIncome}");
            Console.WriteLine($"Total Expenses: {totalExpense}");
            Console.WriteLine($"Net Balance: {netBalance}");
            Console.WriteLine();

            // Polymorphic reporting
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

