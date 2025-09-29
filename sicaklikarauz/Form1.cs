using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using System.Linq;


namespace sicaklikarauz
{
    public partial class Form1 : Form
    {
        SerialPort port = new SerialPort();
        private Dictionary<Control, (Point, Size)> orijinalBoyutlar;

        List<(double time, double temp)> hedefVeri = new List<(double time, double temp)>
        {
            (0,0),
            (10,40),
            (40,40),
            (80,60)
        };

        int veriSayaci = 0;
        const double saniyeAdim = 1; // Arduino'dan 1 sn arayla veri geliyor varsayıyoruz

        int gecenSure = 0;

        public Form1()
        {
            InitializeComponent();
            this.Resize += Form1_Resize;
            this.Shown += Form1_Shown;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Chart alanını temizle
            this.MinimumSize = this.Size;
            chartSicaklik.Series.Clear();

            // Sabit grafik serisi oluştur
            Series sabitSeri = new Series("Hedef");
            sabitSeri.ChartType = SeriesChartType.Line;
            sabitSeri.Color = Color.Red;
            sabitSeri.BorderWidth = 3;

            // Hedef veri listesini çiz
            foreach (var nokta in hedefVeri)
            {
                sabitSeri.Points.AddXY(nokta.time, nokta.temp);
            }
            chartSicaklik.Series.Add(sabitSeri);

            //verileri listbox a ekle
            foreach (var veri in hedefVeri)
            {
                chartSicaklik.Series["Hedef"].ChartType = SeriesChartType.Line;
                listBoxVeriler.Items.Add($"Süre:{veri.time}dk -" +
                    $" Sıcaklık:{veri.temp} °C ");
            }


            // Arduino’dan gelecek gerçek veriler için seri
            Series gercekSeri = new Series("Gerçek");
            gercekSeri.ChartType = SeriesChartType.Line;
            gercekSeri.Color = Color.DodgerBlue;
            gercekSeri.BorderWidth = 2;

            chartSicaklik.Series.Add(gercekSeri);

            // Chart eksen ayarları
            chartSicaklik.ChartAreas[0].AxisX.Title = "Zaman (dk)";
            chartSicaklik.ChartAreas[0].AxisY.Title = "Sıcaklık (°C)";
            chartSicaklik.ChartAreas[0].AxisX.Minimum = 0;
            chartSicaklik.ChartAreas[0].AxisX.Maximum = 140; // biraz geniş tuttum
            chartSicaklik.ChartAreas[0].AxisY.Minimum = 0;
            chartSicaklik.ChartAreas[0].AxisY.Maximum = 100; // ihtiyaç halinde değiştir


            // Chart imleç ve zoom özellikleri
            chartSicaklik.ChartAreas[0].CursorY.IsUserEnabled = true;
            chartSicaklik.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chartSicaklik.ChartAreas[0].CursorX.IsUserEnabled = true;
            chartSicaklik.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            string[] portlar = SerialPort.GetPortNames();
            cmbPort.Items.AddRange(portlar);
            if (cmbPort.Items.Count > 0)
            {
                cmbPort.SelectedIndex = 0;//eger en az 1 tane port varsa otomatik olarak o seçiliyor
            }
            port.DataReceived += Port_DataReceived;
        }

        private void btnBaglanti_Click(object sender, EventArgs e)
        {
            if (cmbPort.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir port seçin!");
                return;
            }

            if (!port.IsOpen)
            {
                port.PortName = cmbPort.SelectedItem.ToString();
                port.BaudRate = 9600;//saniyede kac veri göndericegini belirler
                port.Open();
                MessageBox.Show("Bağlantı kuruldu.");
                timerZaman.Start();
                btnBaglanti.Text = "Bağlantıyı Kes";
                label1.Text = "Port'a bağlandı";
            }
            else
            {
                port.Close();
                MessageBox.Show("Bağlantı Kesildi");
                timerZaman.Stop();
                btnBaglanti.Text = "Bağlan";
                label1.Text = "Port bağlı değil";
            }

        }
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string veri = port.ReadLine().Trim();

