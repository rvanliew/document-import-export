namespace DocumentExportUtility_API.Models
{
    public class BatchImportModel
    {
        public string LoanNumber { get; set; }
        public string FileName { get; set; }

        public BatchImportModel(string loanNumber, string fileName)
        {
            LoanNumber = loanNumber;
            FileName = fileName;
        }
    }
}
