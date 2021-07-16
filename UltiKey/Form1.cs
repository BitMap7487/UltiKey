using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace UltiKey
{
    public partial class Main : Form
    {

        public static int KeyTotal;
        public static List<string> Keys = new List<string>();

        public Main()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Main_Load(object sender, EventArgs e)
        { 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Help_Click(object sender, EventArgs e)
        {

            Help help = new Help();
            help.ShowDialog();

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Generate_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Starting to generate, This might take a while.");

            Keys.Clear();
            KeyTotal = 0;
            Genned.Clear();

            try
            {
                KeyTotal = int.Parse(Amount.Text);
            }
            catch
            {
                KeyTotal = 20000000;
                MessageBox.Show($"The amount is to high, Amount set to: {KeyTotal}");
            }

            for (int i = 0; i < KeyTotal; i++)
            {

                string KeyFormat = Format.Text;

                char[] FormatChars = KeyFormat.ToCharArray();

                StringBuilder sb = new StringBuilder();

                foreach (char chars in FormatChars)
                {

                    if (chars.ToString() == "X")
                    {

                        sb.Append(FullRandomUpper());

                    }
                    else if (chars.ToString() == "x")
                    {

                        sb.Append(FullRandomLower());

                    }
                    else if (chars.ToString() == "A")
                    {

                        sb.Append(RandomUpper());

                    }
                    else if (chars.ToString() == "a")
                    {
                        sb.Append(RandomLower());
                    }
                    else if (chars.ToString() == "0")
                    {

                        sb.Append(RandomNumber());

                    }
                    else if (chars.ToString() == "-")
                    {

                        sb.Append("-");

                    }
                    else if (chars.ToString() == ":")
                    {

                        sb.Append(":");

                    }
                    else if (chars.ToString() == " ")
                    {

                        sb.Append(" ");

                    }

                }

                Keys.Add(sb.ToString());

            }

            Genned.AppendText("\n");
            Preview.Text = Keys.First();
            foreach (string Key in Keys)
            {

                Genned.AppendText(Key.ToString() + Environment.NewLine);

            }

            MessageBox.Show($"Done generating {KeyTotal} keys.");

        }

        private void Save_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Start Saving");

            using (TextWriter tw = new StreamWriter(@"Keys.txt"))
            {
                foreach (string Key in Keys)
                {

                    tw.WriteLine(Key.ToString());

                }
            }

            MessageBox.Show("Done");

        }

        private static Random random = new Random();

        private static string FullRandomUpper()
        {
            string charset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            return new string(Enumerable.Repeat<string>(charset, 1).Select(new Func<string, char>(m1)).ToArray<char>());
        }

        private static string FullRandomLower()
        {
            string charset = "abcdefghijkmnopqrstuvwxyz1234567890";
            return new string(Enumerable.Repeat<string>(charset, 1).Select(new Func<string, char>(m1)).ToArray<char>());
        }

        private static string RandomUpper()
        {
            string charset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat<string>(charset, 1).Select(new Func<string, char>(m1)).ToArray<char>());
        }

        private static string RandomLower()
        {
            string charset = "abcdefghijkmnopqrstuvwxyz";
            return new string(Enumerable.Repeat<string>(charset, 1).Select(new Func<string, char>(m1)).ToArray<char>());
        }

        private static string RandomNumber()
        {
            string charset = "012345678901234567890123456789";
            return new string(Enumerable.Repeat<string>(charset, 1).Select(new Func<string, char>(m1)).ToArray<char>());
        }

        private static char m1(string string_0)
        {
            return string_0[random.Next(string_0.Length)];
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);



        }

        #region presets
        private void button3_Click(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "AAAAA:AAAA-AAAA-AAAA-AAAA";

        }

        private void UplayBtn_Click(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "AAAA-AAAA-AAAA-AAAA";

        }

        private void NitroBtn_Click_1(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "XXXXXXXXXXXXXXXXXXX";

        }

        private void GeforceBtn_Click_1(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "XXXXXXXXXXXXXXXXXXXXXXXX";

        }

        private void AmazonBtn_Click_1(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "XXXX-XXXXXX-XXXX";

        }

        private void ItunesBtn_Click_1(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "XXXX-XXXX-XXXX-XXXX";

        }

        private void MicrosoftBtn_Click_1(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX";

        }

        private void NetflixBtn_Click_1(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "XXXXXXXXXXX";

        }

        private void PlaystationBtn_Click_1(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "XXXX-XXXX-XXXX";

        }

        private void SteamBtn_Click_1(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "XXXX-XXXX-XXXX";

        }

        private void XboxBtn_Click_1(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX";

        }

        private void BlizzardBtn_Click_1(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "XXXXXXXXXXXXXXXXXXXX";

        }

        private void MinecraftBtn_Click_1(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "XXXX-XXXX-XXXX";

        }

        private void PaySafeBtn_Click_1(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "0000-0000-0000-0000";

        }

        private void FortniteBtn_Click_1(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "XXXXX-XXXX-XXXX";

        }

        private void RobloxBtn_Click_1(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "000 000 0000";

        }

        private void NintendoBtn_Click_1(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "XXXXXXXXXXXXXXXX";

        }

        private void GoogleBtn_Click_1(object sender, EventArgs e)
        {

            Format.Clear();
            Format.Text = "XXXX XXXX XXXX XXXX";

        }
        #endregion

    }
}
