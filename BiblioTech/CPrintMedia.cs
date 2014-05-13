using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

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

        public override bool Save(ref System.Xml.XmlDocument doc)
        {
            base.Save(ref doc);

            XmlNode locationNode = doc.CreateNode(XmlNodeType.Text, "location", "");
            XmlNode metaNode = doc.CreateNode(XmlNodeType.Text, "metaData", "");
            MetaData.Save(ref doc);


            return true;

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
