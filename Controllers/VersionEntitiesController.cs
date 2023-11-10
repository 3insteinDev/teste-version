using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teste_version.Data;
using teste_version.Entities;

namespace teste_version.Controllers
{
    public class VersionEntitiesController : Controller
    {
        private readonly DataContext _context;

        public VersionEntitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: VersionEntities
        public async Task<IActionResult> Index()
        {
              return _context.VersionEntities != null ? 
                          View((await _context.VersionEntities.ToListAsync()).OrderByDescending(x => x.Data)) :
                          Problem("Entity set 'DataContext.VersionEntities'  is null.");
        }

        // GET: VersionEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VersionEntities == null)
            {
                return NotFound();
            }

            var versionEntity = await _context.VersionEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (versionEntity == null)
            {
                return NotFound();
            }

            return View(versionEntity);
        }

        // GET: VersionEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VersionEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Projeto,Versao,Descricao,Data")] VersionEntity versionEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(versionEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(versionEntity);
        }

        // GET: VersionEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VersionEntities == null)
            {
                return NotFound();
            }

            var versionEntity = await _context.VersionEntities.FindAsync(id);
            if (versionEntity == null)
            {
                return NotFound();
            }
            return View(versionEntity);
        }

        // POST: VersionEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Projeto,Versao,Descricao,Data")] VersionEntity versionEntity)
        {
            if (id != versionEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(versionEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VersionEntityExists(versionEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(versionEntity);
        }

        // GET: VersionEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VersionEntities == null)
            {
                return NotFound();
            }

            var versionEntity = await _context.VersionEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (versionEntity == null)
            {
                return NotFound();
            }

            return View(versionEntity);
        }

        // POST: VersionEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VersionEntities == null)
            {
                return Problem("Entity set 'DataContext.VersionEntities'  is null.");
            }
            var versionEntity = await _context.VersionEntities.FindAsync(id);
            if (versionEntity != null)
            {
                _context.VersionEntities.Remove(versionEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VersionEntityExists(int id)
        {
          return (_context.VersionEntities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
