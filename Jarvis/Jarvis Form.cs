using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Jarvis
{
    public partial class Jarvis_Form : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(HandleRef hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr WindowHandle);
        public const int SW_RESTORE = 9;

        public bool wake = false;

        public Jarvis_Form()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btn_jarvis_Click(null,null);
        }

        SpeechSynthesizer s = new SpeechSynthesizer();
        SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
        PromptBuilder pb = new PromptBuilder();


        private void Jarvis_Form_Load(object sender, EventArgs e)
        {

        }

        private void btn_jarvis_Click(object sender, EventArgs e)
        {
            tb_output.Text = "Log: ";
            s.SelectVoiceByHints(VoiceGender.Neutral);
            Choices list = new Choices();
            list.Add(File.ReadAllLines(@"C:\Users\zswogger\source\repos\Jarvis\Commands.txt"));

            Grammar gm = new Grammar(new GrammarBuilder(list));

            try
            {
                sr.RequestRecognizerUpdate();
                sr.LoadGrammar(gm);
                sr.SpeechRecognized += sr_SpeechRecognized;
                sr.SetInputToDefaultAudioDevice();
                sr.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                return;
            }

            pb.ClearContent();
            s.Speak(pb);
        }




        public void Say(String phrase)
        {
            s.SpeakAsync(phrase);
            wake = false;
        }




        private void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speechSaid = e.Result.Text;
            System.Media.SoundPlayer confirmplayer = new System.Media.SoundPlayer(@"C:\Windows\Media\Speech Off.wav");

            if (speechSaid == "jarvis")
            {
                System.Media.SoundPlayer wakeplayer = new System.Media.SoundPlayer(@"C:\Windows\Media\Speech On.wav");
                wakeplayer.Play();
                wake = true;
            }

            if (wake)
            {
                
                switch (speechSaid)
                {
                    case ("test"):
                        tb_output.Text = tb_output.Text + Environment.NewLine + speechSaid;
                        Say("this is a test message. how does it sound?");
                        break;

                    case ("close"):
                        tb_output.Text = tb_output.Text + Environment.NewLine + speechSaid;
                        confirmplayer.Play();
                        this.Close();
                        break;

                    case ("open chrome"):
                        tb_output.Text = tb_output.Text + Environment.NewLine + speechSaid;
                        confirmplayer.Play();
                        Process[] chromeproc = System.Diagnostics.Process.GetProcessesByName("chrome");
                        if (chromeproc.Length > 0)
                        {
                            FocusProcess("chrome");
                            break;
                        }
                        Process.Start("chrome.exe");
                        wake = false;
                        break;

                    case ("open edge"):
                        tb_output.Text = tb_output.Text + Environment.NewLine + speechSaid;
                        //confirmplayer.Play();
                        Process[] edgeproc = System.Diagnostics.Process.GetProcessesByName("msedge");
                        if (edgeproc.Length > 0)
                        {
                            confirmplayer.Play();
                            FocusProcess("msedge");
                            break;
                        }
                        Process.Start("msedge.exe");
                        wake = false;
                        break;

                    case ("open black bod"):
                        tb_output.Text = tb_output.Text + Environment.NewLine + "open blackbaud";
                        confirmplayer.Play();
                        Process.Start("https://lindenhall.myschoolapp.com/app/faculty#login");
                        wake = false;
                        break;

                    case ("open outlook"):
                        tb_output.Text = tb_output.Text + Environment.NewLine + speechSaid;
                        confirmplayer.Play();
                        Process[] outlookproc = System.Diagnostics.Process.GetProcessesByName("outlook");
                        if (outlookproc.Length > 0)
                        {
                            FocusProcess("outlook");
                            break;
                        }
                        else
                        {
                            Process.Start("outlook.exe");
                            wake = false;
                            break;
                        }

                    case ("exit application"):
                        tb_output.Text = tb_output.Text + Environment.NewLine + speechSaid;
                        confirmplayer.Play();
                        SendKeys.Send("%{F4}");
                        wake = false;
                        break;

                    case ("new tab"):
                        tb_output.Text = tb_output.Text + Environment.NewLine + speechSaid;
                        confirmplayer.Play();
                        SendKeys.Send("^t");
                        wake = false;
                        break;

                    case ("what's the weather"):
                        tb_output.Text = tb_output.Text + Environment.NewLine + speechSaid;
                        Process.Start("https://www.accuweather.com/en/us/lancaster/17602/weather-forecast/330289");
                        wake = false;
                        break;

                    case ("open active directory"):
                        tb_output.Text = tb_output.Text + Environment.NewLine + speechSaid;
                        confirmplayer.Play();
                        Process.Start("AD.exe");
                        wake = false;
                        break;

                    case ("open gmail"):
                        tb_output.Text = tb_output.Text + Environment.NewLine + speechSaid;
                        confirmplayer.Play();
                        Process.Start("https://www.gmail.com");
                        wake = false;
                        break;

                    case ("close tab"):
                        tb_output.Text = tb_output.Text + Environment.NewLine + speechSaid;
                        confirmplayer.Play();
                        SendKeys.Send("^w");
                        wake = false;
                        break;
                }
            }

        }

        private void FocusProcess(string procName)
        {
            Process[] objProcesses = System.Diagnostics.Process.GetProcessesByName(procName); 
            if (objProcesses.Length > 0)
            {
                IntPtr hWnd = IntPtr.Zero;
                hWnd = objProcesses[0].MainWindowHandle;
                ShowWindowAsync(new HandleRef(null, hWnd), SW_RESTORE);
                SetForegroundWindow(objProcesses[0].MainWindowHandle);
            }
        }
    }
}
