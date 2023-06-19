using System.Xml.Serialization;

[Serializable, XmlRoot("root")]
public record Resource
{
    [XmlElement("data")]
    public Data[] Data;
    [XmlElement("resheader")]
    public Resheader[] Resheaders;
}

public record Resheader
{
    [XmlAttribute("name")]
    public string Name;
    [XmlElement("value")]
    public string Value;
}

public record Data
{
    [XmlAttribute("name")]
    public string Name;
    [XmlAttribute("mimetype")]
    public string Mimetype;
    [XmlAttribute("xml:space")]
    public string XmlSpace;
    [XmlElement("value")]
    public string Value;
    [XmlElement("comment")]
    public string Comment;
}

public static class Constants
{
    public static string MetadataMimeType = "application/x-microsoft.net.object.binary.base64";
}