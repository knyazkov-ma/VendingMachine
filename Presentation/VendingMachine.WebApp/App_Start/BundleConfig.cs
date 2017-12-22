using System.Web.Optimization;

namespace VendingMachine.WebApp
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //VENDOR RESOURCES

            //~/Bundles/App/vendor/css
            bundles.Add(
                new StyleBundle("~/Bundles/App/vendor/css")
                    .Include(
                        "~/Content/bootstrap.css",
                        "~/Content/jquery-ui.css",
                        "~/Content/loading-bar.css"
                    )
                );

            //~/Bundles/App/vendor/js
            bundles.Add(
                new ScriptBundle("~/Bundles/App/vendor/js")
                    .Include(

                        "~/Scripts/json2.min.js",

                        "~/Scripts/modernizr-2.8.3.js",

                        "~/Scripts/jquery-2.1.4.min.js",
                        "~/Scripts/jquery-ui-1.11.4.min.js",

                        "~/Scripts/bootstrap.min.js",

                        "~/Scripts/moment-with-locales.min.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.min.js",
                        "~/Scripts/sweetalert/sweet-alert.min.js",
                        "~/Scripts/others/spinjs/spin.js",
                        "~/Scripts/others/spinjs/jquery.spin.js",


                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-aria.js",
                        "~/Scripts/angular-messages.js",
                        "~/Scripts/angular-animate.min.js",
                        "~/Scripts/svg-assets-cache.js",
                        "~/Scripts/angular-sanitize.min.js",
                        "~/Scripts/angular-ui-router.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap.js",
                        "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                        "~/Scripts/angular-ui/ui-utils.js",
                        "~/Scripts/i18n/angular-locale_ru-ru.js",
                        "~/Scripts/loading-bar.js",
                        "~/Scripts/respond.js"
                    )
                );


            //~/Bundles/App/Main/css
            bundles.Add(
              new StyleBundle("~/Bundles/App/Main/css")
                  .IncludeDirectory("~/App/Main", "*.css", true)
              );


            //~/Bundles/App/Main/js
            bundles.Add(
                new ScriptBundle("~/Bundles/App/Main/js")
                    .IncludeDirectory("~/App/Main", "*.js")
                    .IncludeDirectory("~/App/Main/views/layout", "*.js")
                    .IncludeDirectory("~/App/Main/views/order", "*.js")
                    .IncludeDirectory("~/App/Main/services", "*.js")
                );
            
        }
    }
}