            if (float.TryParse(veri, NumberStyles.Any, CultureInfo.InvariantCulture, out float sicaklik))
            {
                //arayuz elemanlarını güvenli şekilde güncellemek içi invoke kullanılır
                this.Invoke(new Action(() =>
                {
                    //gelen veri sayısına göre gecen dk cnsinden hesaplama
                    double zaman = (veriSayaci * saniyeAdim) / 60.0;

                    Series gercekSeri = chartSicaklik.Series["Gerçek"];
                    gercekSeri.Points.AddXY(zaman, sicaklik);

                    veriSayaci++;

                    //hedef sicakliği gecen zamana gore hesaplamak içinaradaki iki noktayı bulma
                    double hedefSicaklik = 0;
                    for (int i = 0; i < hedefVeri.Count - 1; i++)
                    {
                        if (zaman >= hedefVeri[i].time && zaman < hedefVeri[i + 1].time)
                        {
                            double zaman1 = hedefVeri[i].time;
                            double zaman2 = hedefVeri[i + 1].time;
                            double sicaklik1 = hedefVeri[i].temp;
                            double sicaklik2 = hedefVeri[i + 1].temp;
                            //iki nokta arasindaki oranı hesaplayan ara sıcaklıgı bul
                            double oran = (zaman - zaman1) / (zaman2 - zaman1);
                            hedefSicaklik = sicaklik1 + oran * (sicaklik2 - sicaklik1);
                            break;
                        }
                    }
                    //eger  gecen zaman listedeki en son zaman noktasını geciyors son scıklık alınır
                    if (zaman >= hedefVeri[hedefVeri.Count - 1].time)
                    {
                        hedefSicaklik = hedefVeri[hedefVeri.Count - 1].temp;
                    }

                    double fark = Math.Abs(hedefSicaklik - sicaklik);//mutlak farjk
                    lblKarsilastirma.Text = $"Hedef:{hedefSicaklik:F1}°C  || Gerçek:{sicaklik:F1}°C  || Fark:{fark:F1}°C ";

                    //grafikte veri cok olursa en eski noktayı siler
                    if (gercekSeri.Points.Count > 100)
                    {
                        gercekSeri.Points.RemoveAt(0);
                    }
                }));
            }
        }

        private void chartSicaklik_DoubleClick(object sender, EventArgs e)
        {
            chartSicaklik.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            chartSicaklik.ChartAreas[0].AxisY.ScaleView.ZoomReset();
        }

