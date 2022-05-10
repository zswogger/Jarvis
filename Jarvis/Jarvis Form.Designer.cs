
namespace Jarvis
{
    partial class Jarvis_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Jarvis_Form));
            this.tb_output = new System.Windows.Forms.RichTextBox();
            this.btn_jarvis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_output
            // 
            this.tb_output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            this.tb_output.Location = new System.Drawing.Point(54, 41);
            this.tb_output.Name = "tb_output";
            this.tb_output.Size = new System.Drawing.Size(188, 263);
            this.tb_output.TabIndex = 0;
            this.tb_output.Text = "";
            // 
            // btn_jarvis
            // 
            this.btn_jarvis.Location = new System.Drawing.Point(109, 12);
            this.btn_jarvis.Name = "btn_jarvis";
            this.btn_jarvis.Size = new System.Drawing.Size(75, 23);
            this.btn_jarvis.TabIndex = 1;
            this.btn_jarvis.Text = "Jarvis";
            this.btn_jarvis.UseVisualStyleBackColor = true;
            this.btn_jarvis.Click += new System.EventHandler(this.btn_jarvis_Click);
            // 
            // Jarvis_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(309, 350);
            this.Controls.Add(this.btn_jarvis);
            this.Controls.Add(this.tb_output);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Jarvis_Form";
            this.Text = "Jarvis";
            this.Load += new System.EventHandler(this.Jarvis_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox tb_output;
        private System.Windows.Forms.Button btn_jarvis;
    }
}

