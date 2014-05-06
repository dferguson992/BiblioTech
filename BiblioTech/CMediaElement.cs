using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        #endregion
    }

    public abstract class CMediaElement : IMediaElement
    {
        private string title = string.Empty;
        private string author = string.Empty;
        private CTagReaderWriter tags = null;
        private MediaType media;
        private AccessType access;
        
        public CMediaElement(string title, string author, MediaType media, AccessType access)
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

        public bool Save(System.Xml.XmlDocument doc)
        {
            throw new NotImplementedException();
        }

        public bool Open(string xmlPath)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
