namespace WindowService
{
    public class RecordsHandler
    {
        private DbHandler DbHandler;
        private Parser Parser;
        public RecordsHandler()
        {
            DbHandler = new DbHandler();
            Parser = new Parser();
        }

        public void SaveRecords(string path)
        {
            var records = Parser.ParseData(path);
            foreach (var record in records)
            {
                DbHandler.AddToDatabase(record);
            }
        }
    }
}