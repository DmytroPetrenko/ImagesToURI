namespace ImageToURI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtEditor = new System.Windows.Forms.TextBox();
            this.btnSelectImageFolder = new System.Windows.Forms.Button();
            this.btn_Select_Root_Folder = new System.Windows.Forms.Button();
            this.btnJustDoIt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Преобразовать в URI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(58, 358);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(191, 23);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "Выбрать файл html";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // txtEditor
            // 
            this.txtEditor.Location = new System.Drawing.Point(58, 12);
            this.txtEditor.Multiline = true;
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.Size = new System.Drawing.Size(684, 308);
            this.txtEditor.TabIndex = 2;
            // 
            // btnSelectImageFolder
            // 
            this.btnSelectImageFolder.Location = new System.Drawing.Point(255, 358);
            this.btnSelectImageFolder.Name = "btnSelectImageFolder";
            this.btnSelectImageFolder.Size = new System.Drawing.Size(191, 23);
            this.btnSelectImageFolder.TabIndex = 3;
            this.btnSelectImageFolder.Text = "Выбрать папку с картинками";
            this.btnSelectImageFolder.UseVisualStyleBackColor = true;
            this.btnSelectImageFolder.Click += new System.EventHandler(this.BtnSelectImageFolder_Click);
            // 
            // btn_Select_Root_Folder
            // 
            this.btn_Select_Root_Folder.Location = new System.Drawing.Point(520, 358);
            this.btn_Select_Root_Folder.Name = "btn_Select_Root_Folder";
            this.btn_Select_Root_Folder.Size = new System.Drawing.Size(222, 23);
            this.btn_Select_Root_Folder.TabIndex = 4;
            this.btn_Select_Root_Folder.Text = "Выбрать папку для преобразования";
            this.btn_Select_Root_Folder.UseVisualStyleBackColor = true;
            this.btn_Select_Root_Folder.Click += new System.EventHandler(this.Btn_Select_Root_Folder_Click);
            // 
            // btnJustDoIt
            // 
            this.btnJustDoIt.Location = new System.Drawing.Point(520, 387);
            this.btnJustDoIt.Name = "btnJustDoIt";
            this.btnJustDoIt.Size = new System.Drawing.Size(222, 23);
            this.btnJustDoIt.TabIndex = 5;
            this.btnJustDoIt.Text = "Преобразовать всё";
            this.btnJustDoIt.UseVisualStyleBackColor = true;
            this.btnJustDoIt.Click += new System.EventHandler(this.BtnJustDoIt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnJustDoIt);
            this.Controls.Add(this.btn_Select_Root_Folder);
            this.Controls.Add(this.btnSelectImageFolder);
            this.Controls.Add(this.txtEditor);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtEditor;
        private System.Windows.Forms.Button btnSelectImageFolder;
        private System.Windows.Forms.Button btn_Select_Root_Folder;
        private System.Windows.Forms.Button btnJustDoIt;
    }
}

