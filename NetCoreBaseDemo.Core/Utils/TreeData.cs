using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneCard.Core.DataModel
{
    public class TreeData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("parentId")]
        public string ParentId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("checked")]
        public bool Checked { get; set; }
        [JsonProperty("spread")]
        public bool Spread { get; set; } = true;

        public List<TreeData> children { get; set; }
    }
}
