.NET Dargiz SAP API Application
=========================

This application provides an API for handling SAP requests. The application is specifically tailored for receiving cXML PunchOut requests, processing them, and sending back the required responses in cXML format.

Endpoints:
----------

1. POST: /api/Cxml
   Handles the cXML PunchOut setup request, processes the provided cXML request, extracts necessary details (like the BrowserFormPost URL) and sends back a cXML formatted response.


Getting Started:
----------------

1. **Prerequisites**:
    - .NET SDK (recommended version: ...)
    - An IDE like Visual Studio or VS Code.

2. **Running the Application**:
    - dotnet clean
    - dotnet build
    - dotnet run
   
3. Navigate to Postman or another API tool to test the endpoints.

Usage:
----------------
1. Run the postman API/CXML. This will generate back the API for the StartPage url.
2. Open the startpage url in browser and click the submit button to generate and post the CXML to BrowserFormPost URL
