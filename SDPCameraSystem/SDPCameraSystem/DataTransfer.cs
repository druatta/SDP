using DALSA.SaperaLT.SapClassBasic;

namespace SDPCameraSystem
{
    public class DataTransfer
    {
        public SapTransfer Transfer;

        public DataTransfer(CameraObject DeviceWrapper, ImageBuffers BufferWrappers, ViewingWindow ViewWrapper)
        {
            CreateNewDataTransfer(DeviceWrapper, BufferWrappers, ViewWrapper);
        }

        public void CreateNewDataTransfer(CameraObject DeviceWrapper, ImageBuffers BufferWrappers, ViewingWindow ViewWrapper)
        {
            Transfer = new SapAcqDeviceToBuf(DeviceWrapper.Device, BufferWrappers.Buffers);
            UpdateFrameRate(ViewWrapper);
            CheckForSuccessfulDataTransferCreation(); // Failed! Invalid handle - Buffer
            GrabTransferFeed();
        }

        public void UpdateFrameRate(ViewingWindow ViewWrapper)
        {
            Transfer.Pairs[0].EventType = SapXferPair.XferEventType.EndOfFrame;
            Transfer.XferNotify += new SapXferNotifyHandler(UpdateTransfer);
            Transfer.XferNotifyContext = ViewWrapper.View;
        }

        public void UpdateTransfer(object sender, SapXferNotifyEventArgs args)
        {
            RefreshView(args);
            RefreshFrameRate(sender);
        }

        public void RefreshView(SapXferNotifyEventArgs args)
        {
            SapView View = args.Context as SapView;
            View.Show();
        }

        public void RefreshFrameRate(object sender)
        {
            SapTransfer transfer = sender as SapTransfer;
        }

        public void CheckForSuccessfulDataTransferCreation()
        {
            Transfer.Create();
        }

        public void GrabTransferFeed()
        {
            Transfer.Grab();
        }
    }
}
