using EfMaterialApp.Data;
using EfMaterialApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfMaterialApp.Controllers;

public class MaterialController : Controller
{
    private readonly AppDbContext _context;
    public MaterialController(AppDbContext context) => _context = context;

    // GET: /Material
    public async Task<IActionResult> Index()
    {
        var items = await _context.Materials
            .OrderByDescending(x => x.Id)
            .ToListAsync();
        ViewBag.Success = TempData["Success"];
        return View(items);
    }

    // GET: /Material/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View(new Material { PurchaseDate = DateTime.Today });
    }

    // POST: /Material/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Material model)
    {
        if (!ModelState.IsValid) return View(model);

        _context.Materials.Add(model);
        await _context.SaveChangesAsync();

        TempData["Success"] = $"Material '{model.Name}' created.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Material/Edit/5
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var entity = await _context.Materials.FindAsync(id);
        if (entity == null) return NotFound();
        return View(entity);
    }

    // POST: /Material/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Material model)
    {
        if (id != model.Id) return BadRequest();
        if (!ModelState.IsValid) return View(model);

        try
        {
            _context.Update(model); // state: Modified
            await _context.SaveChangesAsync();
            TempData["Success"] = $"Material '{model.Name}' updated.";
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Materials.AnyAsync(m => m.Id == id))
                return NotFound();
            throw;
        }
    }

    // GET: /Material/Delete/5
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _context.Materials.FindAsync(id);
        if (entity == null) return NotFound();
        return View(entity); // onay sayfası
    }

    // POST: /Material/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var entity = await _context.Materials.FindAsync(id);
        if (entity != null)
        {
            _context.Materials.Remove(entity);
            await _context.SaveChangesAsync();
            TempData["Success"] = $"Material '{entity.Name}' deleted.";
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: /Material/Details/5
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var entity = await _context.Materials.FirstOrDefaultAsync(m => m.Id == id);
        if (entity == null) return NotFound();
        return View(entity);
    }
}
