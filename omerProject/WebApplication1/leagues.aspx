<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="leagues.aspx.cs" Inherits="WebApplication1.leagues" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .leagues-container {
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
            margin-bottom: 30px;
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
            color: #2c3e50;
            font-size: 14px;
            min-width: 120px;
            text-align: right;
        }

        .form-control {
            flex: 1;
            padding: 12px;
            border: 1px solid #ddd;
            border-radius: 6px;
            font-size: 14px;
            transition: all 0.3s ease;
            max-width: 250px;
            background-color: white;
        }

        .form-control:focus {
            border-color: #3498db;
            outline: none;
            box-shadow: 0 0 8px rgba(52,152,219,0.2);
        }

        .validation-error {
            color: #e74c3c;
            font-size: 12px;
            margin-top: 5px;
            display: block;
            font-weight: 500;
        }

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
            transition: all 0.3s ease;
            min-width: 120px;
            font-size: 14px;
            text-align: center;
        }

        .btn-primary {
            background-color: #3498db;
            color: white;
        }

        .btn-danger {
            background-color: #e74c3c;
            color: white;
        }

        .btn-success {
            background-color: #2ecc71;
            color: white;
        }

        .btn:hover {
            transform: translateY(-2px);
            box-shadow: 0 4px 12px rgba(0,0,0,0.15);
            opacity: 0.95;
        }

        .grid-view {
            margin-top: 30px;
            width: 100%;
            border-collapse: separate;
            border-spacing: 0;
            background-color: white;
            border-radius: 10px;
            overflow: hidden;
            box-shadow: 0 2px 8px rgba(0,0,0,0.05);
        }

        .grid-view th {
            background-color: #3498db;
            color: white;
            padding: 15px;
            text-align: right;
            font-weight: 600;
            font-size: 14px;
            border: none;
        }

        .grid-view td {
            padding: 12px 15px;
            border: 1px solid #eee;
            font-size: 14px;
        }

        .grid-view tr:nth-child(even) {
            background-color: #f8f9fa;
        }

        .grid-view tr:hover {
            background-color: #f1f1f1;
        }

        .dropdown-list {
            flex: 1;
            padding: 12px;
            border: 1px solid #ddd;
            border-radius: 6px;
            background-color: white;
            font-size: 14px;
            cursor: pointer;
            max-width: 250px;
            transition: all 0.3s ease;
        }

        .dropdown-list:focus {
            border-color: #3498db;
            outline: none;
            box-shadow: 0 0 8px rgba(52,152,219,0.2);
        }

        .chart-container {
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 2px 8px rgba(0,0,0,0.05);
            margin: 30px 0;
        }

        @media (max-width: 768px) {
            .form-group {
                flex-direction: column;
                align-items: stretch;
                padding: 15px;
            }

            .form-label {
                text-align: right;
                margin-bottom: 8px;
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
    <div class="leagues-container">
        <h2 style="text-align: center; color: #2c3e50; margin-bottom: 30px; font-size: 28px;">ניהול ליגות<asp:GridView ID="GridView1" runat="server" CssClass="grid-view" 
            AutoGenerateColumns="True" GridLines="Both">
        </asp:GridView>
        </h2>
        
        <div class="form-section">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="שם ליגה ושנה" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="שדה חובה" 
                    ValidationGroup="f1" CssClass="validation-error"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="שחקן מצטיין" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="dropdown-list">
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="סך הכל נקודות" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="שדה חובה" 
                    ValidationGroup="f1" CssClass="validation-error"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="רמת ליגה" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="DropDownList4" runat="server" CssClass="dropdown-list">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="DropDownList4" Display="Dynamic" ErrorMessage="שדה חובה" 
                    ValidationGroup="f1" CssClass="validation-error"></asp:RequiredFieldValidator>
            </div>

            <div class="button-group">
                <asp:Button ID="Button7" runat="server" Text="הוספה" ValidationGroup="f1" 
                    OnClick="Button7_Click" CssClass="btn btn-success" />
                <asp:Button ID="Button8" runat="server" Text="מחיקה" OnClick="Button8_Click" 
                    CssClass="btn btn-danger" />
                <asp:Button ID="Button9" runat="server" Text="בחירה" OnClick="Button9_Click" 
                    CssClass="btn btn-primary" />
                <asp:Button ID="Button10" runat="server" Text="עדכון" OnClick="Button10_Click" 
                    CssClass="btn btn-primary" />
                <asp:Button ID="Button12" runat="server" Text="הצגת התקדמות הקבוצה" 
                    OnClick="Button12_Click" CssClass="btn btn-primary" />
            </div>
        </div>

        <div class="chart-container">
            <asp:Chart ID="Chart1" runat="server" Width="900px" Height="400px">
                <series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series1">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
        </div>

    </div>
</asp:Content>