using System.Text;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using WebApplication_4.Models;

[Route("api/[controller]")]
[ApiController]
public class CxmlController : ControllerBase
{
    // POST: api/Cxml
    [HttpPost]
    public async Task<ActionResult<string>> Post()
    {
        using var reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
        var value = await reader.ReadToEndAsync();

        var serializer = new XmlSerializer(typeof(Cxml));
        using var stringReader = new StringReader(value);
        var request = (Cxml)serializer.Deserialize(stringReader);

        // Process the request here...

        var responseCxml = new Cxml
        {
            PayloadId = request.PayloadId,
            Timestamp = DateTime.Now.ToString(),
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
                        URL = "https://fournisseurtech.com/PunchOutServlet/sessionid=7006"
                    }
                }
            }
        };

        // Convert the object to an XML string
        var stringwriter = new System.IO.StringWriter();
        var serializer2 = new XmlSerializer(responseCxml.GetType());
        serializer2.Serialize(stringwriter, responseCxml);

        return Ok(stringwriter.ToString());
    }
}