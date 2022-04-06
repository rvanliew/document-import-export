using DocumentExportUtility_API.Forms;
using DocumentExportUtility_API.Models;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentExportUtility_API.Utils
{
    public class ReadExcelHelper
    {
        public List<ExcelGuidModel> LoanGuidList = new List<ExcelGuidModel>();
        public List<ExcelQuattroConfigModel> QuattroDocList = new List<ExcelQuattroConfigModel>();
        private bool _isSuccess = false;

        public ReadExcelHelper()
        {
            //
        }

        public bool ReadExcel(string filePath, string _dataType)
        {
            try
            {
                using (var stream = File.Open($@"{filePath}", FileMode.Open, FileAccess.Read))
                {
                    IExcelDataReader reader;
                    try
                    {
                        reader = ExcelReaderFactory.CreateReader(stream);

                        var conf = new ExcelDataSetConfiguration
                        {
                            ConfigureDataTable = _ => new ExcelDataTableConfiguration
                            {
                                UseHeaderRow = false
                            }
                        };

                        var dataSet = reader.AsDataSet(conf);
                        var dataTable = dataSet.Tables[0];
                        if (_dataType.Equals("loanList"))
                        {
                            LoanGuidList.Clear();
                            ReadLoanListData(dataTable);
                        }
                        else if (_dataType.Equals("quattro"))
                        {
                            QuattroDocList.Clear();
                            ReadQuattroDocListData(dataTable);
                        }

                        _isSuccess = true;
                        
                    }
                    catch(ExcelDataReader.Exceptions.HeaderException)
                    {
                        MessageBox.Show("Invalid File. Please select a file with a .xlsx file extension.", "Invalid File Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _isSuccess = false;
                    }
                }
            }
            catch(IOException)
            {
                MessageBox.Show("Selected Excel file is open in another program. Please close the file and try again.", "Excel File",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _isSuccess = false;
            }

            return _isSuccess;
        }

        private void ReadLoanListData(DataTable dataTable)
        {
            for (var i = 1; i < dataTable.Rows.Count; i++)
            {
                for (var j = 1; j < dataTable.Columns.Count; j++)
                {
                    var loanNumber = dataTable.Rows[i][0];
                    var guid = dataTable.Rows[i][1];
                    LoanGuidList.Add(new ExcelGuidModel(guid.ToString(), loanNumber.ToString()));
                }
            }
        }

        private void ReadQuattroDocListData(DataTable dataTable)
        {
            for (var i = 1; i < dataTable.Rows.Count; i++)
            {
                for (var j = 1; j < dataTable.Columns.Count; j++)
                {
                    var quattroDoc = dataTable.Rows[i][0];
                    var encDoc = dataTable.Rows[i][1];
                    QuattroDocList.Add(new ExcelQuattroConfigModel(quattroDoc.ToString(), encDoc.ToString()));
                }
            }
        }
    }
}
