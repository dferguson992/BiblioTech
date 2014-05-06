using System.Xml;

namespace BiblioTech
{
    public interface IXMLItem
    {
        bool Save(XmlDocument doc);
        bool Open(string xmlPath);
    }

    public interface IMediaElement : IXMLItem
    {
        string Title { get; }
        string Author { get; }
        IMediaTags Tags { get; }
        MediaType Media { get; }
        AccessType Access { get; }

        XmlDocument ToXML();

    }
    public interface IMediaTags
    {
        string this[object index] { get; set; }
    }

    public interface IPrintMediaElement : IMediaElement
    {
        MediaLocation Location { get; set; }
        BOOK_METADATA MetaData { get; }
    }

    public interface IFileMediaElement : IMediaElement
    {
        MediaLocation Location { get; set; }
        FILE_METADATA MetaData { get; }
    }

    public interface IWebMediaElement : IMediaElement
    {
        MediaLocation Location { get; set; }
        WEB_METADATA MetaData { get; }
    }
}