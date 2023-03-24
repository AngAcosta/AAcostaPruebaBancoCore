using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class BancoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Banco banco = new ML.Banco();
            ML.Result result = BL.Banco.GetAll();


            if (result.Correct)
            {
                banco.Bancos = result.Objects;
                return View(banco);
            }
            else
            {
                return View(banco);
            }
        }

        [HttpGet]
        public ActionResult Delete(int IdBanco)
        {
            ML.Result result = BL.Banco.Delete(IdBanco);

            if (result.Correct)
            {
                ViewBag.Message = " Banco Eliminado" ;
            }
            else
            {
                ViewBag.Message = " Banco No Eliminado";
            }
            return View("Modal");
        }

        [HttpPost]
        public ActionResult Form(int? IdBanco)
        {
            if (IdBanco != 1)
            {
               //ML.Result = new BL.Banco.Add();

            }
            return View("Modal");
        }
    }
}