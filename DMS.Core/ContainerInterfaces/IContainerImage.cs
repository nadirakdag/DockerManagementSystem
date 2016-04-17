namespace DMS.Core.ContainerInterfaces
{
    public interface IContainerImage{
        object GetImages();
        object PullImage(string image);
        object RemoveImage(string image);
        object SearchImage(string term);
    }
}