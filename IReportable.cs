namespace DigitalPettyCashLedger
{
    ///<summary>
    /// Defines a contract for transaction reporting.
    /// Any transaction that can be reported must implement this interface.
    ///</summary>

    public interface IReportable
    {
        string GetSummary();
    }
}

