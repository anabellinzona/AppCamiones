using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AppCamiones
{
    internal class FormRegistro : Home
    {
        //Form
        private string tipoRegistro;

        private ArrayList array = new ArrayList();

        private List<string> campos = new List<string>();

        private NewRoundPanel form = new NewRoundPanel();
        private FlowLayoutPanel flowLayoutForm = new FlowLayoutPanel();


        private ArrayList botonesRegistro = new ArrayList();
        private ArrayList nombreBotonesRegistro = new ArrayList();


        private RoundButton btn_cargar = new RoundButton();

        private NewRoundPanel optionsMenu = new NewRoundPanel();
        private FlowLayoutPanel layoutOptionsMenu = new FlowLayoutPanel();

        private Button btnCamion = new Button();
        private Button btnFlete = new Button();
        private Button btnCliente = new Button();
        private Button btnCheque = new Button();
        private Button btnViaje = new Button();


        //Constructor
        public FormRegistro(string tipoRegistro)
        {

            this.WindowState = FormWindowState.Maximized;

            if (tipoRegistro != "newSection")
            {
                InitializarMenuTipoRegistro();
            }

            this.tipoRegistro = tipoRegistro;
            ResaltarBoton(registrosMenu);
            CargaFormulario(tipoRegistro);

            //ButtonsArray
            Dictionary<Button, string> buttons = new Dictionary<Button, string>
            {
                { btnViaje, "viaje" },
                { btnFlete, "flete" },
                { btnCliente, "cliente" },
                { btnCheque, "cheque" },
                { btnCamion, "camion" }
            };

            //ButtonsEvents
            foreach (var button in buttons)
            {
                //Hovers
                button.Key.MouseEnter += (s, e) => HoverEffect(s, e, true);
                button.Key.MouseLeave += (s, e) => HoverEffect(s, e, false);

                //RegisterFormRedirections
                button.Key.Click += (s, e) => AbrirFormulario(button.Value);
            }

        }


        //Initializations
        private void InitializarMenuTipoRegistro()
        {
            OptionsMenuProperties();
            LayoutOptionsMenuProperties();
            ButtonsProperties();
            AddLayoutOptionsMenu();
            AddPanelToForm();
        }


        //RedirectionalFunctions
        private void GoToCheque_Click(object sender, EventArgs e)
        {
            Cheque tablaCheque = new Cheque();
            tablaCheque.ShowDialog();
            this.Close();
        }
        private void GoToFormUser_Click(object sender, EventArgs e)
        {
            Login formUser = new Login();
            formUser.ShowDialog();
            this.Close();
        }




        //FormRedirection
        private void AbrirFormulario(string tipoRegistro)
        {
            FormRegistro formularioRegistro = new FormRegistro(tipoRegistro)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            formularioRegistro.ShowDialog();
        }




        //HoverFunction
        private void HoverEffect(object sender, EventArgs e, bool isHover)
        {
            var button = sender as Button;
            if (button != null)
            {
                button.Font = new Font("Nunito", isHover ? 20 : 16, FontStyle.Regular);
                button.ForeColor = isHover ? Color.FromArgb(218, 218, 28) : Color.FromArgb(224, 224, 224);
            }
        }




        //OtherFunctions
        private void CargaFormulario(string tipoRegistro)
        {
            switch (tipoRegistro)
            {
                case "flete":
                    CargarFormularioFlete(5);
                    break;
                case "camion":
                    CargarFormularioCamion(3);
                    break;
                case "cheque":
                    CargarFormularioCheque(9);
                    break;
                case "viaje":
                    CargarFormularioViaje(11);
                    break;
                case "cliente":
                    CargarFormularioCliente(9);
                    break;
                case "newSection":
                    CargarFormularioNewSection(2);
                    break;
            }
        }

        private void CargarFormularioNewSection(int cant)
        {
            this.campos.Clear();
            this.campos = new List<string> { "Tipo", "Nombre" };

            btn_cargar.Click += (s, e) =>
            {
                foreach (string ss in this.campos)
                {
                    TextBox result = createTextBoxAndProperties(ss);
                    System.Windows.Forms.Label resultLabel = createLabelAndProperties(ss);
                    if (resultLabel.Text == "Tipo")
                    {
                        Viaje vv = new Viaje();
                        vv.CardGenerator("Camión", "FMM 650");
                        vv.Show();
                    }
                }
            };

            this.optionsMenu = null;
            PropertiesFormRegisterInformation(cant, campos);
        }



        private void CargarFormularioFlete(int cant)
        {
            this.campos.Clear();
            this.campos = new List<string> { "Nombre", "Teléfono", "Email" };

            PropertiesFormRegisterInformation(cant, campos);

        }
        private void CargarFormularioCamion(int cant)
        {
            this.campos.Clear();
            this.campos = new List<string> { "Patente", "Modelo", "Chofer" };

            PropertiesFormRegisterInformation(cant, campos); ;
        }
        private void CargarFormularioCheque(int cant)
        {
            this.campos.Clear();
            this.campos = new List<string> { "Fecha de recibimiento", "Banco", "Nro de cheque", "Pesos", "Nombre", "Número personal de cheque", "Entregado a", "Fecha de retiro" };

            PropertiesFormRegisterInformation(cant, campos);
        }
        private void CargarFormularioCliente(int cant)
        {

            this.campos.Clear();
            this.campos = new List<string> { "Fecha", "Desde", "Hasta", "Kilos", "Remito", "Tarifa", "Pesos", "Carga", "Factura", "Chofer" };

            PropertiesFormRegisterInformation(cant, campos);
        }
        private void CargarFormularioViaje(int cant)
        {
            this.campos.Clear();
            this.campos = new List<string> { "Fecha", "Desde", "Hasta", "Kilos", "Remito", "Tarifa", "Pesos", "Carga", "Factura", "Chofer", "Cliente" };

            NewRoundPanel optionsMenu = new NewRoundPanel();
            PropertiesFormRegisterInformation(cant, campos);
        }


        //FormProperties
        private void PropertiesFormRegisterInformation(int cant, List<string> campos)
        {
            FormProperties(cant);
            LayoutFormProperties(cant);
            TextoBoxAndLabelProperties(cant, campos);
            ButtonsPropertiesForm();
            AddLabels();
            AddForm();
        }
        private void FormProperties(int cant)
        {
            if (cant >= 5)
            {
                form.Width = 1500;
                form.Height = 120;
            }
            else
            {
                form.AutoSize = true;
            }

             this.Resize += (s, e) =>
             {
                    form.Location = new Point((this.Width - form.Width) / 2, 200);
             };

             form.BackColor = System.Drawing.Color.FromArgb(130, Color.Black);
        }
        private void LayoutFormProperties(int cant)
        {
            flowLayoutForm.AutoSize = true;
            flowLayoutForm.Location = new Point(0, 40);
            flowLayoutForm.BackColor = Color.Transparent;
            flowLayoutForm.FlowDirection = FlowDirection.LeftToRight; // Asegura que los elementos se alineen horizontalmente.

            // Configura el scroll horizontal
            flowLayoutForm.AutoScroll = true;
            flowLayoutForm.HorizontalScroll.Enabled = true; // Habilitar el desplazamiento horizontal.
            flowLayoutForm.HorizontalScroll.Visible = true;  // Asegura que el scroll sea visible.
            flowLayoutForm.HorizontalScroll.Maximum = 1000;  // Establece un valor máximo para el scroll horizontal (puedes ajustarlo según lo necesites).
            flowLayoutForm.HorizontalScroll.SmallChange = 5;  // Define el tamaño del cambio al hacer scroll.

            if (cant > 1)
            {
                form.AutoScroll = true;
            }
        }

        private void TextoBoxAndLabelProperties(int cant, List<string> campos)
        {
            foreach (string campo in campos)
            {
                // Crear contenedor para cada par de Label y TextBox
                Panel campoPanel = new Panel();
                campoPanel.AutoSize = true;
                campoPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink; // Asegura que el panel ajuste su tamaño a los controles internos

                // Crear Label y TextBox
                System.Windows.Forms.Label cc = createLabelAndProperties(campo);
                TextBox textBoxForm = createTextBoxAndProperties(campo);

                // Configurar los controles
                campoPanel.Controls.Add(cc);   // Agregar el Label al contenedor
                campoPanel.Controls.Add(textBoxForm);  // Agregar el TextBox al contenedor

                // Agregar el panel contenedor al FlowLayoutPanel
                flowLayoutForm.Controls.Add(campoPanel);
            }
        }
        private System.Windows.Forms.Label createLabelAndProperties(object campo)
        {
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            //label.Text = campo.ToString();
            label.Font = new Font("Nunito", 10, FontStyle.Regular);
            label.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            label.BackColor = Color.Transparent;
            label.Margin = new Padding(0, 0, 0, 5);  // Margen inferior para espacio entre label y textbox
            label.AutoSize = true;

            return label;
        }
        private TextBox createTextBoxAndProperties(object campo)
        {
            TextBox textBoxCampo = new TextBox();
            textBoxCampo.Text = campo.ToString();
            textBoxCampo.Font = new Font("Nunito", 10, FontStyle.Regular);
            textBoxCampo.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
            textBoxCampo.Multiline = true;
            textBoxCampo.Width = 200;
            textBoxCampo.Height = 30;
            textBoxCampo.BorderStyle = BorderStyle.None;
            textBoxCampo.Margin = new Padding(0, 0, 0, 20);  // Margen inferior para separación entre campos
            textBoxCampo.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);
            textBoxCampo.TextAlign = HorizontalAlignment.Left;

            return textBoxCampo;
        }
        private void ButtonsPropertiesForm()
        {
            btn_cargar.BackColor = System.Drawing.Color.FromArgb(218, 218, 28);
            btn_cargar.Size = new Size(140, 30);
            btn_cargar.Text = "Cargar";
            btn_cargar.FlatStyle = FlatStyle.Flat;
            btn_cargar.FlatAppearance.BorderSize = 0;
            btn_cargar.Margin = new Padding(130, 10, 0, 0);
            btn_cargar.ForeColor = System.Drawing.Color.FromArgb(32, 32, 32);
            btn_cargar.Font = new Font("Nunito", 12, FontStyle.Bold);
            //btn_cargar.Location = new Point((flowLayoutForm.Width - btn_cargar.Width) / 2, (flowLayoutForm.Height - btn_cargar.Height) / 2);
        }

        //Options menu
        private void OptionsMenuProperties()
        {
            optionsMenu.Size = new Size(800, 60);
            this.Resize += (s, e) =>
            {
                optionsMenu.Location = new Point((this.Width - optionsMenu.Width) / 2, 100);
            };
            optionsMenu.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            optionsMenu.BorderStyle = BorderStyle.FixedSingle;
        }



        private void LayoutOptionsMenuProperties()
        {
            layoutOptionsMenu.AutoSize = true;
            layoutOptionsMenu.Width = btnCheque.Width;
            layoutOptionsMenu.BackColor = Color.Transparent;
            layoutOptionsMenu.FlowDirection = FlowDirection.LeftToRight;
            optionsMenu.Resize += (s, e) =>
            {
                layoutOptionsMenu.Location = new Point((optionsMenu.Width - layoutOptionsMenu.Width) / 2, (optionsMenu.Height - layoutOptionsMenu.Height) / 2);
            };
        }
        private void ButtonsProperties()
        {
            int j = 0;

            botonesRegistro.Add(btnFlete);
            botonesRegistro.Add(btnViaje);
            botonesRegistro.Add(btnCamion);
            botonesRegistro.Add(btnCliente);
            botonesRegistro.Add(btnCheque);

            nombreBotonesRegistro.Add("Flete");
            nombreBotonesRegistro.Add("Viaje");
            nombreBotonesRegistro.Add("Camión");
            nombreBotonesRegistro.Add("Cliente");
            nombreBotonesRegistro.Add("Cheque");
            for (int i = 0; i < botonesRegistro.Count; i++)
            {
                Button btn = (Button)botonesRegistro[i];

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

                if (j < nombreBotonesRegistro.Count)
                {
                    btn.Text = nombreBotonesRegistro[j].ToString().ToUpper();
                    j++;
                }

                layoutOptionsMenu.Controls.Add(btn);
            }
        }


        //Adds
        private void AddLabels()
        {
            form.Controls.Add(flowLayoutForm);
            //flowLayoutForm.Controls.Add(btn_cargar);
        }
        private void AddForm()
        {
            this.Controls.Add(form);
        }
        private void AddPanelToForm()
        {
            this.Controls.Add(optionsMenu);
        }
        private void AddLayoutOptionsMenu()
        {
            optionsMenu.Controls.Add(layoutOptionsMenu);
        }


    }
}