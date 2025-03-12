using System;
using System.Drawing;
using System.Windows.Forms;

public class RoundButton : Button
{
    public RoundButton()
    {
        // Puedes agregar inicialización de la clase aquí si es necesario

    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent); // Llama al método OnPaint de la clase base (Button).

        // Crea un objeto GraphicsPath para definir la forma redondeada
        GraphicsPath path = new GraphicsPath();

        // Añade las esquinas redondeadas
        path.AddArc(0, 0, 30, 30, 180, 90); // Esquina superior izquierda
        path.AddArc(this.Width - 30, 0, 30, 30, 270, 90); // Esquina superior derecha
        path.AddArc(this.Width - 30, this.Height - 30, 30, 30, 0, 90); // Esquina inferior derecha
        path.AddArc(0, this.Height - 30, 30, 30, 90, 90); // Esquina inferior izquierda

        // Cierra la figura
        path.CloseAllFigures();

        // Asigna la región al botón, lo que cambia su forma a la definida por el GraphicsPath
        this.Region = new Region(path);
    }
}
