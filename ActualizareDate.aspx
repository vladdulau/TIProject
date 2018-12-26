<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ActualizareDate.aspx.cs" Inherits="ActualizareDate" %>


<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="search-view">
        <div class="row">
            <asp:TextBox ID="textCauta" runat="server" BorderStyle="Inset"></asp:TextBox>
            <asp:Button ID="buttonCauta" runat="server" Text="Cauta" BorderStyle="Outset" OnClick="buttonCauta_Click" />
        </div>
    </div>
    <div class="tabel-salarii">
        <asp:GridView ID="gridSalarii" AutoGenerateColumns="True" AllowPaging="True" BorderStyle="Inset" PageSize="6" runat="server" Width="700px" DataKeyNames="NR_CRT" OnSelectedIndexChanged="gridSalarii_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="true" />
                <asp:BoundField DataField="NR_CRT" HeaderText="Nr. Crt" SortExpression="NR_CRT"/>
                <asp:BoundField DataField="NUME" HeaderText="Nume" SortExpression="NUME" />
                <asp:BoundField DataField="PRENUME" HeaderText="Prenume" SortExpression="PRENUME" />
                <asp:BoundField DataField="FUNCTIE" HeaderText="Functie" SortExpression="FUNCTIE" />
            </Columns>
            <HeaderStyle BackColor="DarkGray" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <RowStyle BackColor="White" />
        </asp:GridView>
    </div>

    <div class="actualizare-campuri">
    
    </div>

</asp:Content>