        private void başlatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                port.WriteLine("1");
            }
        }

        private void durdurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                port.WriteLine("0");
            }
        }

        private void sıfırlaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            chartSicaklik.Series[0].Points.Clear();
            if (port.IsOpen)
            {
                port.WriteLine("0");//Arduino kısmında buna özel bir şey yapılacak
            }
        }

        private void btnHedefEkle_Click(object sender, EventArgs e)
        {
            //girilen değer
            int sure = (int)nudSure.Value;
            int sicaklik = (int)nudSicaklik.Value;

            int oncekiSure = 0;
            int oncekiSicaklik = 0;

            if (hedefVeri.Count > 0)
            {
                oncekiSure = (int)hedefVeri.Last().time;
                oncekiSicaklik = (int)hedefVeri.Last().temp;
            }

            int toplamSure = oncekiSure + sure;
            int toplamSicaklik = oncekiSicaklik + sicaklik;

            hedefVeri.Add((toplamSure, toplamSicaklik));

            listBoxVeriler.Items.Add($"Süre:{toplamSure}dk - Sıcaklık:{toplamSicaklik}");

            //grafiği temizleyip tekrar cizmeü
            chartSicaklik.Series["Hedef"].Points.Clear();
            foreach (var item in hedefVeri)
            {
                chartSicaklik.Series["Hedef"].Points.AddXY(item.time, item.temp);
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Metin Dosyası(*.txt)|*.txt|PNG Grafik (*.png)|*.png",
                Title = "Veriyi Kaydet"
            };
            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;
            string path = saveDialog.FileName;
            if (saveDialog.FilterIndex == 1)
            {
                //hedef veri listesini metin haline çevir
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Zaman (dk)\tSıcaklık (°C)");
                foreach (var item in hedefVeri)
                {
                    sb.AppendLine($"{item.time}\t{item.temp}");
                }

                sb.AppendLine(); // boş satır


                var gercekSeri = chartSicaklik.Series["Gerçek"];
                sb.AppendLine("Gerçek Veriler");
                sb.AppendLine("Zaman (dk)\tSıcaklık (°C)");
                foreach (var item in gercekSeri.Points)
                {
                    sb.AppendLine($"{item.XValue:F2}\t{item.YValues[0]:F2}");
                }

                File.WriteAllText(path, sb.ToString());
                MessageBox.Show("Hedef ve gerçek veriler metin dosyası olarak kaydedildi.");
            }
            else if (saveDialog.FilterIndex == 2)
            {
                if (chartSicaklik.Series.Count == 0 || chartSicaklik.Series.All(s => s.Points.Count == 0))
                {
                    MessageBox.Show("Kaydedilecek grafik verisi bulunamadı.");
                    return;
                }
                using (Bitmap bmp = new Bitmap(chartSicaklik.Width, chartSicaklik.Height))
                {
                    chartSicaklik.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                }
                MessageBox.Show("Grafik PNG olarak kaydedildi.");
            }
        }

        private void timerZaman_Tick(object sender, EventArgs e)
        {
            gecenSure++;//her 1 saniye gectiginde arttır
            lblSure.Text = $"Geçen Süre : {gecenSure / 60}dk {gecenSure % 60}sn";
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                // Sabit büyütülmüş konum ve boyutlar (senin verdiğin değerlere göre)
                chartSicaklik.Location = new Point(383, 100);
                chartSicaklik.Size = new Size(1105, 570);

                cmbPort.Location = new Point(12, 56);
                cmbPort.Size = new Size(182, 24);

                btnBaglanti.Location = new Point(44, 86);
                btnBaglanti.Size = new Size(110, 64);

                label2.Location = new Point(12, 200);
                label2.Size = new Size(142, 27);

                listBoxVeriler.Location = new Point(12, 230);
                listBoxVeriler.Size = new Size(240, 280);

                label3.Location = new Point(13, 529);
                label3.Size = new Size(50, 23);

                label4.Location = new Point(13, 562);
                label4.Size = new Size(75, 23);

                nudSure.Location = new Point(89, 529);
                nudSure.Size = new Size(120, 27);

                nudSicaklik.Location = new Point(89, 562);
                nudSicaklik.Size = new Size(120, 27);

                lblSure.Location = new Point(378, 53);
                lblSure.Size = new Size(218, 27);

                lblKarsilastirma.Location = new Point(378, 679);
                lblKarsilastirma.Size = new Size(334, 25);

                btnKaydet.Location = new Point(383, 718);
                btnKaydet.Size = new Size(129, 59);

                btnHedefEkle.Location = new Point(12, 605);
                btnHedefEkle.Size = new Size(142, 59);

                label1.Location = new Point(200, 57);
                label1.Size = new Size(136, 23);
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                // Geri eski konumlara dön (sadece sözlük doluysa)
                if (orijinalBoyutlar != null)
                {
                    foreach (var item in orijinalBoyutlar)
                    {
                        Control ctrl = item.Key;
                        ctrl.Location = item.Value.Item1;
                        ctrl.Size = item.Value.Item2;
                    }
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            orijinalBoyutlar = new Dictionary<Control, (Point, Size)>
            {
                { chartSicaklik, (chartSicaklik.Location, chartSicaklik.Size) },
                { cmbPort, (cmbPort.Location, cmbPort.Size) },
                { btnBaglanti, (btnBaglanti.Location, btnBaglanti.Size) },
                { label2, (label2.Location, label2.Size) },
                { listBoxVeriler, (listBoxVeriler.Location, listBoxVeriler.Size) },
                { label3, (label3.Location, label3.Size) },
                { label4, (label4.Location, label4.Size) },
                { nudSure, (nudSure.Location, nudSure.Size) },
                { nudSicaklik, (nudSicaklik.Location, nudSicaklik.Size) },
                { lblSure, (lblSure.Location, lblSure.Size) },
                { lblKarsilastirma, (lblKarsilastirma.Location, lblKarsilastirma.Size) },
                { btnKaydet, (btnKaydet.Location, btnKaydet.Size) },
                { btnHedefEkle, (btnHedefEkle.Location, btnHedefEkle.Size) },
                { label1, (label1.Location, label1.Size) }
            };
        }

        private void yeniInoAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                string yeniArduinoKodu = @"
void setup() {
//Yeni bir dosya açtınız. Farklı kaydetmeyi Unutmayınız.
}
void loop() {
//Yeni bir dosya açtınız. Farklı kaydetmeyi Unutmayınız.
}
            ";
                string tempFolder = Path.Combine(Path.GetTempPath(), "Yeni_Dosya");
                Directory.CreateDirectory(tempFolder);

                string inoDosyaYolu = Path.Combine(tempFolder, "Yeni_Dosya.ino");
                File.WriteAllText(inoDosyaYolu, yeniArduinoKodu);

                try
                {
                    // Arduino IDE ile açmak için sadece dosya yeterli
                    System.Diagnostics.Process.Start(inoDosyaYolu);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void hazırDosyaAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosyaSecici = new OpenFileDialog();
            dosyaSecici.Filter = "Arduino Dosyaları (*.ino)|*.ino";
            dosyaSecici.Title = "Bir .ino dosyası seçin";

            if (dosyaSecici.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Diagnostics.Process.Start(dosyaSecici.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya açılamadı: " + ex.Message);
                }
            }
        }
    }
}
