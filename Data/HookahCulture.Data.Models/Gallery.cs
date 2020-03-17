namespace HookahCulture.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Gallery
    {
        public Gallery()
        {
            this.imageCollection = new HashSet<string>();
        }

        public IEnumerable<string> imageCollection { get; set; }
    }
}
