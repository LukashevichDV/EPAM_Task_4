using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace WindowService
{
    public class Watcher
    {
        private RecordsHandler RecordsHandler;
        private FileSystemWatcher FileWatcher;
        private Task task;

        public Watcher()
        {
            RecordsHandler = new RecordsHandler();
            FileWatcher = new FileSystemWatcher
            {
                Path = ConfigurationManager.AppSettings["Path"],
                Filter = "*.csv",
                NotifyFilter = NotifyFilters.FileName
            };

            FileWatcher.Changed += OnChanged;
            FileWatcher.Created += OnChanged;
            FileWatcher.EnableRaisingEvents = true;
        }

        public void Run()
        {

        }

        public void OnChanged(object source, FileSystemEventArgs e)
        {
            task = new Task(() => CallParse(source, e));
            task.Start();
        }

        public void CallParse(object source, FileSystemEventArgs e)
        {
            var path = e.FullPath;
            RecordsHandler.SaveRecords(path);
        }

        public void Dispose()
        {
            FileWatcher.Dispose();
        }
    }
}