namespace DigitalPettyCashLedger
{
    // Interface to enforce summary reporting on transactions
    public interface IReportable
    {
        string GetSummary();
    }
}

