using System.Web.Optimization;

namespace IMAS.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // this style have been shared by visitor and user area
            bundles.Add(new StyleBundle("~/content/assets/global/plugins/(font_Icon_Bootstrap)").Include(
    "~/content/assets/global/plugins/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform()).Include(
    "~/content/assets/global/plugins/simple-line-icons/simple-line-icons.css", new CssRewriteUrlTransform()).Include(
    "~/content/assets/global/plugins/bootstrap/css/bootstrap-rtl.min.css", new CssRewriteUrlTransform()));

            // styles which is used in visitor area
            bundles.Add(new StyleBundle("~/visitor-area-styles").Include(
                "~/content/assets/global/css/components-md-rtl.opt.css", new CssRewriteUrlTransform()).Include(
                "~/content/assets/layouts/layout3/css/layout-rtl.min.css", new CssRewriteUrlTransform()).Include(
                "~/content/assets/layouts/layout3/css/themes/default-rtl.min.css", new CssRewriteUrlTransform()).Include(
                "~/content/assets/layouts/layout3/css/custom-rtl.min.css", new CssRewriteUrlTransform()).Include(
                "~/content/assets/global/css/IMAS.css", new CssRewriteUrlTransform()).Include(
                "~/content/assets/global/css/visitor_layout.css",new CssRewriteUrlTransform()));

            //bundles.Add(new StyleBundle(""))

            bundles.Add(new StyleBundle("~/user-area-styles").Include(
                "~/content/assets/global/css/components-rtl.min.css", new CssRewriteUrlTransform()).Include(
                "~/content/assets/global/css/plugins-rtl.min.css", new CssRewriteUrlTransform()).Include(
                "~/content/assets/layouts/layout2/css/layout-rtl.min.css", new CssRewriteUrlTransform()).Include(
                "~/content/assets/layouts/layout2/css/themes/blue-rtl.min.css", new CssRewriteUrlTransform()).Include(
                "~/content/assets/layouts/layout2/css/custom-rtl.min.css", new CssRewriteUrlTransform()).Include(
                "~/content/assets/global/plugins/bootstrap-toastr/toastr-rtl.min.css", new CssRewriteUrlTransform()).Include(
                "~/content/assets/global/css/IMAS.css", new CssRewriteUrlTransform()).Include(
                "~/content/assets/global/css/User_Layout.css", new CssRewriteUrlTransform()));

            // visitor advertisment page styles
            bundles.Add(new StyleBundle("~/visitor-area-advertisment-page-styles").Include(
                    "~/content/assets/pages/css/visitor_profile_index.css", new CssRewriteUrlTransform()).Include(
                    "~/Content/assets/global/css/IMAS-charts.css", new CssRewriteUrlTransform()).Include(
                    "~/Content/assets/pages/css/user_dashboard.css", new CssRewriteUrlTransform()));

            // visistor home page styles
              bundles.Add(new StyleBundle("~/visitor-area-home-page-styles").Include(
                    "~/Content/assets/pages/css/visitor_home_index.css", new CssRewriteUrlTransform()).Include(
                    "~/Content/assets/global/plugins/ListGridView/css/style.css", new CssRewriteUrlTransform()).Include(
                    "~/Content/assets/global/plugins/ListGridView/css/jquery-mobile.css", new CssRewriteUrlTransform()));
              
            // user-area-advertisment-edit-styles
              bundles.Add(new StyleBundle("~/user-area-advertisment-edit-styles").Include(
                    "~/Content/assets/global/plugins/sweetalert/sweetalert.css", new CssRewriteUrlTransform()).Include(
                    "~/Content/assets/global/plugins/light-fileupload/css/style.css", new CssRewriteUrlTransform()));
          
            // user-area-advertisment-edit-styles
              bundles.Add(new StyleBundle("~/user-area-active-advertismets-styles").Include(
                    "~/content/assets/global/plugins/datatables/datatables.min.css", new CssRewriteUrlTransform()).Include(
                    "~/content/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap-rtl.css", new CssRewriteUrlTransform()));

            // visitor-signin-layout-styles"
            bundles.Add(new StyleBundle("~/visitor-signin-layout-styles").Include(
                    "~/content/assets/global/css/components-rtl.min.css", new CssRewriteUrlTransform()).Include(
                    "~/Content/assets/global/css/signin_layout.css", new CssRewriteUrlTransform()).Include(
                    "~/Content/assets/global/css/IMAS.css", new CssRewriteUrlTransform()));


           // visitor area scripts
           bundles.Add(new ScriptBundle("~/visitor-area-scripts").Include(
       "~/content/assets/global/plugins/jquery.min.js",
       "~/content/assets/global/plugins/bootstrap/js/bootstrap.min.js",
       "~/content/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
       "~/content/assets/global/scripts/app.min.js",
       "~/content/assets/layouts/layout3/scripts/layout.min.js",
       "~/content/assets/global/plugins/persian-number/persianumber.min.js",
       "~/content/assets/global/scripts/IMAS.js"
       ));

            // user area scripts
            bundles.Add(new ScriptBundle("~/user-area-scripts").Include(
               "~/Scripts/jquery-2.2.3.min.js",
               "~/content/assets/global/plugins/bootstrap/js/bootstrap.min.js",
               "~/content/assets/global/plugins/js.cookie.min.js",
               "~/content/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
               "~/content/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
               "~/content/assets/global/plugins/jquery.blockui.min.js",
               "~/Content/assets/global/plugins/bootstrap-toastr/toastr.min.js",
               "~/content/assets/global/scripts/app.min.js",
               "~/content/assets/layouts/layout2/scripts/layout.min.js",
               "~/content/assets/pages/scripts/user_layout.js",
               "~/content/assets/global/plugins/persian-number/persianumber.min.js"
               ));
          // visitor area advertimsment page scripts
            bundles.Add(new ScriptBundle("~/visitor-area-advertisment-scripts").Include(
                "~/Content/assets/global/scripts/string-extensions.js",
               "~/Content/assets/global/plugins/botbox/bootbox.min.js",
               "~/Content/assets/pages/scripts/visitor_advertisment_index.js",
               "~/Content/assets/global/plugins/amcharts/amcharts.js",
               "~/Content/assets/global/plugins/amcharts/serial.js",
               "~/Content/assets/global/plugins/amcharts/lang/fa.js",
               "~/Content/assets/global/scripts/IMAS-charts.js"      
               ));

            //user-area-advertisment-edit-scripts
            bundles.Add(new ScriptBundle("~/user-area-advertisment-edit-scripts").Include(
               "~/scripts/jquery.validate.min.js",
              "~/scripts/jquery.validate.unobtrusive.min.js",
              "~/Content/assets/global/plugins/sweetalert/sweetalert.min.js",
              "~/Content/assets/global/plugins/light-fileupload/js/uploader-common.js",
              "~/Content/assets/global/plugins/light-fileupload/js/uploder-multiple.core.js",
              "~/Content/assets/global/scripts/string-extensions.js",
              "~/Content/assets/global/scripts/currency-auto-formatter.js",
              "~/content/assets/pages/scripts/user_advertisment_edit.js"
              ));

    //user-area-active-advertisment-scripts
            bundles.Add(new ScriptBundle("~/user-area-active-advertismets-scripts").Include(
              "~/content/assets/global/plugins/datatables/datatables.min.js",
              "~/content/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js",
              "~/content/assets/global/plugins/datatables/zw-datatable.js",
              "~/content/assets/pages/scripts/user_advertisment_active-advertisments.js"
              ));

                //signin-layout-scripts
            bundles.Add(new ScriptBundle("~/signin-layout-scripts").Include(
              "~/content/assets/global/plugins/jquery.min.js",
              "~/scripts/jquery.validate.min.js",
              "~/scripts/jquery.validate.unobtrusive.min.js",
              "~/content/assets/global/plugins/bootstrap/js/bootstrap.min.js",
              "~/content/assets/global/plugins/backstretch/jquery.backstretch.min.js",
              "~/content/assets/global/scripts/IMAS.js",
              "~/content/assets/pages/scripts/signin_layout.js"
              ));
            
              bundles.Add(new ScriptBundle("~/content/assets/global/scripts/IMAS.js").Include("~/content/assets/global/scripts/IMAS.js"));
              bundles.Add(new ScriptBundle("~/Content/assets/pages/scripts/visitor_home_index.js").Include("~/Content/assets/pages/scripts/visitor_home_index.js"));
            // signalR scripts 
            //bundles.Add(new ScriptBundle("~/signalR-scripts").Include(
            //            "~/Scripts/jquery.signalR-2.2.1.min.js",
            //            "~/signalr/hubs"
            //            ));   

        }
    }
}
