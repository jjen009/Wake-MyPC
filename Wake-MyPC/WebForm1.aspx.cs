using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace Wake_MyPC
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = Request.ServerVariables["LOGON_USER"];
            string UPI = userName.Substring(userName.LastIndexOf("\\") + 1);
            SqlDataSource1.SelectParameters["UPI"].DefaultValue = UPI;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string machine = row.Cells[1].Text;
            int indexNumber = row.DataItemIndex;
            string MACAddress = GridView1.DataKeys[indexNumber]["MacAddress"].ToString();
            Response.Write("You selected machine " + machine + " with MAC Address " + MACAddress);
            DoWOL(MACAddress);
        }

        static void DoWOL(string MACAddress)
        {

            //using (PowerShell PowerShellInstance = PowerShell.Create())
            //{
            //    PowerShellInstance.AddScript(
            //        @"param($MACAddress) Invoke-Command -ComputerName bef-4136-d02 -ScriptBlock {do-WOL $args[0]} -ArgumentList $MACAddress -ConfigurationName 'Remote WOL'
            //        $currentUser = [System.Security.Principal.WindowsIdentity]::GetCurrent().Name
            //        'jj was here '+$MACAddress | out-file -filepath 'c:\temp\jjout2.log' -encoding ascii
            //        'currentUser = ' + $currentUser | out-file -filepath 'c:\temp\jjout2.log' -encoding ascii -append"
            //        );
            //    PowerShellInstance.AddParameter("MACAddress", MACAddress);
            //    PowerShellInstance.Invoke();
            //}
        }
        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            if (row != null)
            {
                //Response.Write("You selected " + row.Cells[0].Text + ".");
            }
        }
    }
}
