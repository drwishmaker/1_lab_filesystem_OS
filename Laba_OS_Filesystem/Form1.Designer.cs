namespace Laba_OS_Filesystem
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxDefault = new System.Windows.Forms.TextBox();
            this.textBoxProceeded = new System.Windows.Forms.TextBox();
            this.buttonFile = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxDefault
            // 
            this.textBoxDefault.Location = new System.Drawing.Point(12, 23);
            this.textBoxDefault.Multiline = true;
            this.textBoxDefault.Name = "textBoxDefault";
            this.textBoxDefault.ReadOnly = true;
            this.textBoxDefault.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDefault.Size = new System.Drawing.Size(275, 260);
            this.textBoxDefault.TabIndex = 0;
            // 
            // textBoxProceeded
            // 
            this.textBoxProceeded.Location = new System.Drawing.Point(293, 23);
            this.textBoxProceeded.Multiline = true;
            this.textBoxProceeded.Name = "textBoxProceeded";
            this.textBoxProceeded.ReadOnly = true;
            this.textBoxProceeded.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxProceeded.Size = new System.Drawing.Size(278, 260);
            this.textBoxProceeded.TabIndex = 1;
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(12, 289);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(559, 23);
            this.buttonFile.TabIndex = 2;
            this.buttonFile.Text = "Choose file";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input data";
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(293, 4);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(37, 13);
            this.result.TabIndex = 4;
            this.result.Text = "Result";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(583, 322);
            this.Controls.Add(this.result);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.textBoxProceeded);
            this.Controls.Add(this.textBoxDefault);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.TextBox textboxProceeded;
        private System.Windows.Forms.TextBox textboxDefault;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.TextBox textBoxDefault;
        private System.Windows.Forms.TextBox textBoxProceeded;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label result;
    }
}

