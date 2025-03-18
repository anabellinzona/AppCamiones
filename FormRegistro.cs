using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AppCamiones
{
    internal class FormRegistro : Form
    {
        private string tipoRegistro;
        private ArrayList array = new ArrayList();

        //CREACIÓN DE LA BARRA DE HERRAMIENTAS Y CADA ÍTEM
        private MenuStrip menuStrip = new MenuStrip();

        private ToolStripMenuItem homeMenu = new ToolStripMenuItem("home");
        private ToolStripMenuItem viajesMenu = new ToolStripMenuItem("viajes");
        private ToolStripMenuItem chequesMenu = new ToolStripMenuItem("cheques");
        private ToolStripMenuItem registrosMenu = new ToolStripMenuItem("registro");
        private ToolStripMenuItem userMenu = new ToolStripMenuItem();
        private ToolStripMenuItem closeSesion = new ToolStripMenuItem("Cerrar sesión");

        private NewRoundPanel form = new NewRoundPanel();

        private FlowLayoutPanel flowLayoutForm = new FlowLayoutPanel();

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
            this.tipoRegistro = tipoRegistro;

            //HACE QUE SE ABRA EN PANTALLA COMPLETA
            this.WindowState = FormWindowState.Maximized;
            InitializeUI();
            CargaFormulario(tipoRegistro);
            InitializarMenuTipoRegistro();

            btnViaje.MouseEnter += new EventHandler(hoverToBtnViaje_MouseEnter);
            btnViaje.MouseLeave += new EventHandler(hoverToBtnViaje_MouseLeave);

            btnChofer.MouseEnter += new EventHandler(hoverToBtnChofer_MouseEnter);
            btnChofer.MouseLeave += new EventHandler(hoverToBtnChofer_MouseLeave);

            btnCliente.MouseEnter += new EventHandler(hoverToBtnCliente_MouseEnter);
            btnCliente.MouseLeave += new EventHandler(hoverToBtnCliente_MouseLeave);

            btnCheque.MouseEnter += new EventHandler(hoverToBtnCheque_MouseEnter);
            btnCheque.MouseLeave += new EventHandler(hoverToBtnCheque_MouseLeave);

            btnCamion.MouseEnter += new EventHandler(hoverToBtnCamion_MouseEnter);
            btnCamion.MouseLeave += new EventHandler(hoverToBtnCamion_MouseLeave);

            //EVENTOS A LOS BOTONES
            btnViaje.Click += new EventHandler(GoToFormViaje_Click);
            btnChofer.Click += new EventHandler(GoToFormChofer_Click);
            btnCliente.Click += new EventHandler(GoToFormCliente_Click);
            btnCheque.Click += new EventHandler(GoToFormCheque_Click);
            btnCamion.Click += new EventHandler(GoToFormCamion_Click);

            //EVENTOS A LAS HERRAMIENTAS DE LA BARRA
            closeSesion.Click += new EventHandler(GoToFormUser_Click);
            chequesMenu.Click += new EventHandler(GoToCheque_Click);
            //viajesMenu.Click += new EventHandler(GoToViaje_Click);
            homeMenu.Click += new EventHandler(GoToHome_Click);
        }

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

        private void GoToHome_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.ShowDialog();
            this.Close();
        }

        private void GoToFormViaje_Click(object sender, EventArgs e)
        {
            AbrirFormulario("Viaje");
        }

        private void GoToFormChofer_Click(object sender, EventArgs e)
        {
            AbrirFormulario("Chofer");
        }

        private void GoToFormCliente_Click(object sender, EventArgs e)
        {
            AbrirFormulario("Cliente");
        }

        private void GoToFormCheque_Click(object sender, EventArgs e)
        {
            AbrirFormulario("Cheque");
        }

        private void GoToFormCamion_Click(object sender, EventArgs e)
        {
            AbrirFormulario("Camion");
        }

        private void AbrirFormulario(string tipoRegistro)
        {
            FormRegistro formularioRegistro = new FormRegistro(tipoRegistro);
            formularioRegistro.StartPosition = FormStartPosition.CenterScreen;
            formularioRegistro.ShowDialog();
        }

        private void hoverToBtnViaje_MouseEnter(object sender, EventArgs e)
        {
            btnViaje.Font = new Font("Nunito", 20, FontStyle.Regular);
            btnViaje.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
        }

        private void hoverToBtnViaje_MouseLeave(object sender, EventArgs e)
        {
            btnViaje.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnViaje.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }

        private void hoverToBtnChofer_MouseEnter(object sender, EventArgs e)
        {
            btnChofer.Font = new Font("Nunito", 20, FontStyle.Regular);
            btnChofer.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
        }

        private void hoverToBtnChofer_MouseLeave(object sender, EventArgs e)
        {
            btnChofer.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnChofer.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }

        private void hoverToBtnCliente_MouseEnter(object sender, EventArgs e)
        {
            btnCliente.Font = new Font("Nunito", 20, FontStyle.Regular);
            btnCliente.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
        }

        private void hoverToBtnCliente_MouseLeave(object sender, EventArgs e)
        {
            btnCliente.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnCliente.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }

        private void hoverToBtnCheque_MouseEnter(object sender, EventArgs e)
        {
            btnCheque.Font = new Font("Nunito", 20, FontStyle.Regular);
            btnCheque.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
        }

        private void hoverToBtnCheque_MouseLeave(object sender, EventArgs e)
        {
            btnCheque.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnCheque.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }

        private void hoverToBtnCamion_MouseEnter(object sender, EventArgs e)
        {
            btnCamion.Font = new Font("Nunito", 20, FontStyle.Regular);
            btnCamion.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
        }

        private void hoverToBtnCamion_MouseLeave(object sender, EventArgs e)
        {
            btnCamion.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnCamion.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }

        private void InitializeUI()
        {
            InitializeBackImage();
            InitializeIconoApp();
            InitializeIconoUser();
            InitializeToolBar();
        }
        private void InitializarMenuTipoRegistro()
        {
            OptionsMenuProperties();
            LayoutOptionsMenuProperties();
            ButtonsProperties();
            AddLayoutOptionsMenu();
            AddPanelToForm();
        }

        private void InitializeBackImage()
        {
            // Ruta absoluta a la imagen en la carpeta de Descargas
            string imagePath = Path.Combine(Application.StartupPath, "Resources", "goma.jpg");

            // Verifica si existe el archivo
            if (File.Exists(imagePath))
            {
                // Carga la imagen
                Image img = Image.FromFile(imagePath);

                // Verifica si la imagen tiene un valor de orientación en sus metadatos EXIF
                if (Array.Exists(img.PropertyIdList, id => id == 0x0112)) // 0x0112 es el ID de la propiedad "Orientation"
                {
                    // Lee el valor de la propiedad de orientación EXIF
                    int orientation = BitConverter.ToUInt16(img.GetPropertyItem(0x0112).Value, 0);

                    // Corrige la orientación de la imagen en base al valor EXIF
                    switch (orientation)
                    {
                        case 1:
                            // Sin rotación (normal)
                            break;
                        case 3:
                            img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case 6:
                            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case 8:
                            img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                }

                // Asigna la imagen corregida al fondo
                this.BackgroundImage = img;
            }
            else
            {
                // Muestra un mensaje de error si no se encuentra la imagen
                MessageBox.Show("La imagen no se encuentra: " + imagePath);
            }
        }

        private void InitializeIconoApp()
        {
            //ASIGNA ÍCONO AL FORMULARIO
            string iconoApp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "icono_camion.ico");

            //PREGUNTA SI EXISTE EL ARCHIVO
            if (File.Exists(iconoApp))
            {
                //LE ASIGNA EL ICONO A LA APLICACIÓN
                this.Icon = new Icon(iconoApp);
            }
            else
            {
                //TIRA EXCEPCIÓN
                MessageBox.Show("La imagen no se encuentra: " + iconoApp);
            }
        }

        private void InitializeIconoUser()
        {
            //ASIGNA ÍCONO A LA BARRA DE HERRAMIENTAS
            string icono_user = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "icono_user.png");


            //PREGUNTA SI EXISTE EL ARCHIVO
            if (File.Exists(icono_user))
            {
                //LE ASIGNA LA IMAGEN A USERMENU
                userMenu.Image = Image.FromFile(icono_user);
            }
            else
            {
                //TIRA EXCEPCIÓN
                MessageBox.Show("La imagen no se encuentra: " + icono_user);
            }
        }

        private void InitializeToolBar()
        {
            ItemsCapitalLetter();
            MenuProperties();
            ItemsColor();
            MarginToItems();
            AddItemsToMenu();
        }

        private void ItemsCapitalLetter()
        {
            //PONE EN MAYÚSUCLA LAS PALABRAS DE LOS ÍTEMS
            homeMenu.Text = homeMenu.Text.ToUpper();
            viajesMenu.Text = viajesMenu.Text.ToUpper();
            chequesMenu.Text = chequesMenu.Text.ToUpper();
            registrosMenu.Text = registrosMenu.Text.ToUpper();
            userMenu.Text = userMenu.Text.ToUpper();
        }

        private void MenuProperties()
        {
            //PROPIEDADES DEL MENÚ
            menuStrip.Font = new Font("Arial", 14, FontStyle.Regular);
            menuStrip.BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            menuStrip.ImageScalingSize = new Size(34, 34);
            menuStrip.AutoSize = false;
            menuStrip.Width = this.Width;
            menuStrip.Height = 80;
            menuStrip.Dock = DockStyle.Top;
            registrosMenu.Font = new Font("Arial", 16, FontStyle.Underline);
        }



        private void ItemsColor()
        {
            //ASIGNA EL COLOR A LOS ÍTEMS
            homeMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            viajesMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            chequesMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            registrosMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            userMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            closeSesion.ForeColor = System.Drawing.Color.FromArgb(141, 138, 138);
        }

        private void MarginToItems()
        {
            //MARGIN
            int x = this.Width;
            int y = x / 10;
            int t = (menuStrip.Width - userMenu.Width);

            homeMenu.Margin = new Padding(y, 0, 0, 0);
            viajesMenu.Margin = new Padding(y, 0, 0, 0);
            chequesMenu.Margin = new Padding(y, 0, 0, 0);
            registrosMenu.Margin = new Padding(y, 0, 0, 0);
            userMenu.Margin = new Padding(t, 0, 0, 0);
            closeSesion.Margin = new Padding(0, 10, 0, 0);
        }

        private void AddItemsToMenu()
        {
            //AGREGA AL MENÚ LOS ÍTEMS
            menuStrip.Items.Add(homeMenu);
            menuStrip.Items.Add(viajesMenu);
            menuStrip.Items.Add(chequesMenu);
            menuStrip.Items.Add(registrosMenu);
            menuStrip.Items.Add(userMenu);

            userMenu.DropDownItems.Add(closeSesion);

            // AGREGA AL FORM LA BARRA DE HERRAMIENTAS
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }


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
            textBoxCampo.Text = campo.ToString();
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
        private void AddLabels()
        {
            form.Controls.Add(flowLayoutForm);
            flowLayoutForm.Controls.Add(btn_cargar);
        }
        private void AddForm()
        {
            this.Controls.Add(form);
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
                    btn.Text = nombreBotonesRegistro[j].ToString();
                    btn.Text = nombreBotonesRegistro[j].ToString().ToUpper();
                    j++;
                }

                layoutOptionsMenu.Controls.Add(btn);
            }
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