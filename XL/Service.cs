using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace XL
{
    public class Service 
    {
        private Microsoft.Office.Interop.Excel.Application _xlApp;
        private Microsoft.Office.Interop.Excel.Workbooks _xlBooks;
        private List<Dir> _dirs;
        private List<Book> _books;
        private List<Sheet> _sheets;
        private List<Row> _rows;
        public Service()
        {
            _xlApp = new Microsoft.Office.Interop.Excel.Application();
            _xlBooks = _xlApp.Workbooks;
            _dirs = new List<Dir>();
            _books = new List<Book>();
            _sheets = new List<Sheet>();
            _rows = new List<Row>();
        }

        #region "public methods"
        public void AddDir(string path)
        {
            Dir d = new Dir(path);
            d.Id = _dirs.Count();
            LoadData(d);
            _dirs.Add(d);
        }

        //get all Dirs
        public List<Dir> GetDirs()
        {
            return _dirs;
        }

        //get a single Dir object by Id
        public Dir GetDir(int id)
        {
            return _dirs[id];
        }

        //get all books
        public List<Book> GetBooks()
        {
            return _books;
        }

        //get a single book object by Id
        public Book GetBook(int id)
        {
            return _books[id];
        }

        //get list of sheets for a book by bookId
        public List<Sheet> GetSheets(int bookId)
        {
            return _sheets.Where(s => s.BookId == bookId).ToList();
        }

        //get list of sheet objects for all workbooks 
        public List<Sheet> GetSheets()
        {
            return _sheets;
        }

        //get a single sheet object by Id
        public Sheet GetSheet(int id)
        {
            return _sheets[id];
        }

        //get list of row objects for all sheets in all workbooks
        public List<Row> GetRows()
        {
            return _rows;
        }

        //get s single row object by Id
        public Row GetRow(int id)
        {
            return _rows[id];
        }

        #endregion

        #region "private methods"

        //populate a list of Book objects for all Excel Workbooks in a directory
        private void LoadData(Dir d)
        {
            Microsoft.Office.Interop.Excel._Workbook xlBook;
            var di = new DirectoryInfo(d.Path);
            var xlFiles = di.GetFiles().Where(f => f.Name.EndsWith(".xls") || f.Name.EndsWith(".xlsx")).OrderBy(f => f.Name).ToList();
            foreach (var f in xlFiles)
            {
                Book b = new Book()
                {
                    Id = _books.Count(),
                    Path = f.FullName
                };
                xlBook = _xlBooks.Open(b.Path);
                LoadSheets(b, xlBook);
                _xlBooks.Close();
                _books.Add(b);
            }
        }

        //populate a list of Sheet objects for a workbook
        private void LoadSheets(Book b, Microsoft.Office.Interop.Excel._Workbook xlBook)
        {
            Microsoft.Office.Interop.Excel.Sheets xlSheets = xlBook.Worksheets;
            foreach (Microsoft.Office.Interop.Excel._Worksheet w in xlSheets)
            {
                Sheet s = new Sheet()
                {
                    Id = _sheets.Count(),
                    BookId = b.Id,
                    Name = w.Name
                };
                LoadRows(s, w);
                _sheets.Add(s);
            }
           
        }

        //get a list of Row objects for a sheet
        private void LoadRows(Sheet s, Microsoft.Office.Interop.Excel._Worksheet xlSheet)
        {
            int row = 2;
            while (xlSheet.get_Range(CellName(row, 1)).Value2 != null)
            {
                Row r = new Row()
                {
                    Id = _rows.Count(),
                    SheetId = s.Id,
                    Data = GetRowData(GetRowVals(xlSheet, 1), GetRowVals(xlSheet, row++))
                };
                _rows.Add(r);
            }
        }

        //get single row values, stored in a string list
        private List<string> GetRowVals(Microsoft.Office.Interop.Excel._Worksheet xlSheet, int row)
        {
            List<string> values = new List<string>();
            Microsoft.Office.Interop.Excel.Range cell = xlSheet.get_Range(CellName(row, 1));
            while (cell.Value2 != null)
            {
                values.Add("" + cell.Value2);
                cell = cell.Next;
            }
            return values;
        }

        //returns a dictionary object with key-value pairs for single row
        private Dictionary<string, string> GetRowData(List<string> headers, List<string> values)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            for (int i = 0; i < headers.Count(); i++)
            {
                data.Add(headers[i], values[i]);
            }
            return data;
        }

        //return cell string name from row, col : (2,1) => "A2"
        private string CellName(int row, int col)
        {
            Char column = (char)(col + 64);
            return column + row.ToString();
        }

        #endregion

    }
}
