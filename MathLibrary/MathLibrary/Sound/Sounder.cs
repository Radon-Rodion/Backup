using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Globalization;

namespace MathLibrary.Sound
{
    public class Sounder
    {
        public void Process(string text)
        {
            var synthesizer = new SpeechSynthesizer();
            var voices = synthesizer.GetInstalledVoices();
            synthesizer.SelectVoice("Microsoft Irina Desktop");
            synthesizer.Speak("Всё, что нам нужно сделать, это продолжать говорить");
            var builder = new PromptBuilder();
            builder.StartVoice(new CultureInfo("ru-RU"));
            builder.AppendText("Всё, что нам нужно сделать, это продолжать говорить. Yes yes yes.");
            builder.EndVoice();
            synthesizer.Speak(builder);
        }
    }
}
