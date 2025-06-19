<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="games.aspx.cs" Inherits="WebApplication1.games" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .games-container {
            max-width: 1000px;
            margin: 20px auto;
            padding: 20px;
            background-color: #f8f9fa;
            border-radius: 10px;
            box-shadow: 0 0 15px rgba(0,0,0,0.1);
        }

        .form-group {
            background-color: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.05);
            margin-bottom: 20px;
            transition: transform 0.2s ease;
            display: flex;
            align-items: center;
            gap: 15px;
        }

        .form-group:hover {
            transform: translateY(-2px);
        }

        .form-label {
            font-weight: 600;
            color: #333;
            font-size: 14px;
            min-width: 150px;
            text-align: right;
        }

        .form-control {
            flex: 1;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            font-size: 14px;
            transition: border-color 0.3s ease;
            max-width: 300px;
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
            gap: 12px;
            margin: 25px 0;
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
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
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
            max-width: 300px;
        }

        .dropdown-list:focus {
            border-color: #4a90e2;
            outline: none;
            box-shadow: 0 0 5px rgba(74,144,226,0.3);
        }

        .checkbox-wrapper {
            display: flex;
            align-items: center;
            gap: 10px;
        }

        .checkbox-wrapper input[type="checkbox"] {
            width: 18px;
            height: 18px;
            cursor: pointer;
        }

        /* עיצוב משופר לגרף */
        .chart-container {
            margin-top: 30px;
            padding: 20px;
            background-color: white;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.05);
        }

        #Chart1 {
            width: 100% !important;
            height: 400px !important;
            margin: 0 auto;
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
                margin-bottom: 10px;
            }

            #Chart1 {
                height: 300px !important;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="games-container">
        <h2 style="text-align: center; color: #333; margin-bottom: 30px;">ניהול משחקים<asp:GridView ID="GridView1" runat="server" CssClass="grid-view" 
            AutoGenerateColumns="True" GridLines="Both">
        </asp:GridView>

        </h2>
        
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="מספר משחק" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="חובה לשים מספר בשדה זה" 
                ValidationExpression="\d+" ValidationGroup="f2" CssClass="validation-error"></asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="מספר זריקות" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="שדה חובה" 
                ValidationGroup="f2" CssClass="validation-error"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="חובה לשים מספר בשדה זה" 
                ValidationExpression="\d+" ValidationGroup="f2" CssClass="validation-error"></asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="ניקוד משחק" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="שדה חובה" 
                ValidationGroup="f2" CssClass="validation-error"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="חובה לשים מספר בשדה זה" 
                ValidationExpression="\d+" ValidationGroup="f2" CssClass="validation-error"></asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="Label4" runat="server" Text="שחקנים שהשתתפו" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown-list">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="DropDownList1" Display="Dynamic" ErrorMessage="שדה חובה" 
                ValidationGroup="f2" CssClass="validation-error"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <div class="checkbox-wrapper">
                <asp:CheckBox ID="CheckBox1" runat="server" />
                <asp:Label ID="Label5" runat="server" Text="ניצחון" CssClass="form-label"></asp:Label>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="Label6" runat="server" Text="רמת משחק" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="dropdown-list">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="DropDownList2" Display="Dynamic" ErrorMessage="שדה חובה" 
                ValidationGroup="f2" CssClass="validation-error"></asp:RequiredFieldValidator>
        </div>

        <div class="button-group">
            <asp:Button ID="Button7" runat="server" Text="הוספה" OnClick="Button7_Click" 
                ValidationGroup="f2" CssClass="btn btn-success" />
            <asp:Button ID="Button9" runat="server" Text="מחיקה" OnClick="Button9_Click" 
                CssClass="btn btn-danger" />
            <asp:Button ID="Button10" runat="server" Text="בחירה" OnClick="Button10_Click" 
                CssClass="btn btn-primary" />
            <asp:Button ID="Button11" runat="server" Text="עדכון" OnClick="Button11_Click" 
                CssClass="btn btn-primary" />
            <asp:Button ID="Button12" runat="server" OnClick="Button12_Click" 
                Text="הצגת גרף הפסדים נגד נצחונות" CssClass="btn btn-primary" />
        </div>

        <div class="chart-container">
            <asp:Chart ID="Chart1" runat="server">
                <Series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </div>
</asp:Content>