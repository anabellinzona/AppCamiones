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
using System.Collections;
using System.Collections.Generic;


namespace AppCamiones
{
    internal class Class1 : Form
    {
        private Form1 form1 = new Form1();
        private Login login = new Login();

        private List<TextBox> textBoxList = new List<TextBox>();

        //DECLARACIÓN DEL FORM
        private NewRoundPanel form = new NewRoundPanel();

        private FlowLayoutPanel flowLayoutForm = new FlowLayoutPanel();

        private ArrayList campos_register = new ArrayList();
        private Label pregunta = new Label();


        private TextBox textBoxNombre = new TextBox();
        private TextBox textBoxApellido = new TextBox();
        private TextBox textBoxNombreUsuario = new TextBox();
        private TextBox textBoxContraseña = new TextBox();
        private TextBox textBoxEmail = new TextBox();

        private string campo1 = "Name";
        private string campo2 = "Surname";
        private string campo3 = "Username";
        private string campo4 = "Email";
        private string campo5 = "Password";

        private RoundButton btn_login = new RoundButton();
        private RoundButton btn_registrer = new RoundButton();

        public Class1()
        {

            InitializeUI();
            //HACE QUE SE ABRA EL FORMULARIO EN PANTALLA COMPLETA
            this.WindowState = FormWindowState.Maximized;
            btn_registrer.Click += new EventHandler(RegistrerUser_Click);
            btn_login.Click += new EventHandler(LoginUser_Click);

            Eventos();

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

            textBoxContraseña.TextChanged += new EventHandler(Contraseña_TextChanged);
        }

        private void Eventos()
        {
            foreach (TextBox txt in textBoxList)
            {
                switch (txt.Text)
                {
                    case "Name":
                        textBoxNombre = txt;
                        break;
                    case "Surname":
                        textBoxApellido = txt;
                        break;
                    case "Username":
                        textBoxNombreUsuario = txt;
                        break;
                    case "Password":
                        textBoxContraseña = txt;
                        this.StartPosition = FormStartPosition.CenterScreen;
                        break;
                    case "Email":
                        textBoxEmail = txt;
                        break;
                }
            }
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
                textBoxContraseña.Text = "Password";
                textBoxContraseña.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);
                textBoxContraseña.Font = new Font("Nunito", 10, FontStyle.Regular);
            }
        }

        private void Contraseña_Click(object sender, EventArgs e)
        {
            if (textBoxContraseña.Text == "Password")
            {
                textBoxContraseña.Text = "";
                textBoxContraseña.ForeColor = Color.Black;
            }
        }

        private void Contraseña_TextChanged(object sender, EventArgs e)
        {
            if (textBoxContraseña.Text != "Password")
            {
                textBoxContraseña.Text = new string('*', textBoxContraseña.Text.Length);
                textBoxContraseña.Font = new Font("Nunito", 14, FontStyle.Regular);
            }
        }
        //------------------------------------
        private void RegistrerUser_Click(object sender, EventArgs e)
        {
            foreach (TextBox txt in textBoxList)
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    //txt.Paint += miTextBox_Paint;

                    //MessageBox.Show("Completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (txt.Text == "Email" && !txt.Text.Contains("@"))
                {
                    MessageBox.Show("Ingrese un email válido");
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        //private void miTextBox_Paint(object sender, PaintEventArgs e)
        //{
        //    Control control = (Control)sender;
        //    Pen pen = new Pen(Color.Red, 2); // Cambia a tu color
        //    e.Graphics.DrawRectangle(pen, 0, 0, control.Width - 1, control.Height - 1);
        //}


        private void LoginUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNombreUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
            TextBoxAndLabelProperties();
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

        private void TextBoxAndLabelProperties()
        {
            campos_register.Add(campo1);
            campos_register.Add(campo2);
            campos_register.Add(campo3);
            campos_register.Add(campo4);
            campos_register.Add(campo5);



            for (int i = 0; i < campos_register.Count; i++)
            {
                System.Windows.Forms.Label campos = new System.Windows.Forms.Label();
                TextBox textBoxCampos = new TextBox();


                campos.Text = campos_register[i].ToString();
                textBoxCampos.Text = campos_register[i].ToString();



                campos.Font = new Font("Nunito", 10, FontStyle.Regular);
                campos.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
                campos.BackColor = Color.Transparent;
                campos.Margin = new Padding(80, 10, 0, 0);
                campos.AutoSize = true;

                textBoxCampos.Font = new Font("Nunito", 10, FontStyle.Regular);
                textBoxCampos.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
                textBoxCampos.Multiline = true;
                textBoxCampos.Width = 200;
                textBoxCampos.Height = 30;
                textBoxCampos.BorderStyle = BorderStyle.None;
                textBoxCampos.Margin = new Padding(90, 10, 0, 10);
                textBoxCampos.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);


                flowLayoutForm.Controls.Add(campos);
                flowLayoutForm.Controls.Add(textBoxCampos);
                textBoxList.Add(textBoxCampos);
            }

            pregunta.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            pregunta.Text = "¿Ya tienes una cuenta?";
            pregunta.Font = new Font("Nunito", 10, FontStyle.Regular);
            pregunta.AutoSize = true;
            pregunta.TextAlign = ContentAlignment.TopCenter;
            pregunta.Margin = new Padding(113, 30, 0, 0); ;
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