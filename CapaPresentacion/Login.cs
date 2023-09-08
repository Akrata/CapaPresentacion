using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new CN_Usuario().Listar();
            Usuario oUsuario = new CN_Usuario().Listar().Where(u => u.Documento == txtDoc.Text && u.Clave == txtPass.Text).FirstOrDefault();


            if (oUsuario != null)
            {
                Inicio form = new Inicio();
                            form.Show();
                            this.Hide();
                            form.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("No se encontró el usuario","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            

            
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            this.txtDoc.Text = "";
            this.txtPass.Text = "";

        }
    }
}
