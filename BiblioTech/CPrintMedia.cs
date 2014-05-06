using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiblioTech
{
    public class CPrintMedia : CMediaController, IPrintMediaElement
    {
        private MediaLocation location;
        private BOOK_METADATA meta;

        public CPrintMedia(string title, string author, MediaType media, AccessType access, MediaLocation location, string publisher, string genre, int rating, int year, bool completed)
            : base(title, author, media, access)
        {
            this.location = location;
            this.meta = new BOOK_METADATA(this, publisher, genre, rating, year, completed);
        }

        #region IPrintMediaElement Members

        public MediaLocation Location
        {
            get { return location; }
            set { location = value; }
        }

        public BOOK_METADATA MetaData
        {
            get { return meta; }
        }

        #endregion
    }
}
