using Newtonsoft.Json;

namespace QuickEmailVerification.NET
{
    /// <summary>
    /// QuickEmailVerification Response information
    /// </summary>
    /// <remarks>
    /// https://github.com/quickemailverification/quickemailverification-node
    /// </remarks>
    public class ResultResponse
    {
        [JsonProperty("result")]
        public string Result { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
        [JsonProperty("disposable")]
        public bool Disposable { get; set; }
        [JsonProperty("accept_all")]
        public bool AcceptAll { get; set; }
        [JsonProperty("role")]
        public bool Role { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("domain")]
        public string Domain { get; set; }
        [JsonProperty("safe_to_send")]
        public bool SafeToSend { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        
        [JsonIgnore]
        public int Code { get; set; }
    }
}
