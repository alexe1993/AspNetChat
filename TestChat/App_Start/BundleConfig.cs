using System.Web.Optimization;

namespace TestChat
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/signalR").Include(
                       "~/Scripts/jquery.signalR-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            /* // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
             // готово к выпуску, используйте средство сборки по адресу https://modernizr.com, чтобы выбрать только необходимые тесты.
             bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                         "~/Scripts/modernizr-*"));

             bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.css",
                       "~/Content/site.css",
                       "~/Content/mystyle.css"
                       ));*/
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/mystyle.css"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/my").Include(
                      "~/Scripts/myscript.js"));
            bundles.Add(new ScriptBundle("~/bundles/events").Include(
                      "~/Scripts/Events.js"));
            bundles.Add(new ScriptBundle("~/bundles/TestForm").Include(
                      "~/Scripts/TestForm.js"));
        }
    }
}