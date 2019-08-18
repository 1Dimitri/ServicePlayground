using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BasicSvc
{
    class Service
    {
        public void StartEntryPoint()
        {
            Console.WriteLine("Starting Service");
        }

        public void StopEntryPoint()
        {
            Console.WriteLine("Stopping Service");
        }
    }
}
