﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="body" runat="server">

    <div class="jumbotron">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Image ID="Image1" runat="server" />
                    <div class ="labelTitle">
                        <asp:Label ID="LabelDefaultMessage" runat="server" Text="Aplicatie salarizare"></asp:Label>
                        <asp:Timer ID="Timer2" runat="server" Interval="2000" OnTick="Timer2_Tick">
                        </asp:Timer>
                    </div>
                  <asp:Label ID="Label1" runat="server" Text="Ora"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>

    
</asp:Content>
