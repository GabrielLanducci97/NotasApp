using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotasApp
{
    public partial class Form1 : Form
    {
        List<Nota> _notas = new List<Nota>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTitulo.Text) &&
                !string.IsNullOrEmpty(txtNota.Text))
            {
                var nota = new Nota();
                nota.Titulo = txtTitulo.Text;
                nota.Notas = txtNota.Text;

                _notas.Add(nota);

                PopularNota();
                BorrarFormulario();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (grdNotas.SelectedRows != null)
            {
                var titulo = grdNotas.SelectedCells[0].Value.ToString();
                BorrarporTitulo(titulo);
                PopularNota();
            }

        }

        private void BorrarporTitulo(string titulo)
        {
            Nota notaaBorrar = null;

            foreach (var nota in _notas)
            {
                if (nota.Titulo == titulo)
                    notaaBorrar = nota;
            }

            if (notaaBorrar != null)
                _notas.Remove(notaaBorrar);
        }

        private void PopularNota()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = _notas;
            grdNotas.DataSource = bs;
        }

        private void BorrarFormulario()
        {
            txtTitulo.Text = string.Empty;
            txtNota.Text = string.Empty;
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            if (grdNotas.SelectedRows != null)
            {
                var titulo = grdNotas.SelectedCells[0].Value.ToString();
                var notas = GetNotasdeTitulo(titulo);

                txtTitulo.Text = titulo;
                txtNota.Text = notas;
            }
        }

        private string GetNotasdeTitulo(string titulo)
        {
            var notas = string.Empty;

            foreach (var nota in _notas)
            {
                if (nota.Titulo == titulo)
                    notas = nota.Notas;
            }

            return notas;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BorrarFormulario();
        }
    }
}
