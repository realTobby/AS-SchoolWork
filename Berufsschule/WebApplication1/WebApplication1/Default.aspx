<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" Title="Zinzeszins-Rechner"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
    
<body>
    <header>
        <asp:Label ID="labelHeader" Text="Zinseszins-Rechnung" runat="server"></asp:Label>
    </header>
    <form id="form1" runat="server">
       <asp:Table runat="server">
           <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Betrag in Euro"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbx_betragEuro" OnTextChanged="tbx_changed" AutoPostBack="true" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Startjahr"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbx_startjahr" OnTextChanged="tbx_changed" AutoPostBack="true" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Laufzeit in Jahren"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbx_laufzeit" OnTextChanged="tbx_changed" AutoPostBack="true" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Zinssatz"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbx_zinssatz" OnTextChanged="tbx_changed" AutoPostBack="true" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btn_calc" runat="server" OnClick="ButtonCalc_Click" Text="Berechne"></asp:Button>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lbl_result" runat="server" Text="Ergebnis"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
       </asp:Table>
    </form>
</body>
</html>
