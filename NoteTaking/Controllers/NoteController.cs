using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteTaking.Data;
using NoteTaking.Models;

namespace NoteTaking.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _context;
        public NoteController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Notes.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Notes.Add(note);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        public IActionResult Delete(Guid? id)
        {
           var note = _context.Notes.FirstOrDefault(note => note.Id == id);
           if (note == null)
           {
                return NotFound();
           }
            return View(note);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Note note)
        {
            //var note = _context.Notes.FirstOrDefault(note => note.Id == id);
            _context.Notes.Remove(note);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid id)
        {
            var note = _context.Notes.FirstOrDefault(note => note.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }

        public IActionResult Edit(Guid? id)
        {
            var note = _context.Notes.FirstOrDefault(note => note.Id == id);
            if(note == null)
            {
                return NotFound();
            }
            return View(note);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditConfirmed(Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Notes.Update(note);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(note);
        }
    }
}
