using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace BasicSvc
{
    class Program
    {
        static void Main(string[] args)
        {

            var rc = HostFactory.Run(x =>                                  
            {
                x.Service<Service>(s =>                                  
                {
                    s.ConstructUsing(name => new Service());                
                    s.WhenStarted(tc => tc.StartEntryPoint());                         
                    s.WhenStopped(tc => tc.StopEntryPoint());                          
                });
                x.RunAsLocalSystem();                                      

                x.SetDescription("Sample Topshelf Basic Service");            
                x.SetDisplayName("Basic Service");                                 
                x.SetServiceName("BasicService");                          
            });                                                             

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  
            Environment.ExitCode = exitCode;
        }
    }
}
