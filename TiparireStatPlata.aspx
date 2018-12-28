<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TiparireStatPlata.aspx.cs" Inherits="TiparireStatPlata" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="search-view">
        <div class="row">
            <asp:Label ID="label1" runat="server" Text="Nume raport"></asp:Label>
            <asp:TextBox ID="textRaport" runat="server" BorderStyle="Inset" ></asp:TextBox>
            <asp:Button ID="buttonExporta" runat="server" Text="Cauta" BorderStyle="Outset" OnClick="buttonExporta_Click" />
        </div>
    </div>

    <div class="row">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" DisplayStatusbar="False" DisplayToolbar="False" EnableToolTips="False" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" Height="50px" SeparatePages="False" ToolPanelView="None" Width="350px" />
    </div>

</asp:Content>

