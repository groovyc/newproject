using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace fourchordproject
{
    public class TodoItem
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }


        public string containerName { get; set; } //added
        public string resourceName { get; set; }
        public string sasQueryString { get; set; }
        public string imageUri { get; set; }

        [JsonProperty(PropertyName = "containerName123")]  //added all
        public string ContainerName { get; set; }

        [JsonProperty(PropertyName = "resourceName123")]
        public string ResourceName { get; set; }

        [JsonProperty(PropertyName = "sasQueryString123")]
        public string SasQueryString { get; set; }

        [JsonProperty(PropertyName = "imageUri123")]
        public string ImageUri { get; set; } 
    }
}
