using Discord;
using Discord.WebSocket;
using System;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;

namespace TestBot
{
    class Program
    {
        static void Main(string[] args) => new Program().StartAsync().GetAwaiter().GetResult();
        private DiscordSocketClient _client;
        public async Task StartAsync()
        {
            Log(" Use Ctrl + Alt + X to start & to select items ", ConsoleColor.Green);

            var token = (File.ReadAllText("token.txt"));

            userid = ulong.Parse(File.ReadAllText("userid.txt"));
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync();

            var tm = new System.Timers.Timer();
            tm.Interval = 100;
            tm.Elapsed += Tm_Elapsed;
            tm.Start();
            

            _client = new DiscordSocketClient();
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            _client.GuildAvailable += _client_GuildAvailable;
            await Task.Delay(-1);
        }
        bool running = false;
        private void Tm_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!running && started)
            {
                running = true;
                BackgroundWorker bw2 = new BackgroundWorker();
                bw2.DoWork += Bw2_DoWork;
                bw2.RunWorkerAsync();
            }
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            _hookID = SetHook(_proc);  //Set our hook
            Application.Run();         //Start a standard application method loop
        }
        public void Bw2_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                var ControlUser = Guild.GetUser(userid);
                if (ControlUser.VoiceChannel == null) throw new Exception("You need to be in a voice channel to use this feature");
                Log("Selecting VoiceChannel...", ConsoleColor.Green);
                var Channel = SelectChannel(Guild);
                Log("Channel " + Channel.Name + " Selected!", ConsoleColor.Green);
                if (Channel != null)
                {
                    Say("choose a User");
                    var user = SelectUser(Channel);
                    Log("User " + user.Username + " Selected!", ConsoleColor.Green);

                    
                    var ToVoicechannel = ControlUser.VoiceChannel;

                    Log($"Moving {user.Username} to {ToVoicechannel.Name}", ConsoleColor.Green);
                    user.ModifyAsync(x => x.Channel = ToVoicechannel);
                }
                
            }
            catch (Exception ex)
            {
                Log(ex.Message, ConsoleColor.Red);
                Say(ex.Message);
            }
            running = false;
            started = false;

        }
        SocketGuild Guild = null;
        private async Task _client_GuildAvailable(SocketGuild arg)
        {
            Guild = arg;
        }
        public void Say(string text)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = -2;     // -10...10
            synthesizer.Speak(text);
        }
        public static bool selected = false;
        private SocketVoiceChannel SelectChannel(SocketGuild arg)
        {
            var channels = arg.VoiceChannels.Where(x => x.Users.Count != 0 && !x.Users.Any(z => z.Id == userid));
            if (channels.Count() != 0)
            {
                Say("choose a channel");


                foreach (var item in channels)
                {
                    Say(item.Name);
                    Thread.Sleep(500);

                    if (selected)
                    {
                        selected = false;
                        return item;

                    }
                }
                selected = false;
                throw new Exception("No channel selected, exiting");
            }
            else
            {
                throw new Exception("Cant find other channels with users in them");
            }
        }
        ulong userid = 0;
        private SocketGuildUser SelectUser(SocketVoiceChannel channel)
        {
            foreach (var item in channel.Users.Where(x=> x.Id != userid))
            {
                Say(item.Username);

                Thread.Sleep(500);

                if (selected)
                {
                    selected = false;
                    return item;
                }
            }
            selected = false;
            throw new Exception("No user selected, exiting");
        }


        public static async Task Log(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine( message, color);
            Console.ResetColor();
        }




        ///////////////////////////////////////////////////////////
        //A bunch of DLL Imports to set a low level keyboard hook
        ///////////////////////////////////////////////////////////
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        ////////////////////////////////////////////////////////////////
        //Some constants to make handling our hook code easier to read
        ////////////////////////////////////////////////////////////////
        private const int WH_KEYBOARD_LL = 13;                    //Type of Hook - Low Level Keyboard
        private const int WM_KEYDOWN = 0x0100;                    //Value passed on KeyDown
        private const int WM_KEYUP = 0x0101;                      //Value passed on KeyUp
        private static LowLevelKeyboardProc _proc = HookCallback; //The function called when a key is pressed
        private static IntPtr _hookID = IntPtr.Zero;
        private static bool CONTROL_DOWN = false;                 //Bool to use as a flag for control key


        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        public static bool started = false;
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN) //A Key was pressed down
            {
                int vkCode = Marshal.ReadInt32(lParam);           //Get the keycode
                string theKey = ((Keys)vkCode).ToString();
                if (theKey.Contains("LMenu"))                //If they pressed control
                {
                    CONTROL_DOWN = true;                          //Flag control as down
                }
                else if (CONTROL_DOWN && theKey == "X")           //If they held CTRL and pressed B
                {
                    if (started)
                    {
                        selected = true;
                    }
                    else
                    {
                        started = true;
                    }
                    
                }
            }
            else if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP) //KeyUP
            {
                int vkCode = Marshal.ReadInt32(lParam);        //Get Keycode
                string theKey = ((Keys)vkCode).ToString();     //Get Key name
                if (theKey.Contains("LMenu"))             //If they let go of control
                {
                    CONTROL_DOWN = false;                      //Unflag control
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam); //Call the next hook
        }
    }
}



