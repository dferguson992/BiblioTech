using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace BiblioTech
{
    public class CPrintMedia : CMediaController, IPrintMediaElement
    {
        private MediaLocation location;
        private BOOK_METADATA meta;
        private string XMLDirectoryLocation;

        public CPrintMedia(string title, string author, MediaType media, AccessType access, MediaLocation location, string publisher, string genre, int rating, int year, bool completed)
            : base(title, author, media, access)
        {
            this.location = location;
            this.meta = new BOOK_METADATA(this, publisher, genre, rating, year, completed);
            XMLDirectoryLocation = base.Title;
        }

        public override bool Save(ref XmlDocument doc)
        {
            base.Save(ref doc);

            XmlNode locationNode = doc.CreateNode(XmlNodeType.Text, "location", "");
            XmlNode metaNode = doc.CreateNode(XmlNodeType.Text, "metaData", "");
            MetaData.Save(ref doc);

            using (StreamWriter s = new StreamWriter(XMLDirectoryLocation))
            {
                XmlWriter writer = XmlWriter.Create(s);
                writer.WriteStartDocument();
                doc.WriteContentTo(writer);
            }
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
