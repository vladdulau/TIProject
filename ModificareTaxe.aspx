<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ModificareTaxe.aspx.cs" Inherits="ModificareTaxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="tabel-salarii">
        <asp:GridView ID="gridSalarii" AutoGenerateColumns="True" AllowPaging="True" BorderStyle="Inset" PageSize="6" runat="server" Width="700px" DataKeyNames="NR_CRT">
            <Columns>
                <asp:CommandField ShowSelectButton="true" />
                <asp:BoundField DataField="DATA_MODIFICARE" HeaderText="Ultima Modificare" SortExpression="NR_CRT" />
                <asp:BoundField DataField="CAS" HeaderText="CAS" SortExpression="CAS" />
                <asp:BoundField DataField="CASS" HeaderText="CASS" SortExpression="CASS" />
                <asp:BoundField DataField="IMPOZIT" HeaderText="IMPOZIT" SortExpression="IMPOZIT" />
            </Columns>
            <HeaderStyle BackColor="DarkGray" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <RowStyle BackColor="White" />
        </asp:GridView>
    </div>
    <p></p>
    <p></p>
    <p></p>
    <p></p>
    <div class="actualizare-campuri">
        <div class="aranjare-campuri">
            <div class="row">
                <asp:Label ID="casLabel" runat="server" Text="CAS"></asp:Label>
                <asp:TextBox ID="CAS" runat="server" BorderStyle="Ridge" Enabled="true" Width="100px"></asp:TextBox>
                <asp:Label ID="cassLabel" runat="server" Text="CASS "></asp:Label>
                <asp:TextBox ID="CASS" runat="server" BorderStyle="Ridge" Enabled="true" Width="200px"></asp:TextBox>
                <asp:Label ID="impozitLabel" runat="server" Text="Impozit"></asp:Label>
                <asp:TextBox ID="IMPOZIT" runat="server" BorderStyle="Ridge" Enabled="true" Width="200px"></asp:TextBox>
            </div>
        </div>
      </div>
        <p></p>
        <p></p>

        <div class="search-view">
            <div class="row">
                <asp:Button ID="btnSalveaza" runat="server" Text="Salveaza" BorderStyle="Outset" />
                <asp:Button ID="btnRenunta" runat="server" Text="Renunta" BorderStyle="Outset" />
            </div>
        </div>

     <div class="actualizare-campuri">
        <div class="aranjare-campuri">
            <div class="row">
                <asp:Label ID="Label1" runat="server" Text="Vechea parola"></asp:Label>
                <asp:TextBox ID="oldPassword" runat="server" BorderStyle="Ridge" Enabled="true" Width="100px"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="Noua parola"></asp:Label>
                <asp:TextBox ID="newPassword" runat="server" BorderStyle="Ridge" Enabled="true" Width="200px"></asp:TextBox>
                <asp:Button ID="savePassword" Text="Schimba parola" runat="server" BorderStyle="Ridge" Enabled="true" Width="200px"></asp:Button>
            </div>
        </div>
      </div>
</asp:Content>

