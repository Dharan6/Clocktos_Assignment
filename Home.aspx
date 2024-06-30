<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Clocktos_Assignment._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>

        <style>
    .custom-gridview {
        width: 800px; 
        border-collapse: collapse; 
    }

    .custom-gridview th,
    .custom-gridview td {
        border: 1px solid #ccc;
        padding: 4px;
    }
</style>


    </header>
    <main>
      
        <div style="background-color: #007bff; padding: 10px; color: #fff;">
    <h4>Criteria</h4>
</div>
<div style="padding: 10px;">
    <div class="row mb-3">
        <div class="col-md-4">
            <asp:Label ID="LabelDegree" runat="server" Text="Degree:" CssClass="text-muted"></asp:Label>
            <asp:DropDownList ID="DropDownListDegree" runat="server" CssClass="form-control">
                
                <asp:ListItem Text="Select Degree" Value=""></asp:ListItem>
                <asp:ListItem Text="B.com" Value="B.com"></asp:ListItem>
                <asp:ListItem Text="BCA" Value="BCA"></asp:ListItem>
                <asp:ListItem Text="ComputerScience" Value="ComputerSciences"></asp:ListItem>
                <asp:ListItem Text="BBA" Value="BBA"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-4">
            <asp:Label ID="LabelBranch" runat="server" Text="Branch:" CssClass="text-muted"></asp:Label>
            <asp:DropDownList ID="DropDownListBranch" runat="server" CssClass="form-control">
                
                <asp:ListItem Text="Select Branch" Value=""></asp:ListItem>
                <asp:ListItem Text="General" Value="General"></asp:ListItem>
                <asp:ListItem Text="Random" Value="Random"></asp:ListItem>
                <asp:ListItem Text="Group" Value="Group"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-4">
            <asp:Label ID="LabelSubject" runat="server" Text="Subject:" CssClass="text-muted"></asp:Label>
            <asp:DropDownList ID="DropDownListSubject" runat="server" CssClass="form-control">
                
                <asp:ListItem Text="Select Subject" Value=""></asp:ListItem>
                <asp:ListItem Text="BANKING THEORY AND LAW PRACTISE" Value="BANKING THEORY AND LAW PRACTISE"></asp:ListItem>
                <asp:ListItem Text="SUBJECT ONE" Value="SUBJECT ONE"></asp:ListItem>
                <asp:ListItem Text="SUBJECT TWO" Value="SUBJECT TWO"></asp:ListItem>
                <asp:ListItem Text="SUBJECT THREE" Value="SUBJECT THREE"></asp:ListItem>
                <asp:ListItem Text="SUBJECT FOUR" Value="SUBJECT FOUR"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="text-end">
         <asp:Button ID="Refresh" runat="server" Text="Page Refresh" CssClass="btn btn-primary" OnClick="ButtonRefresh_Click" />
        <asp:Button ID="ButtonSearch" runat="server" Text=" Go " CssClass="btn btn-primary" OnClick="ButtonSearch_Click" />
    </div>
</div>


        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" CssClass="custom-gridview" >
          
        </asp:GridView>

        <asp:GridView ID="GridViewSearchResults" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered custom-gridview" Visible="false" />

    </main>

  

</asp:Content>


