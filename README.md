# CSharp_Week2_test

## Description
This program is a Digital Petty Cash Ledger System developed using C#.  
It demonstrates basic object-oriented programming concepts such as abstraction,
inheritance, interfaces, generics, and collections.  
The application records income and expense transactions and calculates the
remaining cash balance.

## Use Case
The system allows a petty cash custodian to:
- Record income (cash replenishment)
- Record expenses (small daily spending)
- Calculate total income and expenses
- Calculate net balance
- Display transaction summaries

## Program Structure
- Transaction (abstract class)  
- IncomeTransaction  
- ExpenseTransaction  
- IReportable (interface)  
- Ledger<T> (generic class)  
- Program.cs (application entry point)

## Output
The program displays:
- Total income
- Total expenses
- Net balance
- Summary of all transactions
