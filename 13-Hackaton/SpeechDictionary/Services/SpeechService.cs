using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeechDictionary.Core;
using SpeechDictionary.Core.Services;
using System.Speech.Synthesis;

namespace SpeechDictionary.Core.Services
{
    public class SpeechService
    {
        public static void Speak(string message)
        {
            // Initialize a new instance of the SpeechSynthesizer.
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);

                // Configure the audio output. 
                synth.SetOutputToDefaultAudioDevice();

                // Speak a string synchronously.
                synth.Speak(message);
            }
        }
    }
}
