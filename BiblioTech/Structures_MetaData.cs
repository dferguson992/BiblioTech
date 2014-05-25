using System.IO;
using System.Text;
using System.Xml;

namespace BiblioTech
{
    public struct BOOK_METADATA : IXMLItem
    {
        private IMediaElement host;
        private string publisher;
        private string genre;
        private int rating;
        private int year;
        private bool completed;
        public BOOK_METADATA(IMediaElement host, string publisher, string genre, int rating, int year, bool completed)
        {
            this.host = host;
            this.publisher = publisher;
            this.genre = genre;
            this.rating = rating;
            this.year = year;
            this.completed = completed;
        }
        public string Publisher { get { return this.publisher; } }
        public string Genre { get { return this.genre; } }
        public int Rating { get { return this.rating; } }
        public int Year { get { return this.year; } }
        public bool Completed { get { return this.completed; } set { completed = value; } }

        private static class XmlKeys
        {
            public static string XML_BookMetaData { get { return "bookmetadata"; } }
            public static string XML_Publisher { get { return "publisher"; } }
            public static string XML_Genre { get { return "genre"; } }
            public static string XML_Rating { get { return "rating"; } }
            public static string XML_Year { get { return "year"; } }
            public static string XML_Completed { get { return "completed"; } }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Publisher => " + Publisher);
            sb.AppendLine("Genre => " + Genre);
            sb.AppendLine("Rating => " + Rating);
            sb.AppendLine("Year => " + Year);
            sb.AppendLine("Completed => " + Completed);
            return sb.ToString();
        }

        public XmlDocument ToXML()
        {
            XmlDocument document = new XmlDocument();

            XmlElement PublisherElement = document.CreateElement(XmlKeys.XML_Publisher);
            XmlElement GenreElement = document.CreateElement(XmlKeys.XML_Genre);
            XmlElement RatingElement = document.CreateElement(XmlKeys.XML_Rating);
            XmlElement YearElement = document.CreateElement(XmlKeys.XML_Year);
            XmlElement CompletedElement = document.CreateElement(XmlKeys.XML_Completed);

            PublisherElement.InnerText = Publisher;
            GenreElement.InnerText = Genre;
            RatingElement.InnerText = Rating.ToString();
            YearElement.InnerText = Year.ToString();
            CompletedElement.InnerText = Completed.ToString();

            document.DocumentElement.AppendChild(PublisherElement);
            document.DocumentElement.AppendChild(GenreElement);
            document.DocumentElement.AppendChild(RatingElement);
            document.DocumentElement.AppendChild(YearElement);
            document.DocumentElement.AppendChild(CompletedElement);

            return document;
        }

        public bool Save(ref XmlDocument doc)
        {
            XmlNode metaDataNode = doc.CreateNode(XmlKeys.XML_BookMetaData, "metadata", "");
            XmlDocument metaDoc = ToXML();
            foreach (var item in metaDoc.ChildNodes)
            {
                metaDataNode.AppendChild(item as XmlNode);
            }
            doc.AppendChild(metaDataNode);
            return true;
        }

        public bool Open(string xmlPath)
        {
            throw new System.NotImplementedException();
        }
    }

    public struct FILE_METADATA : IXMLItem
    {
        private IMediaElement host;
        private string filePath;
        private string fileName;
        private string fileExt;
        private string fileDirectory;
        private string publisher;
        private string genre;
        private int rating;
        private bool completed;
        public FILE_METADATA(IMediaElement host, string filePath, string publisher, string genre, int rating, bool completed)
        {
            this.host = host;
            this.filePath = Path.GetFullPath(filePath);
            this.fileName = Path.GetFileName(this.filePath);
            this.fileExt = Path.GetExtension(this.filePath);
            this.fileDirectory = Path.GetDirectoryName(this.filePath);
            this.publisher = publisher;
            this.genre = genre;
            this.rating = rating;
            this.completed = completed;
        }
        public string FilePath { get { return this.filePath; } }
        public string FileName { get { return this.fileName; } }
        public string FileExt { get { return this.fileExt; } }
        public string FileDirectory { get { return this.fileDirectory; } }
        public string Publisher { get { return this.publisher; } }
        public string Genre { get { return this.genre; } }
        public int Rating { get { return this.rating; } }
        public bool Completed { get { return this.completed; } set { completed = value; } }

        public static class XmlKeys
        {
            public static string XML_FileMetaData { get { return "filemetadata"; } }
            public static string XML_FilePath { get { return "filePath"; } }
            public static string XML_FileName { get { return "fileName"; } }
            public static string XML_FileExt { get { return "fileExt"; } }
            public static string XML_FileDirectory { get { return "fileDirectory"; } }
            public static string XML_Publisher { get { return "publisher"; } }
            public static string XML_Genre { get { return "genre"; } }
            public static string XML_Rating { get { return "rating"; } }
            public static string XML_Completed { get { return "completed"; } }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("File Path => " + FilePath);
            sb.AppendLine("File Name => " + FileName);
            sb.AppendLine("File Ext => " + FileExt);
            sb.AppendLine("File Directory => " + FileDirectory);
            sb.AppendLine("Publisher => " + Publisher);
            sb.AppendLine("Genre => " + Genre);
            sb.AppendLine("Rating => " + Rating);
            sb.AppendLine("Completed => " + Completed);
            return sb.ToString();
        }

