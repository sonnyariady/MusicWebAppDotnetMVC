using System.Web;
using System.Web.Optimization;

namespace MusicWebApp
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));
            //bundles.Add(new ScriptBundle("~/bundles/bootstrap")
            //    .Include("~/Scripts/bootstrap.js"));
            //bundles.Add(new StyleBundle("~/Content/css")
            //                .Include("~/Content/site.css")
            //                .Include("~/Content/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Content/ui-framework/js/jquery-3.4.1.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Content/ui-framework/js/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Content/ui-framework/js/app.js"));
            bundles.Add(new ScriptBundle("~/bundles/appplugin").Include(
                        "~/Content/ui-framework/js/app.plugin.js"));
            bundles.Add(new ScriptBundle("~/bundles/fuelux").Include(
                        "~/Content/ui-framework/js/fuelux/fuelux.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery.min").Include(
                        "~/Content/ui-framework/js/jquery-3.4.1.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/app.data").Include(
                        "~/Content/ui-framework/js/app.data.js"));
            bundles.Add(new ScriptBundle("~/bundles/select2.min").Include(
                        "~/Content/ui-framework/js/select2/select2.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datepicker").Include(
                        "~/Content/ui-framework/js/datepicker/bootstrap-datepicker.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery.dataTables.min").Include(
                        "~/Content/ui-framework/js/datatables/jquery.dataTables.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/parsley.min").Include(
                        "~/Content/ui-framework/js/parsley/parsley.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
          "~/Content/bootstrap.css",
          "~/Content/site.css"));

            // Custom Style
            bundles.Add(new StyleBundle("~/bundles/bootstyle").Include(
                        "~/Content/ui-framework/css/bootstrap.css"));
            bundles.Add(new StyleBundle("~/bundles/animate").Include(
                        "~/Content/ui-framework/css/animate.css"));
            bundles.Add(new StyleBundle("~/bundles/font").Include(
                        "~/Content/ui-framework/css/font.css"));
            bundles.Add(new StyleBundle("~/bundles/plugins").Include(
                        "~/Content/ui-framework/css/plugin.css",
                        "~/Content/ui-framework/js/datepicker/datepicker.css"));
            bundles.Add(new StyleBundle("~/bundles/apps").Include(
                        "~/Content/ui-framework/css/app.css",
                        "~/Content/ui-framework/js/fuelux/fuelux.css"));
        }
    }
}