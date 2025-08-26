namespace VoiceAssistant.Core.ServiceInterfaces
{
    public interface IRecognizeServices
    {
        public Task StartRecognize();
        public Task StopRecognize();
    }
}
