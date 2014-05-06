using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiblioTech
{
    public class CWebMedia : CMediaController, IWebMediaElement
    {
        private MediaLocation location;
        private WEB_METADATA meta;

        public CWebMedia(string title, string author, MediaType media, AccessType access, MediaLocation location, string url, string website, string genre, int rating, int year, bool completed)
            : base(title, author, media, access)
        {
            this.location = location;
            this.meta = new WEB_METADATA(this, url, website, genre, rating, year, completed);
        }

        #region IWebMediaElement Members

        public MediaLocation Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        public WEB_METADATA MetaData
        { 
            get { return this.meta; } 
        }

        #endregion
    }
}
