namespace DMS.Docker
{
    using System;
    using DMS.Core.ContainerInterfaces;

    public class Image : IContainerImage
    {
        public object GetImages()
        {
            throw new NotImplementedException();
        }

        public object PullImage(string image)
        {
            throw new NotImplementedException();
        }

        public object RemoveImage(string image)
        {
            throw new NotImplementedException();
        }

        public object SearchImage(string term)
        {
            throw new NotImplementedException();
        }
    }
}