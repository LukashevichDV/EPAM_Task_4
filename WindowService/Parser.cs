﻿using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WindowService
{
    public class Parser
    {
        public Parser()
        {
        }

        public IList<Journal> ParseData(string path)
        {
            string managerName;
            string[] param;
            managerName = Path.GetFileName(path).Split('_').First();
            IList<Journal> records = new List<Journal>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    param = sr.ReadLine().Split(',');
                    records.Add(new Journal(managerName, param[0], param[1], param[2], param[3]));
                }
            }
            return records;
        }
    }
}