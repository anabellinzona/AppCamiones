using System.Drawing;
using System.IO;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
using Button = System.Windows.Forms.Button;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Runtime.CompilerServices;


namespace AppCamiones
{
    internal class Class1 : Form
    {

        private Form1 form1 = new Form1();
        private Login login = new Login();

        //DECLARACIÓN DEL FORM
        private RoundPanel form = new RoundPanel();

        private FlowLayoutPanel flowLayoutForm = new FlowLayoutPanel();

        private Label nombre = new Label();
        private Label apellido = new Label();
        private Label nombre_usuario = new Label();
        private Label contraseña = new Label();
        private Label email = new Label();
        private Label pregunta = new Label();


        private RoundTextBox textBoxNombre = new RoundTextBox();
        private RoundTextBox textBoxApellido = new RoundTextBox();
        private RoundTextBox textBoxNombreUsuario = new RoundTextBox();
        private RoundTextBox textBoxContraseña = new RoundTextBox();
        private RoundTextBox textBoxEmail = new RoundTextBox();

        private RoundButton btn_login = new RoundButton();
        private RoundButton btn_registrer = new RoundButton();

        public Class1()
        {
            InitializeUI();
            btn_registrer.Click += new EventHandler(RegistrerUser_Click);
            btn_login.Click += new EventHandler(LoginUser_Click);

            textBoxNombreUsuario.Leave += new EventHandler(NombreUsuario_Leave);
            textBoxNombreUsuario.Click += new EventHandler(NombreUsuario_Click);

            textBoxNombre.Leave += new EventHandler(Nombre_Leave);
            textBoxNombre.Click += new EventHandler(Nombre_Click);

            textBoxApellido.Leave += new EventHandler(Apellido_Leave);
            textBoxApellido.Click += new EventHandler(Apellido_Click);

            textBoxContraseña.Leave += new EventHandler(Contraseña_Leave);
            textBoxContraseña.Click += new EventHandler(Contraseña_Click);

            textBoxEmail.Leave += new EventHandler(Email_Leave);
            textBoxEmail.Click += new EventHandler(Email_Click);
        }

        //NOMBRE DE USUARIO

