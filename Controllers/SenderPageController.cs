using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using WebApplication_4.Models;

namespace WebApplication_4.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class SenderPageController : Controller
{
    
    private readonly IMemoryCache _memoryCache; // Define IMemoryCache
    private static readonly HttpClient client = new HttpClient();
    public SenderPageController(IMemoryCache memoryCache) // Inject IMemoryCache through constructor
    {
        _memoryCache = memoryCache;
    }
    // GET: /SenderPage/Index
    public IActionResult Index()
    {
        return View();
    }

    // GET: /SenderPage/Welcome/ 
    [HttpPost]
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }

    [HttpPost]
    public async Task<IActionResult> ProductToSync()
    {
        if (Request.Form.ContainsKey("save"))
        {
            // Handle the logic when "save" button is pressed
            if (_memoryCache.TryGetValue("BrowserFormPostUrl", out string cachedUrl))
            {
                // Use the cached URL
                Console.WriteLine("Cached BrowserFormPost URL From My BROWSER: " + cachedUrl);
            }

            if (_memoryCache.TryGetValue("BuyerCookie", out string buyerCookie))
            {
                Console.WriteLine("Cached buyerCookie From My BROWSER: "+ buyerCookie);
            }
            
            var xmlString = ConvertToXml(GeneratePunchOutOrderMessage2(buyerCookie));
            Console.WriteLine(xmlString);
            var values = new Dictionary<string, string>
            {
                { "cXML-urlencoded", xmlString }
            };

            var content = new FormUrlEncodedContent(values);

            var response =  await client.PostAsync(cachedUrl, content);

            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
            return Content(xmlString+"-----------"+responseString);
        }
        Console.WriteLine("HI");
        // If the form doesn't contain "save", return the same view.
        return View("Index");
    }
    private string ConvertToXml(Cxml cxmlObject)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Cxml));
        StringBuilder xmlOutput = new StringBuilder();
        using (XmlWriter xmlWriter = XmlWriter.Create(xmlOutput))
        {
            xmlSerializer.Serialize(xmlWriter, cxmlObject);
        }
        return xmlOutput.ToString();
    }
        public Cxml  GeneratePunchOutOrderMessage(string buyerCookieValue)
    {
        
          var responseCxml = new Cxml
        {
            Response = new Response
            {
                PunchOutOrderMessage = new PunchOutOrderMessage
                {
                    BuyerCookie = buyerCookieValue,
                    PunchOutOrderMessageHeader = new PunchOutOrderMessageHeader
                    {
                        Total = new Total {
                            Money = new Money {
                                Currency = "USD",
                                Value = 100
                            }
                        },
                        OperationAllowed = "create"
                    },
                    ItemIn = new ItemIn {
                        Quantity = 1,
                        ItemID = new ItemID {
                            SupplierPartID = "1234",
                            SupplierPartAuxiliaryID = "additional data"
                        },
                        ItemDetail = new ItemDetail {
                            UnitPrice = new UnitPrice {
                                Money = new Money {
                                    Currency = "USD",
                                    Value = 10
                                }
                            },
                            Description = new Description {
                                XmlLang = "en",
                                DescriptionValue = "punchout order message"
                            },
                            UnitOfMeasure = "EA",
                            Classification = new Classification {
                                Domain = "SPSC",
                                ClassificationValue = "12345"
                            },
                            LeadTime = "1"
                        }
                    }
                }
            }
        };
          return responseCxml;

        // Convert the object to an XML string

    }
        
public Cxml GeneratePunchOutOrderMessage2(string buyerCookieValue)
{
    var responseCxml = new Cxml
    {
        Header = new Header
        {
            From = new From
            {
                Credential = new Credential
                {
                    Domain = "NetworkID",
                    Identity = "AN11134525901-T"
                }
            },
            To = new To
            {
                Credential = new Credential
                {
                    Domain = "NetworkID",
                    Identity = "AN01039381835-T"
                }
            },
            Sender = new Sender
            {
                Credential = new Credential
                {
                    Domain = "www.marketforgood.net.com",
                    Identity = "PunchoutResponse",
                    SharedSecret = "marketforgood"
                },
                UserAgent = "Our PunchOut Site V4.2"
            }
        },
        Message = new Message
        {
            PunchOutOrderMessage = new PunchOutOrderMessage
            {
                BuyerCookie = buyerCookieValue,
                PunchOutOrderMessageHeader = new PunchOutOrderMessageHeader
                {
                    OperationAllowed = "edit",
                    Total = new Total
                    {
                        Money = new Money
                        {
                            Currency = "USD",
                            Value = 999
                        }
                    }
                },
                ItemIn = new ItemIn
                {
                    Quantity = 2,
                    ItemID = new ItemID
                    {
                        SupplierPartID = "laptop_1",
                        SupplierPartAuxiliaryID = "white"
                    },
                    ItemDetail = new ItemDetail
                    {
                        UnitPrice = new UnitPrice
                        {
                            Money = new Money
                            {
                                Currency = "USD",
                                Value = 499
                            }
                        },
                        Description = new Description
                        {
                            XmlLang = "en",
                            DescriptionValue = "SuperBook ABC Laptop"
                        },
                        UnitOfMeasure = "EA",
                        Classification = new Classification
                        {
                            Domain = "UNSPSC",
                            ClassificationValue = "43211503"
                        },
                        ManufacturerPartID = "Manufacturer_ID_1",
                        ManufacturerName = "Tricolore",
                        LeadTime = "8",
                     
                    }
                }
            }
        }
    };

    return responseCxml;
}

}