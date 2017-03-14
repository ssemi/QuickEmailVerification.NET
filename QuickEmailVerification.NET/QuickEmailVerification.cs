using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace QuickEmailVerification.NET
{
    /// <summary>
    /// Quickemailverification 
    /// </summary>
    public class Quickemailverification : IDisposable
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private const string ResourceUrl = "http://api.quickemailverification.com/v1/verify";

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="apiKey">API Key</param>
        /// <remarks>
        /// Apikey must be required
        /// </remarks>
        public Quickemailverification(string apiKey)
        {
            if (String.IsNullOrWhiteSpace(apiKey))
            { 
                throw new ArgumentNullException("apiKey");
            }

            _client = new HttpClient();
            _client.DefaultRequestHeaders.Connection.Add("keep-alive");
            _client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            _client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            _client.DefaultRequestHeaders.ExpectContinue = false;
            
            this._apiKey = apiKey;
        }


        public async Task<bool> Verify(string email, bool forceTrue = false)
        {
            bool verify = false;
            var result = await VerifyInfo(email);

            verify = result.Code == (int)HttpStatusCode.OK && result.Success && "valid".Equals(result.Result); // Should we also add 'unknown'?

            if (forceTrue && !verify) // verify : false && forceTrue 
            {
                verify = result.Code == 402 || result.Code == 429;  // 402 : Low credit. Payment required  , 429 : Too many requests. Rate limit exceeded.
            }
            return verify;
        }

        public async Task<ResultResponse> VerifyInfo(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("email");    
            }

            var result = new ResultResponse();

            if (Validator.IsEmail(email) && Validator.IsDomain(email))
            {
                var uri = String.Format("{0}?email={1}&apikey={2}", ResourceUrl, email, _apiKey);
                var response = await _client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);

                try
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ResultResponse>(json);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                result.Code = (int)response.StatusCode;
            }
            else
            {
                result.Success = false;
                result.Message = "Email is not valid.";
                result.Code = (int)HttpStatusCode.BadRequest;
            }
            return result;
        }
        
        /// <summary>
        /// Dispose Resources
        /// </summary>
        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
