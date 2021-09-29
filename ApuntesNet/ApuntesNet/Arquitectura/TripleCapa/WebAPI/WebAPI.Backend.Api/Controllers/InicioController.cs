using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Frontend.Api.Controllers {
    public class InicioController : BaseApiController {

        [HttpGet]
        [Route("")]
        public ContentResult Inicio() {
            var app = Assembly.GetExecutingAssembly().GetName();
            return Content(
                       "<html>" +
                       "<head>" +
                       $"<title>{app.Name}</title>" +
                       "<style>" +
                       "body{background:#c70700;}" +
                       "h2{text-align:center; margin:20%;color:#000;background:#f5f5f1;padding:25px;}" +
                       "</style>" +
                       "</head>" +
                       "<body>" +
                       $"<h2>{app.Name} ({app.Version}) is running...</h2>" +
                       "</body>" +
                       "</html>",
                "text/html",
                Encoding.UTF8
            );
        }
    }
}
