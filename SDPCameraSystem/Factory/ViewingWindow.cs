using DALSA.SaperaLT.SapClassBasic;

namespace SDPCameraSystem
{
    public class ViewingWindow
    {
        public SapView View;

        public ViewingWindow(ImageBuffers BufferWrappers)
        {
            CreateNewView(BufferWrappers);
            CheckForSuccessfulViewCreation();
        }

        public void CreateNewView(ImageBuffers BufferWrappers)
        {
            View = new SapView(BufferWrappers.Buffers);
        }

        public void CheckForSuccessfulViewCreation()
        {
            View.Create();
        }
    }
}
