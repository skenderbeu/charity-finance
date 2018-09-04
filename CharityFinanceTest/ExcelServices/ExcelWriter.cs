using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace ExcelServices
{
    public class ExcelWriter
    {
        private const string FIRST_CELL = "A2";
        private ExcelFile _excelFile;

        public ExcelWriter(ExcelFile excelFile)
        {
            _excelFile = excelFile;
        }

        public void Write(IList<IncomeSheetDTO> rows)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                AddFileProperties(excelPackage);

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(_excelFile.SheetName);

                AddHeaders(worksheet);

                worksheet.Cells[FIRST_CELL].LoadFromCollection(rows);

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                excelPackage.SaveAs(_excelFile.FilePath);
            }
        }

        public IList<string> Read(string fileName)
        {
            List<string> excelData = new List<string>();

            //read the Excel file as byte array
            byte[] bin = File.ReadAllBytes(fileName);

            //create a new Excel package in a memorystream
            GetExcelData(excelData, bin);

            return excelData;
        }

        private void GetExcelData(List<string> excelData, byte[] bin)
        {
            using (MemoryStream stream = new MemoryStream(bin))
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                //loop all worksheets
                foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                {
                    //loop all rows
                    for (int i = worksheet.Dimension.Start.Row; i <= worksheet.Dimension.End.Row; i++)
                    {
                        //loop all columns in a row
                        for (int j = worksheet.Dimension.Start.Column; j <=
                       worksheet.Dimension.End.Column; j++)
                        {
                            //add the cell data to the List
                            if (worksheet.Cells[i, j].Value != null)
                            {
                                excelData.Add(worksheet.Cells[i, j].Value.ToString());
                            }
                        }
                    }
                }
            }
        }

        private void AddFileProperties(ExcelPackage excelPackage)
        {
            excelPackage.Workbook.Properties.Author = _excelFile.Author;
            excelPackage.Workbook.Properties.Title = _excelFile.Title;
            excelPackage.Workbook.Properties.Subject = _excelFile.Subject;
            excelPackage.Workbook.Properties.Created = DateTime.Now;
        }

        private void AddHeaders(ExcelWorksheet worksheet)
        {
            var properties = typeof(IncomeSheetDTO).GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                worksheet.Cells[1, i + 1].Value = properties[i].Name;
            }
        }
    }
}