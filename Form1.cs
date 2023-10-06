using System;
using System.Collections;
using System.Windows.Forms;
using BiblotecaPersonas;

namespace Ejercicio_11_GRAJ
{

    public partial class Form1 : Form
    {

        ArrayList personas;
        private int indice;

        public Form1()
        {
            InitializeComponent();
            personas = new ArrayList();
             
        }

        public int Indice { 
            get => indice;
            set 
            { 
                if(personas.Count > 0 && value< personas.Count)
                {
                    indice = value;
                }
                else
                {
                    indice = 0;
                }
            } 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            personas.Add (new Persona(txtNombre.Text, txtTelefono.Text, byte.Parse(txtedad.Text),txtDireccion.Text) );
            Guardar();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {

                Persona persona = (Persona)personas[Indice++];

                txtNombre.Text = persona.Nombre;
                txtTelefono.Text = persona.Telefono;
                txtedad.Text = persona.Edad.ToString();
                txtDireccion.Text = persona.Direccion;
            }

            catch(NullReferenceException error) 
            {
                MessageBox.Show("Error: Debes de agregar al menos una perosna ");
            }
            catch(ArgumentOutOfRangeException error) 
            {
                MessageBox.Show("Error: Debes de agregar al menos una perosna ");
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                Guardar();
            }
                
        }

        private void Guardar()
        {
            personas.Add(new Persona(txtNombre.Text, txtTelefono.Text, byte.Parse(txtedad.Text), txtDireccion.Text));
            txtDireccion.Clear();
            txtedad.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
        }
    }
}
