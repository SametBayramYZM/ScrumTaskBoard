namespace ScrumTaskBoard
{
    partial class Scrumtaskboard
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
            this.btn_kayit = new System.Windows.Forms.Button();
            this.tbx_kartno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_guncelle = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btn_taskboard = new System.Windows.Forms.Button();
            this.btn_sil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_kayit
            // 
            this.btn_kayit.Location = new System.Drawing.Point(799, 42);
            this.btn_kayit.Name = "btn_kayit";
            this.btn_kayit.Size = new System.Drawing.Size(169, 90);
            this.btn_kayit.TabIndex = 0;
            this.btn_kayit.Text = "Yeni Kayıt Oluştur";
            this.btn_kayit.UseVisualStyleBackColor = true;
            this.btn_kayit.Click += new System.EventHandler(this.btn_kayit_Click);
            // 
            // tbx_kartno
            // 
            this.tbx_kartno.Location = new System.Drawing.Point(576, 389);
            this.tbx_kartno.Name = "tbx_kartno";
            this.tbx_kartno.Size = new System.Drawing.Size(100, 22);
            this.tbx_kartno.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 394);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kart no";
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.Location = new System.Drawing.Point(746, 355);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(169, 90);
            this.btn_guncelle.TabIndex = 0;
            this.btn_guncelle.Text = "Güncelleme Ekranına Git";
            this.btn_guncelle.UseVisualStyleBackColor = true;
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(29, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(614, 254);
            this.dataGridView.TabIndex = 3;
            // 
            // btn_taskboard
            // 
            this.btn_taskboard.Location = new System.Drawing.Point(269, 351);
            this.btn_taskboard.Name = "btn_taskboard";
            this.btn_taskboard.Size = new System.Drawing.Size(161, 99);
            this.btn_taskboard.TabIndex = 4;
            this.btn_taskboard.Text = "Scrum Task Boarda Git";
            this.btn_taskboard.UseVisualStyleBackColor = true;
            this.btn_taskboard.Click += new System.EventHandler(this.btn_taskboard_Click);
            // 
            // btn_sil
            // 
            this.btn_sil.Location = new System.Drawing.Point(658, 12);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(88, 36);
            this.btn_sil.TabIndex = 5;
            this.btn_sil.Text = "Sil";
            this.btn_sil.UseVisualStyleBackColor = true;
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // Scrumtaskboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 490);
            this.Controls.Add(this.btn_sil);
            this.Controls.Add(this.btn_taskboard);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_guncelle);
            this.Controls.Add(this.tbx_kartno);
            this.Controls.Add(this.btn_kayit);
            this.Name = "Scrumtaskboard";
            this.Text = "Scrumtaskboard";
            this.Load += new System.EventHandler(this.Scrumtaskboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_kayit;
        private System.Windows.Forms.TextBox tbx_kartno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_guncelle;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btn_taskboard;
        private System.Windows.Forms.Button btn_sil;
    }
}