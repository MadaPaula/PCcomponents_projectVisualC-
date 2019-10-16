using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StroiaMadalinaPaula_an3_Proiect.Componente;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace StroiaMadalinaPaula_an3_Proiect
{
    public partial class Form1 : Form
    {
        public Componenta componentaSelectata;
        public static List<Componenta> listaComponente;

        public Form1()
        {
            InitializeComponent();
            listaComponente = new List<Componenta>();
            this.KeyPreview = true;
        }

        void addListView(Componenta componenta, string c)
        {
            ListViewItem item = new ListViewItem(c);
            item.SubItems.Add(componenta.Producator);
            item.SubItems.Add(componenta.Model);
            item.SubItems.Add(componenta.AnFabricatie.ToString());

            listaComponente.Add(componenta);
            listViewComponente.Items.Add(item);
            MessageBox.Show("Componenta s-a introdus cu succes in lista si in List View!");
        }

        void displayList()
        {
            listViewComponente.Items.Clear();
            foreach(Componenta componenta in listaComponente)
            {
                ListViewItem item = new ListViewItem(componenta.GetType().Name);
                item.SubItems.Add(componenta.Producator);
                item.SubItems.Add(componenta.Model);
                item.SubItems.Add(componenta.AnFabricatie.ToString());
                listViewComponente.Items.Add(item);
            }
        }

        #region Clears
        void clearHardDisk()
        {
            tb_producator.Clear();
            tb_model.Clear();
            cb_componenta.SelectedItem = null;
            cb_anFabricatie.SelectedItem = null;
            tb_capacitateHardD.Clear();
            tb_vitezaHardD.Clear();
            setEnabled(false);
        }

        void clearMemorie()
        {
            tb_producator.Clear();
            tb_model.Clear();
            cb_componenta.SelectedItem = null;
            cb_anFabricatie.SelectedItem = null;
            cb_tipMemorie.SelectedItem = null;
            tb_frecvMemorie.Clear();
            tb_capacitateMemorie.Clear();
            setEnabled(false);
        }

        void clearPlacaDeBaza()
        {
            tb_producator.Clear();
            tb_model.Clear();
            cb_componenta.SelectedItem = null;
            cb_anFabricatie.SelectedItem = null;
            cb_formatPlacaBaza.SelectedItem = null;
            numericNrConectoriPlacaBaza.Value = 1;
            numericNrSloturiPlacaBaza.Value = 1;
            setEnabled(false);
        }

        void clearPlacaVideo()
        {
            tb_producator.Clear();
            tb_model.Clear();
            cb_componenta.SelectedItem = null;
            cb_anFabricatie.SelectedItem = null;
            tb_SeriePlacaVideo.Clear();
            tb_FrecventaProcesorPlacaVideo.Clear();
            tb_capacitateMemorie.Clear();
            tb_porturiPlacaVideo.Clear();
        }

        void clearProcesor()
        {
            tb_producator.Clear();
            tb_model.Clear();
            cb_componenta.SelectedItem = null;
            cb_anFabricatie.SelectedItem = null;
            numericNrNucleeProcesor.Value = 1;
            numericNrThreadsProcesor.Value = 1;
            tb_frecventaProcesor.Clear();
            tb_memorieMaxProcesor.Clear();
        }

        void clearSursaTensiune()
        {
            tb_producator.Clear();
            tb_model.Clear();
            cb_componenta.SelectedItem = null;
            cb_anFabricatie.SelectedItem = null;
            tb_putereSursaTensiune.Clear();
            numericNrConectoriSursaTensiune.Value = 1;
        }
#endregion

        void setEnabled(bool variabila)
        {
            tb_producator.Enabled = variabila;
            tb_model.Enabled = variabila;
            cb_anFabricatie.Enabled = variabila;
        }

        private void bt_adaugareListView_Click(object sender, EventArgs e)
        {
            string componentaAleasa = cb_componenta.Text;

            if (cb_componenta.Text.CompareTo("Hard Disk") == 0)
            {
                HardDisk newC = new HardDisk();
                if(string.IsNullOrEmpty(tb_producator.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Producator = tb_producator.Text;
                if (string.IsNullOrEmpty(tb_model.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Model = tb_model.Text;
                if (cb_anFabricatie.SelectedItem==null)
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.AnFabricatie = Convert.ToInt32(cb_anFabricatie.Text);
                if (string.IsNullOrEmpty(tb_capacitateHardD.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Capacitate = Convert.ToInt32(tb_capacitateHardD.Text);
                if (string.IsNullOrEmpty(tb_vitezaHardD.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Viteza = Convert.ToInt32(tb_vitezaHardD.Text);

                addListView(newC, "Hard Disk");
                clearHardDisk();
            }

            if (cb_componenta.Text.CompareTo("Memorie") == 0)
            {
                Memorie newC = new Memorie();
                if (string.IsNullOrEmpty(tb_producator.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Producator = tb_producator.Text;
                if (string.IsNullOrEmpty(tb_model.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Model = tb_model.Text;
                if (cb_anFabricatie.SelectedItem == null)
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.AnFabricatie = Convert.ToInt32(cb_anFabricatie.Text);
                if (cb_tipMemorie.SelectedItem == null)
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Tip = cb_tipMemorie.Text;
                if (string.IsNullOrEmpty(tb_capacitateMemorie.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Capacitate = Convert.ToInt32(tb_capacitateMemorie.Text);
                if (string.IsNullOrEmpty(tb_frecvMemorie.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Frecventa = Convert.ToInt32(tb_frecvMemorie.Text);

                addListView(newC, "Memorie");
                clearMemorie();
            }

            if (cb_componenta.Text.CompareTo("Placa de Baza") == 0)
            {
                PlacaDeBaza newC = new PlacaDeBaza();
                if (string.IsNullOrEmpty(tb_producator.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Producator = tb_producator.Text;
                if (string.IsNullOrEmpty(tb_model.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Model = tb_model.Text;
                if (cb_anFabricatie.SelectedItem == null)
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.AnFabricatie = Convert.ToInt32(cb_anFabricatie.Text);
                if (cb_formatPlacaBaza.SelectedItem == null)
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Format = cb_formatPlacaBaza.Text;
                newC.NumarSloturi =Convert.ToInt32(numericNrSloturiPlacaBaza.Value);
                newC.Conectori = Convert.ToInt32(numericNrConectoriPlacaBaza.Value);

                addListView(newC, "Placa de Baza");
                clearPlacaDeBaza();
            }

            if (cb_componenta.Text.CompareTo("Placa Video") == 0)
            {
                PlacaVideo newC = new PlacaVideo();
                if (string.IsNullOrEmpty(tb_producator.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Producator = tb_producator.Text;
                if (string.IsNullOrEmpty(tb_model.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Model = tb_model.Text;
                if (cb_anFabricatie.SelectedItem == null)
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.AnFabricatie = Convert.ToInt32(cb_anFabricatie.Text);
                if (string.IsNullOrEmpty(tb_capacitatePlacaVideo.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.CapacitateMemorie = Convert.ToInt32(tb_capacitatePlacaVideo.Text);
                if (string.IsNullOrEmpty(tb_FrecventaProcesorPlacaVideo.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.FrecventaProcesor = Convert.ToInt32(tb_FrecventaProcesorPlacaVideo.Text);
                if (string.IsNullOrEmpty(tb_porturiPlacaVideo.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Porturi = tb_porturiPlacaVideo.Text;
                if (string.IsNullOrEmpty(tb_SeriePlacaVideo.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Serie = tb_SeriePlacaVideo.Text;

                addListView(newC, "Placa Video");
                clearPlacaVideo();
            }

            if (cb_componenta.Text.CompareTo("Procesor") == 0)
            {
                Procesor newC = new Procesor();
                if (string.IsNullOrEmpty(tb_producator.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Producator = tb_producator.Text;
                if (string.IsNullOrEmpty(tb_model.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Model = tb_model.Text;
                if (cb_anFabricatie.SelectedItem == null)
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.AnFabricatie = Convert.ToInt32(cb_anFabricatie.Text);
                newC.NumarNuclee = Convert.ToInt32(numericNrNucleeProcesor.Value);
                newC.NumarThreads = Convert.ToInt32(numericNrThreadsProcesor.Value);
                if (string.IsNullOrEmpty(tb_memorieMaxProcesor.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.MemorieMax = Convert.ToInt32(tb_memorieMaxProcesor.Text);
                if (string.IsNullOrEmpty(tb_frecventaProcesor.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Frecventa = tb_frecventaProcesor.Text;

                addListView(newC, "Procesor");
                clearProcesor();
            }

            if (cb_componenta.Text.CompareTo("Sursa Tensiune") == 0)
            {
                SursaTensiune newC = new SursaTensiune();
                if (string.IsNullOrEmpty(tb_producator.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Producator = tb_producator.Text;
                if (string.IsNullOrEmpty(tb_model.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Model = tb_model.Text;
                if (cb_anFabricatie.SelectedItem == null)
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.AnFabricatie = Convert.ToInt32(cb_anFabricatie.Text);
                newC.Conectori = Convert.ToInt32(numericNrConectoriSursaTensiune.Value);
                if (string.IsNullOrEmpty(tb_putereSursaTensiune.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
                newC.Putere = Convert.ToInt32(tb_putereSursaTensiune.Text);

                addListView(newC, "Sursa Tensiune");
                clearSursaTensiune();
            }

        }

        #region Validari
        private void cb_componenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = cb_componenta.SelectedItem;
            if (item != null)
            {
                setEnabled(true);
            }

            if (string.IsNullOrEmpty(cb_componenta.Text))
            {
                gb_hardDisk.Visible = false;
                gb_memorie.Visible = false;
                gb_PlacaDeBaza.Visible = false;
                gb_PlacaVideo.Visible = false;
                gb_procesor.Visible = false;
                gb_SursaTensiune.Visible = false;
            }

            if (cb_componenta.Text.CompareTo("Hard Disk") == 0)
            {
                gb_hardDisk.Visible = true;
                gb_memorie.Visible = false;
                gb_PlacaDeBaza.Visible = false;
                gb_PlacaVideo.Visible = false;
                gb_procesor.Visible = false;
                gb_SursaTensiune.Visible = false;
                gb_hardDisk.BringToFront();
            }

            if (cb_componenta.Text.CompareTo("Memorie") == 0)
            {
                gb_hardDisk.Visible = false;
                gb_memorie.Visible = true;
                gb_PlacaDeBaza.Visible = false;
                gb_PlacaVideo.Visible = false;
                gb_procesor.Visible = false;
                gb_SursaTensiune.Visible = false;
                gb_memorie.BringToFront();
            }

            if (cb_componenta.Text.CompareTo("Placa de Baza") == 0)
            {
                gb_hardDisk.Visible = false;
                gb_memorie.Visible = false;
                gb_PlacaDeBaza.Visible = true;
                gb_PlacaVideo.Visible = false;
                gb_procesor.Visible = false;
                gb_SursaTensiune.Visible = false;
                gb_PlacaDeBaza.BringToFront();
            }

            if (cb_componenta.Text.CompareTo("Placa Video") == 0)
            {
                gb_hardDisk.Visible = false;
                gb_memorie.Visible = false;
                gb_PlacaDeBaza.Visible = false;
                gb_PlacaVideo.Visible = true;
                gb_procesor.Visible = false;
                gb_SursaTensiune.Visible = false;
                gb_PlacaVideo.BringToFront();
            }

            if (cb_componenta.Text.CompareTo("Procesor") == 0)
            {
                gb_hardDisk.Visible = false;
                gb_memorie.Visible = false;
                gb_PlacaDeBaza.Visible = false;
                gb_PlacaVideo.Visible = false;
                gb_procesor.Visible = true;
                gb_SursaTensiune.Visible = false;
                gb_procesor.BringToFront();
            }
            if (cb_componenta.Text.CompareTo("Sursa Tensiune") == 0)
            {
                gb_hardDisk.Visible = false;
                gb_memorie.Visible = false;
                gb_PlacaDeBaza.Visible = false;
                gb_PlacaVideo.Visible = false;
                gb_procesor.Visible = false;
                gb_SursaTensiune.Visible = true;
                gb_SursaTensiune.BringToFront();
            }

        }

        private void tb_model_Validating(object sender, CancelEventArgs e)
        {
            var m = tb_model.Text;
            if (string.IsNullOrEmpty(m))
            {
                e.Cancel = true;
                epComponenta.SetError(tb_model, "Trebuie introdusa o valoare!");
            }
        }

        private void tb_model_Validated(object sender, EventArgs e)
        {
            epComponenta.Clear();
        }

        private void tb_producator_Validating(object sender, CancelEventArgs e)
        {
            var p = tb_producator.Text;
            if (string.IsNullOrEmpty(p))
            {
                e.Cancel = true;
                epComponenta.SetError(tb_producator, "Trebuie introdusa o valoare!");
            }
        }

        private void tb_producator_Validated(object sender, EventArgs e)
        {
            epComponenta.Clear();
        }

        private void tb_capacitateHardD_Validating(object sender, CancelEventArgs e)
        {
            var c = tb_capacitateHardD.Text;
            if (string.IsNullOrEmpty(c))
            {
                e.Cancel = true;
                epHardDisk.SetError(tb_capacitateHardD, "Trebuie introdusa o valoare!");
            }

            try
            {
                int ca = Convert.ToInt32(c);
            }
            catch (FormatException exception)
            {
                e.Cancel = true;
                epHardDisk.SetError(tb_capacitateHardD, "Trebuie introdusa o valoare!");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                MessageBox.Show("A aparut o exceptie!");
            }
            
        }

        private void tb_capacitateHardD_Validated(object sender, EventArgs e)
        {
            epHardDisk.Clear();
        }

        private void tb_vitezaHardD_Validating(object sender, CancelEventArgs e)
        {
            var v = tb_vitezaHardD.Text;
            if (string.IsNullOrEmpty(v))
            {
                e.Cancel = true;
                epHardDisk.SetError(tb_vitezaHardD, "Trebuie introdusa o valoare!");
            }

            try
            {
                int vi = Convert.ToInt32(v);
            }
            catch (FormatException exception)
            {
                e.Cancel = true;
                epHardDisk.SetError(tb_vitezaHardD, "Trebuie introdusa o valoare!");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                MessageBox.Show("A aparut o exceptie!");
            }
        }

        private void tb_vitezaHardD_Validated(object sender, EventArgs e)
        {
            epHardDisk.Clear();
        }

        private void tb_capacitateMemorie_Validating(object sender, CancelEventArgs e)
        {
            var c = tb_capacitateMemorie.Text;
            if (string.IsNullOrEmpty(c))
            {
                e.Cancel = true;
                epMemorie.SetError(tb_capacitateMemorie, "Trebuie introdusa o valoare!");
            }

            try
            {
                int vi = Convert.ToInt32(c);
            }
            catch (FormatException exception)
            {
                e.Cancel = true;
                epMemorie.SetError(tb_capacitateMemorie, "Trebuie introdusa o valoare!");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                MessageBox.Show("A aparut o exceptie!");
                epMemorie.SetError(tb_capacitateMemorie, "Trebuie introdusa o valoare!");
            }
        }

        private void tb_capacitateMemorie_Validated(object sender, EventArgs e)
        {
            epMemorie.Clear();
        }

        private void tb_frecvMemorie_Validating(object sender, CancelEventArgs e)
        {
            var f = tb_frecvMemorie.Text;
            if (string.IsNullOrEmpty(f))
            {
                e.Cancel = true;
                epMemorie.SetError(tb_frecvMemorie, "Trebuie introdusa o valoare!");
            }

            try
            {
                int vi = Convert.ToInt32(f);
            }
            catch (FormatException exception)
            {
                e.Cancel = true;
                epMemorie.SetError(tb_frecvMemorie, "Trebuie introdusa o valoare!");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                MessageBox.Show("A aparut o exceptie!");
                epMemorie.SetError(tb_frecvMemorie, "Trebuie introdusa o valoare!");
            }
        }

        private void tb_frecvMemorie_Validated(object sender, EventArgs e)
        {
            epMemorie.Clear();
        }

        private void tb_SeriePlacaVideo_Validating(object sender, CancelEventArgs e)
        {
            var s = tb_SeriePlacaVideo.Text;
            if (string.IsNullOrEmpty(s))
            {
                e.Cancel = true;
                epPlacaVideo.SetError(tb_SeriePlacaVideo, "Trebuie introdusa o valoare!");
            }
        }

        private void tb_SeriePlacaVideo_Validated(object sender, EventArgs e)
        {
            epPlacaVideo.Clear();
        }

        private void tb_FrecventaProcesorPlacaVideo_Validating(object sender, CancelEventArgs e)
        {
            var f = tb_FrecventaProcesorPlacaVideo.Text;
            if (string.IsNullOrEmpty(f))
            {
                e.Cancel = true;
                epPlacaVideo.SetError(tb_FrecventaProcesorPlacaVideo, "Trebuie introdusa o valoare!");
            }

            try
            {
                int fr = Convert.ToInt32(f);
            }
            catch (FormatException exception)
            {
                e.Cancel = true;
                epPlacaVideo.SetError(tb_FrecventaProcesorPlacaVideo, "Trebuie introdusa o valoare!");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                MessageBox.Show("A aparut o exceptie!");
                epPlacaVideo.SetError(tb_FrecventaProcesorPlacaVideo, "Trebuie introdusa o valoare!");
            }

        }

        private void tb_FrecventaProcesorPlacaVideo_Validated(object sender, EventArgs e)
        {
            epPlacaVideo.Clear();
        }

        private void tb_porturiPlacaVideo_Validating(object sender, CancelEventArgs e)
        {
            var p = tb_porturiPlacaVideo.Text;
            if (string.IsNullOrEmpty(p))
            {
                e.Cancel = true;
                epPlacaVideo.SetError(tb_porturiPlacaVideo, "Trebuie introdusa o valoare!");
            }
        }

        private void tb_porturiPlacaVideo_Validated(object sender, EventArgs e)
        {
            epPlacaVideo.Clear();
        }

        private void tb_capacitatePlacaVideo_Validating(object sender, CancelEventArgs e)
        {
            var c = tb_capacitatePlacaVideo.Text;
            if (string.IsNullOrEmpty(c))
            {
                e.Cancel = true;
                epPlacaVideo.SetError(tb_capacitatePlacaVideo, "Trebuie introdusa o valoare!");
            }

            try
            {
                int ca = Convert.ToInt32(c);
            }
            catch (FormatException exception)
            {
                e.Cancel = true;
                epPlacaVideo.SetError(tb_capacitatePlacaVideo, "Trebuie introdusa o valoare!");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                MessageBox.Show("A aparut o exceptie!");
                epPlacaVideo.SetError(tb_capacitatePlacaVideo, "Trebuie introdusa o valoare!");
            }
        }

        private void tb_capacitatePlacaVideo_Validated(object sender, EventArgs e)
        {
            epPlacaVideo.Clear();
        }

        private void tb_frecventaProcesor_Validating(object sender, CancelEventArgs e)
        {
            var f = tb_frecventaProcesor.Text;
            if (string.IsNullOrEmpty(f))
            {
                e.Cancel = true;
                epProcesor.SetError(tb_frecventaProcesor, "Trebuie introdusa o valoare!");
            }

            try
            {
                string[] values=f.Split('-');
                if (values.Length != 2) throw new FrecventaException();
                int nr1 = Convert.ToInt32(values[0]);
                int nr2 = Convert.ToInt32(values[1]);
                if (nr1 > nr2) throw new FrecventaException();
                
            }
            catch (FrecventaException ex)
            {
                e.Cancel = true;
                epProcesor.SetError(tb_frecventaProcesor, "Frecventa trebuie scrisa de forma: numar-numar");
                MessageBox.Show("Frecventa trebuie scrisa de forma: numar-numar");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                MessageBox.Show("A aparut o exceptie, nu s-au introdus corect datele!");
                epProcesor.SetError(tb_frecventaProcesor, "Frecventa trebuie scrisa de forma: numar-numar");
            }
        }

        private void tb_frecventaProcesor_Validated(object sender, EventArgs e)
        {
            epProcesor.Clear();
        }

        private void tb_memorieMaxProcesor_Validating(object sender, CancelEventArgs e)
        {
            var m = tb_memorieMaxProcesor.Text;
            if (string.IsNullOrEmpty(m))
            {
                e.Cancel = true;
                epProcesor.SetError(tb_memorieMaxProcesor, "Trebuie introdusa o valoare!");
            }

            try
            {
                int fr = Convert.ToInt32(m);
            }
            catch (FormatException exception)
            {
                e.Cancel = true;
                epProcesor.SetError(tb_memorieMaxProcesor, "Trebuie introdusa o valoare!");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                MessageBox.Show("A aparut o exceptie!");
                epProcesor.SetError(tb_memorieMaxProcesor, "Trebuie introdusa o valoare!");
            }
        }

        private void tb_memorieMaxProcesor_Validated(object sender, EventArgs e)
        {
            epProcesor.Clear();
        }

        private void tb_putereSursaTensiune_Validating(object sender, CancelEventArgs e)
        {
            var p = tb_putereSursaTensiune.Text;
            if (string.IsNullOrEmpty(p))
            {
                e.Cancel = true;
                epSursaTensiune.SetError(tb_putereSursaTensiune, "Trebuie introdusa o valoare!");
            }

            try
            {
                int pu = Convert.ToInt32(p);
            }
            catch (FormatException exception)
            {
                e.Cancel = true;
                epSursaTensiune.SetError(tb_putereSursaTensiune, "Trebuie introdusa o valoare!");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                MessageBox.Show("A aparut o exceptie!");
                epSursaTensiune.SetError(tb_putereSursaTensiune, "Trebuie introdusa o valoare!");
            }
        }

        private void tb_putereSursaTensiune_Validated(object sender, EventArgs e)
        {
            epSursaTensiune.Clear();
        }
        #endregion

        private void serializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream stream = File.Create("fisierBin.bin"))
            {
                bf.Serialize(stream, listaComponente);
            }
            MessageBox.Show("Serializare BINAR cu succes!");
        }

        private void deserializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream stream = File.OpenRead("fisierBin.bin"))
            {
                listaComponente =(List<Componenta>) bf.Deserialize(stream);
                displayList();
            }
            MessageBox.Show("Deserializare BINAR cu succes!");
        }

        private void serializareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //XmlSerializer xml = new XmlSerializer(typeof(List<Componenta>));
            //using (StreamWriter sw = new StreamWriter("fisierXML.xml"))
            //{
            //    xml.Serialize(sw, listaComponente);
            //}
            //MessageBox.Show("Serializare XML cu succes!");
            MessageBox.Show("In lucru");
        }

        private void deserializareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //XmlSerializer xml = new XmlSerializer(typeof(List<Componenta>));
            //using(StreamReader sr = new StreamReader("fisierXML.xml"))
            //{
            //    listaComponente = (List<Componenta>)xml.Deserialize(sr);
            //}
            //MessageBox.Show("Deserializare XML cu succes!");
            MessageBox.Show("In lucru");
        }

        private void bt_exportTXT_Click(object sender, EventArgs e)
        {
            using (StreamWriter file = new StreamWriter("fisierTXT.txt"))
            {
                foreach (Componenta componenta in listaComponente)
                {
                    file.WriteLine(componenta.ToString());
                }
            }
            MessageBox.Show("Fisier txt creat!");
        }

        private void vizualizareDetaliiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (componentaSelectata != null)
            {
                if (componentaSelectata.GetType().Name == "HardDisk")
                {
                    HardDisk hd =(HardDisk) componentaSelectata;
                    cb_componenta.SelectedIndex = 0;
                    tb_model.Text = componentaSelectata.Model;
                    tb_producator.Text = componentaSelectata.Producator;
                    cb_anFabricatie.SelectedItem = componentaSelectata.AnFabricatie.ToString();
                    tb_capacitateHardD.Text = hd.Capacitate.ToString();
                    tb_vitezaHardD.Text = hd.Viteza.ToString();
                    gb_componenta.Enabled = false;
                }

                if (componentaSelectata.GetType().Name == "Memorie")
                {
                    Memorie m = (Memorie)componentaSelectata;
                    cb_componenta.SelectedIndex = 1;
                    tb_model.Text = componentaSelectata.Model;
                    tb_producator.Text = componentaSelectata.Producator;
                    cb_anFabricatie.SelectedItem = componentaSelectata.AnFabricatie.ToString();
                    tb_capacitateMemorie.Text = m.Capacitate.ToString();
                    tb_frecvMemorie.Text = m.Frecventa.ToString();
                    cb_tipMemorie.SelectedItem = m.Tip.ToString();
                    gb_componenta.Enabled = false;
                }

                if (componentaSelectata.GetType().Name == "PlacaDeBaza")
                {
                    PlacaDeBaza pb = (PlacaDeBaza)componentaSelectata;
                    cb_componenta.SelectedIndex = 2;
                    tb_model.Text = componentaSelectata.Model;
                    tb_producator.Text = componentaSelectata.Producator;
                    cb_anFabricatie.SelectedItem = componentaSelectata.AnFabricatie.ToString();
                    numericNrSloturiPlacaBaza.Value = pb.NumarSloturi;
                    numericNrConectoriPlacaBaza.Value = pb.Conectori;
                    cb_formatPlacaBaza.SelectedItem = pb.Format.ToString();
                    gb_componenta.Enabled = false;
                }

                if (componentaSelectata.GetType().Name == "PlacaVideo")
                {
                    PlacaVideo pv = (PlacaVideo)componentaSelectata;
                    cb_componenta.SelectedIndex = 3;
                    tb_model.Text = componentaSelectata.Model;
                    tb_producator.Text = componentaSelectata.Producator;
                    cb_anFabricatie.SelectedItem = componentaSelectata.AnFabricatie.ToString();
                    tb_SeriePlacaVideo.Text = pv.Serie;
                    tb_porturiPlacaVideo.Text = pv.Porturi;
                    tb_FrecventaProcesorPlacaVideo.Text = pv.FrecventaProcesor.ToString();
                    tb_capacitatePlacaVideo.Text = pv.CapacitateMemorie.ToString();
                    gb_componenta.Enabled = false;
                }

                if (componentaSelectata.GetType().Name == "Procesor")
                {
                    Procesor p = (Procesor)componentaSelectata;
                    cb_componenta.SelectedIndex = 4;
                    tb_model.Text = componentaSelectata.Model;
                    tb_producator.Text = componentaSelectata.Producator;
                    cb_anFabricatie.SelectedItem = componentaSelectata.AnFabricatie.ToString();
                    tb_memorieMaxProcesor.Text = p.MemorieMax.ToString();
                    tb_frecventaProcesor.Text = p.Frecventa;
                    numericNrNucleeProcesor.Value = p.NumarNuclee;
                    numericNrThreadsProcesor.Value = p.NumarThreads;
                    gb_componenta.Enabled = false;
                }

                if (componentaSelectata.GetType().Name == "SursaTensiune")
                {
                    SursaTensiune st = (SursaTensiune)componentaSelectata;
                    cb_componenta.SelectedIndex = 5;
                    tb_model.Text = componentaSelectata.Model;
                    tb_producator.Text = componentaSelectata.Producator;
                    cb_anFabricatie.SelectedItem = componentaSelectata.AnFabricatie.ToString();
                    tb_putereSursaTensiune.Text = st.Putere.ToString();
                    numericNrConectoriSursaTensiune.Value = st.Conectori;
                    gb_componenta.Enabled = false;
                }

            }
        }

        private void listViewComponente_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected == true)
            {
                componentaSelectata = listaComponente[e.ItemIndex];
            }
            else
            {
                componentaSelectata = null;
                clearHardDisk();
                clearMemorie();
                clearPlacaDeBaza();
                clearPlacaVideo();
                clearProcesor();
                clearSursaTensiune();
                gb_componenta.Enabled = true;
            }
           
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                
                Application.Exit();
            }
        }

        private void bt_grafic_Click(object sender, EventArgs e)
        {
            FormGrafic form = new FormGrafic(listaComponente);
            form.ShowDialog();
           
        }


    }
}
