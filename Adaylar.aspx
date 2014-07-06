<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Sub.master" 
AutoEventWireup="true" CodeBehind="Adaylar.aspx.cs" Inherits="YeniErasmus.ErasmusTurk.Adaylar" %>
<%@ Register Src="../Controls/Icerik.ascx" TagName="Icerik" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="cpBaslik" ContentPlaceHolderID="cpBaslik" runat="server">
    ADAYLAR
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <uc1:Icerik ID="Icerik" runat="server" mySource="ErasmusTurk/Adaylar.html" />
</asp:Content>
