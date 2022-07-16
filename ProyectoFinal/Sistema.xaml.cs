using ProyectoFinal.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProyectoFinal.Modelo;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal
{
    /// <summary>
    /// Lógica de interacción para Sistema.xaml
    /// </summary>
    public partial class Sistema : Window
    {
        public Sistema()
        {
            InitializeComponent();
            GetUser();
        }

        public void GetUser()
        {
            using (var _context = new AplicationdbContext())
            {
                UserTable.ItemsSource = _context.Usuarios.ToList();
            }
        }

        private void SelectItem(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario = (sender as FrameworkElement).DataContext as Usuario;

                txtId.Text = usuario.Id.ToString();
                txtNombre.Text = usuario.Nombre.ToString();
                txtUser.Text = usuario.User.ToString();
                txtPassword.Text = usuario.Password.ToString();
            }
            catch (Exception ex)
            {

                throw new Exception("Error interno: " + ex.Message);
            }
        }

        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {

            Usuario usuarioUpdate = new Usuario();

            usuarioUpdate.Id = int.Parse(txtId.Text);

            using (var _context = new AplicationdbContext())
            {

                usuarioUpdate = _context.Usuarios.Find(usuarioUpdate.Id);
                usuarioUpdate.Nombre = txtNombre.Text;
                usuarioUpdate.User = txtUser.Text;
                usuarioUpdate.Password = txtPassword.Text;

                _context.Entry(usuarioUpdate).State = EntityState.Modified;
                _context.SaveChanges();
                MessageBox.Show(txtNombre.Text + " Sus datos se han cambiado correctamente");
                GetUser();



            }

        }

    }
}