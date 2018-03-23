using System;
using System.Collections.Generic;
using System.Net;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ShoppingCartApi.Models
{
    public partial class StkCallBackViewModel
    {
        [JsonProperty("Body")]
        public Body Body { get; set; }
    }

    public partial class Body
    {
        [JsonProperty("stkCallback")]
        public StkCallback StkCallback { get; set; }
    }

    public partial class StkCallback
    {
        [JsonProperty("MerchantRequestID")]
        public string MerchantRequestId { get; set; }

        [JsonProperty("CheckoutRequestID")]
        public string CheckoutRequestId { get; set; }

        [JsonProperty("ResultCode")]
        public long ResultCode { get; set; }

        [JsonProperty("ResultDesc")]
        public string ResultDesc { get; set; }

        [JsonProperty("CallbackMetadata")]
        public CallbackMetadata CallbackMetadata { get; set; }
    }

    public partial class CallbackMetadata
    {
        [JsonProperty("Item")]
        public Item[] Item { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Value")]
        public long Value { get; set; }
    }
}
