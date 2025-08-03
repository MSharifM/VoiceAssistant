using System.Threading.Tasks;
using VoiceAssistant.Core.ISpeakerService;

namespace VoiceAssistant
{
    public partial class MainPage : ContentPage
    {
        private ISpeakerService _speakerService;

        public MainPage(ISpeakerService speakerService)
        {
            this._speakerService = speakerService;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _speakerService.SpeakAsync("Hello");
        }
    }

}
