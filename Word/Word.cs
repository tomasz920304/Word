using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Word
{
    public partial class Word : Form
    {
        public Word()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            rtbContent.Clear();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            // okno otwierania plików
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // filtr plików możliwych do otwarcia
            openFileDialog.Filter = "Rich Text File (.rtf)|*.rtf|Text Files (.txt)|*.txt";

            // tytuł okna dialogowego
            openFileDialog.Title = "Otwórz plik tekstowy";

            // tryb wczytania pliku tekstowego
            RichTextBoxStreamType streamType = RichTextBoxStreamType.RichText;

            // sprawdzenie rezultatu
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FilterIndex == 2)
                {
                    streamType = RichTextBoxStreamType.PlainText;
                }
                // wypełnienie pola tekstowego zawartością otwieranego pliku
                rtbContent.LoadFile(openFileDialog.FileName, streamType);
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            // okno zapisu do pliku
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // filtr plików możliwych do zapisu
            saveFileDialog.Filter = "Rich Text File (.rtf) | *.rtf | TextFiles(.txt) | *.txt";
            
            // tytuł okna dialogowego
            saveFileDialog.Title = "Zapisz plik";

            // tryb wczytania pliku tekstowego
            RichTextBoxStreamType streamType = RichTextBoxStreamType.RichText;

            // sprawdzenie rezultatu
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FilterIndex == 2)
                {
                    streamType = RichTextBoxStreamType.PlainText;
                }

                rtbContent.SaveFile(saveFileDialog.FileName, streamType);
            }

        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            Font selectedTextFont = rtbContent.SelectionFont;

            if (selectedTextFont != null)
            {
                if (!selectedTextFont.Bold)
                {
                    rtbContent.SelectionFont = new Font(selectedTextFont, FontStyle.Bold);
                }
                else
                {
                    rtbContent.SelectionFont = new Font(selectedTextFont, FontStyle.Regular);
                }
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            Font selectedTextFont = rtbContent.SelectionFont;
            if (selectedTextFont != null)
            {
                if (!selectedTextFont.Italic)
                {
                    rtbContent.SelectionFont = new Font(selectedTextFont, FontStyle.Italic);
                }
                else
                {
                    rtbContent.SelectionFont = new Font(selectedTextFont, FontStyle.Regular);
                }
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            Font selectedTextFont = rtbContent.SelectionFont;
            if (selectedTextFont != null)
            {
                if (!selectedTextFont.Underline)
                {
                    rtbContent.SelectionFont = new Font(selectedTextFont, FontStyle.Underline);
                }
                else
                {
                    rtbContent.SelectionFont = new Font(selectedTextFont, FontStyle.Regular);
                }
            }

        }

        private void Word_Load(object sender, EventArgs e)
        {
            for (int fontSize = 12; fontSize < 70; fontSize++)
            {
                cmbFontSize.Items.Add(fontSize);
            }
            foreach (FontFamily fontFamily in FontFamily.Families)
            {
                cmbFont.Items.Add(fontFamily.Name);
            }
            cmbFontSize.SelectedIndex = 0;
            cmbFont.SelectedIndex = 0;

        }

        private void SetNewFont()
        {
            rtbContent.SelectionFont = new Font(cmbFont.Text,
            int.Parse(cmbFontSize.Text), rtbContent.SelectionFont.Style);
        }

        private void cmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetNewFont();
        }

        private void cmbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetNewFont();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                rtbContent.SelectionColor = colorDialog.Color;
                pbColor.BackColor = colorDialog.Color;
            }
        }
    }
}
