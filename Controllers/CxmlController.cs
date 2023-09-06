using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using WebApplication_4.Models;
using WebApplication_4.Utilities;
using Microsoft.Extensions.Caching.Memory;

[Route("api/[controller]")]
[ApiController]
public class CxmlController : ControllerBase
{
    
    private readonly IMemoryCache _memoryCache;
    
    public CxmlController(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    // POST: api/Cxml
    [HttpPost]
    public async Task<IActionResult> Post()
    {
        using var reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
        var value = await reader.ReadToEndAsync();

        var serializer = new XmlSerializer(typeof(Cxml));
        using var stringReader = new StringReader(value);
        var request = (Cxml)serializer.Deserialize(stringReader);

        // Process the request here...
        // Extract the BrowserFormPost URL
        string browserFormPostUrl = request.Request.PunchOutSetupRequest.BrowserFormPost.URL;


        if(!string.IsNullOrEmpty(browserFormPostUrl))
        {
            // Do something with the URL
            Console.WriteLine(browserFormPostUrl);
            // Store the URL in cache with a unique key
            _memoryCache.Set("BrowserFormPostUrl", browserFormPostUrl, TimeSpan.FromHours(1)); // Store for 1 hour
            Console.WriteLine(browserFormPostUrl);
        }
        else
        {
            // Handle the case where the URL is not found
            Console.WriteLine("BrowserFormPost URL not found!");
        }
        
        var responseCxml = new Cxml
        {
            PayloadId = request.PayloadId,
            Timestamp = DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"),
            Response = new Response
            {
                Status = new Status
                {
                    Code = 200,
                    Text = "success"
                },
                PunchOutSetupResponse = new PunchOutSetupResponse
                {
                    StartPage = new StartPage
                    {
                        //URL = "https://localhost:7269/SenderPage/Index"
                        URL = "https://dargiz-api-3.onrender.com/SenderPage/Index"
                    }
                }
            }
        };

        // Convert the object to an XML string
        var stringwriter = new Utf8StringWriter();
        var settings = new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true };

        using (var xmlWriter = XmlWriter.Create(stringwriter, settings))
        {
            xmlWriter.WriteDocType("cXML", null, "http://xml.cxml.org/schemas/cXML/1.2.048/cXML.dtd", null);


            var serializer2 = new XmlSerializer(responseCxml.GetType());
            var ns = new XmlSerializerNamespaces();
            ns.Add("", ""); // This line removes the xmlns:xsi and xmlns:xsd lines.
            serializer2.Serialize(xmlWriter, responseCxml,ns);
        }

        return new ContentResult
        {
            Content = stringwriter.ToString(),
            ContentType = "application/xml",  // Here you specify the Content-Type
            StatusCode = 200
        };
    }
    
    [HttpPost("GeneratePunchOutOrderMessage")]
    public async Task<IActionResult> GeneratePunchOutOrderMessage()
    {
        using var reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
        var value = await reader.ReadToEndAsync();

        var serializer = new XmlSerializer(typeof(Cxml));
        using var stringReader = new StringReader(value);
        var request = (Cxml)serializer.Deserialize(stringReader);

            var responseCxml = new Cxml
        {
            PayloadId = request.PayloadId,
            Timestamp = DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"),
            Response = new Response
            {
                Status = new Status
                {
                    Code = 200,
                    Text = "success"
                }
                ,
                PunchOutOrderMessage = new PunchOutOrderMessage
                {
                    BuyerCookie = "hihihi",
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
                                ClassificationValue = 12345
                            },
                            LeadTime = 1
                        }
                    }
                }
            }
        };

        // Convert the object to an XML string
        var stringwriter = new Utf8StringWriter();
        var settings = new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true };

        using (var xmlWriter = XmlWriter.Create(stringwriter, settings))
        {
            xmlWriter.WriteDocType("cXML", null, "http://xml.cxml.org/schemas/cXML/1.2.048/cXML.dtd", null);


            var serializer2 = new XmlSerializer(responseCxml.GetType());
            var ns = new XmlSerializerNamespaces();
            ns.Add("", ""); // This line removes the xmlns:xsi and xmlns:xsd lines.
            serializer2.Serialize(xmlWriter, responseCxml,ns);
        }

        return new ContentResult
        {
            Content = stringwriter.ToString(),
            ContentType = "application/xml",  // Here you specify the Content-Type
            StatusCode = 200
        };
    }

    
}
