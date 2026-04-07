using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace BummashTestApplication
{
    public class ToleranceDataModel
    {
        List<int> DiameterBorders { get; set; }
        List<int> HeightBorders { get; set; }

        int[,] bData, deltaData;

        public ToleranceDataModel()
        {
            ReadTable();
        }

        public void ReadTable()
        {
            IWorkbook workbook;
            using (FileStream fileStream = new FileStream("Resources/Data.xls", FileMode.Open, FileAccess.Read))
            {
                workbook = new HSSFWorkbook(fileStream);
            }

            /*
            int sheetCount = workbook.NumberOfSheets;

            string debug2="";

            for (int i = 0; i < sheetCount; i++)
            {
                ISheet sh = workbook.GetSheetAt(i);
                debug2 += sh.SheetName + " ";
            }

            throw new Exception(debug2);*/

            ISheet sheet = workbook.GetSheetAt(9);

            IRow diametersRow = sheet.GetRow(1);

            DiameterBorders = new List<int>();
            DiameterBorders.Add(0);

            for (int i = 2; i < diametersRow.Count(); i++)
            {
                string cellValue = diametersRow.GetCell(i).StringCellValue;

                string[] values = cellValue.Split(new char[] { ' ', '\u00A0' });

                for (int j=0; j< values.Length; j++)
                {
                    bool parsingResult = Int32.TryParse(values[j], out int value);
                    if (parsingResult)
                    {
                        DiameterBorders.Add(value);
                        break;
                    }
                }
            }

            HeightBorders = new List<int>();

            for (int i=3;i< sheet.Rows.Count(); i++)
            {
                IRow row = sheet.GetRow(i);
                string cellValue = row.GetCell(0).StringCellValue;

                string[] values = cellValue.Split(new char[] { ' ', '\u00A0' });

                for (int j = 0; j < values.Length; j++)
                {
                    bool parsingResult = Int32.TryParse(values[j], out int value);
                    if (parsingResult)
                    {
                        HeightBorders.Add(value);
                        break;
                    }
                }
            }

            bData = new int[DiameterBorders.Count, HeightBorders.Count];
            deltaData = new int[DiameterBorders.Count, HeightBorders.Count];

            for (int i=0;i < HeightBorders.Count;i++)
            {
                for (int j = 0; j < DiameterBorders.Count; j++)
                {
                    IRow row = sheet.GetRow(i+3);

                    string cellValue = row.GetCell(j+1).StringCellValue;

                    if (cellValue == "-")
                    {
                        bData[j, i] = deltaData[j, i] = -1;
                    }
                    else
                    {
                        string[] values = cellValue.Split(new char[] { ' ', '\u00A0' });

                        bool parsingResult = Int32.TryParse(values[0], out int value);
                        if (parsingResult)
                        {
                            bData[j,i] = value;
                        }
                        else
                        {
                            throw new ArgumentException("Некорректные данные по допускам в таблице!");
                        }

                        parsingResult = Int32.TryParse(values[2], out value);
                        if (parsingResult)
                        {
                            deltaData[j, i] = value;
                        }
                        else
                        {
                            throw new ArgumentException("Некорректные данные по допускам в таблице!");
                        }
                    }
                }
            }
        }

        public Tuple<int,int>? GetToleranceValueFromTable(int height, int diameter)
        {
            Tuple<int, int>? answer = null;

            int heightIndex = 0;

            for (; heightIndex < HeightBorders.Count; heightIndex++)
            {
                if (height < HeightBorders[heightIndex])
                {
                    break;
                }
            }
            if (heightIndex == HeightBorders.Count) heightIndex = heightIndex - 1;

            int diameterIndex = 0;

            for (; diameterIndex < DiameterBorders.Count; diameterIndex++)
            {
                if (diameter < DiameterBorders[diameterIndex])
                {
                    break;
                }
            }
            if (diameterIndex == DiameterBorders.Count) diameterIndex = diameterIndex - 1;

            if (bData[diameterIndex, heightIndex] == -1)
            {
                throw new ArgumentException("Отсутствуют данные по допускам для таких диаметра и высоты!");
            }
            else
            {
                answer = new Tuple<int, int>(bData[diameterIndex, heightIndex], deltaData[diameterIndex, heightIndex]);
            }

            return answer;
        }
    }
}
