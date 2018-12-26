<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ActualizareTaxe.aspx.cs" Inherits="ActualizareTaxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="search-view">
        <div class="row">
            <asp:Label ID="labelParola" Text="Introduceti parola:" runat="server"></asp:Label>
            <asp:TextBox ID="textCauta" runat="server" BorderStyle="Inset" TextMode="Password"></asp:TextBox>
            <asp:Button ID="buttonCauta" runat="server" Text="Cauta" BorderStyle="Outset" OnClick="buttonCauta_Click" />
        </div>
    </div>
</asp:Content>

