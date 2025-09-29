namespace sicaklikarauz
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.btnBaglanti = new System.Windows.Forms.Button();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chartSicaklik = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kontrollerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.başlatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.durdurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sıfırlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxVeriler = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudSure = new System.Windows.Forms.NumericUpDown();
            this.nudSicaklik = new System.Windows.Forms.NumericUpDown();
            this.btnHedefEkle = new System.Windows.Forms.Button();
            this.lblKarsilastirma = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.lblSure = new System.Windows.Forms.Label();
            this.timerZaman = new System.Windows.Forms.Timer(this.components);
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniInoAçToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hazırDosyaAçToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chartSicaklik)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSicaklik)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBaglanti
            // 
            this.btnBaglanti.BackColor = System.Drawing.Color.Navy;
            this.btnBaglanti.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBaglanti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBaglanti.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.btnBaglanti.Location = new System.Drawing.Point(44, 86);
            this.btnBaglanti.Name = "btnBaglanti";
            this.btnBaglanti.Size = new System.Drawing.Size(110, 64);
            this.btnBaglanti.TabIndex = 0;
            this.btnBaglanti.Text = "Bağlan";
            this.btnBaglanti.UseVisualStyleBackColor = false;
            this.btnBaglanti.Click += new System.EventHandler(this.btnBaglanti_Click);
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(12, 56);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(182, 24);
            this.cmbPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(200, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port bağlı değil";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.MidnightBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.label2.Location = new System.Drawing.Point(12, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hedef Veriler:";
            // 
            // chartSicaklik
            // 
            this.chartSicaklik.BackColor = System.Drawing.Color.Lavender;
            chartArea2.AxisX.Title = "ZAMAN";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.DarkBlue;
            chartArea2.AxisY.Title = "SICAKLIK";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            chartArea2.AxisY.TitleForeColor = System.Drawing.Color.DarkBlue;
            chartArea2.BackColor = System.Drawing.Color.LavenderBlush;
            chartArea2.BorderColor = System.Drawing.Color.Bisque;
            chartArea2.Name = "ChartArea1";
            this.chartSicaklik.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSicaklik.Legends.Add(legend2);
            this.chartSicaklik.Location = new System.Drawing.Point(383, 86);
            this.chartSicaklik.Name = "chartSicaklik";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.DarkBlue;
            series2.Legend = "Legend1";
            series2.Name = "Veri";
            this.chartSicaklik.Series.Add(series2);
            this.chartSicaklik.Size = new System.Drawing.Size(764, 408);
            this.chartSicaklik.TabIndex = 5;
            title2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            title2.Name = "Title1";
            title2.Text = "Sıcaklık - Zaman Grafiği";
            this.chartSicaklik.Titles.Add(title2);
            this.chartSicaklik.DoubleClick += new System.EventHandler(this.chartSicaklik_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kontrollerToolStripMenuItem,
            this.dosyaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1189, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kontrollerToolStripMenuItem
            // 
            this.kontrollerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.başlatToolStripMenuItem,
            this.durdurToolStripMenuItem,
            this.sıfırlaToolStripMenuItem});
            this.kontrollerToolStripMenuItem.Name = "kontrollerToolStripMenuItem";
            this.kontrollerToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.kontrollerToolStripMenuItem.Text = "Kontroller";
            // 
            // başlatToolStripMenuItem
            // 
            this.başlatToolStripMenuItem.Name = "başlatToolStripMenuItem";
            this.başlatToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.başlatToolStripMenuItem.Text = "Başlat";
            this.başlatToolStripMenuItem.Click += new System.EventHandler(this.başlatToolStripMenuItem_Click);
            // 
            // durdurToolStripMenuItem
            // 
            this.durdurToolStripMenuItem.Name = "durdurToolStripMenuItem";
            this.durdurToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.durdurToolStripMenuItem.Text = "Durdur";
            this.durdurToolStripMenuItem.Click += new System.EventHandler(this.durdurToolStripMenuItem_Click);
            // 
            // sıfırlaToolStripMenuItem
            // 
            this.sıfırlaToolStripMenuItem.Name = "sıfırlaToolStripMenuItem";
            this.sıfırlaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sıfırlaToolStripMenuItem.Text = "Sıfırla";
            this.sıfırlaToolStripMenuItem.Click += new System.EventHandler(this.sıfırlaToolStripMenuItem_Click);
            // 
            // listBoxVeriler
            // 
            this.listBoxVeriler.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBoxVeriler.FormattingEnabled = true;
            this.listBoxVeriler.ItemHeight = 23;
            this.listBoxVeriler.Location = new System.Drawing.Point(12, 230);
            this.listBoxVeriler.Name = "listBoxVeriler";
            this.listBoxVeriler.Size = new System.Drawing.Size(240, 280);
            this.listBoxVeriler.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(13, 529);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "Süre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(13, 562);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 19;
            this.label4.Text = "Sıcaklık:";
            // 
            // nudSure
            // 
            this.nudSure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudSure.Location = new System.Drawing.Point(89, 529);
            this.nudSure.Name = "nudSure";
            this.nudSure.Size = new System.Drawing.Size(120, 27);
            this.nudSure.TabIndex = 17;
            // 
            // nudSicaklik
            // 
            this.nudSicaklik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudSicaklik.Location = new System.Drawing.Point(89, 562);
            this.nudSicaklik.Name = "nudSicaklik";
            this.nudSicaklik.Size = new System.Drawing.Size(120, 27);
            this.nudSicaklik.TabIndex = 20;
            // 
            // btnHedefEkle
            // 
            this.btnHedefEkle.BackColor = System.Drawing.Color.Navy;
            this.btnHedefEkle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHedefEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHedefEkle.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.btnHedefEkle.Location = new System.Drawing.Point(12, 605);
            this.btnHedefEkle.Name = "btnHedefEkle";
            this.btnHedefEkle.Size = new System.Drawing.Size(142, 59);
            this.btnHedefEkle.TabIndex = 21;
            this.btnHedefEkle.Text = "Hedef Ekle";
            this.btnHedefEkle.UseVisualStyleBackColor = false;
            this.btnHedefEkle.Click += new System.EventHandler(this.btnHedefEkle_Click);
            // 
            // lblKarsilastirma
            // 
            this.lblKarsilastirma.AutoSize = true;
            this.lblKarsilastirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKarsilastirma.ForeColor = System.Drawing.Color.Black;
            this.lblKarsilastirma.Location = new System.Drawing.Point(378, 531);
            this.lblKarsilastirma.Name = "lblKarsilastirma";
            this.lblKarsilastirma.Size = new System.Drawing.Size(334, 25);
            this.lblKarsilastirma.TabIndex = 22;
            this.lblKarsilastirma.Text = "Hedef: - °C | Gerçek: - °C |Fark: - °C ";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.Navy;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.btnKaydet.Location = new System.Drawing.Point(383, 605);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(129, 59);
            this.btnKaydet.TabIndex = 23;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // lblSure
            // 
            this.lblSure.AutoSize = true;
            this.lblSure.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSure.ForeColor = System.Drawing.Color.Black;
            this.lblSure.Location = new System.Drawing.Point(378, 53);
            this.lblSure.Name = "lblSure";
            this.lblSure.Size = new System.Drawing.Size(218, 27);
            this.lblSure.TabIndex = 24;
            this.lblSure.Text = "Geçen Süre: 0 dk 0 sn";
            // 
            // timerZaman
            // 
            this.timerZaman.Interval = 1000;
            this.timerZaman.Tick += new System.EventHandler(this.timerZaman_Tick);
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniInoAçToolStripMenuItem,
            this.hazırDosyaAçToolStripMenuItem});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // yeniInoAçToolStripMenuItem
            // 
            this.yeniInoAçToolStripMenuItem.Name = "yeniInoAçToolStripMenuItem";
            this.yeniInoAçToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.yeniInoAçToolStripMenuItem.Text = "Yeni İno Aç";
            this.yeniInoAçToolStripMenuItem.Click += new System.EventHandler(this.yeniInoAçToolStripMenuItem_Click);
            // 
            // hazırDosyaAçToolStripMenuItem
            // 
            this.hazırDosyaAçToolStripMenuItem.Name = "hazırDosyaAçToolStripMenuItem";
            this.hazırDosyaAçToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.hazırDosyaAçToolStripMenuItem.Text = "Hazır Dosya Aç";
            this.hazırDosyaAçToolStripMenuItem.Click += new System.EventHandler(this.hazırDosyaAçToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 721);
            this.Controls.Add(this.lblSure);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lblKarsilastirma);
            this.Controls.Add(this.btnHedefEkle);
            this.Controls.Add(this.nudSicaklik);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudSure);
            this.Controls.Add(this.listBoxVeriler);
            this.Controls.Add(this.chartSicaklik);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPort);
            this.Controls.Add(this.btnBaglanti);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.PowderBlue;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Sıcaklık";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chartSicaklik)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSicaklik)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBaglanti;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSicaklik;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kontrollerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem başlatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem durdurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sıfırlaToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxVeriler;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudSure;
        private System.Windows.Forms.NumericUpDown nudSicaklik;
        private System.Windows.Forms.Button btnHedefEkle;
        private System.Windows.Forms.Label lblKarsilastirma;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label lblSure;
        private System.Windows.Forms.Timer timerZaman;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yeniInoAçToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hazırDosyaAçToolStripMenuItem;
    }
}

