using BLL.Services;
using iText.Html2pdf;

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.DTOs;
using System.Linq;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/pdf")]
    public class PdfController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetPdf()
        {
            try
            {
                var product = ProductService.GetProduct().Last();

                var html = $@"
                    <!DOCTYPE html>
                    <html lang='en'>
                    <head>
                        <meta charset='UTF-8'>
                        <title>Title</title>
                    </head>
                    <body>
                        <h1 style='text-align: center'>Wise Trips</h1>
                        <h2>Product Details</h2>
                        <p><b>Product Name: </b> {product.Name}</p>
                        <p><b>Product Description: </b>{product.Description}</p>
                        <p><b>Product Price: </b>{product.Price}</p>
                        <p><b>Product Quantity: </b>{product.Quantity}</p>
                    </body>
                    </html>";

                var mapPath = HostingEnvironment.MapPath("~\\PDF\\");
                var filename = product.Name + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                var pdfPath = mapPath + filename + ".pdf";
                var serverPdfPath = "https://localhost:44366/PDF/" + filename + ".pdf";

                CreatePdf("https://localhost:44359", html, pdfPath);

                return Request.CreateResponse(HttpStatusCode.OK, serverPdfPath);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to generate PDF");
            }
        }

        private void CreatePdf(string baseUri, string html, string destination)
        {
            var prop = new ConverterProperties();
            prop.SetBaseUri(baseUri);
            HtmlConverter.ConvertToPdf(html, new FileStream(destination, FileMode.Create), prop);
        }
    }
}
