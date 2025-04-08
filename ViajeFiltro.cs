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
        public ViajeFiltro(string dato, int cant, List<string> camposForm, string filtro)
        {
            InitializeGrid(camposForm);

            GeneratorForm(dato, cant, filtro);
        }

        private void GeneratorForm(string dato, int cant, string filtro)
        {
            FormRegistro formulario = new FormRegistro(campos, cant, dato, filtro);
            formulario.TopLevel = true;
            formulario.ShowDialog();
        }


        //Initializations
        private void InitializeGrid(List<string> camposForm)
        {
            AddInfoToCampos(camposForm);
        }

        private void AddInfoToCampos(List<string> camposForm)
        {
            this.campos.Clear();
            foreach(string i in camposForm)
            {
                this.campos.Add(i);
            }
        }
    }
}