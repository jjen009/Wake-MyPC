<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Wake_MyPC.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView
            ID="GridView1"
            runat="server"
            AutoGenerateColumns="False"
            AutoGenerateSelectButton="True"
            DataSourceID="SqlDataSource1"
            OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
            DataKeyNames ="MacAddress"
            >
            <Columns>
                <asp:BoundField DataField="MachineHostName" HeaderText="MachineHostName" SortExpression="MachineHostName" />
                <asp:BoundField DataField="IP" HeaderText="IP" SortExpression="IP" Visible="false" />
                <asp:BoundField DataField="MacAddress" HeaderText="MacAddress" SortExpression="MacAddress" Visible="false" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource
            ID="SqlDataSource1"
            runat="server"
            ConnectionString="<%$ ConnectionStrings:LogonLogging %>"
            OnSelecting="SqlDataSource1_Selecting"
            SelectCommand=";WITH cteRowNumber AS ( SELECT MachineHostName, UserName, IP, MacAddress, row_number() OVER ( partition BY MachineHostName ORDER BY LogonTime DESC ) AS rownum FROM [CSU Logging].dbo.SessionLogging WHERE UserName =@UPI AND MachineHostName LIKE 'bef-%-d[0-9][0-9]' AND LogonTime &gt;= DATEADD(day,-90, GETDATE()) ) SELECT MachineHostName,IP, MacAddress FROM cteRowNumber WHERE rownum=1"
            >
            <SelectParameters>
                <asp:Parameter DefaultValue="" Name="UPI" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
