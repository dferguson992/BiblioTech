using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace BiblioTech
{
    public class CFileMedia : CMediaController, IFileMediaElement
    {
        private MediaLocation location;
        private FILE_METADATA meta;
        private string XMLDirectoryLocation;

        public CFileMedia(string title, string author, MediaType media, AccessType access, MediaLocation location, string filePath, string publisher, string genre, int rating, int year, bool completed)
            : base(title, author, media, access)
        {
            this.location = location;
            this.meta = new FILE_METADATA(this, filePath, publisher, genre, rating, completed);
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
