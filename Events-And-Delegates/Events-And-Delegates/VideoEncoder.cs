using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_And_Delegates
{
    internal class VideoEncoder
    {
        public delegate void VideoEncodedEventHandler(object source,EventArgs args);

        public event VideoEncodedEventHandler VideoEncoded;


        public void Encode(VideoEncoder video)
        {
            Console.WriteLine("encodeing the video");
            Thread.Sleep(3000);

            OnVideoEncoded();
        }

        protected virtual void OnVideoEncoded()
        {
            if(VideoEncoded != null) VideoEncoded(this, EventArgs.Empty);
        }
    }
}
