using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AppCamiones
{
    internal class FormRegistro : Form
    {
        private string tipoRegistro;

        //CREACIÓN DE LA BARRA DE HERRAMIENTAS Y CADA ÍTEM
        private MenuStrip menuStrip = new MenuStrip();

        private ToolStripMenuItem homeMenu = new ToolStripMenuItem("home");
        private ToolStripMenuItem viajesMenu = new ToolStripMenuItem("viajes");
        private ToolStripMenuItem chequesMenu = new ToolStripMenuItem("cheques");
        private ToolStripMenuItem registrosMenu = new ToolStripMenuItem("registro");
        private ToolStripMenuItem userMenu = new ToolStripMenuItem();
        private ToolStripMenuItem closeSesion = new ToolStripMenuItem("Cerrar sesión");

        private RoundPanel form = new RoundPanel();

        private FlowLayoutPanel flowLayoutForm = new FlowLayoutPanel();

        private Label campo1 = new Label();
        private Label campo2 = new Label();
        private Label campo3 = new Label();
        private Label campo4 = new Label();
        private Label campo5 = new Label();
        private Label campo6 = new Label();


        //private TextBox textBoxCampo1 = new TextBox();
        private TextBox textBoxCampo2 = new TextBox();
        private TextBox textBoxCampo3 = new TextBox();
        private TextBox textBoxCampo4 = new TextBox();
        private TextBox textBoxCampo5 = new TextBox();
        private TextBox textBoxCampo6 = new TextBox();

        private RoundButton btn_cargar = new RoundButton();

        private RoundPanel optionsMenu = new RoundPanel();
        private FlowLayoutPanel layoutOptionsMenu = new FlowLayoutPanel();

        private Button btnCamion = new Button();
        private Button btnChofer = new Button();
        private Button btnCliente = new Button();
        private Button btnCheque = new Button();
        private Button btnViaje = new Button();

        public FormRegistro(string tipoRegistro)
        {
            this.tipoRegistro = tipoRegistro;
            InitializeUI();
            CargaFormulario();
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

            btnViaje.Click += new EventHandler(GoToFormViaje);
            btnChofer.Click += new EventHandler(GoToFormChofer);
            btnCliente.Click += new EventHandler(GoToFormCliente);
            btnCheque.Click += new EventHandler(GoToFormCheque);
            btnCamion.Click += new EventHandler(GoToFormCamion);
        }

        private void GoToFormViaje(object sender, EventArgs e)
        {
            AbrirFormulario("Viaje");
        }

        private void GoToFormChofer(object sender, EventArgs e)
        {
            AbrirFormulario("Chofer");
        }

        private void GoToFormCliente(object sender, EventArgs e)
        {
            AbrirFormulario("Cliente");
        }

        private void GoToFormCheque(object sender, EventArgs e)
        {
            AbrirFormulario("Cheque");
        }

        private void GoToFormCamion(object sender, EventArgs e)
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
            AddButtonsToPanel();
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


        private void CargaFormulario()
        {
            //panelContenido.Controls.Clear(); // Limpia el contenido anterior

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
            campo1.Text = "Nombre";
            campo2.Text = "Apellido";
            campo3.Text = "Teléfono";
            campo4.Text = "Email";
            campo5.Text = "DNI";
            FormProperties(cant);
            LayoutFormProperties();
            LabelProperties(cant);
            ButtonsPropertiesForm();
            AddLabels();
            AddForm();
            btnChofer.Font = new Font("Nunito", 16, FontStyle.Underline);
        }

        private void CargarFormularioCamion(int cant)
        {
            campo1.Text = "Patente";
            campo2.Text = "Modelo";
            campo3.Text = "Chofer";
            FormProperties(cant);
            LayoutFormProperties();
            LabelProperties(cant);
            ButtonsPropertiesForm();
            AddLabels();
            AddForm();
            btnCamion.Font = new Font("Nunito", 16, FontStyle.Underline);
        }

        private void CargarFormularioCheque(int cant)
        {
            campo1.Text = "Patente";
            campo2.Text = "Modelo";
            campo3.Text = "Chofer";
            FormProperties(cant);
            LayoutFormProperties();
            LabelProperties(cant);
            ButtonsPropertiesForm();
            AddLabels();
            AddForm();
            btnCheque.Font = new Font("Nunito", 16, FontStyle.Underline);
        }

        private void CargarFormularioCliente(int cant)
        {
            campo1.Text = "Patente";
            campo2.Text = "Modelo";
            campo3.Text = "Chofer";
            FormProperties(cant);
            LayoutFormProperties();
            LabelProperties(cant);
            ButtonsPropertiesForm();
            AddLabels();
            AddForm();
            btnCliente.Font = new Font("Nunito", 16, FontStyle.Underline);
        }

        private void CargarFormularioViaje(int cant)
        {
            campo1.Text = "Patente";
            campo2.Text = "Modelo";
            campo3.Text = "Chofer";
            FormProperties(cant);
            LayoutFormProperties();
            LabelProperties(cant);
            ButtonsPropertiesForm();
            AddLabels();
            AddForm();
            btnViaje.Font = new Font("Nunito", 16, FontStyle.Underline);
        }

     
        private void FormProperties(int cant)
        {
            form.Width = 400;
            form.Height = cant * 120;
            this.Resize += (s, e) =>
            {
                form.Location = new Point((this.Width - form.Width) / 2, 170);
            };

            form.BackColor = System.Drawing.Color.FromArgb(130, Color.Black);
            if(form.Height > 1000)
            {
                form.AutoScroll = true;
            }
        }

        private void LayoutFormProperties()
        {
            flowLayoutForm.Size = new Size(form.Width, form.Height);
            flowLayoutForm.Location = new Point(0, 50);
            flowLayoutForm.BackColor = Color.Transparent;
            //form.AutoScroll = true;
        }

        private void LabelProperties(int cant)
        {
            for (int i = 0; i < cant; i++)
            {

                Label ll = new Label();
                ll.Text = campo1.Text;
                ll.Font = new Font("Nunito", 10, FontStyle.Regular);
                ll.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
                ll.BackColor = Color.Transparent;
                ll.Margin = new Padding(80, 10, 0, 0);
                ll.AutoSize = true;

                TextBox textBoxCampo1 = new TextBox();
                textBoxCampo1.Text = "Name";
                textBoxCampo1.Font = new Font("Nunito", 10, FontStyle.Regular);
                textBoxCampo1.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
                textBoxCampo1.Multiline = true;
                textBoxCampo1.Width = 200;
                textBoxCampo1.Height = 30;
                textBoxCampo1.BorderStyle = BorderStyle.None;
                textBoxCampo1.Margin = new Padding(90, 10, 0, 10);
                textBoxCampo1.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);
                textBoxCampo1.TextAlign = HorizontalAlignment.Left;

                flowLayoutForm.Controls.Add(ll);
                flowLayoutForm.Controls.Add(textBoxCampo1);

            }
        }

        private void ButtonsPropertiesForm()
        {
            btn_cargar.BackColor = System.Drawing.Color.FromArgb(218, 218, 28);
            btn_cargar.AutoSize = true;
            btn_cargar.Height = 30;
            btn_cargar.Text = "Registrarse";
            btn_cargar.FlatStyle = FlatStyle.Flat;
            btn_cargar.FlatAppearance.BorderSize = 0;
            btn_cargar.Margin = new Padding(132, 10, 0, 0);
            btn_cargar.ForeColor = System.Drawing.Color.FromArgb(32, 32, 32);
            btn_cargar.Font = new Font("Nunito", 12, FontStyle.Bold);

            //btn_login.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            //btn_login.Size = new Size(140, 30);
            //btn_login.Text = "Iniciar sesión";
            //btn_login.FlatStyle = FlatStyle.Flat;
            //btn_login.FlatAppearance.BorderSize = 0;  // Grosor del borde
            //btn_login.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(218, 218, 28); // Color del borde
            //btn_login.Margin = new Padding(120, 10, 0, 0);
            //btn_login.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            //btn_login.Font = new Font("Nunito", 12, FontStyle.Bold);
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
            btnChofer.Text = "chofer";
            btnChofer.Size = new Size(150, 50);
            btnChofer.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnChofer.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnChofer.FlatStyle = FlatStyle.Flat;
            btnChofer.BackColor = Color.Transparent;
            btnChofer.FlatAppearance.BorderSize = 0;
            btnChofer.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnChofer.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnChofer.Text = btnChofer.Text.ToUpper();
            btnChofer.Margin = new Padding(0, 20, 0, 0);
            btnChofer.TextAlign = ContentAlignment.MiddleCenter;


            btnCamion.Text = "camión";
            btnCamion.Size = new Size(150, 50);
            btnCamion.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnCamion.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnCamion.FlatStyle = FlatStyle.Flat;
            btnCamion.BackColor = Color.Transparent;
            btnCamion.FlatAppearance.BorderSize = 0;
            btnCamion.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnCamion.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnCamion.Text = btnCamion.Text.ToUpper();
            btnCamion.TextAlign = ContentAlignment.MiddleCenter;
            btnCamion.Margin = new Padding(0, 20, 0, 0);

            btnCliente.Text = "cliente";
            btnCliente.Size = new Size(150, 50);
            btnCliente.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnCliente.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnCliente.FlatStyle = FlatStyle.Flat;
            btnCliente.BackColor = Color.Transparent;
            btnCliente.FlatAppearance.BorderSize = 0;
            btnCliente.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnCliente.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnCliente.Text = btnCliente.Text.ToUpper();
            btnCliente.TextAlign = ContentAlignment.MiddleCenter;
            btnCliente.Margin = new Padding(0, 20, 0, 0);

            btnCheque.Text = "cheque";
            btnCheque.Size = new Size(150, 50);
            btnCheque.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnCheque.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnCheque.FlatStyle = FlatStyle.Flat;
            btnCheque.BackColor = Color.Transparent;
            btnCheque.FlatAppearance.BorderSize = 0;
            btnCheque.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnCheque.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnCheque.Text = btnCheque.Text.ToUpper();
            btnCheque.TextAlign = ContentAlignment.MiddleCenter;
            btnCheque.Margin = new Padding(0, 20, 0, 0);

            btnViaje.Text = "viaje";
            btnViaje.Size = new Size(150, 50);
            btnViaje.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnViaje.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnViaje.FlatStyle = FlatStyle.Flat;
            btnViaje.BackColor = Color.Transparent;
            btnViaje.FlatAppearance.BorderSize = 0;
            btnViaje.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnViaje.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnViaje.Text = btnViaje.Text.ToUpper();
            btnViaje.TextAlign = ContentAlignment.MiddleCenter;
            btnViaje.Margin = new Padding(0, 20, 0, 0);

        }

        private void AddPanelToForm()
        {
            this.Controls.Add(optionsMenu);
        }

        private void AddButtonsToPanel()
        {
            optionsMenu.Controls.Add(layoutOptionsMenu);
            layoutOptionsMenu.Controls.Add(btnChofer);
            layoutOptionsMenu.Controls.Add(btnViaje);
            layoutOptionsMenu.Controls.Add(btnCamion);
            layoutOptionsMenu.Controls.Add(btnCliente);
            layoutOptionsMenu.Controls.Add(btnCheque);
        }


    }
}