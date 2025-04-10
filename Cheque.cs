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
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
using Button = System.Windows.Forms.Button;

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

        //Filter
        private Panel filterPanel = new Panel();
        private FlowLayoutPanel filterFL = new FlowLayoutPanel();

        private TextBox filterTextBox = new TextBox();
        private RoundButton filterBtn = new RoundButton();

        //Grid
        private DataGridView cheq = new DataGridView();
        private Panel panelGrid = new Panel();

        DataGridViewButtonColumn eliminar = new DataGridViewButtonColumn();
        DataGridViewButtonColumn modificar = new DataGridViewButtonColumn();



        //Constructor
        public Cheque()
        {
            ResaltarBoton(chequesMenu);

            InitializeUI();

            //ShowForm
            CargarFormularioCheque(9);

            //Hovers
            btnCargar.MouseEnter += (s, e) => HoverEffect(s, e, true);
            btnCargar.MouseLeave += (s, e) => HoverEffect(s, e, false);

            //Events
            btnCargar.Click += cargaClickEvent;

            cheq.CellClick += eliminarFila;
            cheq.CellClick += modificarFila;

            ConfigurarDataGridView();

            PositionGrid();
        }

        private void ConfigurarDataGridView()
        {
            if (cheq.Columns["Eliminar"] == null)
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "Eliminar";
                btnEliminar.HeaderText = "X";  // Puedes dejarlo vacío si prefieres
                btnEliminar.Text = "x"; // Ícono de eliminar
                btnEliminar.UseColumnTextForButtonValue = true; // Hace que todas las celdas muestren "❌"
                btnEliminar.Width = 40; // Ajustar tamaño
                cheq.Columns.Add(btnEliminar);
            }

            if (cheq.Columns["Modificar"] == null)
            {
                DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
                btnModificar.Name = "Modificar";
                btnModificar.HeaderText = "X";  // Puedes dejarlo vacío si prefieres
                btnModificar.Text = "x"; // Ícono de modificar
                btnModificar.UseColumnTextForButtonValue = true; // Hace que todas las celdas muestren "M"
                btnModificar.Width = 40; // Ajustar tamaño
                cheq.Columns.Add(btnModificar);
            }
        }

        //Initializations
        private void InitializeUI()
        {
            AddItemsToGrid();
            GridChequesProperties();
            InitializeFilter();
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
        private void InitializeFilter()
        {
            AddFilter();
            filterProperties();
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
            cheq.Columns.Add("eliminar", "Eliminar");
            cheq.Columns.Add("modificar", "Modificar");

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
        private void AddFilter()
        {
            filterFL.Controls.Add(filterTextBox);
            filterFL.Controls.Add(filterBtn);

            filterPanel.Controls.Add(filterFL);

            this.Controls.Add(filterPanel);
        }



        //HoverFunction
        private void HoverEffect(object sender, EventArgs e, bool isHover)
        {
            var button = sender as Button;
            if (button != null)
            {
                button.ForeColor = isHover ? Color.FromArgb(48, 48, 48) : Color.Black;
            }
        }


        //FormInformation
        private void CargarFormularioCheque(int cant)
        {
            this.campos.Clear();
            this.campos = new List<string> { "F. Recibido", "Banco", "Nro. Cheque", "Pesos", "Nombre", "Nro. Personal", "Entregado a", "Fecha de retiro" };

            InitializeFormProperties(cant, campos);
        }


        //FilterProperties
        private void filterProperties()
        {
            
            filterPanel.Size = new Size(200, 50);
            filterPanel.BackColor = Color.Transparent; 
            filterPanel.Location = new Point(cheq.Location.X + cheq.Width - (filterPanel.Width / 2), menuStrip.Height + formFL.Height + 30);

            filterFL.Dock = DockStyle.Fill;
            filterFL.FlowDirection = FlowDirection.LeftToRight;
            filterFL.WrapContents = false;
            filterFL.AutoSize = false;
            filterFL.Margin = new Padding(0);
            filterFL.Padding = new Padding(0);

            filterTextBox.Size = new Size(120, 30);
            filterTextBox.Font = new Font("Nunito", 10);
            filterTextBox.PlaceholderText = "Buscar por Nro. Cheque...";
            filterTextBox.Margin = new Padding(5, 10, 5, 10);

            filterBtn.Text = "🔍";
            filterBtn.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            filterBtn.BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            filterBtn.Size = new Size(30, 25);
            filterBtn.Margin = new Padding(0, 10, 5, 10);
            filterBtn.FlatStyle = FlatStyle.Flat;
            filterBtn.FlatAppearance.BorderColor = Color.FromArgb(48, 48, 48);
            filterBtn.FlatAppearance.BorderSize = 1;

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

                System.Windows.Forms.Label labelCampo = new System.Windows.Forms.Label();
                labelCampo.Text = campo;
                labelCampo.Font = new Font("Nunito", 10, FontStyle.Bold);
                labelCampo.ForeColor = Color.White;
                labelCampo.TextAlign = ContentAlignment.MiddleLeft;
                labelCampo.Dock = DockStyle.Right;
                labelCampo.AutoSize = true;

                TextBox textBoxForm = createTextBoxAndProperties(campo);

                campoPanel.Controls.Add(labelCampo); 
                campoPanel.Controls.Add(textBoxForm);
                formFL.Controls.Add(campoPanel);
            }
        }
        private TextBox createTextBoxAndProperties(object campo)
        {
            TextBox textBoxCampo = new TextBox();
            textBoxCampo.Font = new Font("Nunito", 12, FontStyle.Regular);
            textBoxCampo.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
            textBoxCampo.Multiline = true;
            textBoxCampo.Width = 200;
            textBoxCampo.Height = 20;
            textBoxCampo.MinimumSize = new Size(200, 40);
            textBoxCampo.BorderStyle = BorderStyle.FixedSingle;
            textBoxCampo.Margin = new Padding(0, 0, 0, 20);
            textBoxCampo.ForeColor = System.Drawing.Color.Gray;
            textBoxCampo.TextAlign = HorizontalAlignment.Left;
            textBoxCampo.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);

            string placeholderDefault = !string.IsNullOrWhiteSpace(campo?.ToString()) ? campo.ToString() : "Placeholder";

            //PlaceHolersProperties
            string placeholderText = campo.ToString();
            textBoxCampo.Text = placeholderText;

            textBoxCampo.GotFocus += (s, e) =>
            {
                if (textBoxCampo.Text == placeholderText)
                {
                    textBoxCampo.Text = "";

                    textBoxCampo.ForeColor = Color.Black;
                }
            };

            textBoxCampo.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBoxCampo.Text))
                {
                    textBoxCampo.Text = placeholderText;
                    textBoxCampo.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);
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
            this.Resize += (s, e) =>
            {
                btnPanel.Location = new Point((this.Width - btnPanel.Width) - 50, 110);

                PositionGrid();
            };

            btnPanel.Size = new Size(110, 30);
            btnPanel.BackColor = Color.Transparent;
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

            if (!btnPanel.Controls.Contains(btnCargar))
            {
                btnPanel.Controls.Add(btnCargar);
            }

            btnPanel.Resize += (s, e) =>
            {
                btnCargar.Location = new Point((btnPanel.Width - btnCargar.Width) / 2, (btnPanel.Height - btnCargar.Height) / 2);

                PositionGrid();
            };
        }



        //GridProperties
        private void GridChequesProperties()
        {
            panelGrid.Size = new Size(1200, 400);
            panelGrid.BackColor = Color.Transparent;

            cheq.Size = new Size(panelGrid.Width, panelGrid.Height);
            cheq.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cheq.Height = 400;
            cheq.BackgroundColor = Color.DarkGray;
            cheq.GridColor = Color.Black;
            cheq.Font = new Font("Nunito", 12, FontStyle.Bold);

            cheq.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            cheq.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            cheq.EnableHeadersVisualStyles = false;
            cheq.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            cheq.AllowUserToResizeRows = false;

            panelGrid.Controls.Add(cheq);
            this.Controls.Add(panelGrid);
        }

        private void PositionGrid()
        {
            panelGrid.Location = new Point((this.Width - panelGrid.Width) / 2, 250);

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
                            foreach(string campo in campos)
                            {
                                if (textBox.Text == campo.ToString())
                                {
                                    MessageBox.Show("Complete todos los campos");
                                    return;
                                }
                                if (textBox.Name == campo)
                                {
                                    if (campo == "Fecha")
                                    {
                                        TextBox campoFecha = textBox;
                                        DateTime fecha;
                                        if (!DateTime.TryParse(campoFecha.Text, out fecha))
                                        {
                                            MessageBox.Show("Por favor, ingrese una fecha válida.");
                                            textBox.Focus();
                                            return;
                                        }
                                    }
                                }
                            }
                            
                            datos.Add(textBox.Text); // Agregar el texto de cada TextBox
                        }
                    }
                }
            }

            // Verificar que los datos no estén vacíos
            if (datos.All(dato => !string.IsNullOrWhiteSpace(dato)))
            {

                eliminar.Text = "X";
                eliminar.UseColumnTextForButtonValue = true;

                datos.Add(eliminar.Text);

                modificar.Text = "M";
                modificar.UseColumnTextForButtonValue = true;

                datos.Add(modificar.Text);

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
        }

        private void eliminarFila(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si la celda clickeada pertenece a la columna "Eliminar"
            if (e.ColumnIndex == cheq.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                // Confirmar antes de eliminar (opcional)
                DialogResult resultado = MessageBox.Show("¿Desea eliminar esta fila?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    cheq.Rows.RemoveAt(e.RowIndex); //funcionEliminar
                }

            }
        }

        private void modificarFila(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si la celda clickeada pertenece a la columna "Modificar"
            if (e.ColumnIndex == cheq.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                // Confirmar antes de modificar (opcional)
                DialogResult resultado = MessageBox.Show("¿Desea modificar esta fila?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    //funcionModificar
                }

            }
        }
    }
}