        public XmlDocument ToXML()
        {
            XmlDocument document = new XmlDocument();

            XmlElement FilePathElement = document.CreateElement(XmlKeys.XML_FilePath);
            XmlElement FileNameElement = document.CreateElement(XmlKeys.XML_FileName);
            XmlElement FileExtElement = document.CreateElement(XmlKeys.XML_FileExt);
            XmlElement FileDirectoryElement = document.CreateElement(XmlKeys.XML_FileDirectory);
            XmlElement PublisherElement = document.CreateElement(XmlKeys.XML_Publisher);
            XmlElement GenreElement = document.CreateElement(XmlKeys.XML_Genre);
            XmlElement RatingElement = document.CreateElement(XmlKeys.XML_Rating);
            XmlElement CompletedElement = document.CreateElement(XmlKeys.XML_Completed);

            FilePathElement.InnerText = FilePath;
            FileNameElement.InnerText = FileName;
            FileExtElement.InnerText = FileExt;
            FileDirectoryElement.InnerText = FileDirectory;
            PublisherElement.InnerText = Publisher;
            GenreElement.InnerText = Genre;
            RatingElement.InnerText = Rating.ToString();
            CompletedElement.InnerText = Completed.ToString();

            document.DocumentElement.AppendChild(FilePathElement);
            document.DocumentElement.AppendChild(FileNameElement);
            document.DocumentElement.AppendChild(FileExtElement);
            document.DocumentElement.AppendChild(FileDirectoryElement);
            document.DocumentElement.AppendChild(PublisherElement);
            document.DocumentElement.AppendChild(GenreElement);
            document.DocumentElement.AppendChild(RatingElement);
            document.DocumentElement.AppendChild(CompletedElement);

            return document;
        }

        public bool Save(ref XmlDocument doc)
        {
            XmlNode metaDataNode = doc.CreateNode(XmlKeys.XML_FileMetaData, "metadata", "");
            XmlDocument metaDoc = ToXML();
            foreach (var item in metaDoc.ChildNodes)
            {
                metaDataNode.AppendChild(item as XmlNode);
            }
            doc.AppendChild(metaDataNode);
            return true;
        }

        public bool Open(string xmlPath)
        {
            throw new System.NotImplementedException();
        }
    }

    public struct WEB_METADATA : IXMLItem
    {
        private IMediaElement host;
        private string url;
        private string website;
        private string genre;
        private int rating;
        private bool completed;
        public WEB_METADATA(IMediaElement host, string url, string website, string genre, int rating, int year, bool completed)
        {
            this.host = host;
            this.url = url;
            this.website = website;
            this.genre = genre;
            this.rating = rating;
            this.completed = completed;
        }
        public string URL { get { return this.url; } }
        public string Website { get { return this.website; } }
        public string Genre { get { return this.genre; } }
        public int Rating { get { return this.rating; } }
        public bool Completed { get { return this.completed; } set { completed = value; } }

        public static class XmlKeys
        {
            public static string XML_WebMetaData { get { return "webmetadata"; } }
            public static string XML_URL { get { return "url"; } }
            public static string XML_Website { get { return "website"; } }
            public static string XML_Genre { get { return "genre"; } }
            public static string XML_Rating { get { return "rating"; } }
            public static string XML_Completed { get { return "completed"; } }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("URL => " + URL);
            sb.AppendLine("Website => " + Website);
            sb.AppendLine("Genre => " + Genre);
            sb.AppendLine("Rating => " + Rating);
            sb.AppendLine("Completed => " + Completed);
            return sb.ToString();
        }

        public XmlDocument ToXML()
        {
            XmlDocument document = new XmlDocument();

            XmlElement URLElement = document.CreateElement(XmlKeys.XML_URL);
            XmlElement WebsiteElement = document.CreateElement(XmlKeys.XML_Website);
            XmlElement GenreElement = document.CreateElement(XmlKeys.XML_Genre);
            XmlElement RatingElement = document.CreateElement(XmlKeys.XML_Rating);
            XmlElement CompletedElement = document.CreateElement(XmlKeys.XML_Completed);

            URLElement.InnerText = URL;
            WebsiteElement.InnerText = Website;
            GenreElement.InnerText = Genre;
            RatingElement.InnerText = Rating.ToString();
            CompletedElement.InnerText = Completed.ToString();

            document.DocumentElement.AppendChild(URLElement);
            document.DocumentElement.AppendChild(WebsiteElement);
            document.DocumentElement.AppendChild(GenreElement);
            document.DocumentElement.AppendChild(RatingElement);
            document.DocumentElement.AppendChild(CompletedElement);

            return document;
        }

        public bool Save(ref XmlDocument doc)
        {
            XmlNode metaDataNode = doc.CreateNode(XmlKeys.XML_WebMetaData, "metadata", "");
            XmlDocument metaDoc = ToXML();
            foreach (var item in metaDoc.ChildNodes)
            {
                metaDataNode.AppendChild(item as XmlNode);
            }
            doc.AppendChild(metaDataNode);
            return true;
        }

        public bool Open(string xmlPath)
        {
            throw new System.NotImplementedException();
        }
    }
}