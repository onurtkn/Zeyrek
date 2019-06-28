<%@ Page Title="" Language="C#" MasterPageFile="~/Zeyrek.Master" AutoEventWireup="true" CodeBehind="TaskList.aspx.cs" Inherits="ZeyrekWeb.TaskList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentholder" runat="server">
    <div class="container-fluid">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Bekleyen İşlemlerim</h1>
        </div>
        <div class="row">
            <div class="col-xl-12 col-lg-7">
                <div class="card shadow mb-4">
                    <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                        <h6 class="m-0 font-weight-bold text-primary">
                            <asp:label id="TitleLb" runat="server" text=""></asp:label>
                        </h6>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table class="table table-bordered" id="dataTable1" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>Başlık</th>
                                        <th>Açıklama</th>
                                        <th>Bitiş Tarihi</th>
                                        <th>Tip</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:literal id="GorevLt" runat="server"></asp:literal>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
