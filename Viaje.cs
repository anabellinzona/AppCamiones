using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Collections;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AppCamiones
{
    internal class Viaje : Home
    {
        //Filter
        private NewRoundPanel filter = new NewRoundPanel();
        private FlowLayoutPanel filterFL = new FlowLayoutPanel();

        private ArrayList buttonsFilter = new ArrayList();
        private ArrayList buttonsNameFilter = new ArrayList();
        private RoundButton fleteFilter = new RoundButton();
        private RoundButton camionFilter = new RoundButton();
        private RoundButton clienteFilter = new RoundButton();

        private RoundButton agregarNuevo = new RoundButton();

        private ArrayList botonesRegistro = new ArrayList();
        private ArrayList nombreBotonesRegistro = new ArrayList();

        private RoundButton btn_volver = new RoundButton();

        //Form
        private NewRoundPanel formCargarSection = new NewRoundPanel();
        private FlowLayoutPanel layourFormSection = new FlowLayoutPanel();
        private System.Windows.Forms.ComboBox select = new System.Windows.Forms.ComboBox();
        private System.Windows.Forms.TextBox textBoxNombre = new System.Windows.Forms.TextBox();
        private RoundButton buttonAcept = new RoundButton();

        private List<string> camiones = new List<string>();
        private List<string> clientes = new List<string>();
        private List<string> fletes = new List<string> { "López", "Fernández", "Martínez" };

        private List<string> campos = new List<string>();
        private int cant = 0;


        //Card
        private FlowLayoutPanel cardsContainer = new FlowLayoutPanel();



        //Constructor
        public Viaje()
        {
            buttonAcept.Click += ButtonAcept_Click1;
            InitializeFilterCards();
            ResaltarBoton(viajesMenu);


            //Hovers
            fleteFilter.MouseEnter += (s, e) => HoverEffect(s, e, true);
            fleteFilter.MouseLeave += (s, e) => HoverEffect(s, e, false);

            clienteFilter.MouseEnter += (s, e) => HoverEffect(s, e, true);
            clienteFilter.MouseLeave += (s, e) => HoverEffect(s, e, false);

            camionFilter.MouseEnter += (s, e) => HoverEffect(s, e, true);
            camionFilter.MouseLeave += (s, e) => HoverEffect(s, e, false);

            //Events
            fleteFilter.Click += (s, e) => CardGenerator("Flete", " ");
            clienteFilter.Click += (s, e) => CardGenerator("Cliente", " ");
            camionFilter.Click += (s, e) => CardGenerator("Camión", " ");

           
        }

        private void ButtonAcept_Click1(object sender, EventArgs e)
        {
            if (select.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona una opción antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            MessageBox.Show("Agregado correctamente");
            string seleccion = select.SelectedItem.ToString();
            GetFilterInfo(seleccion, textBoxNombre.Text);
            CardGenerator(seleccion, " ");
        }


        //HoverFunction
        private void HoverEffect(object sender, EventArgs e, bool isHover)
        {
            var button = sender as RoundButton;
            if (button != null)
            {
                button.Font = new Font("Nunito", isHover ? 20 : 16, FontStyle.Regular);
                button.ForeColor = isHover ? Color.FromArgb(218, 218, 28) : Color.FromArgb(224, 224, 224);
            }
        }



        //Initializations

        private void InitializeFilterCards()
        {
            OptionsMenuProperties();
            LayoutOptionsMenuProperties();
            ButtonsProperties();
            CardProperties();
            AddItemsToFilter();
            AddButtonNewAdd();
            ButtonNewAddProperties();
        }

        private void AddItemsToFilter()
        {
            this.Controls.Add(filter);
            this.Controls.Add(cardsContainer);
            filter.Controls.Add(filterFL);
        }

        //FilterProperties
        private void OptionsMenuProperties()
        {
            filter.Size = new Size(800, 60);
            this.Resize += (s, e) =>
            {
                filter.Location = new Point((this.Width - filter.Width) / 2, 100);
            };
            filter.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            filter.BorderStyle = BorderStyle.FixedSingle;
        }
        private void LayoutOptionsMenuProperties()
        {
            filterFL.AutoSize = true;
            filterFL.Width = fleteFilter.Width;
            filterFL.BackColor = Color.Transparent;
            filterFL.FlowDirection = FlowDirection.LeftToRight;
            filter.Resize += (s, e) =>
            {
                filterFL.Location = new Point((filter.Width - filterFL.Width) / 2, (filter.Height - filterFL.Height) / 2);
            };
        }

        private void AddButtonNewAdd()
        {
            cardsContainer.Controls.Add(agregarNuevo);
        }

        //InfoFunctions
        public void CardGenerator(string filtro, string info)
        {
            cardsContainer.Controls.Clear();

            List<string> datos = GetFilterInfo(filtro, info);

            foreach (string dato in datos)
            {
                Panel card = new Panel
                {
                    Size = new Size(200, 100),
                    BackColor = System.Drawing.Color.FromArgb(48, 48, 48),
                    Margin = new Padding(10),
                    Font = new Font("Nunito", 16, FontStyle.Regular),
                };

                Label label = new Label
                {
                    Text = dato,
                    ForeColor = System.Drawing.Color.FromArgb(218, 218, 28),
                    AutoSize = true,
                    TextAlign = ContentAlignment.TopCenter,
                    Location = new Point(10, 10),
                    BackColor = Color.Transparent
                };

                card.Controls.Add(label);
                cardsContainer.Controls.Add(card);
                cant = 0;
                if (filtro == "Camión")
                {
                    campos.Clear();
                    this.campos = new List<string> { "Fecha", "Origen", "Destino", "RTO o CPE", "Carga", "Km", "Kg", "Tarifa", "Total", "Porcentaje", "Chofer", "Productor" };
                    cant = campos.Count();
                }
                else if (filtro == "Cliente")
                {
                    
                    campos.Clear();
                    this.campos = new List<string> { "Fecha", "Origen", "Destino", "RTO o CPE", "Carga", "Km", "Kg", "Tarifa", "Total", "Porcentaje", "Chofer", "Productor" };
                    cant = campos.Count();
                }
                else if (filtro == "Flete")
                {
                    campos.Clear();
                    this.campos = new List<string> { "Fecha", "Origen", "HOLA", "RTO o CPE", "Carga", "Km", "Kg", "Tarifa", "Total", "Porcentaje", "Productor" };
                    cant = campos.Count();
                }

                card.Click += (s, e) =>
                {
                    ViajeFiltro form = new ViajeFiltro(dato, cant, campos, filtro);
                    form.Show();
                };
            }
        }


        public List<string> GetFilterInfo(string filtro, string info)
        {
            if (!string.IsNullOrWhiteSpace(info))
            {
                if (filtro == "Camión")
                {
                    camiones.Add(info);
                }
                else if (filtro == "Cliente")
                {
                    clientes.Add(info);
                }
                else if (filtro == "Flete")
                {
                    fletes.Add(info);
                }
            }

            // Retornar la lista correspondiente
            return filtro switch
            {
                "Camión" => camiones,
                "Cliente" => clientes,
                "Flete" => fletes,
                _ => new List<string>()
            };
        }

        private void ButtonsProperties()
        {
            int j = 0;

            buttonsFilter.Add(fleteFilter);
            buttonsFilter.Add(clienteFilter);
            buttonsFilter.Add(camionFilter);

            buttonsNameFilter.Add("Flete");
            buttonsNameFilter.Add("Cliente");
            buttonsNameFilter.Add("Camión");

            for (int i = 0; i < buttonsFilter.Count; i++)
            {
                System.Windows.Forms.Button btn = (System.Windows.Forms.Button)buttonsFilter[i];

                btn.Size = new Size(150, 50);
                btn.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
                btn.Font = new Font("Nunito", 16, FontStyle.Regular);
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.Transparent;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
                btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                btn.Margin = new Padding(0, 20, 0, 0);
                btn.TextAlign = ContentAlignment.MiddleCenter;

                if (j < buttonsNameFilter.Count)
                {
                    btn.Text = buttonsNameFilter[j].ToString().ToUpper();
                    j++;
                }



                btn.Click += (s, e) => CardGenerator(btn.Text, " ");

                filterFL.Controls.Add(btn);
            }
        }

        //CardProperties
        private void CardProperties()
        {
            cardsContainer.Size = new Size(800, 400);
            cardsContainer.AutoScroll = true;
            cardsContainer.FlowDirection = FlowDirection.LeftToRight;
            cardsContainer.WrapContents = true;
            cardsContainer.Margin = new Padding(10, 10, 10, 10);
            cardsContainer.BackColor = System.Drawing.Color.FromArgb(200, Color.Black);

            this.Resize += (s, e) =>
            {
                cardsContainer.Location = new Point((this.Width - cardsContainer.Width) / 2, filter.Bottom + 10);
            };
        }

        private void ButtonNewAddProperties()
        {
            agregarNuevo.Size = new Size(200, 150);
            agregarNuevo.BackColor = System.Drawing.Color.FromArgb(200, Color.Black);
            agregarNuevo.Text = "+";
            agregarNuevo.FlatStyle = FlatStyle.Flat;
            agregarNuevo.FlatAppearance.BorderSize = 0;  // Grosor del borde
            agregarNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(218, 218, 28); // Color del borde
            agregarNuevo.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            agregarNuevo.Font = new Font("Nunito", 24, FontStyle.Bold);
            agregarNuevo.Margin = new Padding((cardsContainer.Width - agregarNuevo.Width) / 2, (cardsContainer.Height - agregarNuevo.Height) / 2, 0, 0);

            agregarNuevo.Click += (s, e) => FormAddNew();
        }

        private void FormAddNew()
        {
            agregarNuevo.Visible = false;
            FormProperties();
            LayoutFormProperties();
            TextBoxProperties();
            ButtonAceptProperties();
            ComboBoxProperties();
        }

        private void FormProperties()
        {
            formCargarSection.Size = new Size(200, 300);
            formCargarSection.Margin = new Padding((cardsContainer.Width - formCargarSection.Width) / 2, (cardsContainer.Height - formCargarSection.Height) / 2, 0, 0);
            formCargarSection.BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            cardsContainer.Controls.Add(formCargarSection);
            formCargarSection.Controls.Add(layourFormSection);
            formCargarSection.Controls.Add(buttonAcept);
        }

        private void LayoutFormProperties()
        {
            layourFormSection.BackColor = Color.Transparent;
            layourFormSection.FlowDirection = FlowDirection.TopDown;
            layourFormSection.AutoSize = true;
            layourFormSection.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Centramos después de la carga
            formCargarSection.Resize += (s, e) => CenterLayoutFormSection();

            // Llamar al método después de agregar los elementos
            AddElementsOfLayoutFrom();
            CenterLayoutFormSection(); // Para posicionar correctamente al inicio
        }

        private void CenterLayoutFormSection()
        {
            if (layourFormSection.Parent != null)
            {
                layourFormSection.Location = new Point(
                    (formCargarSection.Width - layourFormSection.Width) / 2, 60
                );
            }
        }
        private void ComboBoxProperties()
        {
            select.Size = new Size(120, 30);
            select.Items.Add("Cliente");
            select.Items.Add("Flete");
            select.Items.Add("Camión");

            select.SelectedIndex = 0;
        }

        private void AddElementsOfLayoutFrom()
        {
            List<string> campos = new List<string>();
            campos.Add("Seleccionar");
            campos.Add("Nombre");
            foreach (string i in campos)
            {
                Label labelForm = LabelProperties(i);

                layourFormSection.Controls.Add(labelForm);
                AddTheRestComponents(i);
            }
        }

        private Label LabelProperties(string nombreCampo)
        {
            Label ll = new Label();

            ll.Text = nombreCampo;
            ll.Font = new Font("Nunito", 10, FontStyle.Regular);
            ll.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            ll.BackColor = Color.Transparent;
            ll.AutoSize = true;

            return ll;
        }

        private void AddTheRestComponents(string nombreCampo)
        {
            if (nombreCampo == "Seleccionar")
            {
                layourFormSection.Controls.Add(select);
            }
            else
            {
                layourFormSection.Controls.Add(textBoxNombre);
            }
        }

        private void TextBoxProperties()
        {
            textBoxNombre.Font = new Font("Nunito", 10, FontStyle.Regular);
            textBoxNombre.BackColor = Color.White;
            //textBoxNombre.Text = textBox.ToString();
            textBoxNombre.Multiline = true;
            textBoxNombre.Width = 120;
            textBoxNombre.Height = 20;
            textBoxNombre.BorderStyle = BorderStyle.None;
            textBoxNombre.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);
        }

        private void ButtonAceptProperties()
        {
            buttonAcept.BackColor = System.Drawing.Color.FromArgb(218, 218, 28);
            buttonAcept.AutoSize = true;
            buttonAcept.Height = 30;
            buttonAcept.Text = "Cargar";
            buttonAcept.FlatStyle = FlatStyle.Flat;
            buttonAcept.FlatAppearance.BorderSize = 0;
            buttonAcept.Margin = new Padding(132, 10, 0, 0);
            buttonAcept.ForeColor = System.Drawing.Color.FromArgb(32, 32, 32);
            buttonAcept.Font = new Font("Nunito", 12, FontStyle.Bold);

            CenterButtonFormSection(); // Para posicionar correctamente al inicio
        }

        private void CenterButtonFormSection()
        {
            if (buttonAcept.Parent != null)
            {
                buttonAcept.Location = new Point(
                    (formCargarSection.Width - buttonAcept.Width) / 2, 210
                );
            }
        }
    }
}
