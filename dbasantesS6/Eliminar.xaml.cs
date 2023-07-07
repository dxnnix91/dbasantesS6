using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dbasantesS6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Eliminar : ContentPage
    {
        private string url = "http://192.168.10.41/uisrael/post.php?codigo=";
        WebClient client = new WebClient();
        public Eliminar(Estudiante datos)
        {
            InitializeComponent();
            txtCodigo.Text = datos.codigo.ToString();
            txtNombre.Text = datos.nombre.ToString();
            txtApellido.Text = datos.apellido.ToString();
            txtEdad.Text = datos.edad.ToString();
            
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var datos = new System.Collections.Specialized.NameValueCollection();

                datos.Add("nombre", txtNombre.Text);
                datos.Add("apellido", txtApellido.Text);
                datos.Add("edad", txtEdad.Text);

                var parametros = txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text;

                cliente.UploadValues(url + parametros, "PUT", datos);
                var mensaje = "Dato modificado correctamente";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
                Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datos = new System.Collections.Specialized.NameValueCollection();
                datos.Add("codigo", txtCodigo.Text);
                client.UploadValues(url+txtCodigo.Text,"DELETE", datos);
                var mensaje = "Dato eliminado correctamente";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
                Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
                throw;
            }
        }
    }
}