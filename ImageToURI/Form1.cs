using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToURI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // файл для обработки и папка с изображениями
        string filePath, folderPath;

        string rootFolderPath;

        private void Button1_Click(object sender, EventArgs e)
        {
            TransformToURL();
            Process.Start(filePath);
        }

        private string[] DeleteMetaInFile(string fileFullName)
        {
            string[] text = File.ReadAllLines(fileFullName);

            string pattern = @"<meta[\s\S]";

            Regex regex = new Regex(pattern);
            for (int i = 0; i < text.Length; i++)
            {
                if (regex.IsMatch(text[i]))
                {
                    text[i] = Regex.Replace(text[i], pattern, "");
                }
            }            

            return text;
        }

        private void TransformToURL()
        {
            string[] text = File.ReadAllLines(filePath);
            string[] text1 = text;

            DirectoryInfo directory = new DirectoryInfo(folderPath);
            var filesInDirectory = directory.GetFiles();
            string[] filesNames = new string[filesInDirectory.Length];
            string[] filesFullNames = new string[filesInDirectory.Length];
            string[] patterns = new string[filesInDirectory.Length];

            int filesCounter = 0;
            foreach (var file in filesInDirectory)
            {
                filesNames[filesCounter] = file.Name;
                filesFullNames[filesCounter] = file.FullName;
                filesCounter++;
            }
            filesCounter = 0;

            // Создание необходимого количества патернов
            for (int i = 0; i < filesNames.Length; i++)
            {
                patterns[filesCounter] = @"<img(\s+)width(.{1,})" + filesNames[filesCounter] + "\">";
                filesCounter++;
            }

            int patternCounter;
            for (int i = 0; i < text.Length; i++)
            {
                Regex regex;

                // Совмещение строк с названием картинки
                foreach (var fileName in filesNames)
                {
                    regex = new Regex(fileName);
                    if (regex.IsMatch(text[i]))
                    {
                        text1[i] = text1[i - 1] + " " + text[i];
                        text1[i - 1] = "";
                    }
                }

                // Замещение строк с картинками на URI
                patternCounter = 0;
                foreach (var pattern in patterns)
                {
                    regex = new Regex(pattern);
                    if (regex.IsMatch(text[i]))
                    {
                        text1[i] = Regex.Replace(text[i], pattern, ImgToURI(filesFullNames[patternCounter]));
                    }
                    patternCounter++;
                }



            }


            File.WriteAllLines(filePath, text1);
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            txtEditor.Text += "Выбран " + openFileDialog.FileName;
            filePath = openFileDialog.FileName;
        }

        private static string ImgToURI(string imgFile)
        {
            return "<img src=\"data:image/"
                        + Path.GetExtension(imgFile).Replace(".", "")
                        + ";base64,"
                        + Convert.ToBase64String(File.ReadAllBytes(imgFile)) + "\" />";
        }
          
        private void BtnSelectImageFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                dialog.ShowDialog();
                txtEditor.Text += "Выбрана папка: " + dialog.SelectedPath;
                folderPath = dialog.SelectedPath;
            }
        }

        private void BtnJustDoIt_Click(object sender, EventArgs e)
        {
            DirectoryInfo rootDirectory = new DirectoryInfo(rootFolderPath);
            var directories = rootDirectory.GetDirectories();
            bool checkExtension;
            foreach (var directory in directories)
            {
                checkExtension = false;

                if (directory.GetDirectories().Length != 0)
                {
                    // Получение папки с изображениями
                    var subdirectories = directory.GetDirectories();

                    

                    foreach (var subdirectory in subdirectories)
                    {
                        foreach (var file in subdirectory.GetFiles())
                        {
                            if (file.Extension == ".png" || file.Extension == ".jpg" || file.Extension == ".jpeg")
                            {
                                checkExtension = true;
                                break;
                            }
                        }
                        folderPath = subdirectory.FullName;
                    }

                }

                // Получение html файла для обработки и удаление meta в файлах
                var files = directory.GetFiles();
                foreach (var file in files)
                {
                    filePath = file.FullName;
                    DeleteMetaInFile(filePath);
                }
                                       
                if (directory.GetDirectories().Length != 0)
                {
                    TransformToURL();

                    if (checkExtension == true)
                    {
                        Process.Start(filePath);
                    }
                }
                }
            }
        }

        private void Btn_Select_Root_Folder_Click(object sender, EventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                dialog.ShowDialog();
                txtEditor.Text += "Выбрана корневая папка: " + dialog.SelectedPath;
                rootFolderPath = dialog.SelectedPath;
            }
        }
    }

}
