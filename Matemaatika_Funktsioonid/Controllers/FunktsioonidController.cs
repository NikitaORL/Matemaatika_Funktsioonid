using Matemaatika_Funktsioonid.Data;
using Matemaatika_Funktsioonid.Models;
using Microsoft.AspNetCore.Mvc;
using Matemaatika_Funktsioonid.Services;
using Microsoft.EntityFrameworkCore;

namespace Matemaatika_Funktsioonid.Controllers
{
    public class FunktsioonidController : Controller
    {
        private readonly AppDbContext _kontekst;

        public FunktsioonidController(AppDbContext kontekst)
        {
            _kontekst = kontekst;
        }

        // READ — список всех
        public async Task<IActionResult> Index()
        {
            var nimekiri = await _kontekst.FunktsiooniUurimised
                                          .OrderByDescending(f => f.LuodudAeg)
                                          .ToListAsync();
            return View(nimekiri);
        }

        // READ — подробности
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var olem = await _kontekst.FunktsiooniUurimised.FirstOrDefaultAsync(m => m.Id == id);
            if (olem == null) return NotFound();
            return View(olem);
        }

        // CREATE — GET
        public IActionResult Create() => View();

        // CREATE — POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Valem")] FunktsiooniUurimine olem)
        {
            if (!ModelState.IsValid) return View(olem);

            
            var analyys = FunktsiooniAnalyys.Analüüsi(olem.Valem);
            olem.Maaramispiirkond = analyys.Maaramispiirkond;
            olem.Tuletis = analyys.Tuletis;
            olem.KriitilisedPunktid = analyys.KriitilisedPunktid;
            olem.Ekstreemumid = analyys.Ekstreemumid;

            _kontekst.Add(olem);
            await _kontekst.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // UPDATE — GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var olem = await _kontekst.FunktsiooniUurimised.FindAsync(id);
            if (olem == null) return NotFound();
            return View(olem);
        }

        // UPDATE — POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valem")] FunktsiooniUurimine olem)
        {
            if (id != olem.Id) return NotFound();
            if (!ModelState.IsValid) return View(olem);

            var olemas = await _kontekst.FunktsiooniUurimised.FindAsync(id);
            if (olemas == null) return NotFound();

            var analyys = FunktsiooniAnalyys.Analüüsi(olem.Valem);
            olemas.Valem = olem.Valem;
            olemas.Maaramispiirkond = analyys.Maaramispiirkond;
            olemas.Tuletis = analyys.Tuletis;
            olemas.KriitilisedPunktid = analyys.KriitilisedPunktid;
            olemas.Ekstreemumid = analyys.Ekstreemumid;

            await _kontekst.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // DELETE — GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var olem = await _kontekst.FunktsiooniUurimised.FirstOrDefaultAsync(m => m.Id == id);
            if (olem == null) return NotFound();
            return View(olem);
        }

        // DELETE — POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var olem = await _kontekst.FunktsiooniUurimised.FindAsync(id);
            if (olem != null) _kontekst.FunktsiooniUurimised.Remove(olem);
            await _kontekst.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
