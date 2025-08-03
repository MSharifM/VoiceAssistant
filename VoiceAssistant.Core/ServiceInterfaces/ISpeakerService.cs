namespace VoiceAssistant.Core.ISpeakerService
{
    public interface ISpeakerService
    {
        Task SpeakAsync(string text);
        void ChangeVolume(int amount);
    }
}
