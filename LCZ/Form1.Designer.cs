namespace LCZ
{
    partial class FormPesquisa
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
            dtGriPesquisa = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dtGriPesquisa).BeginInit();
            SuspendLayout();
            // 
            // dtGriPesquisa
            // 
            dtGriPesquisa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGriPesquisa.Location = new Point(25, 28);
            dtGriPesquisa.Name = "dtGriPesquisa";
            dtGriPesquisa.RowTemplate.Height = 25;
            dtGriPesquisa.Size = new Size(743, 178);
            dtGriPesquisa.TabIndex = 0;
            // 
            // FormPesquisa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtGriPesquisa);
            Name = "FormPesquisa";
            Text = "Pesquisa";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dtGriPesquisa).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtGriPesquisa;
    }
}