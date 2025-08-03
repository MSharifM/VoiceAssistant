using VoiceAssistant.Core.ISpeakerService;
//#if WINDOWS
using System.Speech.Synthesis;
using System.Threading.Tasks;

namespace VoiceAssistant.Platform.Services
{
    public class SpeakerService : ISpeakerService
    {
        private SpeechSynthesizer _speaker;
        public SpeakerService()
        {
            _speaker = new();
            _speaker.SetOutputToDefaultAudioDevice();
        }

        public async Task SpeakAsync(string text)
        {
#if WINDOWS
            _speaker.SpeakAsync(text);
#endif
        }
        public void ChangeVolume(int amount)
        {
            _speaker.Volume = amount;
        }
    }
}