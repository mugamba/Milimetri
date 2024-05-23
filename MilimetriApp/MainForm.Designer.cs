namespace MilimetriApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonSelectFile = new Button();
            textBoxSelectedFile = new TextBox();
            textBoxFolder = new TextBox();
            buttonOdaberiFolder = new Button();
            buttonPokreniObradu = new Button();
            SuspendLayout();
            // 
            // buttonSelectFile
            // 
            buttonSelectFile.Location = new Point(12, 14);
            buttonSelectFile.Name = "buttonSelectFile";
            buttonSelectFile.Size = new Size(175, 23);
            buttonSelectFile.TabIndex = 0;
            buttonSelectFile.Text = "Odaberi ulaznu datoteku";
            buttonSelectFile.UseVisualStyleBackColor = true;
            buttonSelectFile.Click += buttonOdaberiDatoteku_Click;
            // 
            // textBoxSelectedFile
            // 
            textBoxSelectedFile.Location = new Point(193, 14);
            textBoxSelectedFile.Name = "textBoxSelectedFile";
            textBoxSelectedFile.Size = new Size(468, 23);
            textBoxSelectedFile.TabIndex = 1;
            // 
            // textBoxFolder
            // 
            textBoxFolder.Location = new Point(193, 43);
            textBoxFolder.Name = "textBoxFolder";
            textBoxFolder.Size = new Size(468, 23);
            textBoxFolder.TabIndex = 2;
            // 
            // buttonOdaberiFolder
            // 
            buttonOdaberiFolder.Location = new Point(12, 42);
            buttonOdaberiFolder.Name = "buttonOdaberiFolder";
            buttonOdaberiFolder.Size = new Size(175, 23);
            buttonOdaberiFolder.TabIndex = 3;
            buttonOdaberiFolder.Text = "Odaberi izlazni direktorij";
            buttonOdaberiFolder.UseVisualStyleBackColor = true;
            buttonOdaberiFolder.Click += buttonOdaberiFolder_Click;
            // 
            // buttonPokreniObradu
            // 
            buttonPokreniObradu.Location = new Point(486, 210);
            buttonPokreniObradu.Name = "buttonPokreniObradu";
            buttonPokreniObradu.Size = new Size(175, 23);
            buttonPokreniObradu.TabIndex = 4;
            buttonPokreniObradu.Text = "Pokreni obradu";
            buttonPokreniObradu.UseVisualStyleBackColor = true;
            buttonPokreniObradu.Click += buttonPokreniObradu_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 254);
            Controls.Add(buttonPokreniObradu);
            Controls.Add(buttonOdaberiFolder);
            Controls.Add(textBoxFolder);
            Controls.Add(textBoxSelectedFile);
            Controls.Add(buttonSelectFile);
            Name = "MainForm";
            Text = "Milimetar app";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSelectFile;
        private TextBox textBoxSelectedFile;
        private TextBox textBoxFolder;
        private Button buttonOdaberiFolder;
        private Button buttonPokreniObradu;
    }
}
