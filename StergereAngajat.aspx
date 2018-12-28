<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StergereAngajat.aspx.cs" Inherits="StergereAngajat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="search-view">
        <div class="row">
            <asp:TextBox ID="textCauta" runat="server" BorderStyle="Inset"></asp:TextBox>
            <asp:Button ID="buttonCauta" runat="server" Text="Cauta" BorderStyle="Outset" OnClick="buttonCauta_Click" />
        </div>
    </div>
    <div class="tabel-salarii">
        <asp:GridView ID="gridSalarii" AutoGenerateColumns="True" AllowPaging="True" BorderStyle="Inset" PageSize="6" runat="server" Width="700px" DataKeyNames="NR_CRT" OnPageIndexChanging="gridSalarii_PageIndexChanging" OnSelectedIndexChanging="gridSalarii_SelectedIndexChanging">
            <Columns>
                <asp:CommandField ShowSelectButton="true" />
                <asp:BoundField DataField="NR_CRT" HeaderText="Nr. Crt" SortExpression="NR_CRT" />
                <asp:BoundField DataField="NUME" HeaderText="Nume" SortExpression="NUME" />
                <asp:BoundField DataField="PRENUME" HeaderText="Prenume" SortExpression="PRENUME" />
                <asp:BoundField DataField="FUNCTIE" HeaderText="Functie" SortExpression="FUNCTIE" />
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
            <div class="row">
                <asp:Label ID="nrCrtLabel" runat="server" Text="Nr. Crt"></asp:Label>
                <asp:TextBox ID="NR_CRT" runat="server" BorderStyle="Ridge" Enabled="false" Width="100px"></asp:TextBox>
                <asp:Label ID="numeLabel" runat="server" Text="Nume "></asp:Label>
                <asp:TextBox ID="NUME" runat="server" BorderStyle="Ridge" Enabled="true" Width="200px"></asp:TextBox>
                <asp:Label ID="prenumeLabel" runat="server" Text="Prenume"></asp:Label>
                <asp:TextBox ID="PRENUME" runat="server" BorderStyle="Ridge" Enabled="true" Width="200px"></asp:TextBox>
                <asp:Label ID="functieLabel" runat="server" Text="Functie"></asp:Label>
                <asp:TextBox ID="FUNCTIE" runat="server" BorderStyle="Ridge" Enabled="true" Width="200px"></asp:TextBox>
            </div>
        <p></p>
         <p></p>
        <div class="row">
            <asp:Label ID="salarBazaLabel" runat="server" Text="Salar baza"></asp:Label>
            <asp:TextBox ID="SALAR_BAZA" runat="server" BorderStyle="Ridge" Enabled="true" Width="100px"></asp:TextBox>
            <asp:Label ID="sporLabel" runat="server" Text="Spor "></asp:Label>
            <asp:TextBox ID="SPOR" runat="server" BorderStyle="Ridge" Enabled="true" Width="100px"></asp:TextBox>
            <asp:Label ID="premiiBruteLabel" runat="server" Text="Premii brute"></asp:Label>
            <asp:TextBox ID="PREMII_BRUTE" runat="server" BorderStyle="Ridge" Enabled="true" Width="100px"></asp:TextBox>
            <asp:Label ID="totalBrutLabel" runat="server" Text="Total Brut"></asp:Label>
            <asp:TextBox ID="TOTAL_BRUT" runat="server" BorderStyle="Ridge" Enabled="false" Width="100px"></asp:TextBox>
        </div>
        <p></p>
    <p></p>
        <div class="row">
            <asp:Label ID="brutImpozitabilLabel" runat="server" Text="Brut impozitabil"></asp:Label>
            <asp:TextBox ID="BRUT_IMPOZITABIL" runat="server" BorderStyle="Ridge" Enabled="false" Width="100px"></asp:TextBox>
            <asp:Label ID="impozitLabel" runat="server" Text="Impozit"></asp:Label>
            <asp:TextBox ID="IMPOZIT" runat="server" BorderStyle="Ridge" Enabled="false" Width="100px"></asp:TextBox>
            <asp:Label ID="casLabel" runat="server" Text="CAS"></asp:Label>
            <asp:TextBox ID="CAS" runat="server" BorderStyle="Ridge" Enabled="false" Width="100px"></asp:TextBox>
            <asp:Label ID="cassLabel" runat="server" Text="CASS"></asp:Label>
            <asp:TextBox ID="CASS" runat="server" BorderStyle="Ridge" Enabled="false" Width="100px"></asp:TextBox>
        </div>
        <p></p>
    <p></p>
        <div class="row">
            <asp:Label ID="retineriLabel" runat="server" Text="Retineri"></asp:Label>
            <asp:TextBox ID="RETINERI" runat="server" BorderStyle="Ridge" Enabled="true" Width="100px"></asp:TextBox>
            <asp:Label ID="viratCardLabel" runat="server" Text="Virat Card"></asp:Label>
            <asp:TextBox ID="VIRAT_CARD" runat="server" BorderStyle="Ridge" Enabled="false" Width="100px"></asp:TextBox>
        </div>
        <p></p>
    <p></p>
        <div class="search-view">
            <div class="row">
                <asp:Button ID="btnSalveaza" runat="server" Text="Sterge" BorderStyle="Outset" OnClick="buttonStergere_Click" />
                <asp:Button ID="btnRenunta" runat="server" Text="Renunta" BorderStyle="Outset" OnClick="buttonRenunta_Click" />
            </div>
        </div>
    </div>

</asp:Content>

