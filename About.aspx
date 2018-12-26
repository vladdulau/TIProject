<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="body" runat="server">
    <div class="jumbotron">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" ViewStateMode="Enabled">
         <Columns>
                <asp:BoundField DataField="NR_CRT" HeaderText="NR_CRT" SortExpression="NR_CRT" ReadOnly="True" />
                <asp:BoundField DataField="NUME" HeaderText="NUME" SortExpression="NUME" />
                <asp:BoundField DataField="PRENUME" HeaderText="PRENUME" SortExpression="PRENUME" />
                <asp:BoundField DataField="FUNCTIE" HeaderText="FUNCTIE" SortExpression="FUNCTIE" />
            </Columns>
    </asp:GridView>


   </div>
</asp:Content>
