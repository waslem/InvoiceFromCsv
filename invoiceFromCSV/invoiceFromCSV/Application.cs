using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;


namespace invoiceFromCSV
{
    class Application : ServiceBase
    {
        public static void Main(string[] args)
        {
            ServiceBase.Run(new Application());
        }

        public Application()
        {
            this.ServiceName = "csv invoice service";
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            base.OnStop();
        }
    }
}
