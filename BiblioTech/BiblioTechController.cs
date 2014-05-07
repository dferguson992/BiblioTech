using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BiblioTech
{
    public class BiblioTechController
    {
        private const string _defaultLibraryFilePath = "\\bin\\Debug\\";
        private List<IMediaElement> _library;
        private string _libraryFilePath;

        public BiblioTechController()
        {
            _library = new List<IMediaElement>();
            _libraryFilePath = _defaultLibraryFilePath;
        }

        public BiblioTechController(string librarySourceFilePath)
        {
            _libraryFilePath = librarySourceFilePath;
            _library = OpenXMLLib(_libraryFilePath);
        }

        private bool SaveXMLLib()
        {
            XmlDocument doc;
            List<IXMLItem> FailedItems = new List<IXMLItem>();
            try
            {
                foreach (var item in _library)
                {
                    doc = new XmlDocument();
                    if ((item as IXMLItem).Save(doc))
                    {
                        continue;
                    }
                    else
                    {
                        throw new BiblioTechExceptions.XMLWriteException(BiblioStrings.ExcXmlWriteFail);
                    }
                }
                return true;
            }
            catch (BiblioTechExceptions.XMLWriteException exc)
            {
                //log this exception?
                return false;
            }
        }

        private List<IMediaElement> OpenXMLLib(string XMLLocation)
        {

            return null;
        }
    }
}
