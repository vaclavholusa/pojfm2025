namespace WinFormsAsyncDemo
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
            syncButton = new Button();
            asyncButton = new Button();
            SuspendLayout();
            // 
            // syncButton
            // 
            syncButton.Location = new Point(114, 132);
            syncButton.Margin = new Padding(4, 5, 4, 5);
            syncButton.Name = "syncButton";
            syncButton.Size = new Size(107, 39);
            syncButton.TabIndex = 0;
            syncButton.Text = "Sync";
            syncButton.UseVisualStyleBackColor = true;
            syncButton.Click += syncButton_Click;
            // 
            // asyncButton
            // 
            asyncButton.Location = new Point(316, 132);
            asyncButton.Name = "asyncButton";
            asyncButton.Size = new Size(112, 39);
            asyncButton.TabIndex = 1;
            asyncButton.Text = "Async";
            asyncButton.UseVisualStyleBackColor = true;
            asyncButton.Click += asyncButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 365);
            Controls.Add(asyncButton);
            Controls.Add(syncButton);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            Text = "Async Demo";
            ResumeLayout(false);
        }

        #endregion

        private Button syncButton;
        private Button asyncButton;
    }
}
