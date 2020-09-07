namespace Sales.ViewModels
{
    using Sales.Common.Models;
    using Sales.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel
    {
        // objeto que se encarga de las comunicaciones
        private ApiService apiService;

        private ObservableCollection<Product> products; // propiedad privada

        public ObservableCollection<Product> Products {
            get { return this.products; } // devuelve la propiedad
            set { this.SetValue(ref this.products, value); } // al usar SetValue no solo devolvemos el valos, sino que el metodo tambien se encarga de refrescar los cambios
        }

        public ProductsViewModel()
        {
            this.apiService = new ApiService();
            // cargamos los productos con un metodo
            this.LoadProducts();
        }

        // metodo que va a consumir la lista de productos
        private async void LoadProducts()
        {
            // la lista de productos esta en la API service
            var response = await this.apiService.GetList<Product>("http://192.168.1.7:4040", "/api", "/Products"); // parametros URL base, prefijo, controlador

            // preguntamos si no tenemos el listado de productos
            if (!response.IsSuccess)
            {
                // pintamos el mensaje de error asincrono
                // parametro titulo de error, mensaje, botoncito
                await Application.Current.MainPage.DisplayAlert("Error",response.Message,"Acceps");
                return; // salimos
            }

            // si estamos aca ya tenemos la lista de productos
            // response.Result debuelve un object que castearemos a lista de Product
            var list = (List<Product>)response.Result;
            // armamos la ObservableCollection pasando la lista en el constructor
            this.Products = new ObservableCollection<Product>(list);
        }
    } 
}

