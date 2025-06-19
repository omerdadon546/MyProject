<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="trainers.aspx.cs" Inherits="WebApplication1.trainers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .trainers-container {
            max-width: 1000px;
            margin: 20px auto;
            padding: 20px;
            background-color: #f8f9fa;
            border-radius: 10px;
            box-shadow: 0 0 15px rgba(0,0,0,0.1);
        }

        .form-section {
            background-color: white;
            padding: 25px;
            border-radius: 10px;
            box-shadow: 0 2px 8px rgba(0,0,0,0.05);
        }

        .form-group {
            background-color: #f8f9fa;
            padding: 20px;
            border-radius: 8px;
            margin-bottom: 20px;
            transition: transform 0.2s ease;
            display: flex;
            align-items: center;
            gap: 15px;
            flex-wrap: wrap;
        }

        .form-group:hover {
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(0,0,0,0.05);
        }

        .form-label {
            font-weight: 600;
            color: #333;
            font-size: 14px;
            min-width: 120px;
            text-align: right;
        }

        .form-control {
            flex: 1;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            font-size: 14px;
            transition: border-color 0.3s ease;
            max-width: 250px;
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

        .button-group {
            display: flex;
            gap: 10px;
            margin: 20px 0;
            justify-content: center;
            flex-wrap: wrap;
        }

        .btn {
            padding: 12px 24px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-weight: 600;
            transition: all 0.3s ease;
            min-width: 100px;
        }

        .btn-primary {
            background-color: #4a90e2;
            color: white;
        }

        .btn-danger {
            background-color: #dc3545;
            color: white;
        }

        .btn-success {
            background-color: #28a745;
            color: white;
        }

        .btn:hover {
            opacity: 0.9;
            transform: translateY(-1px);
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
        }

        .grid-view {
            margin-top: 30px;
            width: 100%;
            border-collapse: collapse;
            background-color: white;
            border-radius: 8px;
            overflow: hidden;
            box-shadow: 0 2px 4px rgba(0,0,0,0.05);
        }

        .grid-view th {
            background-color: #4a90e2;
            color: white;
            padding: 15px;
            text-align: right;
            font-weight: 600;
        }

        .grid-view td {
            padding: 12px 15px;
            border: 1px solid #eee;
        }

        .grid-view tr:nth-child(even) {
            background-color: #f8f9fa;
        }

        .grid-view tr:hover {
            background-color: #f1f1f1;
        }

        .dropdown-list {
            flex: 1;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            background-color: white;
            font-size: 14px;
            cursor: pointer;
            max-width: 250px;
        }

        .dropdown-list:focus {
            border-color: #4a90e2;
            outline: none;
            box-shadow: 0 0 5px rgba(74,144,226,0.3);
        }

        .calendar {
            border: 1px solid #ddd;
            border-radius: 4px;
            padding: 10px;
            background-color: white;
            box-shadow: 0 2px 4px rgba(0,0,0,0.05);
        }

        @media (max-width: 768px) {
            .form-group {
                flex-direction: column;
                align-items: stretch;
            }

            .form-label {
                text-align: right;
                margin-bottom: 5px;
            }

            .form-control, .dropdown-list {
                max-width: 100%;
            }

            .button-group {
                flex-direction: column;
            }
            
            .btn {
                width: 100%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="trainers-container">
        <h2 style="text-align: center; color: #333; margin-bottom: 30px;">ניהול מאמנים</h2>
        
        <div class="form-section">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="מספר מאמן" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="שדה חובה" 
                    ValidationGroup="f3" CssClass="validation-error"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="חובה לשים מספר בשדה זה" 
                    ValidationExpression="\d+" ValidationGroup="f3" CssClass="validation-error"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="שם פרטי" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="שדה חובה" 
                    ValidationGroup="f3" CssClass="validation-error"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="אותיות חובה בשדה זה" 
                    ValidationExpression="$*[א-ת]" ValidationGroup="f3" CssClass="validation-error"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="שם משפחה" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="רמה" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown-list">
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="תאריך לידה" CssClass="form-label"></asp:Label>
                <asp:Calendar ID="Calendar1" runat="server" CssClass="calendar"></asp:Calendar>
            </div>

            <div class="button-group">
                <asp:Button ID="Button7" runat="server" Text="הוספה" OnClick="Button7_Click" 
                    ValidationGroup="f3" CssClass="btn btn-success" />
                <asp:Button ID="Button8" runat="server" Text="מחיקה" OnClick="Button8_Click" 
                    CssClass="btn btn-primary" />
                <asp:Button ID="Button9" runat="server" Text="בחירה" OnClick="Button9_Click" 
                    CssClass="btn btn-danger" />
                <asp:Button ID="Button10" runat="server" Text="עדכון" OnClick="Button10_Click" 
                    CssClass="btn btn-primary" />
                <asp:Button ID="Button11" runat="server" Text="הצגה" OnClick="Button11_Click" 
                    CssClass="btn btn-primary" />
                <asp:Button ID="Button12" runat="server" Text="הצגת שכר" OnClick="Button12_Click" 
                    CssClass="btn btn-primary" />
            </div>

            <asp:GridView ID="GridView1" runat="server" CssClass="grid-view" 
                AutoGenerateColumns="True" GridLines="Both">
            </asp:GridView>
        </div>
    </div>
</asp:Content>