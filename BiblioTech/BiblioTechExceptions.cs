using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BiblioTech
{
    public static class BiblioTechExceptions
    {
        [Serializable]
        public class BiblioTechUserAlertException : Exception
        {
            public BiblioTechUserAlertException() { }
            public BiblioTechUserAlertException(string message) : base(message) { MessageBox.Show(message); }
            public BiblioTechUserAlertException(string message, Exception inner) : base(message, inner) { MessageBox.Show(message + Environment.NewLine + inner.Message); }
            protected BiblioTechUserAlertException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
        }

        [Serializable]
        public class BiblioTechSystemAlertException : Exception
        {
            public BiblioTechSystemAlertException() { }
            public BiblioTechSystemAlertException(string message) : base(message) { return; }
            public BiblioTechSystemAlertException(string message, Exception inner) : base(message, inner) { }
            protected BiblioTechSystemAlertException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
        }

        [Serializable]
        public class XMLWriteException : BiblioTechUserAlertException
        {
            public XMLWriteException() { }
            public XMLWriteException(string message) : base(message) { return; }
            public XMLWriteException(string message, Exception inner) : base(message, inner) { }
            protected XMLWriteException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
        }
    }
}
