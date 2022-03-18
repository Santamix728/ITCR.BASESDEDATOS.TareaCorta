﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TABAS_Mobile.Views
{
    /// <summary>
    /// Page to show the no photos
    /// </summary>
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoPhotosPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoPhotosPage" /> class.
        /// </summary>
        public NoPhotosPage()
        {
            this.InitializeComponent();

        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (CrossMedia.Current.IsTakePhotoSupported)
            {
                var imagen = await CrossMedia.Current.PickPhotoAsync();
                if (imagen != null)
                {
                    Miimagen.Source = ImageSource.FromStream(() =>
                    {
                        var stream = imagen.GetStream();
                        imagen.Dispose();
                        return stream;
                    });
                }
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var opciones_almacenamiento = new StoreCameraMediaOptions()
            {
                SaveToAlbum = true,
                Name = "Escaneo.jpg"
            };
            var foto = await CrossMedia.Current.TakePhotoAsync(opciones_almacenamiento);
            Miimagen.Source = ImageSource.FromStream(() =>
            {
                var stream = foto.GetStream();
                foto.Dispose();
                return stream;
            });
        }


    }
}