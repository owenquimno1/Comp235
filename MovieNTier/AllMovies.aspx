<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllMovies.aspx.cs" Inherits="MovieNTier.AllMovies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <!--Data Source-->
<asp:ObjectDataSource ID="odsmovies" runat="server" TypeName="MovieApp.MovieUtils.MovieUtilities.MovieUtilities" SelectMethod="SelectAll" UpdateMethod="Update">
    <UpdateParameters>
        <asp:Parameter Name="Title" />
        <asp:Parameter Name="ID" />
        <asp:Parameter Name="Director" />
    </UpdateParameters>
</asp:ObjectDataSource>
<!-- Page content-->
<asp:GridView ID="grdMovies" runat="server" DataSourceID="odsMovies">
    <Columns>
        <asp:CommandFIeld ShowEditButton="true" />
    </Columns>
</asp:GridView>
 











</asp:Content>
