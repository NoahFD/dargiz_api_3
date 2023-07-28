using System.Xml.Serialization;

namespace WebApplication_4.Models;

public class Response
{
    [XmlElement(ElementName = "Status")]
    public Status Status { get; set; }

    [XmlElement(ElementName = "PunchOutSetupResponse")]
    public PunchOutSetupResponse PunchOutSetupResponse { get; set; }
}

public class Status
{
    [XmlAttribute(AttributeName = "code")]
    public int Code { get; set; }

    [XmlAttribute(AttributeName = "text")]
    public string Text { get; set; }
}

public class PunchOutSetupResponse
{
    [XmlElement(ElementName = "StartPage")]
    public StartPage StartPage { get; set; }
}

public class StartPage
{
    [XmlElement(ElementName = "URL")]
    public string URL { get; set; }
}

