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
            gdvPesquisa = new DataGridView();
            btnSelecionar = new Button();
            txtId = new TextBox();
            ((System.ComponentModel.ISupportInitialize)gdvPesquisa).BeginInit();
            SuspendLayout();
            // 
            // gdvPesquisa
            // 
            gdvPesquisa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gdvPesquisa.Location = new Point(25, 28);
            gdvPesquisa.Name = "gdvPesquisa";
            gdvPesquisa.RowTemplate.Height = 25;
            gdvPesquisa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gdvPesquisa.Size = new Size(542, 163);
            gdvPesquisa.TabIndex = 0;
            gdvPesquisa.CellMouseClick += gdvPesquisa_CellMouseClick;
            // 
            // btnSelecionar
            // 
            btnSelecionar.Location = new Point(450, 217);
            btnSelecionar.Name = "btnSelecionar";
            btnSelecionar.Size = new Size(117, 33);
            btnSelecionar.TabIndex = 1;
            btnSelecionar.Text = "Selecionar";
            btnSelecionar.UseVisualStyleBackColor = true;
            btnSelecionar.Click += btnSelecionar_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(25, 217);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 2;
            txtId.Visible = false;
            // 
            // FormPesquisa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 283);
            Controls.Add(txtId);
            Controls.Add(btnSelecionar);
            Controls.Add(gdvPesquisa);
            Name = "FormPesquisa";
            Text = "Pesquisa";
            Load += FormPesquisa_Load;
            ((System.ComponentModel.ISupportInitialize)gdvPesquisa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gdvPesquisa;
        private Button btnSelecionar;
        private TextBox txtId;
    }
}