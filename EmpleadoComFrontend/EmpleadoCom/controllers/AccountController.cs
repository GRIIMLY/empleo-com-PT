using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    public IActionResult Logout()
    {
        // Limpiar los datos de la sesión
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}
