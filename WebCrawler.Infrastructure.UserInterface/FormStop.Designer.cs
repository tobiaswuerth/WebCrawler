﻿namespace ch.wuerth.tobias.WebCrawler.Infrastructure.UserInterface
{
    partial class FormStop
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
            this.lblLoading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLoading
            // 
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblLoading.Location = new System.Drawing.Point(12, 9);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(174, 39);
            this.lblLoading.TabIndex = 1;
            this.lblLoading.Text = "Stopping...";
            this.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormStop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(189, 63);
            this.ControlBox = false;
            this.Controls.Add(this.lblLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormStop";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FormStop";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLoading;
    }
}