using System.Collections.Generic;

namespace DigitalPettyCashLedger
{
    // Generic ledger to store transactions in memory
    // Not sealed to allow reuse or extension if needed
    public class Ledger<T> where T : Transaction
    {
        // Private list to protect internal data
        private readonly List<T> _entries = new List<T>();

        // Adds a transaction to the ledger
        public void AddEntry(T entry)
        {
            _entries.Add(entry);
        }

        // Returns a copy to prevent external modification
        public List<T> GetAll()
        {
            return new List<T>(_entries);
        }
    }
}

