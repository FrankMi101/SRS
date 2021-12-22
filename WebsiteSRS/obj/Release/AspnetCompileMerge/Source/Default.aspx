<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebsiteSRS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div  >
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>FeedBack Service</h2>
            <p>
                TCDSB FeedBack Service is common Model for all TCDSB applications. To use this Service provide Query string
                appID=""&modelID=""&userID=""&userRole="" &schoolYear=""&schoolCode="" in Any Application
             </p>
            <p>
                OpenForm(title, page, arg, pHeight, pWidth) 
                  <label class="btn btn-default" id ="Feedback"> Feedback Service </label>
           </p>
        </div>
        <div class="col-md-4">
            <h2>Application Access Request Service</h2>
            <p>
                Teacher request a application Access Permission Service to use this Service need to provide Quesry string 
                appID=""&modelID=""&userID=""&userRole="" &schoolYear=""&schoolCode=""in Any Application
            </p>
 
            <p>
                <label class="btn btn-default" id ="AccessPromission"> Access Request Service </label>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Request Class Match Service</h2>
            <p>
                Teacher Request Classese Match Service.
                Provide the QueryString  appID=""&modelID=""&userID=""&userRole="" &schoolYear=""&schoolCode=""in Any Application
            </p>
              <p>
                <label class="btn btn-default" id ="ClassMatch"> Class Match Service </label>
            </p>
        </div>
    </div>

</asp:Content>
