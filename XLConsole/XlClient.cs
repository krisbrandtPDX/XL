using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using XL;

namespace XLConsole
{
    public class XlClient
    {
        private const string QUIT = "Q";
        private Service _xlService;
        private JsonSerializerOptions _serialzerOptions;
        public XlClient()
        {
            _xlService = new Service();
            _serialzerOptions = new JsonSerializerOptions() { WriteIndented = true };
        }

        public void Run()
        {
            ControlLoop();
        }
        private void ControlLoop()
        {
            string menu = Menu();
            string menuChoice = UI.Prompt(menu, QUIT);

            while (menuChoice != QUIT)
            {
                switch (menuChoice)
                {
                    case "1":
                        LoadDir();
                        break;
                    case "2":
                        GetDirs();
                        break;
                    case "3":
                        GetDir();
                        break;
                    case "4":
                        GetBooks();
                        break;
                    case "5":
                        GetBook();
                        break;
                    case "6":
                        GetSheets();
                        break;
                    case "7":
                        GetSheet();
                        break;
                    case "8":
                        GetRows();
                        break;
                    case "9":
                        GetRow();
                        break;
                    default:
                        menuChoice = QUIT;
                        continue;
                }
                menuChoice = UI.Prompt(menu, QUIT);
            }
        }

        private static string Menu()
        {
            string prompt = "\nSelect Option:\n";
            prompt += " 1  - Post Dir\n";
            prompt += " 2  - Get Dirs\n";
            prompt += " 3  - Get Dir\n";
            prompt += " 4  - Get Books\n";
            prompt += " 5  - Get Book\n";
            prompt += " 6  - Get Sheets\n";
            prompt += " 7  - Get Sheet\n";
            prompt += " 8  - Get Rows\n";
            prompt += " 9  - Get Row\n";
            prompt += "<" + QUIT + "> - Quit\n";
            return prompt;
        }

        private void LoadDir()
        {
            string dir = UI.Prompt("Enter directory path: ", "0");
            _xlService.AddDir(dir);
        }

        private void GetDirs()
        {
            List<Dir> dirs = _xlService.GetDirs();
            string json = JsonSerializer.Serialize(dirs, _serialzerOptions);
            UI.Notify(json);
        }

        private void GetDir()
        {
            string dirId = UI.Prompt("Enter Dir Id: ", "0");
            Int32.TryParse(dirId, out int id);
            Dir d = _xlService.GetDir(id);
            string json = JsonSerializer.Serialize(d, _serialzerOptions);
            UI.Notify(json);
        }

        private void GetBooks()
        {
            List<Book> books = _xlService.GetBooks();
            string json = JsonSerializer.Serialize(books, _serialzerOptions);
            UI.Notify(json);
        }

        private void GetBook()
        {
            string bookId = UI.Prompt("Enter Book Id: ", "0");
            Int32.TryParse(bookId, out int id);
            Book b = _xlService.GetBook(id);
            string json = JsonSerializer.Serialize(b, _serialzerOptions);
            UI.Notify(json);
        }

        private void GetSheets()
        {
            List<Sheet> sheets = _xlService.GetSheets();;
            string json = JsonSerializer.Serialize(sheets, _serialzerOptions);
            UI.Notify(json);
        }

        private void GetSheet()
        {
            string sheetId = UI.Prompt("Enter Sheet Id: ", "0");
            Int32.TryParse(sheetId, out int id);
            Sheet s = _xlService.GetSheet(id);
            string json = JsonSerializer.Serialize(s, _serialzerOptions);
            UI.Notify(json);
        }

        private void GetRows()
        {
            List<Row> rows = _xlService.GetRows();
            string json = JsonSerializer.Serialize(rows, _serialzerOptions);
            UI.Notify(json);
        }
        private void GetRow()
        {
            string rowId = UI.Prompt("Enter Row Id: ", "0");
            Int32.TryParse(rowId, out int id);
            Row r = _xlService.GetRow(id);
            string json = JsonSerializer.Serialize(r, _serialzerOptions);
            UI.Notify(json);
        }
    }
}
