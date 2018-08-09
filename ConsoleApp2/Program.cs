using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;

namespace ConsoleApp2
{
    public class Program
    {
        public object HttpContext { get; private set; }

        public void Main(string[] args)
        {
            System.Security.Principal.WindowsIdentity identity = HttpContext.Current.Request.LogonUserIdentity;
            string identityName = identity.Name;
            Console.WriteLine(identityName);
        }
    }
}
