<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TiparireFluturas.aspx.cs" Inherits="TiparireFluturas" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:Label ID="DBQuery" runat="server" Text="Label" Visible="False"></asp:Label>
    <div class="search-view">
        <div class="row">
            <asp:TextBox ID="textCauta" runat="server" BorderStyle="Inset"></asp:TextBox>
            <asp:Button ID="buttonCauta" runat="server" Text="Cauta" BorderStyle="Outset" OnClick="buttonCauta_Click" />
            <asp:Button ID="buttonRenunta" runat="server" Text="Renunta" BorderStyle="Outset" OnClick="buttonRenunta_Click" />
        </div>
    </div>
    <div class="row">
        <div class="actualizare-tabel-tiparire">
            <div class="tabel-salarii">
                <asp:GridView ID="gridSalarii" AutoGenerateColumns="True" AllowPaging="True" BorderStyle="Inset" PageSize="6" runat="server" Width="700px" DataKeyNames="NR_CRT" OnSelectedIndexChanging="gridSalarii_SelectedIndexChanging">
                    <HeaderStyle BackColor="DarkGray" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <RowStyle BackColor="White" />
                </asp:GridView>

            </div>
        </div>
        <div class="search-view">
            <div class="row">
                <asp:Label ID="Label1" runat="server" Text="Raport: &amp;nbsp&amp;nbsp&amp;nbsp" Font-Size="Smaller"></asp:Label>
                <asp:TextBox ID="NUME_RAPORT" runat="server" BorderStyle="Inset" Width="200px" CssClass="actualizare-field"></asp:TextBox>
                <asp:Button ID="BTN_EXPORTA" runat="server" Text="Exporta Fluturas" Height="37px" Width="141px" OnClick="BTN_EXPORTA_Click" />
            </div>
        </div>
        <div class="row">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" DisplayStatusbar="False" DisplayToolbar="False" EnableToolTips="False" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" Height="50px" SeparatePages="False" ToolPanelView="None" Width="350px" />
        </div>
    </div>
</asp:Content>

