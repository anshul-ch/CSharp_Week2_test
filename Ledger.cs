using System.Collections.Generic;

namespace DigitalPettyCashLedger
{
    /// <summary>
    /// Generic ledger class used to store transactions in memory.
    /// </summary>
    /// <typeparam name="T">A type derived from Transaction.</typeparam>
    public class Ledger<T> where T : Transaction
    {
        /// <summary>
        /// Internal list that stores ledger entries.
        /// Kept private to protect data integrity.
        /// </summary>
        private readonly List<T> _entries = new List<T>();

        /// <summary>
        /// Adds a transaction entry to the ledger.
        /// </summary>
        /// <param name="entry">Transaction to add.</param>
        public void AddEntry(T entry)
        {
            _entries.Add(entry);
        }

        /// <summary>
        /// Returns a copy of all ledger entries.
        /// </summary>
        /// <returns>List of transactions.</returns>
        public List<T> GetAll()
        {
            return new List<T>(_entries);
        }
    }
}

