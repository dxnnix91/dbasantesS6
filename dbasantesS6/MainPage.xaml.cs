﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace dbasantesS6
{
    public partial class MainPage : ContentPage
    {
        private string url = "192.168.10.41/uisrael/post.php";
        private readonly HttpClient Client = new HttpClient();
        private ObservableCollection<Estudiante> post;
        public MainPage()
        {
            InitializeComponent();
            Obtener();
        }

        private async void btnConsultar_Clicked(object sender, EventArgs e)
        {
            var contenido = await Client.GetStringAsync(url);
            List<Estudiante> datosPost = JsonConvert.DeserializeObject<List<Estudiante>>(contenido);
            post = new ObservableCollection<Estudiante>(datosPost);
            listaEstudiantes.ItemsSource = post;
        }

        public async void Obtener()
        {
            var contenido = await Client.GetStringAsync(url);
            List<Estudiante> datosPost = JsonConvert.DeserializeObject<List<Estudiante>>(contenido);
            post = new ObservableCollection<Estudiante>(datosPost);
            listaEstudiantes.ItemsSource = post;
        }
    }
}