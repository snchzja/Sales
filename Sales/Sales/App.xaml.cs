namespace Sales
{
    using Views;
    using Xamarin.Forms;

    // El proyecto arranca por aca
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ProductsPage(); // la pagina principal va a ser ProductsPage
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