        private void NombreUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNombreUsuario.Text))
            {
                textBoxNombreUsuario.Text = "Username";
                textBoxNombreUsuario.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77); // Cambia el color del texto placeholder
            }
        }

        private void NombreUsuario_Click(object sender, EventArgs e)
        {
            if (textBoxNombreUsuario.Text == "Username")
            {
                textBoxNombreUsuario.Text = "";
                textBoxNombreUsuario.ForeColor = Color.Black; // Cambia el color del texto
            }
        }

        //NOMBRE

        private void Nombre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                textBoxNombre.Text = "Name";
                textBoxNombre.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77); // Cambia el color del texto placeholder
            }
        }

        private void Nombre_Click(object sender, EventArgs e)
        {
            if (textBoxNombre.Text == "Name")
            {
                textBoxNombre.Text = "";
                textBoxNombre.ForeColor = Color.Black; // Cambia el color del texto
            }
        }

        //APELLIDO

        private void Apellido_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxApellido.Text))
            {
                textBoxApellido.Text = "Surname";
                textBoxApellido.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77); // Cambia el color del texto placeholder
            }
        }

        private void Apellido_Click(object sender, EventArgs e)
        {
            if (textBoxApellido.Text == "Surname")
            {
                textBoxApellido.Text = "";
                textBoxApellido.ForeColor = Color.Black; // Cambia el color del texto
            }
        }

        private void Email_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                textBoxEmail.Text = "Email";
                textBoxEmail.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77); // Cambia el color del texto placeholder
            }
        }

        private void Email_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "Email")
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.Black; // Cambia el color del texto
            }
        }

        //CONTRASEÑA

        private void Contraseña_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxContraseña.Text))
            {
                textBoxContraseña.Text = "PassWord";
                textBoxContraseña.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);
            }
        }

        private void Contraseña_Click(object sender, EventArgs e)
        {
            if (textBoxContraseña.Text == "Password")
            {
                textBoxContraseña.Text = "";
                textBoxContraseña.Font = new Font("Nunito", 14, FontStyle.Regular);
                textBoxContraseña.ForeColor = Color.Black;
                textBoxContraseña.PasswordChar = '*';
            }
        }
        //------------------------------------
        private void RegistrerUser_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void LoginUser_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        //-------------------------------------
        private void InitializeUI()
        {
            InitializeBackImage();
            InitializeIconoApp();
            InitializeForm();
        }

        private void InitializeBackImage()
        {
            // Ruta absoluta a la imagen en la carpeta de Descargas

            string imagePath = Path.Combine(Application.StartupPath, "Resources", "goma.jpg");
            //string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "goma.jpg");
//>>>>>>> 332652517b22fa6a155ae508d410fb4cb681add1

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

        //FORMULARIO DE REGISTRARSE
        private void InitializeForm()
        {
            FormProperties();
            LayoutFormProperties();
            LabelProperties();
            TextBoxProperties();
            ButtonsProperties();
            AddLabels();
            AddForm();
        }

        private void FormProperties()
        {
            form.Size = new Size(400, 600);
            this.Resize += (s, e) =>
            {
                form.Location = new Point((this.Width - form.Width) / 2, (this.Height - form.Height) / 2);
            };

            form.BackColor = System.Drawing.Color.FromArgb(130, Color.Black);
        }

        private void LayoutFormProperties()
        {
            flowLayoutForm.Size = new Size(form.Width, form.Height);
            flowLayoutForm.Location = new Point(0, 50);
            flowLayoutForm.BackColor = Color.Transparent;
        }

        private void LabelProperties()
        {
            nombre.Text = "Nombre:";
            nombre.Font = new Font("Nunito", 10, FontStyle.Regular);
            nombre.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            nombre.BackColor = Color.Transparent;
            nombre.Margin = new Padding(80, 10, 0, 0);
            nombre.AutoSize = true;

            apellido.Text = "Apellido:";
            apellido.Font = new Font("Nunito", 10, FontStyle.Regular);
            apellido.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            apellido.BackColor = Color.Transparent;
            apellido.Margin = new Padding(80, 10, 0, 0);
            apellido.AutoSize = true;

            email.Text = "Email:";
            email.Font = new Font("Nunito", 10, FontStyle.Regular);
            email.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            email.BackColor = Color.Transparent;
            email.Margin = new Padding(80, 10, 0, 0);
            email.AutoSize = true;

            contraseña.Text = "Contraseña:";
            contraseña.Font = new Font("Nunito", 10, FontStyle.Regular);
            contraseña.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            contraseña.BackColor = Color.Transparent;
            contraseña.Margin = new Padding(80, 10, 0, 0);
            contraseña.AutoSize = true;

            nombre_usuario.Text = "Nombre de usuario:";
            nombre_usuario.Font = new Font("Nunito", 10, FontStyle.Regular);
            nombre_usuario.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            nombre_usuario.BackColor = Color.Transparent;
            nombre_usuario.Margin = new Padding(80, 10, 0, 0);
            nombre_usuario.AutoSize = true;

            pregunta.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            pregunta.Text = "¿Ya tienes una cuenta?";
            pregunta.Font = new Font("Nunito", 10, FontStyle.Regular);
            pregunta.AutoSize = true;
            pregunta.TextAlign = ContentAlignment.TopCenter;
            pregunta.Margin = new Padding(113, 30, 0, 0); ;
        }

        private void TextBoxProperties()
        {
            textBoxNombre.Text = "Name";
            textBoxNombre.Font = new Font("Nunito", 10, FontStyle.Regular);
            textBoxNombre.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
            textBoxNombre.Multiline = true;
            textBoxNombre.Width = 200;
            textBoxNombre.Height = 30;
            textBoxNombre.BorderStyle = BorderStyle.None;
            textBoxNombre.Margin = new Padding(90, 10, 0, 10);
            textBoxNombre.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);
            textBoxNombre.TextAlign = HorizontalAlignment.Left;


            textBoxApellido.Text = "Surname";
            textBoxApellido.Font = new Font("Nunito", 10, FontStyle.Regular);
            textBoxApellido.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
            textBoxApellido.Multiline = true;
            textBoxApellido.Width = 200;
            textBoxApellido.Height = 30;
            textBoxApellido.BorderStyle = BorderStyle.None;
            textBoxApellido.Margin = new Padding(90, 10, 0, 10);
            textBoxApellido.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);


            textBoxEmail.Text = "Email";
            textBoxEmail.Font = new Font("Nunito", 10, FontStyle.Regular);
            textBoxEmail.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
            textBoxEmail.Multiline = true;
            textBoxEmail.Width = 200;
            textBoxEmail.Height = 30;
            textBoxEmail.BorderStyle = BorderStyle.None;
            textBoxEmail.Margin = new Padding(90, 10, 0, 10);
            textBoxEmail.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);

            textBoxContraseña.Text = "Password";
            textBoxContraseña.Font = new Font("Nunito", 10, FontStyle.Regular);
            textBoxContraseña.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
            textBoxContraseña.Multiline = true;
            textBoxContraseña.Width = 200;
            textBoxContraseña.Height = 30;
            textBoxContraseña.BorderStyle = BorderStyle.None;
            textBoxContraseña.Margin = new Padding(90, 10, 0, 10);
            textBoxContraseña.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);

            textBoxNombreUsuario.Text = "Username";
            textBoxNombreUsuario.Font = new Font("Nunito", 10, FontStyle.Regular);
            textBoxNombreUsuario.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
            textBoxNombreUsuario.Multiline = true;
            textBoxNombreUsuario.Width = 200;
            textBoxNombreUsuario.Height = 30;
            textBoxNombreUsuario.BorderStyle = BorderStyle.None;
            textBoxNombreUsuario.Margin = new Padding(90, 10, 0, 10);
            textBoxNombreUsuario.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);
        }

        private void ButtonsProperties()
        {
            btn_registrer.BackColor = System.Drawing.Color.FromArgb(218, 218, 28);
            btn_registrer.AutoSize = true;
            btn_registrer.Height = 30;
            btn_registrer.Text = "Registrarse";
            btn_registrer.FlatStyle = FlatStyle.Flat;
            btn_registrer.FlatAppearance.BorderSize = 0;
            btn_registrer.Margin = new Padding(132, 10, 0, 0);
            btn_registrer.ForeColor = System.Drawing.Color.FromArgb(32, 32, 32);
            btn_registrer.Font = new Font("Nunito", 12, FontStyle.Bold);

            btn_login.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            btn_login.Size = new Size(140, 30);
            btn_login.Text = "Iniciar sesión";
            btn_login.FlatStyle = FlatStyle.Flat;
            btn_login.FlatAppearance.BorderSize = 0;  // Grosor del borde
            btn_login.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(218, 218, 28); // Color del borde
            btn_login.Margin = new Padding(120, 10, 0, 0);
            btn_login.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            btn_login.Font = new Font("Nunito", 12, FontStyle.Bold);
        }
        private void AddLabels()
        {
            form.Controls.Add(flowLayoutForm);
            flowLayoutForm.Controls.Add(nombre);
            flowLayoutForm.Controls.Add(textBoxNombre);
            flowLayoutForm.Controls.Add(apellido);
            flowLayoutForm.Controls.Add(textBoxApellido);
            flowLayoutForm.Controls.Add(nombre_usuario);
            flowLayoutForm.Controls.Add(textBoxNombreUsuario);
            flowLayoutForm.Controls.Add(email);
            flowLayoutForm.Controls.Add(textBoxEmail);
            flowLayoutForm.Controls.Add(contraseña);
            flowLayoutForm.Controls.Add(textBoxContraseña);
            flowLayoutForm.Controls.Add(btn_registrer);
            flowLayoutForm.Controls.Add(pregunta);
            flowLayoutForm.Controls.Add(btn_login);
        }
        private void AddForm()
        {
            this.Controls.Add(form);
        }
    }

    public class RoundButton : Button
    {
        public RoundButton()
        {
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            GraphicsPath path = new GraphicsPath();

            path.AddArc(0, 0, 10, 10, 180, 90); // Esquina superior izquierda
            path.AddArc(this.Width - 10, 0, 10, 20, 270, 90); // Esquina superior derecha
            path.AddArc(this.Width - 10, this.Height - 10, 10, 10, 0, 90); // Esquina inferior derecha
            path.AddArc(0, this.Height - 10, 20, 10, 90, 90); // Esquina inferior izquierda

            path.CloseAllFigures();

            this.Region = new Region(path);
        }
    }

    public class RoundTextBox : TextBox
    {
        private int cornerRadius = 20;

        public RoundTextBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.BorderStyle = BorderStyle.None;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90); // Esquina superior izquierda
            path.AddArc(this.Width - cornerRadius - 1, 0, cornerRadius, cornerRadius, 270, 90); // Esquina superior derecha
            path.AddArc(this.Width - cornerRadius - 1, this.Height - cornerRadius - 1, cornerRadius, cornerRadius, 0, 90); // Esquina inferior derecha
            path.AddArc(0, this.Height - cornerRadius - 1, cornerRadius, cornerRadius, 90, 90); // Esquina inferior izquierda
            path.CloseFigure();

            this.Region = new Region(path);

            g.FillPath(new SolidBrush(this.BackColor), path);

            TextRenderer.DrawText(g, this.Text, this.Font, this.ClientRectangle, this.ForeColor, TextFormatFlags.Top | TextFormatFlags.Left);
        }
    }

    public class RoundPanel : Panel
    {
        private int cornerRadius = 40;

        public RoundPanel()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90); // Esquina superior izquierda
            path.AddArc(this.Width - cornerRadius - 1, 0, cornerRadius, cornerRadius, 270, 90); // Esquina superior derecha
            path.AddArc(this.Width - cornerRadius - 1, this.Height - cornerRadius - 1, cornerRadius, cornerRadius, 0, 90); // Esquina inferior derecha
            path.AddArc(0, this.Height - cornerRadius - 1, cornerRadius, cornerRadius, 90, 90); // Esquina inferior izquierda
            path.CloseFigure();

            this.Region = new Region(path);

            using (Brush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            base.OnPaint(e);
        }

        public int CornerRadius
        {
            get { return cornerRadius; }
            set { cornerRadius = value; Invalidate(); }
        }
    }
}