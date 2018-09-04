using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace ExcelServices
{
    public class ExcelWriter
    {
        public void Write(ExcelFile excelFile, IList<IncomeSheetDTO> rows)
        {
            //Create a new ExcelPackage
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                //Set some properties of the Excel document
                AddFileProperties(excelFile, excelPackage);
                //Create the WorkSheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(excelFile.SheetName);

                AddHeaders(worksheet);

                worksheet.Cells["A2"].LoadFromCollection(rows);

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                excelPackage.SaveAs(excelFile.FilePath);
            }
        }

        public IList<string> Read(string fileName)
        {
            //create a list to hold all the values
            List<string> excelData = new List<string>();
            //read the Excel file as byte array
            byte[] bin = File.ReadAllBytes(fileName);
            //create a new Excel package in a memorystream
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

            return excelData;
        }

        private void AddFileProperties(ExcelFile excelFile, ExcelPackage excelPackage)
        {
            excelPackage.Workbook.Properties.Author = excelFile.Author;
            excelPackage.Workbook.Properties.Title = excelFile.Title;
            excelPackage.Workbook.Properties.Subject = excelFile.Subject;
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