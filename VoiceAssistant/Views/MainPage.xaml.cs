using System.Threading.Tasks;
using VoiceAssistant.Core.ISpeakerService;
using System.Speech.Recognition;

namespace VoiceAssistant
{
    public partial class MainPage : ContentPage
    {
        private ISpeakerService _speakerService;
        //private MainViewModel vm = new MainViewModel();

        public MainPage(ISpeakerService speakerService)
        {
            this._speakerService = speakerService;
            //BindingContext = vm;
            InitializeComponent();
        }

            SpeechRecognitionEngine engine = new();
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _speakerService.SpeakAsync("Hello");

            Choices commands = new Choices();

            List<string> instr = new List<string>()
            {
                "Say Hello",
                "What is your name",
                "Say Bye",
                "Hassan",
            };
            commands.Add(phrases: instr.ToArray());
            GrammarBuilder grammarBuilder = new();
            grammarBuilder.Append(commands);
            Grammar grammar = new Grammar(grammarBuilder);
            engine.LoadGrammarAsync(grammar);
            engine.SetInputToDefaultAudioDevice();
            engine.RecognizeAsync(RecognizeMode.Multiple);

        }

        private void Rec_Engine_speechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            txtLog.Text += e.Result.Text;
        }

        public async void OnClickBtnStart(object sender , EventArgs e)
        {
            engine.RecognizeAsyncStop();
        }
    }

}
