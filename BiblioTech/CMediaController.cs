using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace BiblioTech
{
    public class CTagReaderWriter : IMediaTags
    {
        private Dictionary<object, string> tags;

        public CTagReaderWriter()
        {
            tags = new Dictionary<object, string>();
        }
        public CTagReaderWriter(Dictionary<object, string> tags)
        {
            this.tags = tags;
        }

        #region IMediaTags Members

        public string this[object index]
        {
            get
            {
                return tags[index];
            }
            set
            {
                tags[index] = value;
            }
        }

        public int Count
        {
            get { return tags.Count; }
        }

        #endregion
    }

    public abstract class CMediaController : IMediaElement
    {
        private string title = string.Empty;
        private string author = string.Empty;
        private CTagReaderWriter tags = null;
        private MediaType media;
        private AccessType access;
        
        public CMediaController(string title, string author, MediaType media, AccessType access)
        {
            this.title = title;
            this.author = author;
            this.tags = new CTagReaderWriter();
            this.media = media;
            this.access = access;
        }

        #region IMediaElement Members

        public string Title
        {
            get { return this.title; }
        }

        public string Author
        {
            get { return this.author; }
        }

        public IMediaTags Tags
        {
            get { return tags; }
        }

        public MediaType Media
        {
            get { return this.media; }
        }

        public AccessType Access
        {
            get { return this.access; }
        }

        public System.Xml.XmlDocument ToXML()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IXMLItem Members

        public virtual bool Save(ref XmlDocument doc)
        {
            doc.LoadXml("<root>");

            XmlNode titleNode = doc.CreateNode(XmlNodeType.Text, "title", "");
            XmlNode authorNode = doc.CreateNode(XmlNodeType.Text, "author", "");
            XmlNode tagsNode = doc.CreateNode(XmlNodeType.Text, "tags", "");
            for (int i = 0; i < (tags as IMediaTags).Count; i++)
            {
                tagsNode.AppendChild(doc.CreateNode(XmlNodeType.Text, "tag", ""));
            }
            XmlNode mediaNode = doc.CreateNode(XmlNodeType.Text, "media", "");
            XmlNode accessNode = doc.CreateNode(XmlNodeType.Text, "access", "");

            doc.AppendChild(titleNode);
            doc.AppendChild(authorNode);
            doc.AppendChild(tagsNode);
            doc.AppendChild(mediaNode);
            doc.AppendChild(accessNode);

            return true;
        }

        public virtual bool Open(string xmlPath)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
