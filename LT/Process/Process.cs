using LT.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LT.Process
{
    public class Process
    {
        /// <summary>
        /// Metodo para obtener en base64 la autenticacion
        /// </summary>
        /// <returns></returns>
        public static string GetBase64()
        {
            string usuario = "teste_dev3";
            string contrasena = "WhOnBcjTsGseYDE9819GloHYhgL";

            return Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{contrasena}"));

        }

        /// <summary>
        /// Metodop par aobetener todas las cuidades
        /// </summary>
        /// <returns></returns>
        public static async Task<Response<List<Paradas>>> GetParadas()
        {
            try
            {
                string url = "https://queropassagem.qpdevs.com/ws_v4/stops";
                string data = "";

                HttpResponseMessage response = await RequestHttpAsync("GET", string.Empty, url, true);

                if (response.IsSuccessStatusCode)
                {
                    data = await response.Content.ReadAsStringAsync();
                }
                else
                {

                    return new Response<List<Paradas>>()
                    {
                        Data = null,
                        Error = new Models.Error()
                        {
                            Code = (int)response.StatusCode,
                            Message = response?.ReasonPhrase ?? "",
                        }
                    };
                }


                List<Paradas> paradas = JsonConvert.DeserializeObject<List<Paradas>>(data);

                Response<List<Paradas>> res = new Response<List<Paradas>>()
                {
                    Data = paradas ?? []
                };

                return res;


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo para obtener viajes por ciudad
        /// </summary>
        /// <param name="_search">Filtro a buscar</param>
        /// <returns></returns>
        public static async Task<Response<List<BusInfo>>> GetBusByCity(SearchFilterBus _search)
        {

            try
            {
                string url = "https://queropassagem.qpdevs.com/ws_v4/new/search";
                string data = "";
                string body = JsonConvert.SerializeObject(_search);

                HttpResponseMessage response = await RequestHttpAsync("POST", body, url, true);

                if (response.IsSuccessStatusCode)
                {
                    data = await response.Content.ReadAsStringAsync();
                }
                else
                {

                    return new Response<List<BusInfo>>()
                    {
                        Data = null,
                        Error = new Models.Error()
                        {
                            Code = (int)response.StatusCode,
                            Message = response?.ReasonPhrase ?? "",
                        }
                    };
                }


                List<BusInfo> infoviajes = JsonConvert.DeserializeObject<List<BusInfo>>(data);

                //Order by time
                List<BusInfo> viajeOrderbyDeparture = infoviajes.OrderBy(c => c.departure.time).ToList();

                Response<List<BusInfo>> res = new Response<List<BusInfo>>()
                {
                    Data = viajeOrderbyDeparture ?? []
                };

                return res;


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///  Metodo obtener asiento por viaje
        /// </summary>
        /// <param name="_search">Filtro a buscar</param>
        /// <returns></returns>
        public static async Task<Response<List<Asientos>>> GetAsientos(SearchFilterAsientos _search)
        {

            try
            {
                string url = "https://queropassagem.qpdevs.com/ws_v4/new/seats";
                string data = "";
                string body = JsonConvert.SerializeObject(_search);

                HttpResponseMessage response = await RequestHttpAsync("POST", body, url, true);

                if (response.IsSuccessStatusCode)
                {
                    data = await response.Content.ReadAsStringAsync();
                }
                else
                {

                    return new Response<List<Asientos>>()
                    {
                        Data = null,
                        Error = new Models.Error()
                        {
                            Code = (int)response.StatusCode,
                            Message = response?.ReasonPhrase ?? "",
                        }
                    };
                }


                List<Asientos> asientos = JsonConvert.DeserializeObject<List<Asientos>>(data);

                Response<List<Asientos>> res = new Response<List<Asientos>>()
                {
                    Data = asientos ?? []
                };

                return res;


            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// Metodo para realizar solicitud httpclient
        /// </summary>
        /// <param name="_method">Indica tipo metodo</param>
        /// <param name="_body">Indica el cuerpo de solicitud</param>
        /// <param name="_url">Indica url de solicitud</param>
        /// <param name="isAuth">Indica si solicitud requiere autenticacion</param>
        /// <returns></returns>

        public static async Task<HttpResponseMessage> RequestHttpAsync(string _method, string _body, string _url, bool isAuth)
        {
            try
            {
                string credencial = "";


                if (isAuth)
                {

                    credencial = GetBase64();
                }

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                    if (isAuth)
                    {
                        httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {credencial}");

                    }

                    if (_method == "POST")
                    {
                        StringContent httpContent = new StringContent(_body, Encoding.UTF8, "application/json");

                        return await httpClient.PostAsync($"{_url}", httpContent);
                    }
                    else if (_method == "GET")
                    {
                        return await httpClient.GetAsync($"{_url}");
                    }
                    else
                    {
                        return null;
                    }

                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
