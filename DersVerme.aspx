<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Sub.Master" 
AutoEventWireup="true" CodeBehind="DersVerme.aspx.cs" Inherits="YeniErasmus.ErasmusTurk.DersVerme" %>
<%@ Register Src="../Controls/Icerik.ascx" TagName="Icerik" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="cpBaslik" ContentPlaceHolderID="cpBaslik" runat="server">
    DERS VERME HAREKETLİLİĞİ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Icerik ID="Icerik" runat="server" mySource="ErasmusTurk/DersVerme.html" />
</asp:Content>
