using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToURI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static Encoding[] inputEncodings = new Encoding[]
        {
            new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true),
            Encoding.GetEncoding(1251, new EncoderExceptionFallback(), new DecoderExceptionFallback()),
        };
        public static void ProcessFile(string filename, ref string oldEncodingName, Encoding newEncoding)
        {
            var bytes = File.ReadAllBytes(filename);

            string text = null;
            bool isASCII = true;

            foreach (byte b in bytes)
            {
                if (b < 128) continue;
                isASCII = false;
                break;
            }

            if (isASCII)
            {
                oldEncodingName = "ASCII";
                text = Encoding.Default.GetString(bytes);
            }
            else if (bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
            {
                oldEncodingName = "UTF-8 с BOM";
                if (bytes.Length > 3) text = Encoding.UTF8.GetString(bytes, 3, bytes.Length - 3);
                else text = "";
            }
            else if (bytes.Length >= 4 && bytes[0] == 0xFF && bytes[1] == 0xFE && bytes[2] == 0 && bytes[3] == 0)
            {
                oldEncodingName = "UTF-32 LE";
                if (bytes.Length > 4) text = Encoding.UTF32.GetString(bytes, 4, bytes.Length - 4);
                else text = "";
            }
            else if (bytes.Length >= 4 && bytes[0] == 0 && bytes[1] == 0 && bytes[2] == 0xFE && bytes[3] == 0xFF)
            {
                oldEncodingName = "UTF-32 BE";
                if (bytes.Length > 4) text = new UTF32Encoding(true, false).GetString(bytes, 4, bytes.Length - 4);
                else text = "";
            }
            else if (bytes.Length >= 2 && bytes[0] == 0xFF && bytes[1] == 0xFE)
            {
                oldEncodingName = "UTF-16 LE";
                if (bytes.Length > 2) text = Encoding.Unicode.GetString(bytes, 2, bytes.Length - 2);
                else text = "";
            }
            else if (bytes.Length >= 2 && bytes[0] == 0xFE && bytes[1] == 0xFF)
            {
                oldEncodingName = "UTF-16 BE";
                if (bytes.Length > 2) text = Encoding.BigEndianUnicode.GetString(bytes, 2, bytes.Length - 2);
                else text = "";
            }
            else foreach (var enc in inputEncodings)
                {
                    try { text = enc.GetString(bytes); }
                    catch (Exception) { continue; }
                    oldEncodingName = enc.EncodingName;
                    break;
                }

            if (text == null)
            {
                oldEncodingName = "Unknown";
                return;
            }            

            if (newEncoding != null) File.WriteAllText(filename, text, newEncoding);
        }
    }
}
