<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" language="javascript">
        function localDemo() {
            
            //Will wrap object like {"d":{"__type":"Customer:#MvcJsonp.Htt...stName":"Martin","lastName":"Blanke"}}
            var GetAsObject = "http://localhost:2527/HttpHandlers/JsonpServiceDemo.svc/GetCustomerAsObject?callback=?";
            //Will wrap objects like {"d":"jsonp1272380726037(MvcJsonp.HttpHandlers.Customer);"}
            var GetAsString = "http://localhost:2527/HttpHandlers/JsonpServiceDemo.svc/GetCustomerAsString?callback=?";
            
            //This is not wrapped, from ASHX
            var GetFromHandler = "http://localhost:2527/HttpHandlers/JsonpHandlerDemo.ashx?callback=?";
            //This is not wrapped, from Atom Feed type service
            var GetFromAtomFeedProject = "http://localhost:2065/Service1.svc/DoWork?callback=?";

            $.getJSON(GetAsString,
            function(data) {
                $.each(data, function(i, item) {
                    //console.log(item.firstName + ' ' + item.lastName);
                    alert(item.firstName + ' ' + item.lastName);
                });
            });
        }
    </script>

    <h2>
        <%= Html.Encode(ViewData["Message"]) %></h2>
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">
            http://asp.net/mvc</a>.
    </p>
    <input type="button" onclick="localDemo();" value="Execute" />
</asp:Content>
