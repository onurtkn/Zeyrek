<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPass.aspx.cs" Inherits="ZeyrekWeb.ForgotPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Zeyrek</title>
    <link href="assets/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />

    <link href="css/zeyrek.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="card o-hidden border-0 shadow-lg my-5">
                <div class="card-body p-0">
                    <div class="row">
                        <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>
                        <div class="col-lg-7">
                            <div class="p-5">
                                <div class="text-center">
                                    <h1 class="h4 text-gray-900 mb-4">Güvenlik Sorusu</h1>
                                </div>
                                <h6>Şifrenizi sıfırlamak için lütefen güvenlik sorularınızdan hanhangi birini yazınız.</h6>
                                <div class="form-group">
                                    <asp:TextBox ID="GuvSorTxt" runat="server" class="form-control form-control-user" placeholder="Güvenlik Sorusu" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="GuvCevTxt" runat="server" class="form-control form-control-user" placeholder="Güvenlik Cevabı" TextMode="Password"></asp:TextBox>
                                </div>
                                <asp:LinkButton ID="SifirlaBtn" runat="server" class="btn btn-primary btn-user btn-block" OnClick="SifirlaBtn_Click">Doğrula</asp:LinkButton>
                            </div>
                            <div class="p-5">
                                <asp:Panel ID="SifrePnl" runat="server" Visible="false">
                                    <div class="form-group">
                                        <asp:TextBox ID="SifreTxt" runat="server" class="form-control form-control-user" placeholder="Şifre" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="SifreTekrarTxt" runat="server" class="form-control form-control-user" placeholder="Şifre (Tekrar)" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <h5><b>
                                        <asp:Label ID="HataLb" runat="server" Text="" Visible="false"></asp:Label></b></h5>
                                    <asp:LinkButton ID="KaydetBtn" runat="server" class="btn btn-primary btn-user btn-block" OnClick="KaydetBtn_Click">Kaydet</asp:LinkButton>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="Default.aspx" class="btn btn-light">
                    <span class="icon text-gray-600"></span>
                    <span class="text">AnaSayfaya Dön</span>
                </a>
            </div>
        </div>

        <!-- Bootstrap core JavaScript-->
        <script src="assets/jquery/jquery.min.js"></script>
        <script src="assets/bootstrap/js/bootstrap.bundle.min.js"></script>

        <!-- Core plugin JavaScript-->
        <script src="assets/jquery-easing/jquery.easing.min.js"></script>

        <!-- Custom scripts for all pages-->
        <script src="js/zeyrek.min.js"></script>
    </form>
</body>
</html>
