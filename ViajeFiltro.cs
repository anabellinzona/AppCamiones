using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AppCamiones
{
    internal class ViajeFiltro : Home
    {
        //Grid
        private NewRoundPanel form = new NewRoundPanel();
        private FlowLayoutPanel flForm = new FlowLayoutPanel();

        private DataGridView info = new DataGridView();
        private Panel panelGrid = new Panel();

        private RoundButton volver = new RoundButton();

        private List<string> campos = new List<string>();


        //Constructor
        public ViajeFiltro(string filtro)
        {
            InitializeGrid();

            GeneratorForm(filtro);
        }

        private void GeneratorForm(string filtro)
        {
            if(filtro == "Flete")
            {
                FormRegistro formulario = new FormRegistro("flete");
                formulario.Show();
            }
        }


        //Initializations
        private void InitializeGrid()
        {
            AddInfoToCampos();
            AddItemsToGrid();
            GridChequesProperties();
            ButtonProperties();
        }

        private void AddInfoToCampos()
        {
            this.campos.Clear();
            this.campos = new List<string> { "Fecha", "Origen", "Destino", "RTO o CPE", "Carga", "Km", "Kg", "Tarifa", "Total", "Porcentaje", "Chofer", "Productor" };
        }
        


        //Adds
        private void AddItemsToGrid()
        {
           
            foreach(string i in campos){
                info.Columns.Add(i.ToString(), i);
            }
   
            panelGrid.Controls.Add(info);
            this.Controls.Add(panelGrid);
            this.Controls.Add(volver);

            CargarDatos();
        }



        //Grid
        private void GridChequesProperties()
        {
            panelGrid.Size = new Size(1200, 450);
            this.Resize += (s, e) =>
            {
                panelGrid.Location = new Point((this.Width - panelGrid.Width) / 2, (this.Height - panelGrid.Height) / 2);
            };
            panelGrid.BackColor = Color.Transparent;

            info.Size = new Size(1200, 450);
            info.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            info.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            info.BackgroundColor = Color.DarkGray;
            info.GridColor = Color.Black;
            info.Font = new Font("Nunito", 12, FontStyle.Regular);
            info.Margin = new Padding(0, 1000, 0, 0);

            info.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            info.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            info.EnableHeadersVisualStyles = false;
            info.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            info.AllowUserToResizeRows = false;

        }

        //Properties
        private void ButtonProperties()
        {
            volver.Text = "Volver";
            volver.Size = new Size(150, 50);
            volver.FlatAppearance.BorderSize = 0;
            volver.FlatStyle = FlatStyle.Flat;
            volver.Location = new Point(60, 100);
            volver.Font = new Font("Nunito", 16, FontStyle.Regular);
            volver.BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            volver.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            volver.Click += (s, e) =>
            {
                this.Close();
            };
        }


        //Otros
        private void CargarDatos()
        {
            for (int i = 0; i < 200; i++) 
            {
                info.Rows.Add(" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ");

            }
        }
    }
}