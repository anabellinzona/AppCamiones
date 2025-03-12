using System.Drawing;
using System.IO;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
using Button = System.Windows.Forms.Button;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace AppCamiones
{
    public partial class Class1 : Form
    {

        private Form1 ff = new Form1();
        private Login login = new Login();

        //DECLARACIÓN DEL FORM
        private Panel form = new Panel();

        private FlowLayoutPanel flowLayoutForm = new FlowLayoutPanel();

        private Label nombre = new Label();
        private Label apellido = new Label();
        private Label nombre_usuario = new Label();
        private Label contraseña = new Label();
        private Label email = new Label();
        private Label pregunta = new Label();


        private TextBox textBoxNombre = new TextBox();
        private TextBox textBoxApellido = new TextBox();
        private TextBox textBoxNombreUsuario = new TextBox();
        private TextBox textBoxContraseña = new TextBox();
        private TextBox textBoxEmail = new TextBox();

        private Button btn_login = new Button();
        private Button btn_registrer = new Button();

        public Class1()
        {
            InitializeUI();
            btn_registrer.Click += new EventHandler(RegistrerUser_Click);
            btn_login.Click += new EventHandler(LoginUser_Click);
        }

        private void RegistrerUser_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void LoginUser_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Close();
        }

        private void InitializeUI()
        {
            InitializeBackImage();
            InitializeIconoApp();
            InitializeForm();
        }

        private void InitializeBackImage()
        {
            //ASIGNA LA RUTA D ELA IMAGEN DE MANERA RELATIVA
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "goma.jpg");

            //PREGUNTA SI EXISTE DICHO ARCHIVO
            if (File.Exists(imagePath))
            {
                //LE ASGINA A BACKGROUNDIMAGE LA IMAGEN
                using (Image img = Image.FromFile(imagePath))
                {
                    this.BackgroundImage = new Bitmap(img);
                }
            }
            else
            {
                //TIRA EXCEPCIÓN
                MessageBox.Show("La imagen no se encuentra: " + imagePath);
            }

            //Path.Combine(...) --> se asegura de unir correctamente partes de una ruta de archivo sin problema
            //AppDomain.CurrentDomain.BaseDirectory --> Obtiene el directorio base de dónde se está ejecutando la aplicación
            //"Resources", "goma.jpg" --> Resources es la carpeta donde se encuentra el archivo goma.jpg
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
           
            form.BackColor = System.Drawing.Color.FromArgb(200, Color.Black);
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
            nombre.Font = new Font("Nunito", 12, FontStyle.Regular);
            nombre.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            nombre.BackColor = Color.Transparent;
            nombre.Margin = new Padding(80, 10, 0, 0);
            nombre.AutoSize = true;

            apellido.Text = "Apellido:";
            apellido.Font = new Font("Nunito", 12, FontStyle.Regular);
            apellido.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            apellido.BackColor = Color.Transparent;
            apellido.Margin = new Padding(80, 10, 0, 0);
            apellido.AutoSize = true;

            email.Text = "Email:";
            email.Font = new Font("Nunito", 12, FontStyle.Regular);
            email.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            email.BackColor = Color.Transparent;
            email.Margin = new Padding(80, 10, 0, 0);
            email.AutoSize = true;

            contraseña.Text = "Contraseña:";
            contraseña.Font = new Font("Nunito", 12, FontStyle.Regular);
            contraseña.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            contraseña.BackColor = Color.Transparent;
            contraseña.Margin = new Padding(80, 10, 0, 0);
            contraseña.AutoSize = true;

            nombre_usuario.Text = "Nombre de usuario:";
            nombre_usuario.Font = new Font("Nunito", 12, FontStyle.Regular);
            nombre_usuario.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            nombre_usuario.BackColor = Color.Transparent;
            nombre_usuario.Margin = new Padding(80, 10, 0, 0);
            nombre_usuario.AutoSize = true;

            pregunta.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            pregunta.Text = "¿Ya tienes una cuenta?";
            pregunta.Font = new Font("Nunito", 12, FontStyle.Regular);
            pregunta.AutoSize = true;
            pregunta.TextAlign = ContentAlignment.TopCenter;
            pregunta.Margin = new Padding(100, 30, 0, 0); ;
        }

        private void TextBoxProperties()
        {
            textBoxNombre.Text = "Nombre";
            textBoxNombre.Font = new Font("Nunito", 10, FontStyle.Regular);
            textBoxNombre.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
            textBoxNombre.Multiline = true;
            textBoxNombre.Width = 200;
            textBoxNombre.Height = 25;
            textBoxNombre.BorderStyle = BorderStyle.None;
            textBoxNombre.Margin = new Padding(90, 10, 0, 10);
            textBoxNombre.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77); 


            textBoxApellido.Text = "Apellido";
            textBoxApellido.Font = new Font("Nunito", 10, FontStyle.Regular);
            textBoxApellido.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
            textBoxApellido.Multiline = true;
            textBoxApellido.Width = 200;
            textBoxApellido.Height = 25;
            textBoxApellido.BorderStyle = BorderStyle.None;
            textBoxApellido.Margin = new Padding(90, 10, 0, 10);
            textBoxApellido.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);

            textBoxEmail.Text = "Email";
            textBoxEmail.Font = new Font("Nunito", 10, FontStyle.Regular);
            textBoxEmail.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
            textBoxEmail.Multiline = true;
            textBoxEmail.Width = 200;
            textBoxEmail.Height = 25;
            textBoxEmail.BorderStyle = BorderStyle.None;
            textBoxEmail.Margin = new Padding(90, 10, 0, 10);
            textBoxEmail.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);

            textBoxContraseña.Text = "Contraseña";
            textBoxContraseña.Font = new Font("Nunito", 10, FontStyle.Regular);
            textBoxContraseña.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
            textBoxContraseña.Multiline = true;
            textBoxContraseña.Width = 200;
            textBoxContraseña.Height = 25;
            textBoxContraseña.BorderStyle = BorderStyle.None;
            textBoxContraseña.Margin = new Padding(90, 10, 0, 10);
            textBoxContraseña.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);

            textBoxNombreUsuario.Text = "Nombre de usuario";
            textBoxNombreUsuario.Font = new Font("Nunito", 10, FontStyle.Regular);
            textBoxNombreUsuario.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
            textBoxNombreUsuario.Multiline = true;
            textBoxNombreUsuario.Width = 200;
            textBoxNombreUsuario.Height = 25;
            textBoxNombreUsuario.BorderStyle = BorderStyle.None;
            textBoxNombreUsuario.Margin = new Padding(90, 10, 0, 10);
            textBoxNombreUsuario.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);
        }

        private void ButtonsProperties()
        {
            btn_registrer.BackColor = System.Drawing.Color.FromArgb(218, 218, 28);
            btn_registrer.AutoSize = true;
            btn_registrer.Text = "Registrarse";
            btn_registrer.FlatStyle = FlatStyle.Flat;
            btn_registrer.FlatAppearance.BorderSize = 0;
            btn_registrer.Margin = new Padding(130, 10, 0, 0);
            btn_registrer.ForeColor = System.Drawing.Color.FromArgb(32, 32, 32);
            btn_registrer.Font = new Font("Nunito", 12, FontStyle.Bold);

            btn_login.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            btn_login.Size = new Size(150, 40);
            btn_login.Text = "Iniciar sesión";
            btn_login.FlatStyle = FlatStyle.Flat;
            btn_login.FlatAppearance.BorderSize = 2;  // Grosor del borde
            btn_login.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(218, 218, 28); // Color del borde

            btn_login.Margin = new Padding(115, 10, 0, 0);
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
}