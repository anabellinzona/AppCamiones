using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AppCamiones
{
    public partial class Cheque : Home
    {
        //Form
        private Panel formPanel = new Panel();
        private FlowLayoutPanel formFL = new FlowLayoutPanel();

        private List<string> campos = new List<string>();


        //Button
        private Panel btnPanel = new Panel();
        private RoundButton btnCargar = new RoundButton();


        //Grid
        private DataGridView cheq = new DataGridView();
        private Panel panelGrid = new Panel();



        //Constructor
        public Cheque()
        {
            //MaximizeWindom
            this.WindowState = FormWindowState.Maximized;

            InitializeUI();

            //ShowForm
            CargarFormularioCheque(8);

            //Hovers
            btnCargar.MouseEnter += (s, e) => HoverEffect(s, e, true);
            btnCargar.MouseLeave += (s, e) => HoverEffect(s, e, false);

            //Events
            btnCargar.Click += cargaClickEvent;

            PositionGrid();
        }



        //Initializations
        private void InitializeUI()
        {
            AddItemsToGrid();
            GridChequesProperties();
        }
        private void InitializeFormProperties(int cant, List<string> campos)
        {
            FormProperties(cant);
            LayoutFormProperties(cant);
            TextoBoxAndLabelProperties(cant, campos);
            ButtonsPropertiesForm();
            PanelButtonProperties();
            AddLabels();
            AddForm();
        }



        //Adds
        private void AddItemsToGrid()
        {
            cheq.Columns.Add("fRecibido", "F. Recibido");
            cheq.Columns.Add("banco", "Banco");
            cheq.Columns.Add("nroCheque", "Nro de cheque");
            cheq.Columns.Add("pesos", "Pesos");
            cheq.Columns.Add("nombre", "Nombre");
            cheq.Columns.Add("nroPersonal", "Número personal de cheque");
            cheq.Columns.Add("entregadoA", "Entregado a");
            cheq.Columns.Add("fechaRetiro", "Fecha de retiro");

            panelGrid.Controls.Add(cheq);
            this.Controls.Add(panelGrid);

        }
        private void AddLabels()
        {
            formPanel.Controls.Add(formFL);
        }
        private void AddForm()
        {
            this.Controls.Add(formPanel);
        }



        //HoverFunction
        private void HoverEffect(object sender, EventArgs e, bool isHover)
        {
            var button = sender as Button;
            if (button != null)
            {
                button.ForeColor = isHover ? Color.FromArgb(48,48,48) : Color.Black;
            }
        }


        //FormInformation
        private void CargarFormularioCheque(int cant)
        {
            this.campos.Clear();
            this.campos = new List<string> { "F. Recibido", "Banco", "Nro. de cheque", "Pesos", "Nombre", "Número personal de cheque", "Entregado a", "Fecha de retiro" };

            InitializeFormProperties(cant, campos);
        }



        //FormProperties
        private void FormProperties(int cant)
        {

            formPanel.Size = new Size(ClientSize.Width * 4, 60);
            formPanel.AutoScroll = true;
            formPanel.HorizontalScroll.Enabled = true;
            formPanel.HorizontalScroll.Visible = true;
            formPanel.VerticalScroll.Enabled = false;
            formPanel.VerticalScroll.Visible = false;

            this.Resize += (s, e) =>
            {
                formPanel.Location = new Point((this.Width - formPanel.Width) / 2, 100);
            };

            formPanel.BackColor = System.Drawing.Color.FromArgb(200, Color.Black);
        }
        private void LayoutFormProperties(int cant)
        {
            formFL.AutoSize = true;
            formFL.FlowDirection = FlowDirection.LeftToRight;
            formFL.WrapContents = false;
            formFL.Dock = DockStyle.Top;
            formFL.BackColor = Color.Transparent;

            // Configurar el scroll horizontal
            formFL.AutoScroll = true;
            formFL.HorizontalScroll.Enabled = true;
            formFL.HorizontalScroll.Visible = true;
            formFL.VerticalScroll.Enabled = false;
            formFL.VerticalScroll.Visible = false;

            formPanel.Controls.Add(formFL);
        }


        //TextBoxProperties
        private void TextoBoxAndLabelProperties(int cant, List<string> campos)
        {
            foreach (string campo in campos)
            {
                Panel campoPanel = new Panel();
                campoPanel.AutoSize = true;
                campoPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                campoPanel.Dock = DockStyle.Top;

                TextBox textBoxForm = createTextBoxAndProperties(campo);

                campoPanel.Controls.Add(textBoxForm);
                formFL.Controls.Add(campoPanel);
            }
        }
        private TextBox createTextBoxAndProperties(object campo)
        {
            TextBox textBoxCampo = new TextBox();
            textBoxCampo.Font = new Font("Nunito", 10, FontStyle.Regular);
            textBoxCampo.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
            textBoxCampo.Multiline = true;
            textBoxCampo.Width = 200;
            textBoxCampo.Height = 20;
            textBoxCampo.MinimumSize = new Size(200, 40);
            textBoxCampo.BorderStyle = BorderStyle.FixedSingle;
            textBoxCampo.Margin = new Padding(0, 0, 0, 20);
            textBoxCampo.ForeColor = System.Drawing.Color.Gray;
            textBoxCampo.TextAlign = HorizontalAlignment.Left;
            textBoxCampo.ForeColor = Color.Black;

            string placeholderDefault = !string.IsNullOrWhiteSpace(campo?.ToString()) ? campo.ToString() : "Placeholder";

            //PlaceHolersProperties
            string placeholderText = campo.ToString();
            textBoxCampo.Text = placeholderText;

            textBoxCampo.GotFocus += (s, e) =>
            {
                if (textBoxCampo.Text == placeholderText)
                {
                    textBoxCampo.Text = "";
                }
            };

            textBoxCampo.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBoxCampo.Text))
                {
                    textBoxCampo.Text = placeholderText;
                    textBoxCampo.ForeColor = Color.Black;
                }
            };

            textBoxCampo.SizeChanged += (s, e) =>
            {
                textBoxCampo.Height = 40; 
            };

            return textBoxCampo;
        }



        //ButtonProperties
        private void PanelButtonProperties()
        {
            btnPanel.Width = this.ClientSize.Width;
            btnPanel.Height = 60;
            btnPanel.BackColor = Color.Red;

            this.Controls.Add(btnPanel);
        }
        private void ButtonsPropertiesForm()
        {
            btnCargar.BackColor = System.Drawing.Color.FromArgb(218, 218, 28);
            btnCargar.Size = new Size(110, 30);
            btnCargar.Text = "Cargar";
            btnCargar.FlatStyle = FlatStyle.Flat;
            btnCargar.FlatAppearance.BorderSize = 0;
            btnCargar.ForeColor = Color.Black;
            btnCargar.Font = new Font("Nunito", 12, FontStyle.Bold);

            //btnCargar.Location = new Point(btnPanel.Width - btnCargar.Width - 10, (btnPanel.Height - btnCargar.Height) / 2);

            if (!btnPanel.Controls.Contains(btnCargar))
            {
                btnPanel.Controls.Add(btnCargar);
            }

            this.Resize += (s, e) =>
            {
                btnPanel.Width = this.ClientSize.Width;
                btnPanel.Location = new Point(0, formPanel.Bottom + 20);

                btnCargar.Location = new Point(btnPanel.Width - btnCargar.Width - 10, 0);

                PositionGrid();
            };
        }



        //GridProperties
        private void GridChequesProperties()
        {
            panelGrid.Size = new Size(1200, 400);
            panelGrid.BackColor = Color.Transparent;

            cheq.Size = new Size(1200, 400);
            cheq.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cheq.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cheq.BackgroundColor = Color.DarkGray;
            cheq.GridColor = Color.Black;
            cheq.Font = new Font("Nunito", 12, FontStyle.Bold);

            cheq.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            cheq.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            cheq.EnableHeadersVisualStyles = false;
            cheq.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            cheq.AllowUserToResizeRows = false;



            panelGrid.Controls.Add(cheq);
            this.Controls.Add(panelGrid);
        }
        private void PositionGrid()
        {
            panelGrid.Location = new Point(
                (this.ClientSize.Width - panelGrid.Width) / 2,
                btnPanel.Bottom + 5 // Debajo del btn + 5 de margin
            );
        }


        //Otros
        //CargaDeDatos
        private void cargaClickEvent(object sender, EventArgs e)
        {
            // Obtener los valores de los TextBox
            List<string> datos = new List<string>();
            foreach (Control control in formFL.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control child in panel.Controls)
                    {
                        if (child is TextBox textBox)
                        {
                            datos.Add(textBox.Text); // Agregar el texto de cada TextBox
                        }
                    }
                }
            }

            // Verificar que los datos no estén vacíos
            if (datos.All(dato => !string.IsNullOrWhiteSpace(dato)))
            {
                cheq.Rows.Add(datos.ToArray());

                foreach (Control control in formFL.Controls)
                {
                    if (control is Panel panel)
                    {
                        foreach (Control child in panel.Controls)
                        {
                            if (child is TextBox textBox)
                            {
                                string placeholderText = textBox.Text;
                                textBox.Clear();
                                textBox.Text = placeholderText; // Restaurar el placeholder??????????
                                textBox.ForeColor = Color.Black;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos.");
            }

        }
    }
}