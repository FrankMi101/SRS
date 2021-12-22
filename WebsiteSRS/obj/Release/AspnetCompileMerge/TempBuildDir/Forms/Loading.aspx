<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loading.aspx.cs" Inherits="WebsiteSRS.Forms.Loading" %>

<!DOCTYPE html>

<html>

<head runat="server">
    <title>Loading Page</title>
    <style>
        div {
            text-align: center;
            margin: 0 auto;
            padding-top: 15%;
        }

        img {
            height: 100px;
            width: 100px;
        }
    </style>
</head>
<body>
    <div>
        <img src="../Content/images/source.gif" />
        <a id="PageURL" runat="server" href='#' target="_self">Loading ......</a>

    </div>

    <script type="text/javascript">
        var myHref = document.getElementById("PageURL").getAttribute("href");
        window.location.href = myHref;
    </script>

</body>
</html>
