<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signUp.aspx.cs" Inherits="WebApplication1.signUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>הרשמה</title>
    <style type="text/css">
        body {
            background-color: #f0f2f5;
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 20px;
            direction: rtl;
        }

        .signup-container {
            max-width: 500px;
            margin: 40px auto;
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
        }

        .form-title {
            text-align: center;
            color: #1a237e;
            font-size: 24px;
            margin-bottom: 30px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-label {
            display: block;
            margin-bottom: 8px;
            color: #333;
            font-weight: bold;
        }

        .form-input {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 5px;
            font-size: 16px;
            box-sizing: border-box;
        }

        .form-input:focus {
            border-color: #1a237e;
            outline: none;
            box-shadow: 0 0 0 2px rgba(26, 35, 126, 0.2);
        }

        .form-dropdown {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 5px;
            font-size: 16px;
            background-color: white;
        }

        .calendar-container {
            margin-top: 10px;
            background-color: white;
            border-radius: 5px;
            overflow: hidden;
        }

        .calendar-container table {
            width: 100%;
        }

        .submit-button {
            width: 100%;
            padding: 12px;
            background-color: #1a237e;
            color: white;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            margin-top: 20px;
            transition: background-color 0.3s;
        }

        .submit-button:hover {
            background-color: #283593;
        }

        /* עיצוב ללוח השנה */
        .MyCalendar {
            background-color: white;
            border: 1px solid #ddd !important;
            border-radius: 5px;
            width: 100%;
        }

        .MyCalendar td, .MyCalendar th {
            padding: 5px;
            text-align: center;
        }

        .MyCalendar .ajax__calendar_title {
            color: #1a237e;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="signup-container">
            <h2 class="form-title">הרשמה למערכת</h2>
            
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="שם משתמש" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-input" placeholder="הכנס שם משתמש"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="סיסמא" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-input" TextMode="Password" placeholder="הכנס סיסמא"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="תאריך לידה" CssClass="form-label"></asp:Label>
                <div class="calendar-container">
                    <asp:Calendar ID="Calendar1" runat="server" CssClass="MyCalendar"></asp:Calendar>
                </div>
            </div>

            <asp:Button ID="btnSignUp" runat="server" Text="הרשמה" CssClass="submit-button" OnClick="btnSignUp_Click" />
        </div>
    </form>
</body>
</html>