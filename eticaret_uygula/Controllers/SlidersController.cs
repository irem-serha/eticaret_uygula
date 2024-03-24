using eticaret_uygula.Data;
using eticaret_uygula.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eticaret_uygula.Controllers
{
    public class SlidersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlidersController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: SlidersController
        public async Task<IActionResult> Index()
        {
            return _context.Slider != null ?
                View(await _context.Slider.ToListAsync()) :
                Problem("Entity set'ApplicationDbContext.Slider' is null.");
        }



        // GET: SlidersController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Slider == null)
            {
                return NotFound();
            }
            var slider = await _context.Slider.FirstOrDefaultAsync(n =>n.SliderId == id);
            if(slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // GET: SlidersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SlidersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SliderId,SliderName,Header1,Header2,Context,SliderImage")] Slider slider,IFormFile ImageUpload)
        {
            if (ImageUpload != null)
            {
                var uzanti = Path.GetExtension(ImageUpload.FileName);
                string yeniisim = Guid.NewGuid().ToString() + uzanti;
                string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Slider/" + yeniisim);
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    ImageUpload.CopyToAsync(stream);
                }
                slider.SliderImage = yeniisim;
            }
            if (ModelState.IsValid)
            {
                _context.Add(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
            
        }

        // GET: SlidersController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null|| _context.Slider == null)
            {
                return NotFound();
            }
            var slider = await _context.Slider.FindAsync(id);
            if (slider == null)
            {
                return NotFound();  
            }
            return View(slider);
        }

        // POST: SlidersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Slider slider,IFormFile ImageUpload)
        {
            if (ImageUpload != null)
            {
                var uzanti = Path.GetExtension(ImageUpload.FileName);
                string yeniisim = Guid.NewGuid().ToString() + uzanti;
                string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Slider/" + yeniisim);
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    ImageUpload.CopyToAsync(stream);
                }
                slider.SliderImage = yeniisim;
            }
            if (slider.SliderId==null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slider);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                    //
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!sliderExists(slider.SliderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(slider);
            }
            return View();
        }

        private bool sliderExists(int id)
        {
            return(_context.Slider?.Any(e=>e.SliderId == id)).GetValueOrDefault();
        }

        // GET: SlidersController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Slider == null)
            {
                return NotFound();
            }
            var slider = await _context.Slider.FirstOrDefaultAsync(n => n.SliderId == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // POST: SlidersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int SliderId)
        {
            if (_context.Slider == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Slider' is null.");
            }
            var slider = await _context.Slider.FindAsync(SliderId);
            if (slider == null)
            {
               _context.Slider.Remove(slider) ;
            }
            string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Slider/" + slider.SliderImage);
            FileInfo yolFile = new FileInfo(yol);
            if (yolFile.Exists)
            {
                System.IO.File.Delete(yolFile.FullName);
                yolFile.Delete();
            }
            _context.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
