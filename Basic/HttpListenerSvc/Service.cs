using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;



namespace HttpListenerSvc
{
    class HttpListenerService
    {
        private static HttpListener _listener;

        public void StartEntryPoint()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost/httplistenersvc/");
            _listener.Start();
            _listener.BeginGetContext(OnClientConnectionContext, null);

        }

        private static void OnClientConnectionContext(IAsyncResult ar)
        {
            var ctx = _listener.EndGetContext(ar);
            _listener.BeginGetContext(OnClientConnectionContext, null);

            // Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " Handling request");

            var buf = Encoding.ASCII.GetBytes($"Hello dear client at {DateTime.UtcNow.ToString()}");
            ctx.Response.ContentType = "text/plain";

            // simulate work
            // Thread.Sleep(10000);

            ctx.Response.OutputStream.Write(buf, 0, buf.Length);
            ctx.Response.OutputStream.Close();


            // Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " completed");
        }
        public void StopEntryPoint()
        {
            // Console.WriteLine("Stopping Service");
            _listener.Stop();
        }
    }
}
