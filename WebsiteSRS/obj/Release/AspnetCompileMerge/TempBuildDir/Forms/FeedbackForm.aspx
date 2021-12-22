<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedbackForm.aspx.cs" Inherits="WebsiteSRS.Forms.FeedbackForm" %>

<!DOCTYPE html>
<html>

<head runat="server">
    <title></title>
    <meta http-equiv="Pragma" content="No-cache" />
    <meta http-equiv="Cache-Control" content="no-Store,no-Cache" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/JqueryUI/jquery-ui.min.js"></script>
    <link href="../Scripts/JqueryUI/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />

    <link href="../Content/ContentForms.css" rel="stylesheet" />

    <style>
        body {
            width: 100%;
            height: 100%
        }

        .NameColumn {
            width: 20%;
        }

        .ContentColum {
            width: 30%
        }

        .center-table {
        }

        .Content-Aeas-Grant img {
            height: 20px;
            width: 22px;
            margin-bottom: 0px;
            margin-top: -4px;
        }

        div {
            margin-left: auto;
            margin-right: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Content-Area Content-Aeas-Grant">

            <table>
                <tr>
                    <td>
                        <label for="ddlApps">Application:</label></td>
                    <td colspan="3">
                        <asp:DropDownList runat="server" ID="ddlApps" AutoPostBack="true" Width="100%" OnSelectedIndexChanged="ddlApps_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="ddlModel">Model Name:</label></td>
                    <td colspan="3">
                        <asp:DropDownList runat="server" ID="ddlModel" Width="100%"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="TextUserName">User Name:</label></td>
                    <td>
                        <asp:TextBox runat="server" ID="TextUserID" SkinID="LockText"> </asp:TextBox>
                    </td>
                    <td colspan="2">

                        <asp:TextBox runat="server" ID="TextUserName" Width="98%" SkinID="LockText"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="TextUserRole">User Role:</label></td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="TextUserRole" Width="99%" SkinID="LockText"> </asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <label for="ddlSchool">School:</label></td>
                    <td colspan="3">
                        <asp:DropDownList runat="server" ID="ddlSchoolCode" SkinID="LockText" AutoPostBack="true" Width="60px"></asp:DropDownList>
                        <asp:DropDownList runat="server" ID="ddlSchool" SkinID="LockText" AutoPostBack="true" Width="400px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="ddlAppSection">Application Section:</label></td>
                    <td colspan="3">
                        <asp:DropDownList runat="server" ID="ddlAppSection" Width="100%" AutoPostBack="true">
                        </asp:DropDownList>

                    </td>

                </tr>
                <tr>
                    <td>
                        <label for="ddlFeedbackType">About:</label>
                    </td>
                    <td colspan="3">
                        <asp:DropDownList runat="server" ID="ddlFeedbackType" Width="100%">
                            <asp:ListItem>Suggestion</asp:ListItem>
                            <asp:ListItem>Glitches</asp:ListItem>
                            <asp:ListItem Value="NewFunction">New Function</asp:ListItem>

                        </asp:DropDownList>
                    </td>
                </tr>


                <tr>
                    <td>
                        <label for="TetComments">Comments:</label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="TextComments" Width="99%" Height="250px" TextMode="MultiLine"> </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4"></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:Button runat="server" ID="btnSubmit" Text="Submit"   CssClass="action-button" />

                    </td>
                </tr>
                <tr>
                    <td class="NameColumn"></td>
                    <td class="ContentColum"></td>
                    <td class="NameColumn"></td>
                    <td class="ContentColum"></td>
                </tr>

            </table>
            <asp:HiddenField ID="hfSchoolyearStartDate" runat="server" />
            <asp:HiddenField ID="hfSchoolyearEndDate" runat="server" />
            <asp:HiddenField ID="hfIDs" runat="server" />
            <asp:HiddenField ID="hfCategory" runat="server" />
            <asp:HiddenField ID="hfPageID" runat="server" />
            <asp:HiddenField ID="hfUserID" runat="server" />
            <asp:HiddenField ID="hfUserRole" runat="server" />
            <asp:HiddenField ID="hfAppID" runat="server" />
            <asp:HiddenField ID="hfModelID" runat="server" />
            <asp:HiddenField ID="hfAction" runat="server" Value="Add" />
            <asp:HiddenField ID="hfSchoolYear" runat="server" />
            <asp:HiddenField ID="hfSchoolCode" runat="server" />
            <asp:HiddenField ID="hfUserLoginRole" runat="server" />
            <asp:HiddenField ID="hfRunningModel" runat="server" />


        </div>
    </form>
</body>
</html>
<script src="../Scripts/MoursPoint.js"></script>
<script src="../Scripts/CommonDOM.js"></script>
<script src="../Scripts/ActionMenu.js"></script>
<script src="../Scripts/ActionWebApi.js"></script>

<script type="text/javascript">

    $(document).ready(function () {

        InitialDatePickerControl();

        $("#btnSubmit").click(function (e) {
            SaveDataToDatabase();
        });

    });

    function BindFormData(data) {
        var userGD = data[0];
        $("#lblIDs").html(userGD.IDs);

    }

    function SaveDataToDatabase() {
        try {
            var para = {
                Operate: $("#hfAction").val(),
                UserID: $("#hfUserID").val(),
                UserRole: $("#TextUserRole").val(),
                IDs: $("#hfIDs").val(),
                SchoolYear: $("#hfSchoolYear").val(),
                SchoolCode: $("#ddlSchool").val(),
                AppID: $("#ddlApps").val(),
                ModelID: $("#ddlModel").val(),
                AppSection: $("#ddlAppSection").val(),
                FeedbackType: $("#ddlFeedbackType").val(),
                Comments: $("#TextComments").val(),
            };

            var uri = "UserFeedback";
            console.log(para);
            console.log(para.SchoolCode);
            console.log(para.Comments);

            if (para.Operate == "Add") WebAPICall.AddData(uri, para, "Parent");
            if (para.Operate == "Edit") WebAPICall.EditData(uri, para, "Parent");
            if (para.Operate == "Delete") WebAPICall.DeletData(uri, para.IDs, "Parent");

        }
        catch (e) {
            alert(para.Operate + " Submit click something going wrong");
        }
    }

    function InitialDatePickerControl() {
        var minD = new Date($("#hfSchoolyearStartDate").val());
        var maxD = new Date($("#hfSchoolyearEndDate").val());
        JDatePicker.Initial($("#dateStart"), minD, maxD, minD);
        JDatePicker.Initial($("#dateEnd"), minD, maxD, maxD);
    }

</script>
