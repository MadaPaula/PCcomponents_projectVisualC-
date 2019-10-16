using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace StroiaMadalinaPaula_an3_Proiect
{
    public partial class FormGrafic : Form
    {
        Dictionary<String, int> dictionary;
        List<Componenta> listaC;
        Font font = new Font(FontFamily.GenericSansSerif, 10);
        Color culoare = Color.Blue;
        const int marg = 10;
        int nrobs = 0;

        public FormGrafic(List<Componenta> lista)
        {
            InitializeComponent();
            dictionary = new Dictionary<String,int>();
            listaC = lista;
            foreach (Componenta c in listaC)
            {
                if (dictionary.ContainsKey(c.GetType().Name))
                {
                    dictionary[c.GetType().Name]++;
                }
                else
                {
                    dictionary[c.GetType().Name] = 1;
                    nrobs++;
                }
            }
            panel1.Invalidate();
            //foreach (String entry in dictionary.Keys)
            //{
            //    Console.WriteLine(entry + " " + dictionary[entry]);
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (listaC.Count!=0)
            {
                Graphics gr = e.Graphics;

                Pen stilou = new Pen(Color.White, 3);
                Rectangle drep = new Rectangle(marg,
                    2 * marg,
                    panel1.Width - 2 * marg,
                    panel1.Height - 5 * marg);

                gr.DrawRectangle(stilou, drep);

                Rectangle[] dreptungiuri = new Rectangle[nrobs];
                gr.DrawRectangles(stilou, dreptungiuri);

                double latime = (drep.Width) / 3 / nrobs;
                double distanta = (drep.Width - latime * nrobs) / (nrobs + 1);

                double vmax = Maxim();
                Brush br = new SolidBrush(culoare);
                int i = 0;
                foreach (String entry in dictionary.Keys)
                {
                    dreptungiuri[i] = new Rectangle((int)(drep.Left + (i + 1) * distanta + i * latime),
                        (int)(drep.Bottom - dictionary[entry] / vmax * (drep.Bottom - drep.Top)) + 5,
                        (int)latime,
                        (int)(dictionary[entry] / vmax * (drep.Bottom - drep.Top)) - 5);

                    gr.DrawString(Convert.ToString(dictionary[entry]), font, br, (int)(drep.Left + (i + 1) * distanta + i * latime + latime / 2),
                        (int)(drep.Bottom - dictionary[entry] / vmax * (drep.Bottom - drep.Top) - font.Height - 5));

                    gr.DrawString(entry, font, br, (int)(drep.Left + (i + 1) * distanta + i * latime + latime / 2),
                        (int)(drep.Bottom + font.Height - 5));
                    i++;
                }

                //for (int i = 0; i < nrobs - 1; i++)
                //    gr.DrawLine(stilou, new Point(dreptungiuri[i].Location.X + (int)dreptungiuri[i].Width, dreptungiuri[i].Location.Y),
                //        new Point(dreptungiuri[i + 1].Location.X + (int)dreptungiuri[i + 1].Width, dreptungiuri[i + 1].Location.Y));

                gr.FillRectangles(br, dreptungiuri);
            }
            Invalidate();
        }

        double Maxim()
        {
            int max = dictionary[dictionary.Keys.ToArray<String>()[0]];
            foreach (String entry in dictionary.Keys)
            {
                if (dictionary[entry] > max)
                {
                    max = dictionary[entry];
                }
            }
            return max;
        }

        private void previewDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(this.pd_Paint);
                PrintPreviewDialog pdlg = new PrintPreviewDialog();
                pdlg.Document = pd;
                pdlg.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }

        private void pd_Paint(object sender, PrintPageEventArgs e)
        {
            if (listaC.Count != 0)
            {
                Graphics gr = e.Graphics;

                Pen stilou = new Pen(Color.White, 3);
                Rectangle drep = new Rectangle(marg,
                    2 * marg,
                    e.PageBounds.Width - 2 * marg,
                    e.PageBounds.Height - 5 * marg);

                gr.DrawRectangle(stilou, drep);

                Rectangle[] dreptungiuri = new Rectangle[nrobs];
                gr.DrawRectangles(stilou, dreptungiuri);

                double latime = (drep.Width) / 3 / nrobs;
                double distanta = (drep.Width - latime * nrobs) / (nrobs + 1);

                double vmax = Maxim();
                Brush br = new SolidBrush(culoare);
                int i = 0;
                foreach (String entry in dictionary.Keys)
                {
                    dreptungiuri[i] = new Rectangle((int)(drep.Left + (i + 1) * distanta + i * latime),
                        (int)(drep.Bottom - dictionary[entry] / vmax * (drep.Bottom - drep.Top)) + 5,
                        (int)latime,
                        (int)(dictionary[entry] / vmax * (drep.Bottom - drep.Top)) - 5);

                    gr.DrawString(Convert.ToString(dictionary[entry]), font, br, (int)(drep.Left + (i + 1) * distanta + i * latime + latime / 2),
                        (int)(drep.Bottom - dictionary[entry] / vmax * (drep.Bottom - drep.Top) - font.Height - 5));

                    gr.DrawString(entry, font, br, (int)(drep.Left + (i + 1) * distanta + i * latime + latime / 2),
                        (int)(drep.Bottom + font.Height - 5));
                    i++;
                }

                //for (int i = 0; i < nrobs - 1; i++)
                //    gr.DrawLine(stilou, new Point(dreptungiuri[i].Location.X + (int)dreptungiuri[i].Width, dreptungiuri[i].Location.Y),
                //        new Point(dreptungiuri[i + 1].Location.X + (int)dreptungiuri[i + 1].Width, dreptungiuri[i + 1].Location.Y));

                gr.FillRectangles(br, dreptungiuri);
            }
            Invalidate();
        }
    }
}
