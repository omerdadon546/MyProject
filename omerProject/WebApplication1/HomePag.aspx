<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePag.aspx.cs" Inherits="WebApplication1.HomePag" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .home-container {
            position: relative;
            min-height: 100vh;
            background-color: #f8f9fa;
        }

        .hero-section {
            position: relative;
            height: 60vh;
            overflow: hidden;
            background: linear-gradient(rgba(41, 128, 185, 0.9), rgba(52, 152, 219, 0.9));
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .content-wrapper {
            text-align: center;
            padding: 2rem;
            max-width: 800px;
            background: rgba(255, 255, 255, 0.1);
            border-radius: 15px;
            border: 2px solid rgba(255, 255, 255, 0.2);
        }

        .main-title {
            font-size: 3.5rem;
            font-weight: bold;
            margin-bottom: 1rem;
            text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.3);
            color: #1a237e;
            font-family: 'Segoe UI', Arial, sans-serif;
        }

        .sub-title {
            font-size: 1.8rem;
            margin-bottom: 1.5rem;
            color: #283593;
            text-shadow: 1px 1px 2px rgba(0, 0, 0, 0.3);
        }

        .info-section {
            padding: 2rem;
            background: #ffffff;
            text-align: center;
        }

        .info-card {
            background: #ffffff;
            padding: 2rem;
            border-radius: 10px;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
            margin: 1rem auto;
            max-width: 800px;
            border: 1px solid #e3e6f0;
        }

        .info-title {
            color: #1a237e;
            font-size: 2rem;
            margin-bottom: 1rem;
        }

        .info-text {
            color: #263238;
            font-size: 1.2rem;
            line-height: 1.6;
            margin-bottom: 2rem;
        }

        .highlight-box {
            background: linear-gradient(135deg, #3498db, #2980b9);
            padding: 2rem;
            border-radius: 10px;
            margin: 2rem auto;
            max-width: 800px;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
        }

        .highlight-text {
            font-size: 1.5rem;
            color: #ffffff;
            margin-bottom: 1.5rem;
        }

        .featured-image {
            max-width: 100%;
            height: auto;
            border-radius: 10px;
            margin: 1rem auto;
            display: block;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.2);
        }

        @media (max-width: 768px) {
            .main-title {
                font-size: 2.5rem;
            }

            .sub-title {
                font-size: 1.3rem;
            }

            .info-title {
                font-size: 1.6rem;
            }

            .highlight-text {
                font-size: 1.2rem;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-container">
        <section class="hero-section">
            <div class="content-wrapper">
                <h1 class="main-title">הפועל עומר</h1>
                <h2 class="sub-title">הדור הבא של הכדורסל</h2>
            </div>
        </section>

        <section class="info-section">
            <div class="info-card">
                <h3 class="info-title">ברוכים הבאים</h3>
                <p class="info-title">
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </p>
                <p class="info-title">
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </p>
            </div>

            <div class="highlight-box">
                <p class="highlight-text">
                    הצטרפו אלינו למסע לעבר מצויינות</p>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/pictures/lebron.jpg" CssClass="featured-image" />
            </div>
        </section>
    </div>
</asp:Content>