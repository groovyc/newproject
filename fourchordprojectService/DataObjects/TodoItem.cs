using Microsoft.WindowsAzure.Mobile.Service;

namespace fourchordprojectService.DataObjects
{
    public class TodoItem : StorageData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }

      public string containerName { get; set; } //added
        public string resourceName { get; set; }
        public string sasQueryString { get; set; }
        public string imageUri { get; set; } 
    }
}