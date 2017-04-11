using DALSA.SaperaLT.SapClassBasic;

namespace SDPCameraSystem
{
    public class ViewingWindow
    {
        public static SapView View;

        public ViewingWindow()
        {
            CreateNewView();
            CheckForSuccessfulViewCreation();
        }

        public void CreateNewView()
        {
            View = new SapView(ImageBuffers.Buffers);
        }

        public void CheckForSuccessfulViewCreation()
        {
            View.Create();
        }
    }
}
