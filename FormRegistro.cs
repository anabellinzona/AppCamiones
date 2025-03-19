using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AppCamiones
{
    internal class FormRegistro : Home
    {
        //
        private string tipoRegistro;
        private ArrayList array = new ArrayList();

        private List<TextBox> textBoxList = new List<TextBox>();

        private NewRoundPanel form = new NewRoundPanel();

        private FlowLayoutPanel flowLayoutForm = new FlowLayoutPanel();

        private TextBox textBoxCampo1 = new TextBox();
        private TextBox textBoxCampo2 = new TextBox();
        private TextBox textBoxCampo3 = new TextBox();
        private TextBox textBoxCampo4 = new TextBox();
        private TextBox textBoxCampo5 = new TextBox();

        private string campo1;
        private string campo2;
        private string campo3;
        private string campo4;
        private string campo5;
        private string campo6;
        private string campo7;
        private string campo8;
        private string campo9;
        private string campo10;

        private ArrayList botonesRegistro = new ArrayList();
        private ArrayList nombreBotonesRegistro = new ArrayList();

        private TextBox tt = new TextBox();

        private RoundButton btn_cargar = new RoundButton();

        private NewRoundPanel optionsMenu = new NewRoundPanel();
        private FlowLayoutPanel layoutOptionsMenu = new FlowLayoutPanel();

        private Button btnCamion = new Button();
        private Button btnChofer = new Button();
        private Button btnCliente = new Button();
        private Button btnCheque = new Button();
        private Button btnViaje = new Button();

        public FormRegistro(string tipoRegistro)
        {
            InitializeUI();
            this.WindowState = FormWindowState.Maximized;

            this.tipoRegistro = tipoRegistro;
            ResaltarBoton(registrosMenu);
            CargaFormulario(tipoRegistro);


            Dictionary<Button, string> buttons = new Dictionary<Button, string>
            {
                { btnViaje, "Viaje" },
                { btnChofer, "Chofer" },
                { btnCliente, "Cliente" },
                { btnCheque, "Cheque" },
                { btnCamion, "Camion" }
            };

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
        public void InitializeUI()
        {
            InitializarMenuTipoRegistro();
        }
        private void InitializarMenuTipoRegistro()
        {
            OptionsMenuProperties();
            LayoutOptionsMenuProperties();
            ButtonsProperties();
            AddLayoutOptionsMenu();
            AddPanelToForm();
        }
        //private void Eventos()
        //{
        //    foreach (TextBox txt in textBoxList)
        //    {
        //        switch (txt.Text)
        //        {
        //            case "Name":
        //                textBoxCampo1 = txt;
        //                break;
        //            case "Surname":
        //                textBoxCampo1 = txt;
        //                break;
        //            case "Username":
        //                textBoxCampo1 = txt;
        //                break;
        //            case "Password":
        //                textBoxCampo1 = txt;
        //                this.StartPosition = FormStartPosition.CenterScreen;
        //                break;
        //            case "Email":
        //                textBoxCampo1 = txt;
        //                break;
        //        }
        //    }
        //}








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
                case "Chofer":
                    CargarFormularioChofer(5);
                    break;
                case "Camion":
                    CargarFormularioCamion(3);
                    break;
                case "Cheque":
                    CargarFormularioCheque(9);
                    break;
                case "Viaje":
                    CargarFormularioViaje(9);
                    break;
                case "Cliente":
                    CargarFormularioCliente(9);
                    break;
            }
        }
        private void CargarFormularioChofer(int cant)
        {
            campo1 = "Nombre";
            campo2 = "Apellido";
            campo3 = "Teléfono";
            campo4 = "Email";
            campo5 = "DNI";

            array.Clear();
            array.Add(campo1);
            array.Add(campo2);
            array.Add(campo3);
            array.Add(campo4);
            array.Add(campo5);

            PropertiesFormRegisterInformation(cant);
        }
        private void CargarFormularioCamion(int cant)
        {
            campo1 = "Patente";
            campo2 = "Modelo";
            campo3 = "Chofer";

            array.Clear();
            array.Add(campo1);
            array.Add(campo2);
            array.Add(campo3);

            PropertiesFormRegisterInformation(cant); ;
        }
        private void CargarFormularioCheque(int cant)
        {
            campo1 = "Fecha de recibimiento";
            campo2 = "Banco";
            campo3 = "Nro de cheque";
            campo4 = "Fecha de cobro";
            campo5 = "Pesos";
            campo6 = "Nombre";
            campo7 = "Mi cheque N°";
            campo8 = "Entregado a";
            campo9 = "...";

            array.Clear();
            array.Add(campo1);
            array.Add(campo2);
            array.Add(campo3);
            array.Add(campo4);
            array.Add(campo5);
            array.Add(campo6);
            array.Add(campo7);
            array.Add(campo8);
            array.Add(campo9);

            PropertiesFormRegisterInformation(cant);
        }
        private void CargarFormularioCliente(int cant)
        {
            campo1 = "Fecha";
            campo2 = "Desde";
            campo3 = "Hasta";
            campo4 = "Kilos";
            campo5 = "Remito";
            campo6 = "Tarifa";
            campo7 = "Pesos";
            campo8 = "Carga";
            campo9 = "Factura";
            campo10 = "Chofer";

            array.Clear();
            array.Add(campo1);
            array.Add(campo2);
            array.Add(campo3);
            array.Add(campo4);
            array.Add(campo5);
            array.Add(campo6);
            array.Add(campo7);
            array.Add(campo8);
            array.Add(campo9);
            array.Add(campo10);

            PropertiesFormRegisterInformation(cant);
        }
        private void CargarFormularioViaje(int cant)
        {
            campo1 = "Fecha";
            campo2 = "Desde";
            campo3 = "RTO o CPE";
            campo4 = "Carga";
            campo5 = "KM";
            campo6 = "KG";
            campo7 = "Tarifa";
            campo8 = "Total";
            campo9 = "Cliente";

            array.Clear();
            array.Add(campo1);
            array.Add(campo2);
            array.Add(campo3);
            array.Add(campo4);
            array.Add(campo5);
            array.Add(campo6);
            array.Add(campo7);
            array.Add(campo8);
            array.Add(campo9);

            PropertiesFormRegisterInformation(cant);
        }







        //Adds
        private void AddLabels()
        {
            form.Controls.Add(flowLayoutForm);
            flowLayoutForm.Controls.Add(btn_cargar);
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









        //FormProperties
        private void PropertiesFormRegisterInformation(int cant)
        {
            FormProperties(cant);
            LayoutFormProperties();
            TextoBoxAndLabelProperties(cant);
            ButtonsPropertiesForm();
            AddLabels();
            AddForm();
        }
        private void FormProperties(int cant)
        {
            form.Width = 400;
            form.Height = cant * 115;
            this.Resize += (s, e) =>
            {
                form.Location = new Point((this.Width - form.Width) / 2, 200);
            };

            form.BackColor = System.Drawing.Color.FromArgb(130, Color.Black);

            if (form.Height > 1000)
            {
                form.AutoScroll = true;
            }
        }
        private void LayoutFormProperties()
        {
            flowLayoutForm.Size = new Size(form.Width, form.Height + 200);
            flowLayoutForm.Location = new Point(0, 40);
            flowLayoutForm.BackColor = Color.Transparent;
            flowLayoutForm.FlowDirection = FlowDirection.TopDown;
        }
        private void TextoBoxAndLabelProperties(int cant)
        {

            for (int i = 0; i < array.Count; i++)
            {
                Label campo = createLabelAndProperties(array[i]);
                TextBox textBoxForm = createTextBoxAndProperties(array[i]);

                flowLayoutForm.Controls.Add(campo);
                flowLayoutForm.Controls.Add(textBoxForm);
            }
        }
        private Label createLabelAndProperties(object campo)
        {
            Label label = new Label();
            label.Text = campo.ToString();
            label.Font = new Font("Nunito", 10, FontStyle.Regular);
            label.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            label.BackColor = Color.Transparent;
            label.Margin = new Padding(80, 10, 0, 0);
            label.AutoSize = true;

            return label;
        }
        private TextBox createTextBoxAndProperties(object campo)
        {
            TextBox textBoxCampo = new TextBox();
            //textBoxCampo.Text = campo.ToString();
            textBoxCampo.Font = new Font("Nunito", 10, FontStyle.Regular);
            textBoxCampo.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
            textBoxCampo.Multiline = true;
            textBoxCampo.Width = 200;
            textBoxCampo.Height = 30;
            textBoxCampo.BorderStyle = BorderStyle.None;
            textBoxCampo.Margin = new Padding(90, 10, 0, 10);
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

            botonesRegistro.Add(btnChofer);
            botonesRegistro.Add(btnViaje);
            botonesRegistro.Add(btnCamion);
            botonesRegistro.Add(btnCliente);
            botonesRegistro.Add(btnCheque);

            nombreBotonesRegistro.Add("Chofer");
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
    }
}