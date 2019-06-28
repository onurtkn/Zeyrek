<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="ZeyrekWeb.Menu" %>
<ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">
    <a class="sidebar-brand d-flex align-items-center justify-content-center" href="Default.aspx">
        <div class="sidebar-brand-icon rotate-n-30">
            <img src="img/zeyrek-logo.png" />
        </div>
        <%--<div class="sidebar-brand-text mx-3">AKILLI ASİSTAN</div>--%>
    </a>
    <hr class="sidebar-divider my-0">
    <li class="nav-item active">
        <a class="nav-link" href="Default.aspx">
            <i class="fas fa-fw fa-tachometer-alt"></i>
            <span>Anasayfa</span></a>
    </li>
    <hr class="sidebar-divider">
    <div class="sidebar-heading">
        İŞLEMLER
    </div>
    <li class="nav-item">
        <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="true" aria-controls="collapseTwo">
            <i class="fas fa-fw fa-clipboard-list"></i>
            <span>Bekleyen İşlemlerim</span>
        </a>
        <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionSidebar">
            <div class="bg-white py-2 collapse-inner rounded">
                <a class="collapse-item" href="TaskList.aspx?GroupId=1">EVRAKA</a>
                <a class="collapse-item" href="TaskList.aspx?GroupId=2">SAP</a>
                <a class="collapse-item" href="TaskList.aspx?GroupId=3">SHAREPOINT</a>
                <a class="collapse-item" href="TaskList.aspx?GroupId=4">KYO-KM</a>
                <a class="collapse-item" href="TaskList.aspx?GroupId=5">JIRA</a>
                <a class="collapse-item" href="TaskList.aspx?GroupId=6">TFS</a>
            </div>
        </div>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="ForgotPass.aspx">
            <i class="fas fa-fw fa-lock"></i>
            <span>Şifremi Unuttum</span></a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="Register.aspx">
            <i class="fas fa-fw fa-question"></i>
            <span>Güvenlik Sorusu Belirle</span></a>
    </li>
    <hr class="sidebar-divider">
    <div class="sidebar-heading">
        BİLDİRİMLER
    </div>
    <li class="nav-item">
        <a class="nav-link" href="NotificationList.aspx?GroupId=1">
            <i class="fas fa-fw fa-comments"></i>
            <span>Genel Bildirimler</span></a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="NotificationList.aspx?GroupId=2">
            <i class="fas fa-fw fa-comments"></i>
            <span>Kişisel Bildirimler</span></a>
    </li>
    <hr class="sidebar-divider d-none d-md-block">
    <div class="sidebar-heading">
        DURUM
    </div>
    <li class="nav-item">
        <a class="nav-link" href="BirthDayList.aspx">
            <i class="fas fa-fw fa-birthday-cake"></i>
            <span>Doğum Günü Olanlar</span></a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="BusServiceList.aspx">
            <i class="fas fa-fw fa-bus"></i>
            <span>Servis Listesi</span></a>
    </li>
</ul>
