using System.ServiceProcess;

namespace WindowService
{
    public partial class ManagerService : ServiceBase
    {
        private Watcher _watcher;
        public ManagerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _watcher = new Watcher();
        }

        protected override void OnStop()
        {
            _watcher.Dispose();
        }
    }
}