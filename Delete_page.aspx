<%@ Page Title="Delete Confirmation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete_page.aspx.cs" Inherits="Clocktos_Assignment.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Select valid credentials </h3>

        <header>

            <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<link rel="stylesheet" href="https://code.jquery.com/ui/1.13.0/themes/base/jquery-ui.css">
<script src="https://code.jquery.com/ui/1.13.0/jquery-ui.min.js"></script>
        </header>
       

        <div class="container">
  <div class="row">
    <div class="col-md-6">
      <label for="ddlSubjectCode" class="form-label">Subject Code:</label>
      <asp:DropDownList ID="ddlSubjectCode" runat="server" CssClass="form-select">
        
        <asp:ListItem Text="Select Subject Code" Value=""></asp:ListItem>
        <asp:ListItem Text="CZ23C" Value="CZ23C"></asp:ListItem>
        <asp:ListItem Text="CZ24C" Value="CZ24C"></asp:ListItem>
          <asp:ListItem Text="CZ25C" Value="CZ25C"></asp:ListItem>
          <asp:ListItem Text="CZ26C" Value="CZ26C"></asp:ListItem>
          <asp:ListItem Text="CZ27C" Value="CZ27C"></asp:ListItem>

       
      </asp:DropDownList>
    </div>
    <div class="col-md-6">
      <label for="calendarDate" class="form-label">Choose Date:</label>
      <div class="input-group">
        <asp:TextBox ID="calendarDate" runat="server" CssClass="form-control datepicker_2" placeholder="Select Date"></asp:TextBox>
        <span class="input-group-text">
          <i class="bi bi-calendar"></i>
        </span>
      </div>
    </div>
  </div>
            <div class="row mt-3">
            <div class="col-md-6">
      <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                <asp:Button ID="cancel_btn" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="btncancel_Click" />
    </div>
  </div>
</div>
        
       

     </main>

      <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/5.3.0/js/bootstrap.bundle.min.js"></script>
   
     <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.js"></script>

    <script>
        $(document).ready(function () {
            $('.datepicker_2').datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true

            });
        });
    </script>
</asp:Content>
