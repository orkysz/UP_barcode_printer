//using BarcodeLib;
using Spire.Barcode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;

namespace BarPrinterCode
{
    public partial class BarcodeForm : Form
    {
        Image barcodeImg;

        public BarcodeForm()
        {
            InitializeComponent();
        }

        bool IsCodeValid(string code) 
            //funkcja sprawdzajaca czy wprowadzony przez uzytkownika ciag ma 12 znakow
        {
            if (code.Length != 12)
            {
                MessageBox.Show("Wpisz dokladnie 12 cyfr");
                return false;
            }

            return code.All(c => char.IsNumber(c));
        }

        private static Image cropImage(Image img, Rectangle cropArea)
            // tworzenie bitmapy na ktorej bedzie tworzony kod kreskowy
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        private void btnGenerateToBarcode_Click(object sender, EventArgs e)
        {

            var code = tbCodeToGenerate.Text.Trim();
            if (!IsCodeValid(code)) return;

            //generowanie kodu kreskowego z cyfr od uzytkownika  + wyliczenie sumy kontrolnej
            var codeToGenerateWithChecksum = code + Char.ConvertFromUtf32(Ean13CodeGenerator.ControlSum(code) + '0');

            var barcodegenerator = new Spire.Barcode.BarCodeGenerator(new BarcodeSettings()
            {
                Type = BarCodeType.EAN13,
                BackColor = Color.White,
                ForeColor = Color.Black,

                Data = codeToGenerateWithChecksum,
                ShowText = true,
                ShowTextOnBottom = true,

            });


            barcodeImg = barcodegenerator.GenerateImage(); 
            barcodeImg = cropImage(barcodeImg, new Rectangle(0, 15, barcodeImg.Width, barcodeImg.Height - 15));

            pbBarcode.Image = barcodeImg;
            pbBarcode.Update();
            pbBarcode.Visible = true;
        }



        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            if (barcodeImg == null)
            {
                MessageBox.Show("obrazek jest pusty");
                return;
            }

            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(barcodeImg, typeof(byte[]));

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintPage);
            PrintDialog pdi = new PrintDialog();
            pdi.Document = pd;
            if (pdi.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
            else
            {
                MessageBox.Show("drukowanie anulowane");
            }
        }

        //drukowanie
        private void PrintPage(object o, PrintPageEventArgs e)
        {
            try
            {
                ////dopasuj rozmiar obrazka do drukowania
                Rectangle m = e.MarginBounds;
                m.Height = 100;
                m.Width = 300;

                //funkcja, drukujaca kod kreskowy             
                System.Drawing.Image image = barcodeImg;
                e.Graphics.DrawImage(image, m); 

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
