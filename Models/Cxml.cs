using System.Xml.Serialization;

namespace WebApplication_4.Models;

[XmlRoot(ElementName = "cXML")]
public class Cxml
{
    [XmlElement(ElementName = "Header")]
    public Header Header { get; set; }
    [XmlElement(ElementName = "Response")]
    public Response Response { get; set; }
    
    [XmlAttribute(AttributeName = "payloadID")]
    public string PayloadId { get; set; }
    [XmlAttribute(AttributeName = "timestamp")]
    public string Timestamp { get; set; }
}

public class Header
{
    [XmlElement(ElementName = "From")]
    public From From { get; set; }
    [XmlElement(ElementName = "To")]
    public List<To> To { get; set; }
    [XmlElement(ElementName = "Sender")]
    public Sender Sender { get; set; }
}

public class From
{
    [XmlElement(ElementName = "Credential")]
    public Credential Credential { get; set; }
}

public class To
{
    [XmlElement(ElementName = "Credential")]
    public Credential Credential { get; set; }
}

public class Sender
{
    [XmlElement(ElementName = "Credential")]
    public Credential Credential { get; set; }
    [XmlElement(ElementName = "UserAgent")]
    public string UserAgent { get; set; }
}

public class Credential
{
    [XmlElement(ElementName = "Identity")]
    public string Identity { get; set; }
    [XmlAttribute(AttributeName = "domain")]
    public string Domain { get; set; }
}

public class Request
{
    [XmlElement(ElementName = "PunchOutSetupRequest")]
    public PunchOutSetupRequest PunchOutSetupRequest { get; set; }
}

public class PunchOutSetupRequest
{
    // Add properties here for other XML elements...
}
