﻿
using System.Collections.Generic;

namespace Alumni
{
  public class MIMEType
  {
    public static string[,] SourceMIMETypes = new string[74, 3]
    {
      {
        ".aac",
        "AAC audio",
        "audio/aac"
      },
      {
        ".abw",
        "AbiWord document",
        "application/x-abiword"
      },
      {
        ".arc",
        "Archive document (multiple files embedded)",
        "application/x-freearc"
      },
      {
        ".avi",
        "AVI: Audio Video Interleave",
        "video/x-msvideo"
      },
      {
        ".azw",
        "Amazon Kindle eBook format",
        "application/vnd.amazon.ebook"
      },
      {
        ".bin",
        "Any kind of binary data",
        "application/octet-stream"
      },
      {
        ".bmp",
        "Windows OS/2 Bitmap Graphics",
        "image/bmp"
      },
      {
        ".bz",
        "BZip archive",
        "application/x-bzip"
      },
      {
        ".bz2",
        "BZip2 archive",
        "application/x-bzip2"
      },
      {
        ".csh",
        "C-Shell script",
        "application/x-csh"
      },
      {
        ".css",
        "Cascading Style Sheets (CSS)",
        "text/css"
      },
      {
        ".csv",
        "Comma-separated values (CSV)",
        "text/csv"
      },
      {
        ".doc",
        "Microsoft Word",
        "application/msword"
      },
      {
        ".docx",
        "Microsoft Word (OpenXML)",
        "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
      },
      {
        ".eot",
        "MS Embedded OpenType fonts",
        "application/vnd.ms-fontobject"
      },
      {
        ".epub",
        "Electronic publication (EPUB)",
        "application/epub+zip"
      },
      {
        ".gz",
        "GZip Compressed Archive",
        "application/gzip"
      },
      {
        ".gif",
        "Graphics Interchange Format (GIF)",
        "image/gif"
      },
      {
        ".htm",
        "HyperText Markup Language (HTML)",
        "text/html"
      },
      {
        ".html",
        "HyperText Markup Language (HTML)",
        "text/html"
      },
      {
        ".ico",
        "Icon format",
        "image/vnd.microsoft.icon"
      },
      {
        ".ics",
        "iCalendar format",
        "text/calendar"
      },
      {
        ".jar",
        "Java Archive (JAR)",
        "application/java-archive"
      },
      {
        ".jpeg",
        "JPEG images",
        "image/jpeg"
      },
      {
        ".jpg",
        "JPEG images",
        "image/jpeg"
      },
      {
        ".js",
        "JavaScript",
        "text/javascript"
      },
      {
        ".json",
        "JSON format",
        "application/json"
      },
      {
        ".jsonld",
        "JSON-LD format",
        "application/ld+json"
      },
      {
        ".mid",
        "Musical Instrument Digital Interface (MIDI)",
        "audio/midi"
      },
      {
        ".midi",
        "Musical Instrument Digital Interface (MIDI)",
        "audio/midi"
      },
      {
        ".mjs",
        "JavaScript module",
        "text/javascript"
      },
      {
        ".mp3",
        "MP3 audio",
        "audio/mpeg"
      },
      {
        ".mpeg",
        "MPEG Video",
        "video/mpeg"
      },
      {
        ".mpkg",
        "Apple Installer Package",
        "application/vnd.apple.installer+xml"
      },
      {
        ".odp",
        "OpenDocument presentation document",
        "application/vnd.oasis.opendocument.presentation"
      },
      {
        ".ods",
        "OpenDocument spreadsheet document",
        "application/vnd.oasis.opendocument.spreadsheet"
      },
      {
        ".odt",
        "OpenDocument text document",
        "application/vnd.oasis.opendocument.text"
      },
      {
        ".oga",
        "OGG audio",
        "audio/ogg"
      },
      {
        ".ogv",
        "OGG video",
        "video/ogg"
      },
      {
        ".ogx",
        "OGG",
        "application/ogg"
      },
      {
        ".opus",
        "Opus audio",
        "audio/opus"
      },
      {
        ".otf",
        "OpenType font",
        "font/otf"
      },
      {
        ".png",
        "Portable Network Graphics",
        "image/png"
      },
      {
        ".pdf",
        "Adobe Portable Document Format (PDF)",
        "application/pdf"
      },
      {
        ".php",
        "Hypertext Preprocessor (Personal Home Page)",
        "application/x-httpd-php"
      },
      {
        ".ppt",
        "Microsoft PowerPoint",
        "application/vnd.ms-powerpoint"
      },
      {
        ".pptx",
        "Microsoft PowerPoint (OpenXML)",
        "application/vnd.openxmlformats-officedocument.presentationml.presentation"
      },
      {
        ".rar",
        "RAR archive",
        "application/vnd.rar"
      },
      {
        ".rtf",
        "Rich Text Format (RTF)",
        "application/rtf"
      },
      {
        ".sh",
        "Bourne shell script",
        "application/x-sh"
      },
      {
        ".svg",
        "Scalable Vector Graphics (SVG)",
        "image/svg+xml"
      },
      {
        ".swf",
        "Small web format (SWF) or Adobe Flash document",
        "application/x-shockwave-flash"
      },
      {
        ".tar",
        "Tape Archive (TAR)",
        "application/x-tar"
      },
      {
        ".tif",
        "Tagged Image File Format (TIFF)",
        "image/tiff"
      },
      {
        ".tiff",
        "Tagged Image File Format (TIFF)",
        "image/tiff"
      },
      {
        ".ts",
        "MPEG transport stream",
        "video/mp2t"
      },
      {
        ".ttf",
        "TrueType Font",
        "font/ttf"
      },
      {
        ".txt",
        "Text, (generally ASCII or ISO 8859-n)",
        "text/plain"
      },
      {
        ".vsd",
        "Microsoft Visio",
        "application/vnd.visio"
      },
      {
        ".wav",
        "Waveform Audio Format",
        "audio/wav"
      },
      {
        ".weba",
        "WEBM audio",
        "audio/webm"
      },
      {
        ".webm",
        "WEBM video",
        "video/webm"
      },
      {
        ".webp",
        "WEBP image",
        "image/webp"
      },
      {
        ".woff",
        "Web Open Font Format (WOFF)",
        "font/woff"
      },
      {
        ".woff2",
        "Web Open Font Format (WOFF)",
        "font/woff2"
      },
      {
        ".xhtml",
        "XHTML",
        "application/xhtml+xml"
      },
      {
        ".xls",
        "Microsoft Excel",
        "application/vnd.ms-excel"
      },
      {
        ".xlsx",
        "Microsoft Excel (OpenXML)",
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
      },
      {
        ".xml",
        "XML",
        "application/xml"
      },
      {
        ".xul",
        "XUL",
        "application/vnd.mozilla.xul+xml"
      },
      {
        ".zip",
        "ZIP archive",
        "application/zip"
      },
      {
        ".3gp",
        "3GPP audio/video container",
        "video/3gpp"
      },
      {
        ".3g2",
        "3GPP2 audio/video container",
        "video/3gpp2"
      },
      {
        ".7z",
        "7-zip archive",
        "application/x-7z-compressed"
      }
    };
    public string Extension;
    public string Description;
    public string Type;
    public static Dictionary<string, MIMEType> MIMETypes = new Dictionary<string, MIMEType>();

    public static void InitializeMIMETypes()
    {
      int index = 0;
      while (index < 74)
      {
        MIMEType.MIMETypes.Add(MIMEType.SourceMIMETypes[index, 0], new MIMEType(MIMEType.SourceMIMETypes[index, 0], MIMEType.SourceMIMETypes[index, 1], MIMEType.SourceMIMETypes[index, 2]));
        checked { ++index; }
      }
    }

    public MIMEType(string Extension, string Description, string Type)
    {
      this.Extension = Extension;
      this.Description = Description;
      this.Type = Type;
    }
  }
}
