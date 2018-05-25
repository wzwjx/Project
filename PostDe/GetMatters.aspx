<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetMatters.aspx.cs" Inherits="PostDe.GetMatters" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 125px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Panel ID="Panel1" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Sorting:"></asp:Label>
                <br />
                <select id="Select1" runat="server" class="auto-style1" name="Select1" >
                    <option>choose value</option>
                    <option>id</option>
                    <option>createtime</option>
                    <option>createuserid</option>
                    <option>lasttime</option>
                    <option>moduleid</option>
                    
                </select>
                <asp:Button ID="Button1" runat="server" Text="Sorting  Asce" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Sorting  Desc" OnClick="Button2_Click" />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Select:"></asp:Label>
                <br />
                ID:<input id="Text1" type="text" runat="server" />
                Name:<input id="Text2" type="text" runat="server" />
                Createuserid:
                <input id="Text3" type="text" runat="server"  />
                Createusername:
                <input id="Text4" type="text" runat="server" />
                <asp:Button ID="Button3" runat="server" Text="Seleting" OnClick="Button3_Click" />
                &nbsp;
                <asp:Button ID="Button4" runat="server" Text="Revert" OnClick="Button4_Click" />
            </asp:Panel>
            <asp:GridView ID="GridView1" runat="server"  CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
