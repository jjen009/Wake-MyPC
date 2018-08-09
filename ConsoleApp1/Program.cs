using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public void Main(string[] args)
        {
            System.Security.Principal.WindowsIdentity identity = HttpContext.Current.Request.LogonUserIdentity;
            string identityName = identity.Name;
            Console.WriteLine(identityName);
        }
    }
}
