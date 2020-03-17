namespace HookahCulture.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Gallery
    {
        public Gallery()
        {
            this.ImageCollection = new HashSet<string>();
        }
        public IEnumerable<string> ImageCollection { get; set; }
    }
}
