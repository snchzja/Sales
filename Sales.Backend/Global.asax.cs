namespace Sales.Backend
{
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Controlar las migraciones, cada vez que arranque controlar la base de datos
            // y si la base de datos cambió, vas a migrar la base de datos para que no haya problemas
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<Models.LocalDataContext,
                Migrations.Configuration>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
