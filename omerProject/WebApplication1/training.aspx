<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="training.aspx.cs" Inherits="WebApplication1.training" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .training-container {
            max-width: 800px;
            margin: 20px auto;
            padding: 20px;
            background-color: #f8f9fa;
            border-radius: 10px;
            box-shadow: 0 0 15px rgba(0,0,0,0.1);
        }

        .form-group {
            margin-bottom: 20px;
            padding: 15px;
            background-color: white;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.05);
        }

        .form-label {
            display: block;
            margin-bottom: 8px;
            font-weight: 600;
            color: #333;
            font-size: 14px;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            margin-bottom: 5px;
            font-size: 14px;
        }

        .form-control:focus {
            border-color: #4a90e2;
            outline: none;
            box-shadow: 0 0 5px rgba(74,144,226,0.3);
        }

        .validation-error {
            color: #dc3545;
            font-size: 12px;
            margin-top: 5px;
            display: block;
        }

        /* עיצוב משופר לכפתורים */
        .button-group {
            display: flex;
            gap: 10px;
            margin-top: 20px;
            justify-content: center;
            flex-wrap: wrap;
        }

        .btn {
            padding: 12px 24px;
            border: none;
            border-radius: 6px;
            cursor: pointer;
            font-weight: 600;
            font-size: 14px;
            transition: all 0.2s ease;
            min-width: 120px;
            text-align: center;
        }

        .btn-primary {
            background-color: #4a90e2;
            color: white;
            box-shadow: 0 2px 4px rgba(74,144,226,0.2);
        }

        .btn-danger {
            background-color: #dc3545;
            color: white;
            box-shadow: 0 2px 4px rgba(220,53,69,0.2);
        }

        .btn-success {
            background-color: #28a745;
            color: white;
            box-shadow: 0 2px 4px rgba(40,167,69,0.2);
        }

        .btn:hover {
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(0,0,0,0.15);
        }

        .btn:active {
            transform: translateY(0);
        }

        .grid-view {
            margin-top: 30px;
            width: 100%;
            border-collapse: collapse;
        }

        .grid-view th {
            background-color: #4a90e2;
            color: white;
            padding: 12px;
            text-align: right;
        }

        .grid-view td {
            padding: 10px;
            border: 1px solid #ddd;
        }

        .grid-view tr:nth-child(even) {
            background-color: #f8f9fa;
        }

        .grid-view tr:hover {
            background-color: #f1f1f1;
        }

        .dropdown-list {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            background-color: white;
            font-size: 14px;
        }

        /* עיצוב משופר לאזור המדיה */
        .media-container {
            margin: 30px 0;
            padding: 20px;
            background-color: white;
            border-radius: 10px;
            box-shadow: 0 2px 8px rgba(0,0,0,0.1);
            text-align: center;
        }

        .media-container img {
            max-width: 100%;
            height: auto;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }

        .media-container video {
            max-width: 100%;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }

        @media (max-width: 768px) {
            .button-group {
                flex-direction: column;
            }
            
            .btn {
                width: 100%;
                margin-bottom: 10px;
            }

            .media-container {
                padding: 15px;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="training-container">
        <h2 style="text-align: center; color: #333; margin-bottom: 30px;">ניהול אימונים<asp:GridView ID="GridView1" runat="server" CssClass="grid-view" 
            AutoGenerateColumns="True" GridLines="Both">
        </asp:GridView>
        </h2>
        
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="יום אימון" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="שדה חובה" 
                ValidationGroup="f5" CssClass="validation-error"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="אותיות חובה בשדה זה" 
                ValidationExpression="$*[א-ת]" ValidationGroup="f5" CssClass="validation-error"></asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="סוג אימון" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown-list">
                <asp:ListItem>קורדינציה</asp:ListItem>
                <asp:ListItem>כוח</asp:ListItem>
                <asp:ListItem>משחק</asp:ListItem>
                <asp:ListItem>כוח וקורדינציה</asp:ListItem>
                <asp:ListItem>כדורסל</asp:ListItem>
                <asp:ListItem>כדורסל וכוח</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="DropDownList1" Display="Dynamic" ErrorMessage="שדה חובה" 
                ValidationGroup="f5" CssClass="validation-error"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="רמת אימון" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="dropdown-list">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="DropDownList2" Display="Dynamic" ErrorMessage="שדה חובה" 
                ValidationGroup="f5" CssClass="validation-error"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="Label4" runat="server" Text="שעת אימון" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="dropdown-list">
                <asp:ListItem>13:00</asp:ListItem>
                <asp:ListItem>15:00</asp:ListItem>
                <asp:ListItem>17:00</asp:ListItem>
                <asp:ListItem>17:30</asp:ListItem>
                <asp:ListItem>18:00</asp:ListItem>
                <asp:ListItem>18:30</asp:ListItem>
                <asp:ListItem>19:30</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="DropDownList3" Display="Dynamic" ErrorMessage="שדה חובה" 
                ValidationGroup="f5" CssClass="validation-error"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="Label5" runat="server" Text="תז מאמן" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="dropdown-list">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="DropDownList4" Display="Dynamic" ErrorMessage="שדה חובה" 
                ValidationGroup="f5" CssClass="validation-error"></asp:RequiredFieldValidator>
        </div>

        <div class="button-group">
            <asp:Button ID="Button9" runat="server" Text="הוספה" OnClick="Button9_Click" CssClass="btn btn-success" />
            <asp:Button ID="Button10" runat="server" Text="מחיקה" OnClick="Button10_Click" CssClass="btn btn-danger" />
            <asp:Button ID="Button12" runat="server" Text="בחירה" OnClick="Button12_Click" CssClass="btn btn-primary" />
            <asp:Button ID="Button11" runat="server" Text="עדכון" OnClick="Button11_Click" CssClass="btn btn-primary" />
            <asp:Button ID="Button13" runat="server" OnClick="Button13_Click" Text="הצגת סרטון לאימון בבית" CssClass="btn btn-primary" />
            <asp:Button ID="Button14" runat="server" OnClick="Button14_Click" Text="הצגת מערך לאימון" CssClass="btn btn-primary" />
        </div>

        <div class="media-container">
            <asp:Image ID="imgRandom" runat="server" Width="400" />
            <asp:Literal ID="litVideo" runat="server" />
        </div>

        <asp:Label ID="Label6" runat="server" Text="" CssClass="form-label"></asp:Label>

    </div>
</asp:Content>