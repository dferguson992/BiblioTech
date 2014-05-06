using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            _library = BuildLibFromXML(_libraryFilePath);
        }

        private bool SaveXMLLib()
        {
            foreach (var item in _library)
            {
                (item as IXMLItem).Save();
            }
        }

        private List<IMediaElement> BuildLibFromXML(string XMLLocation)
        {

            return null;
        }
    }
}
