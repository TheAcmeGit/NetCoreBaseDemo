using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBaseDemo.DTOEntity
{
   public  class SysNavMenuDto
    {
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Label")]
        public string Name { get; set; }
        public string Method { get; set; }
        public string UrlLink { get; set; }
        public string ParentId { get; set; }
        public bool IsLeaf { get; set; }
        public bool IsButton { get; set; }
        public int Status { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public List<SysNavMenuDto> Children { get; set; } = new List<SysNavMenuDto>();
    }
}
