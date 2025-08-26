using System.Speech.Recognition;
using VoiceAssistant.Core.ServiceInterfaces;

namespace VoiceAssistant.Platform.Services
{
    public class RecognizeServices : IRecognizeServices
    {
        SpeechRecognitionEngine recognitionEngine = new();

        public RecognizeServices()
        {
            SetSetting();
        }

        private async Task SetSetting()
        {
            AddSentences();
            SetDefaultAudioDevice();
        }

        private async Task AddSentences()
        {
            Choices sentences = new Choices();

            List<string> sentencesList = new List<string>();

            sentences.Add(phrases: sentencesList.ToArray());
            GrammarBuilder grammarBuilder = new();
            grammarBuilder.Append(sentences);
            Grammar grammar = new Grammar(grammarBuilder);

            recognitionEngine.LoadGrammarAsync(grammar);
        }

        private async Task SetDefaultAudioDevice()
        {
            recognitionEngine.SetInputToDefaultAudioDevice();
        }

        public async Task StartRecognize()
        {
            recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
            recognitionEngine.SpeechRecognized += Rec_Engine_speechRecognized;
        }

        public async Task StopRecognize()
        {
            recognitionEngine.RecognizeAsyncStop();
        }

        private void Rec_Engine_speechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            
        }

        public async Task SendResult(string text)
        {

        }
    }
}
