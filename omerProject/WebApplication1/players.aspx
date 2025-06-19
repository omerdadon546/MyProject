<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="players.aspx.cs" Inherits="WebApplication1.players" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .players-container {
            max-width: 1000px;
            margin: 20px auto;
            padding: 20px;
            background-color: #f8f9fa;
            border-radius: 10px;
            box-shadow: 0 0 15px rgba(0,0,0,0.1);
        }

        .form-section {
            display: grid;
            grid-template-columns: repeat(2, 1fr);
            gap: 20px;
            margin-bottom: 30px;
        }
        
        .form-group {
            background-color: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.05);
            transition: transform 0.2s ease;
        }

        .form-group:hover {
            transform: translateY(-2px);
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
            transition: border-color 0.3s ease;
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
            margin: 20px 0;
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
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            background-color: white;
            font-size: 14px;
            cursor: pointer;
        }

        .dropdown-list:focus {
            border-color: #4a90e2;
            outline: none;
            box-shadow: 0 0 5px rgba(74,144,226,0.3);
        }

        .stats-section {
            display: grid;
            grid-template-columns: repeat(2, 1fr);
            gap: 15px;
            margin-top: 20px;
        }

        .stats-group {
            display: flex;
            gap: 10px;
            align-items: center;
        }

        .stats-label {
            min-width: 80px;
            font-weight: 600;
            color: #333;
        }

        @media (max-width: 768px) {
            .form-section {
                grid-template-columns: 1fr;
            }
            
            .stats-section {
                grid-template-columns: 1fr;
            }
            
            .button-group {
                flex-direction: column;
            }
            
            .btn {
                width: 100%;
                margin-bottom: 10px;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="players-container">
        <h2 style="text-align: center; color: #333; margin-bottom: 30px;">ניהול שחקנים</h2>
        
        <div class="form-section">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="מספר שחקן" CssClass="form-label"></asp:Label>
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
                    ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="אותיות בלבד בשדה זה" 
                    ValidationExpression="$*[א-ת]" ValidationGroup="f3" CssClass="validation-error"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="שם משפחה" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="שדה חובה" 
                    ValidationGroup="f3" CssClass="validation-error"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="אותיות בלבד בשדה זה" 
                    ValidationExpression="$*[א-ת]" ValidationGroup="f3" CssClass="validation-error"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="יום אימון" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown-list" AutoPostBack="True">
                    <asp:ListItem>ראשון</asp:ListItem>
                    <asp:ListItem>שני</asp:ListItem>
                    <asp:ListItem>שלישי</asp:ListItem>
                    <asp:ListItem>רביעי</asp:ListItem>
                    <asp:ListItem>חמישי</asp:ListItem>
                    <asp:ListItem>שישי</asp:ListItem>
                    <asp:ListItem>שבת</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="רמת שחקן" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="dropdown-list">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label ID="Label12" runat="server" Text="ליגות" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="dropdown-list">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                    ControlToValidate="DropDownList3" Display="Dynamic" ErrorMessage="שדה חובה" 
                    ValidationGroup="f3" CssClass="validation-error"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="Label13" runat="server" Text="תז מאמן" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="DropDownList4" runat="server" CssClass="dropdown-list">
                </asp:DropDownList>
            </div>
        </div>

        <div class="stats-section">
            <div class="form-group">
                <div class="stats-group">
                    <asp:Label ID="Label6" runat="server" Text="FGM" CssClass="stats-label"></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                        ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="מספרים בלבד" 
                        ValidationExpression="\d+" ValidationGroup="f3" CssClass="validation-error"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="שדה חובה" 
                        ValidationGroup="f3" CssClass="validation-error"></asp:RequiredFieldValidator>
                </div>
                <div class="stats-group">
                    <asp:Label ID="Label7" runat="server" Text="משחקים" CssClass="stats-label"></asp:Label>
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                        ControlToValidate="TextBox5" Display="Dynamic" ErrorMessage="מספרים בלבד" 
                        ValidationExpression="\d+" ValidationGroup="f3" CssClass="validation-error"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="TextBox5" Display="Dynamic" ErrorMessage="שדה חובה" 
                        ValidationGroup="f3" CssClass="validation-error"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <div class="stats-group">
                    <asp:Label ID="Label8" runat="server" Text="AST" CssClass="stats-label"></asp:Label>
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                        ControlToValidate="TextBox6" Display="Dynamic" ErrorMessage="מספרים בלבד" 
                        ValidationExpression="\d+" ValidationGroup="f3" CssClass="validation-error"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="TextBox6" Display="Dynamic" ErrorMessage="שדה חובה" 
                        ValidationGroup="f3" CssClass="validation-error"></asp:RequiredFieldValidator>
                </div>
                <div class="stats-group">
                    <asp:Label ID="Label9" runat="server" Text="STL" CssClass="stats-label"></asp:Label>
                    <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                        ControlToValidate="TextBox7" Display="Dynamic" ErrorMessage="מספרים בלבד" 
                        ValidationExpression="\d+" ValidationGroup="f3" CssClass="validation-error"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ControlToValidate="TextBox7" Display="Dynamic" ErrorMessage="שדה חובה" 
                        ValidationGroup="f3" CssClass="validation-error"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <div class="stats-group">
                    <asp:Label ID="Label10" runat="server" Text="BLK" CssClass="stats-label"></asp:Label>
                    <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                        ControlToValidate="TextBox8" Display="Dynamic" ErrorMessage="מספרים בלבד" 
                        ValidationExpression="\d+" ValidationGroup="f3" CssClass="validation-error"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                        ControlToValidate="TextBox8" Display="Dynamic" ErrorMessage="שדה חובה" 
                        ValidationGroup="f3" CssClass="validation-error"></asp:RequiredFieldValidator>
                </div>
                <div class="stats-group">
                    <asp:Label ID="Label11" runat="server" Text="TO" CssClass="stats-label"></asp:Label>
                    <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                        ControlToValidate="TextBox9" Display="Dynamic" ErrorMessage="שדה חובה" 
                        ValidationGroup="f3" CssClass="validation-error"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                        ControlToValidate="TextBox9" Display="Dynamic" ErrorMessage="מספרים בלבד" 
                        ValidationExpression="\d+" ValidationGroup="f3" CssClass="validation-error"></asp:RegularExpressionValidator>
                </div>
            </div>
        </div>

        <div class="button-group">
            <asp:Button ID="Button13" runat="server" OnClick="Button13_Click1" Text="סיום הרשמה" />
            <asp:Button ID="Button8" runat="server" Text="הוספה" OnClick="Button8_Click" CssClass="btn btn-success" />
            <asp:Button ID="Button9" runat="server" Text="מחיקה" OnClick="Button9_Click" CssClass="btn btn-danger" />
            <asp:Button ID="Button11" runat="server" Text="בחירה" OnClick="Button11_Click" CssClass="btn btn-primary" />
            <asp:Button ID="Button10" runat="server" Text="עדכון" OnClick="Button10_Click" CssClass="btn btn-primary" />
            <asp:Button ID="Button7" runat="server" Text="הצגה" OnClick="Button7_Click" CssClass="btn btn-primary" />
            <asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="הצגת שחקנים הזקוקים לשיפור" CssClass="btn btn-primary" />
        </div>

        <asp:GridView ID="GridView1" runat="server" CssClass="grid-view" 
            AutoGenerateColumns="True" GridLines="Both">
        </asp:GridView>
    </div>
</asp:Content>