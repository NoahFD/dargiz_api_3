using System.Xml.Serialization;

namespace WebApplication_4.Models;

[XmlRoot(ElementName = "cXML")]
public class Cxml
{
    [XmlElement(ElementName = "Header")]
    public Header Header { get; set; }
    [XmlElement(ElementName = "Response")]
    public Response Response { get; set; }
    [XmlElement(ElementName = "Request")]
    public Request Request { get; set; }
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
    [XmlAttribute(AttributeName = "operation")]
    public string Operation { get; set; }

    [XmlElement(ElementName = "BuyerCookie")]
    public string BuyerCookie { get; set; }

    [XmlElement(ElementName = "Extrinsic")]
    public List<Extrinsic> Extrinsics { get; set; }

    [XmlElement(ElementName = "BrowserFormPost")]
    public BrowserFormPost BrowserFormPost { get; set; }

    [XmlElement(ElementName = "SupplierSetup")]
    public SupplierSetup SupplierSetup { get; set; }

    [XmlElement(ElementName = "ShipTo")]
    public ShipTo ShipTo { get; set; }

    [XmlElement(ElementName = "Contact")]
    public Contact Contact { get; set; }

    [XmlElement(ElementName = "SelectedItem")]
    public SelectedItem SelectedItem { get; set; }
}

public class Extrinsic
{
    [XmlAttribute(AttributeName = "name")]
    public string Name { get; set; }

    [XmlText]
    public string Value { get; set; }
}

public class BrowserFormPost
{
    [XmlElement(ElementName = "URL")]
    public string URL { get; set; }
}

public class SupplierSetup
{
    [XmlElement(ElementName = "URL")]
    public string URL { get; set; }
}

public class ShipTo
{
    [XmlElement(ElementName = "Address")]
    public Address Address { get; set; }
}

public class Address
{
    [XmlAttribute(AttributeName = "addressID")]
    public string AddressID { get; set; }

    [XmlElement(ElementName = "Name")]
    public Name Name { get; set; }

    [XmlElement(ElementName = "PostalAddress")]
    public PostalAddress PostalAddress { get; set; }
}

public class Name
{
    [XmlAttribute(AttributeName = "xml:lang")]
    public string Lang { get; set; }

    [XmlText]
    public string Value { get; set; }
}

public class PostalAddress
{
    [XmlElement(ElementName = "DeliverTo")]
    public string DeliverTo { get; set; }

    [XmlElement(ElementName = "Street")]
    public string Street { get; set; }

    [XmlElement(ElementName = "City")]
    public string City { get; set; }

    [XmlElement(ElementName = "State")]
    public string State { get; set; }

    [XmlElement(ElementName = "PostalCode")]
    public string PostalCode { get; set; }

    [XmlElement(ElementName = "Country")]
    public Country Country { get; set; }
}

public class Country
{
    [XmlAttribute(AttributeName = "isoCountryCode")]
    public string IsoCountryCode { get; set; }

    [XmlText]
    public string Name { get; set; }
}

public class Contact
{
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }
}

public class SelectedItem
{
    [XmlElement(ElementName = "ItemID")]
    public ItemID ItemID { get; set; }
}

public class ItemID
{
    [XmlElement(ElementName = "SupplierPartID")]
    public string SupplierPartID { get; set; }
    
    [XmlElement(ElementName = "SupplierPartAuxiliaryID")]
    public string SupplierPartAuxiliaryID { get; set; }
    
    
}

