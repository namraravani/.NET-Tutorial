using Events_And_Delegates;

namespace EventsAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { title = "Video 1" };
            var videoEncoder = new VideoEncoder();
            var mailService = new MailService(); 

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.Encode(video);

        }
    }


}
