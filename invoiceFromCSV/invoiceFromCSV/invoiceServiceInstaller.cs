using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration.Install;
using System.ComponentModel;
using System.ServiceProcess;

namespace invoiceFromCSV
{
    [RunInstaller(true)]
    public class invoiceServiceInstaller : Installer
    {
        public invoiceServiceInstaller()
        {
            var processInstaller = new ServiceProcessInstaller();
            var serviceInstaller = new ServiceInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;

            serviceInstaller.DisplayName = "csv invoice service";
            serviceInstaller.StartType = ServiceStartMode.Manual;

            //must be the same as what was set in Program's constructor
            serviceInstaller.ServiceName = "csv invoice service";

            this.Installers.Add(processInstaller);
            this.Installers.Add(serviceInstaller);


        }
    }
}
