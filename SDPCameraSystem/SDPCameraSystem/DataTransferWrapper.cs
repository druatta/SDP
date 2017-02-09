using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class DataTransferWrapper
    {
        public SapTransfer Transfer;

        public DataTransferWrapper(AcquisitionDeviceWrapper DeviceWrapper, BufferWrappers BufferWrappers, ViewWrapper ViewWrapper)
        {
            CreateNewDataTransfer(DeviceWrapper, BufferWrappers, ViewWrapper);
        }

        public void CreateNewDataTransfer(AcquisitionDeviceWrapper DeviceWrapper, BufferWrappers BufferWrappers, ViewWrapper ViewWrapper)
        {
            Transfer = new SapAcqDeviceToBuf(DeviceWrapper.Device, BufferWrappers.Buffer);
            UpdateFrameRate(ViewWrapper);
            CheckForSuccessfulDataTransferCreation();
        }

        public void UpdateFrameRate(ViewWrapper ViewWrapper)
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
    }
}
