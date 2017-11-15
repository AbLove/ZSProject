using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Common
{

    public class HttpHelper : IDisposable
    {

        /// <summary>
        /// Send post request
        /// </summary>
        /// <param name="url">eg: "https://open.ys7.com/api/lapp/token/get"</param>
        /// <param name="postData">  var postData = string.Format(
        ///            "appKey={0}&appSecret={1}",
        ///            "f027c9edc6bf491fa08d30aa536cf92f",
        ///            "da70a5c4ef5d71ef54116235ca5de102"
        ///          )</param>
        /// <returns></returns>
        public string HttpPost(string url, string postData)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }


        public string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }





        #region Fields

        /// <summary>
        /// The default service host.
        /// </summary>
        private const string SERVICE_HOST = "http://open.ys7.com";


        private const string token = "";

        /// <summary>
        /// The JSON content type header.
        /// </summary>
        private const string JsonContentTypeHeader = "application/json";

        /// <summary>
        /// The stream content type header.
        /// </summary>
        private const string StreamContentTypeHeader = "application/x-www-form-urlencoded";//"application/octet-stream";


        protected string ServiceHost = SERVICE_HOST;

        /// <summary>
        /// The HTTP client
        /// </summary>
        private HttpClient _httpClient;

        #endregion

        /// <summary>
        /// The settings
        /// </summary>
        private static JsonSerializerSettings s_settings = new JsonSerializerSettings()
        {
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };


        //public async Task<ImgBack> GetImgUrl()
        //{
            
        //        var requestUrl = string.Format(
        //            "{0}?accessToken={1}&deviceSerial={2}&channelNo={3}",
        //            ServiceHost,
        //            "da70a5c4ef5d71ef54116235ca5de102",
        //            "624522059",
        //            1
        //          );

        //        return await this.SendRequestAsync<object, ImgBack>(HttpMethod.Post, requestUrl, null);
        //            //new {
        //            //    url = imageUrl
        //            //});
            
           
        //}

       

   

        /// <summary>
        /// Sends the request asynchronous.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="requestUrl">The request URL.</param>
        /// <param name="requestBody">The request body.</param>
        /// <returns>The response.</returns>
        /// <exception cref="OxfordAPIException">The client exception.</exception>
        public async Task<TResponse> SendRequestAsync<TRequest, TResponse>(HttpMethod httpMethod, string requestUrl, TRequest requestBody)
        {
            var request = new HttpRequestMessage(httpMethod, ServiceHost);
            request.RequestUri = new Uri(requestUrl);
            if (requestBody != null)
            {
                if (requestBody is Stream)
                {
                    request.Content = new StreamContent(requestBody as Stream);
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(StreamContentTypeHeader);
                }
                else
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(requestBody, s_settings), Encoding.UTF8, JsonContentTypeHeader);
                }
            }

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = null;
                if (response.Content != null)
                {
                    responseContent = await response.Content.ReadAsStringAsync();
                }

                if (!string.IsNullOrWhiteSpace(responseContent))
                {
                    return JsonConvert.DeserializeObject<TResponse>(responseContent, s_settings);
                }

                return default(TResponse);
            }
            else
            {
                if (response.Content != null && response.Content.Headers.ContentType.MediaType.Contains(JsonContentTypeHeader))
                {
                    //var errorObjectString = await response.Content.ReadAsStringAsync();
                    //ClientError ex = JsonConvert.DeserializeObject<ClientError>(errorObjectString);
                    //if (ex.Error != null)
                    //{
                    //    throw new FaceAPIException(ex.Error.ErrorCode, ex.Error.Message, response.StatusCode);
                    //}
                    //else
                    //{
                    //    ServiceError serviceEx = JsonConvert.DeserializeObject<ServiceError>(errorObjectString);
                    //    if (ex != null)
                    //    {
                    //        throw new FaceAPIException(serviceEx.ErrorCode, serviceEx.Message, response.StatusCode);
                    //    }
                    //    else
                    //    {
                    //        throw new FaceAPIException("Unknown", "Unknown Error", response.StatusCode);
                    //    }
                    //}
                }

                response.EnsureSuccessStatusCode();
            }

            return default(TResponse);
        }

        

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~HttpHelper()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_httpClient != null)
                {
                    _httpClient.Dispose();
                    _httpClient = null;
                }
            }
        }
    }
}