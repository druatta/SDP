using DALSA.SaperaLT.SapClassBasic;

namespace SDPCameraSystem
{
    public class DataTransfer
    {
        public static SapTransfer Transfer;

        public DataTransfer()
        {
            Transfer = new SapAcqDeviceToBuf(Node.Device, ImageBuffers.Buffers);
            UpdateFrameRate();
            CheckForSuccessfulDataTransferCreation();
            GrabTransferFeed();
        }

        public void UpdateFrameRate()
        {
            Transfer.Pairs[0].EventType = SapXferPair.XferEventType.EndOfFrame;
            Transfer.XferNotify += new SapXferNotifyHandler(UpdateTransfer);
            Transfer.XferNotifyContext = ViewingWindow.View;
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
