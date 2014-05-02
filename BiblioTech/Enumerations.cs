
namespace BiblioTech
{
    public enum MediaType
    {
        /// <summary>
        /// Non-Fiction Book
        /// </summary>
        NF_BOOK,
        /// <summary>
        /// Fiction Book
        /// </summary>
        F_BOOK,
        /// <summary>
        /// Certification Manual
        /// </summary>
        CERTIFICATION,
        /// <summary>
        /// Books that would go on a Coffee Table
        /// </summary>
        COFFEE_TABLE,
        /// <summary>
        /// Useful Software or Website
        /// </summary>
        E_RESOURCE,
        /// <summary>
        /// Educational Material or Reference Collection
        /// </summary>
        EDU_REFERENCE,
        /// <summary>
        /// Video File
        /// </summary>
        DVD,
        /// <summary>
        /// Magazine or Journal Subscription
        /// </summary>
        PERIODICAL,
        /// <summary>
        /// PDF or other File
        /// </summary>
        E_BOOK,
        /// <summary>
        /// Scholarly Article or Paper
        /// </summary>
        ARTICLE,
    }

    public enum AccessType
    {
        /// <summary>
        /// Book, Paper, or Physical Resource
        /// </summary>
        PRINT,
        /// <summary>
        /// Locally stored File
        /// </summary>
        FILE,
        /// <summary>
        /// Web Location of Resource
        /// </summary>
        WEB,
    }

    public enum MediaLocation
    {
        /// <summary>
        /// Physical Copy at Home
        /// </summary>
        HOME,
        /// <summary>
        /// Physical Copy at Apartment
        /// </summary>
        APARTMENT,
        /// <summary>
        /// Physical Copy at School
        /// </summary>
        SCHOOL,
        /// <summary>
        /// E-Copy on Server
        /// </summary>
        SERVER,
        /// <summary>
        /// E-Copy on Web
        /// </summary>
        WEB,
    }
}