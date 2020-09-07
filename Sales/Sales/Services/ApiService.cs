namespace Sales.Services
{
    using Newtonsoft.Json;
    using Sales.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    public class ApiService
    {
        // Metodo publico que consume servicios asincronos para devolver una lista
        // Metodo generico que devuelve una lista generica
        // Al ser generico permite consumir de cualquier servicio api y nos va a servir para consumir cualquier lista
        public async Task<Response> GetList<T>(string urlBase, string prefix, string controller)
        {   
            // como el resultado puede ser incierto tiramos un try catch
            try
            {
                // vamos a consumir el servicio RESTFULL
                // vamos a crear el cliente como objeto de la clase HttpClient
                // client es el objeto que nos va a servir para hacer la comunicacion
                var client = new HttpClient();

                // una ves que ya tenemos el objeto solo hay que cargarle la direccion
                // la cargamos en la propiedad BaseAddress
                client.BaseAddress = new Uri(urlBase);

                // por ultimo hay que concatenar el prefijo y el controlador
                // para obtener la lista
                var url = $"{prefix}{controller}"; //esto es equivalente a hacer un string.Format

                // disparamos el request
                // creamos un objeto y lo ponemos a esperar
                var response = await client.GetAsync(url);
                // response almacena el resultado en formato Json

                // cuando termina hay que pasar el resultado que esta en formato Json a un variable de tipo string
                var answer = await response.Content.ReadAsStringAsync();
                // answer almacena el resultado como string

                // aca pueden pasar dos cosas
                // 1 que me haya llegado el objeto como tal
                // 2 o que me haya llegado un mensaje de error

                // response.IsSuccessStatusCode contiene el codigo de exito y si no existe entonses hubo un error

                // preguntamo si existió un error con la negacion de response.IsSuccessStatusCode
                if (!response.IsSuccessStatusCode)
                {
                    // como hubo un erros creamos una instancia de la clase de respuesta y la retornamos
                    return new Response
                    {
                        IsSuccess = false,
                        // en este caso en answer quedo el codigo de error que devolvio el servicio
                        Message = answer,
                        // notese que no pasamos nada en la propiedad Result
                    };
                }

                // en esta punto no existió ningun error
                // vamos a deserializar el string almacenado en answer
                // y lo almacenamos en una lista de objetos
                // utilizamos la libreria JsonConvert del NewtonSoftJason para la deserializacion
                var list = JsonConvert.DeserializeObject<List<T>>(answer);

                // ahora si retornamos la respuesta con la lista como cuerpo del resultado
                return new Response
                {
                    IsSuccess = true,
                    Result = list,
                    // como no hubo errores, Message estara vacio
                };

            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,                  
                };
            }
        }
    }
}
