﻿namespace WindowService
{
    public class RecordsHandler
    {
        private DbHandler _dbHandler;
        private Parser _parser;
        public RecordsHandler()
        {
            _dbHandler = new DbHandler();
            _parser = new Parser();
        }
        public void SaveRecords(string path)
        {
            var records = _parser.ParseData(path);
            foreach (var record in records)
            {
                _dbHandler.AddToDatabase(record);
            }
        }
    }
}