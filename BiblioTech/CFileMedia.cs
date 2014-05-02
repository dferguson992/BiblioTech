using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiblioTech
{
    public class CFileMedia : CMediaElement, IFileMediaElement
    {
        private MediaLocation location;
        private FILE_METADATA meta;

        public CFileMedia(string title, string author, MediaType media, AccessType access, MediaLocation location, string filePath, string publisher, string genre, int rating, int year, bool completed)
            : base(title, author, media, access)
        {
            this.location = location;
            this.meta = new FILE_METADATA(this, filePath, publisher, genre, rating, completed);
        }

        #region IFileMediaElement Members

        public MediaLocation Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        public FILE_METADATA MetaData
        {
            get { return this.meta; }
        }

        #endregion
    }
}
