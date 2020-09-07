namespace Sales.Infrastructure
{
    using ViewModels;

    // esta clase instancia la MainViewModel
    // Main es el objeto que todas las paginas va a bindear
    // el binding principal va a ir contra el Main
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
