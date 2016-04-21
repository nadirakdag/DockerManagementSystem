namespace DMS.Services.Services
{
    using Core.ContainerInterfaces;

    public class ContainerService
    {
        private IContainer container;
        public ContainerService(IContainer container)
        {
            this.container = container;
        }
    }
}
