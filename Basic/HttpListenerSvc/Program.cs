using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace HttpListenerSvc
{
    class Program
    {
        static void Main(string[] args)
        {

            var rc = HostFactory.Run(x =>
            {
                x.Service<HttpListenerService>(s =>
                {
                    s.ConstructUsing(name => new HttpListenerService());
                    s.WhenStarted(tc => tc.StartEntryPoint());
                    s.WhenStopped(tc => tc.StopEntryPoint());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Sample Topshelf Http Listener Service");
                x.SetDisplayName("Basic HttpListener Service");
                x.SetServiceName("BasicHttpListenerService");
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;

        }
    }
}
