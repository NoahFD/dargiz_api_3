using System.Xml.Serialization;

namespace WebApplication_4.Models;

public class Response
{
    [XmlElement(ElementName = "Status")]
    public Status Status { get; set; }

    [XmlElement(ElementName = "PunchOutSetupResponse")]
    public PunchOutSetupResponse PunchOutSetupResponse { get; set; }
    
    [XmlElement(ElementName = "PunchOutOrderMessage")]
    public PunchOutOrderMessage PunchOutOrderMessage { get; set; }
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

public class Message
{
    [XmlElement(ElementName = "PunchOutOrderMessage")]
    public PunchOutOrderMessage PunchOutOrderMessage { get; set; }
}

public class PunchOutOrderMessage
{
    [XmlElement(ElementName = "BuyerCookie")]
    public string BuyerCookie { get; set; }

    [XmlElement(ElementName = "PunchOutOrderMessageHeader")]
    public PunchOutOrderMessageHeader PunchOutOrderMessageHeader { get; set; }

    [XmlElement(ElementName = "ItemIn")]
    public ItemIn ItemIn { get; set; }
}

public class PunchOutOrderMessageHeader
{
    [XmlAttribute(AttributeName = "operationAllowed")]
    public string OperationAllowed { get; set; }

    [XmlElement(ElementName = "Total")]
    public Total Total { get; set; }
}

public class Total
{
    [XmlElement(ElementName = "Money")]
    public Money Money { get; set; }
}

public class Money
{
    [XmlAttribute(AttributeName = "currency")]
    public string Currency { get; set; }

    [XmlText]
    public decimal Value { get; set; }
}

public class ItemIn
{
    [XmlAttribute(AttributeName = "quantity")]
    public int Quantity { get; set; }

    [XmlElement(ElementName = "ItemID")]
    public ItemID ItemID { get; set; }

    [XmlElement(ElementName = "ItemDetail")]
    public ItemDetail ItemDetail { get; set; }
}

public class ItemDetail
{
    [XmlElement(ElementName = "UnitPrice")]
    public UnitPrice UnitPrice { get; set; }
    
    [XmlElement(ElementName = "Description")]
    public Description Description { get; set; }
    [XmlElement(ElementName = "UnitOfMeasure")]
    public string UnitOfMeasure { get; set; }
    [XmlElement(ElementName = "Classification")]
    public Classification Classification { get; set; }
    [XmlElement(ElementName = "LeadTime")]
    public string LeadTime { get; set; }
    [XmlElement(ElementName = "ManufacturerPartID")]
    public string ManufacturerPartID { get; set; }
    [XmlElement(ElementName = "ManufacturerName ")]
    public string ManufacturerName  { get; set; }
    
    // ... other elements (Description, UnitOfMeasure, etc.)
}

public class UnitPrice
{
    [XmlElement(ElementName = "Money")]
    public Money Money { get; set; }
}


public class Description 
{
    [XmlAttribute(AttributeName = "xml:lang")]
    public string XmlLang { get; set; }
    [XmlText]
    public string DescriptionValue { get; set; }
}

public class Classification 
{
    [XmlAttribute(AttributeName = "domain")]
    public string Domain { get; set; }
    [XmlElement(ElementName = "ClassificationValue")]
    public string ClassificationValue { get; set; }
}