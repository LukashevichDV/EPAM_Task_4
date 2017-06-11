using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace WindowService
{
    public class Watcher
    {
        private RecordsHandler _recordsHandler;
        private FileSystemWatcher _fileWatcher;
        private Task task;

        public Watcher()
        {
            _recordsHandler = new RecordsHandler();
            _fileWatcher = new FileSystemWatcher();
            _fileWatcher.Path = ConfigurationManager.AppSettings["Path"];
            _fileWatcher.Filter = "*.csv";
            _fileWatcher.NotifyFilter = NotifyFilters.FileName;

            _fileWatcher.Changed += new FileSystemEventHandler(OnChanged);
            _fileWatcher.Created += new FileSystemEventHandler(OnChanged);
            _fileWatcher.EnableRaisingEvents = true;
        }

        public void run()
        {

        }
        public void OnChanged(object source, FileSystemEventArgs e)
        {
            task = new Task(() => CallParse(source, e));
            task.Start();
        }
        public void CallParse(object source, FileSystemEventArgs e)
        {
            string path;
            path = e.FullPath;
            _recordsHandler.SaveRecords(path);
        }
        public void Dispose()
        {
            _fileWatcher.Dispose();
        }
    }
}