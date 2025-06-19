<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>התחברות למערכת</title>
    <style type="text/css">
        body {
            font-family: 'Segoe UI', Arial, sans-serif;
            background-color: #f0f2f5;
            margin: 0;
            padding: 0;
            direction: rtl;
        }

        .login-container {
            max-width: 400px;
            margin: 100px auto;
            padding: 20px;
            background-color: white;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }

        .login-title {
            text-align: center;
            color: #1a237e;
            font-size: 24px;
            margin-bottom: 30px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            font-size: 16px;
            margin-top: 5px;
        }

        .form-label {
            display: block;
            margin-bottom: 5px;
            color: #333;
            font-weight: bold;
        }

        .btn-login {
            width: 100%;
            padding: 12px;
            background-color: #1a237e;
            color: white;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .btn-login:hover {
            background-color: #283593;
        }

        .error-message {
            color: #d32f2f;
            margin-top: 5px;
            font-size: 14px;
        }

        .signup-link {
            text-align: center;
            margin-top: 20px;
        }

        .signup-link a {
            color: #1a237e;
            text-decoration: none;
        }

        .signup-link a:hover {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2 class="login-title">התחברות למערכת</h2>
            
            <div class="form-group">
                <asp:Label ID="lblUsername" runat="server" Text="שם משתמש" CssClass="form-label" />
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblPassword" runat="server" Text="סיסמה" CssClass="form-label" Height="29px" />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
            </div>

            <div class="form-group">
                <asp:Button ID="btnLogin" runat="server" Text="התחבר" CssClass="btn-login" OnClick="btnLogin_Click" />
            </div>

            <div class="signup-link">
                עדיין אין לך חשבון? 
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="הירשם כאן" />
            </div>

            <asp:Label ID="lblError" runat="server" CssClass="error-message" />
        </div>
    </form>
</body>
</html>
