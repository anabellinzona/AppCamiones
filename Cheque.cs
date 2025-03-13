using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AppCamiones
{
    internal class Cheque : Form
    {
        private RoundPanel form = new RoundPanel();
        private RoundPanel title = new RoundPanel();

        private FlowLayoutPanel flForm = new FlowLayoutPanel();
        private FlowLayoutPanel flTitle = new FlowLayoutPanel();

        private RoundTextBox txtfIngreso = new RoundTextBox();
        private RoundTextBox txtentrega = new RoundTextBox();
        private RoundTextBox txtbanco = new RoundTextBox();
        private RoundTextBox txtnro = new RoundTextBox();
        private RoundTextBox txtimporte = new RoundTextBox();
        private RoundTextBox txtfCobro = new RoundTextBox();
        private RoundTextBox txtentregado = new RoundTextBox();

        private Label lblfIngreso = new Label();
        private Label lblentrega = new Label();
        private Label lblbanco = new Label();
        private Label lblnro = new Label();
        private Label lblimporte = new Label();
        private Label lblfCobro = new Label();
        private Label lblentregado = new Label();

        public Cheque()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            InitializeBackImage();
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

    }
}