<%@ Page Title="FoodLog" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FoodLog.aspx.cs" Inherits="FoodLog.FoodLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <!-- SQL DATASOURCE -->
    <!-- MEAL DATA SOURCE -->
    <asp:SqlDataSource ID="SQLMeal" runat="server"
        ConnectionString="<%$ ConnectionStrings:FoodLogConn %>"
        ProviderName="<%$ ConnectionStrings:FoodLogConn.ProviderName %>"
        SelectCommand="SELECT * FROM [Meal]"></asp:SqlDataSource>

    <!-- MEAL DATA SOURCE -->
    <asp:SqlDataSource ID="SQLFoodLog" runat="server"
        ConnectionString="<%$ ConnectionStrings:FoodLogConn %>"
        SelectCommand="SELECT * FROM [FoodLog] WHERE ([MealType] = @MealType2)" InsertCommand="INSERT INTO FoodLog(ItemName, PreparedBy, ConsumedAt, ImagePath, MealType) VALUES (@ItemName, @PreparedBy, @ConsumedAt, @ImagePath, @MealType)">
        <InsertParameters>
            <asp:Parameter Name="ItemName" />
            <asp:Parameter Name="PreparedBy" />
            <asp:Parameter Name="ConsumedAt" />
            <asp:Parameter Name="ImagePath" />
            <asp:Parameter Name="MealType" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="MealType2" QueryStringField="mealTypeId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>


    <!-- SQL DATASOURCE -->

    <h1>Food Log</h1>

    <!-- Meal REPEATER -->
    <asp:Repeater ID="rptMeal" runat="server" DataSourceID="SQLMeal">
        <ItemTemplate>
            <a href='FoodLog.aspx?mealTypeID=<%#Eval("Id") %>'><%#Eval("MealDescription")%> </a>|
        </ItemTemplate>
    </asp:Repeater>

    <br />
    <hr />
    <br />

    <!-- FoodLog REPEATER -->

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SQLFoodLog" CssClass="table">
        <Columns>

            <asp:ImageField DataImageUrlField="ImagePath" HeaderText="Image" ControlStyle-Width="250"></asp:ImageField>
            <asp:BoundField DataField="ItemName" HeaderText="ItemName" SortExpression="ItemName" />
            <asp:BoundField DataField="PreparedBy" HeaderText="PreparedBy" SortExpression="PreparedBy" />
            <asp:BoundField DataField="ConsumedAt" HeaderText="ConsumedAt" SortExpression="ConsumedAt" />
            
        </Columns>

    </asp:GridView>

    <br />
    <hr />
    <br />

    <h1>Add Food</h1>
    <!-- Add Food -->
    <asp:Panel ID="Panel1" runat="server" BackColor="White" Width="50%">
        <div class="form-group">
            <label>Item Name: </label>
            <asp:TextBox ID="txtItemName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label>Prepared by: </label>
            <asp:TextBox ID="txtPreparedBy" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label>Consumed At: </label>
            <asp:TextBox ID="txtConsumedAt" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>

        <div class="form-group">
            <label>Image: </label>
            <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label>Meal Type: </label>
            <asp:DropDownList ID="ddlMealType" runat="server" DataSourceID="SQLMeal" DataTextField="MealDescription" DataValueField="Id"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Button ID="btnAdd" runat="server" Text="Add Food" OnClick="btnAdd_Click" CssClass="btn btn-primary" />
        </div>

    </asp:Panel>
</asp:Content>
