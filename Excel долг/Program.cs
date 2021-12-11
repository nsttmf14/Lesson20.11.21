using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Excel_долг
{
    class Program
    {
        readonly static string PathOut = "output.txt";
        readonly static string PathToDiseases = "1.Diseases.xlsx";
        readonly static string PathToGeneral = "2.General.xlsx";
        static void Main(string[] args)
        {
            int Key = 0;
            string stringKey = "диагноз";

            Console.WriteLine("Excel");

            object[,] DiseasesAndTreatment = ReadExcel(PathToDiseases, "A1:B11");
            string[] Diseases = GetColumnFromExcelTable(DiseasesAndTreatment, 1);
            string[] Treatment = GetColumnFromExcelTable(DiseasesAndTreatment, 2);
            string[,] result = new string[35, 4];
            DiseasesAndTreatment = ReadExcel(PathToGeneral, "A1:H35");
            string[] titles = GetRowFromExcelTable(DiseasesAndTreatment, 1);
            string[] id = GetColumnFromExcelTable(DiseasesAndTreatment, 1);
            for (int i = 1; i < titles.Length; i++)
            {
                if (titles[i].ToLower().Equals(stringKey))
                {
                    Key = i;
                    i = titles.Length;
                }
            }
            if (Key == 0)
            {
                Environment.Exit(0); //Закрытие программы
            }

            string[] match3 = GetColumnFromExcelTable(DiseasesAndTreatment, Key);
            for (int i = 2; i < match3.Length; i++)
            {
                bool done = false;
                for (int j = 2; j < Diseases.Length; j++)
                {
                    if (match3[i].ToLower().Contains(Diseases[j].ToLower()))
                    {
                        result[i, 1] = id[i];
                        result[i, 2] = match3[i];
                        if (result[i, 3] != null)
                        {
                            result[i, 3] += "\n" + Treatment[j];
                        }
                        else
                        {
                            result[i, 3] = Treatment[j];
                        }
                        done = true;
                    }
                }
                if (!done)
                {
                    result[i, 1] = id[i];
                    result[i, 2] = match3[i];
                    result[i, 3] = "";
                }
            }
            WriteToExcel(result);
        }

        static void WriteToPath(string str)
        {
            string sout = "";
            if (File.Exists(PathOut))
            {
                StreamReader sr = new StreamReader(PathOut);
                sout = sr.ReadToEnd();
                sr.Close();
            }
            StreamWriter sw = new StreamWriter(PathOut);
            sw.Write(sout + str);
            sw.Close();
        }

        //Считывание файла
        static object[,] ReadExcel(string path, string area)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook book = excel.Workbooks.Open($@"{Environment.CurrentDirectory}\{path}", 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Excel.Worksheet sheet = (Excel.Worksheet)book.Sheets[1];
            object[,] table = (object[,])sheet.Range[area].Value;
            excel.Quit();
            return table;
        }

        //Считывание столбца
        static string[] GetColumnFromExcelTable(object[,] table, int column)
        {
            string[] column_array = new string[table.GetLength(0)];
            for (int i = 1; i < table.GetLength(0); i++)
            {
                if (table[i, column] != null)
                {
                    column_array[i] = table[i, column].ToString();
                }
                else
                {
                    i = table.GetLength(0);
                }
            }

            return column_array;
        }

        //Считывания ряда
        static string[] GetRowFromExcelTable(object[,] table, int row)
        {
            string[] row_array = new string[table.GetLength(1)];
            for (int i = 1; i < table.GetLength(1); i++)
            {
                if (table[row, i] != null)
                {
                    row_array[i] = table[row, i].ToString();
                }
                else
                {
                    i = table.GetLength(1);
                }
            }
            return row_array;
        }

        static void WriteToExcel(string[,] table)
        {
            Excel.Application excel = new Excel.Application
            {
                Visible = true,
                SheetsInNewWorkbook = 2
            };

            Excel.Workbook workBook = excel.Workbooks.Add(Type.Missing);
            excel.DisplayAlerts = false;

            Excel.Worksheet sheet = (Excel.Worksheet)excel.Worksheets.get_Item(1);
            sheet.Name = "Результат";
            sheet.Cells[1, 1] = "ID";
            sheet.Cells[1, 2] = "Диагноз";
            sheet.Cells[1, 3] = "Лекарство(а)";

            for (int i = 2; i < table.GetLength(0); i++)
            {
                for (int j = 1; j < table.GetLength(1); j++)
                {
                    sheet.Cells[i, j] = table[i, j];
                }
            }

            excel.Application.ActiveWorkbook.SaveAs($@"{Environment.CurrentDirectory}\Result.xlsx", Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            excel.Quit();
        }

    }
}
