using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserHouseRole.Data;
using UserHouseRole.Models;

namespace UserHouseRole.Controllers
{
    public class RentHousesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public RentHousesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }
        

        // GET: RentHouses
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentHouse.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Index(string Rentsearch)
        {
            var rentquery = from x in _context.RentHouse select x;
            if (!String.IsNullOrEmpty(Rentsearch))
            {
                rentquery = rentquery.Where(x => x.Street.Contains(Rentsearch) || x.Price.Contains(Rentsearch) || x.City.Contains(Rentsearch) || x.TipRent.Contains(Rentsearch));
            }
            return View(await rentquery.AsNoTracking().ToListAsync());
        }


        public async Task<IActionResult> Index1(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.RentHouse
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        public async Task<IActionResult> Index2()
        {
            return View(await _context.RentHouse.ToListAsync());
        }

        // GET: RentHouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentHouse = await _context.RentHouse
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (rentHouse == null)
            {
                return NotFound();
            }

            return View(rentHouse);
        }

        // GET: RentHouses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentHouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleId,UserName,TipRent,KolKomnat,Price,TipStroenie,Year,Floor,Ploshad,City,PhoneNumber,Street,Sostoyanie,Internet,Bolkony,Uchastok,Text,RImageFile1,RImageFile2,RImageFile3,RImageFile4,RImageFile5,RImageFile6")] RentHouse rentHouse)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;

                string fileName1 = Path.GetFileNameWithoutExtension(rentHouse.RImageFile1.FileName);
                string extension1 = Path.GetExtension(rentHouse.RImageFile1.FileName);

                string fileName2 = Path.GetFileNameWithoutExtension(rentHouse.RImageFile2.FileName);
                string extension2 = Path.GetExtension(rentHouse.RImageFile2.FileName);

                string fileName3 = Path.GetFileNameWithoutExtension(rentHouse.RImageFile3.FileName);
                string extension3 = Path.GetExtension(rentHouse.RImageFile3.FileName);

                string fileName4 = Path.GetFileNameWithoutExtension(rentHouse.RImageFile4.FileName);
                string extension4 = Path.GetExtension(rentHouse.RImageFile4.FileName);

                string fileName5 = Path.GetFileNameWithoutExtension(rentHouse.RImageFile5.FileName);
                string extension5 = Path.GetExtension(rentHouse.RImageFile5.FileName);

                string fileName6 = Path.GetFileNameWithoutExtension(rentHouse.RImageFile6.FileName);
                string extension6 = Path.GetExtension(rentHouse.RImageFile6.FileName);

                rentHouse.RImageName1 = fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension1;
                string path1 = Path.Combine(wwwRootPath + "/Image/", fileName1);

                rentHouse.RImageName2 = fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension2;
                string path2 = Path.Combine(wwwRootPath + "/Image/", fileName2);

                rentHouse.RImageName3 = fileName3 = fileName3 + DateTime.Now.ToString("yymmssfff") + extension3;
                string path3 = Path.Combine(wwwRootPath + "/Image/", fileName3);

                rentHouse.RImageName4 = fileName4 = fileName4 + DateTime.Now.ToString("yymmssfff") + extension4;
                string path4 = Path.Combine(wwwRootPath + "/Image/", fileName4);

                rentHouse.RImageName5 = fileName5 = fileName5 + DateTime.Now.ToString("yymmssfff") + extension5;
                string path5 = Path.Combine(wwwRootPath + "/Image/", fileName5);

                rentHouse.RImageName6 = fileName6 = fileName6 + DateTime.Now.ToString("yymmssfff") + extension6;
                string path6 = Path.Combine(wwwRootPath + "/Image/", fileName6);



                using (var fileStream = new FileStream(path1, FileMode.Create))
                {
                    await rentHouse.RImageFile1.CopyToAsync(fileStream);
                }

                using (var fileStream = new FileStream(path2, FileMode.Create))
                {
                    await rentHouse.RImageFile2.CopyToAsync(fileStream);
                }

                using (var fileStream = new FileStream(path3, FileMode.Create))
                {
                    await rentHouse.RImageFile3.CopyToAsync(fileStream);
                }

                using (var fileStream = new FileStream(path4, FileMode.Create))
                {
                    await rentHouse.RImageFile4.CopyToAsync(fileStream);
                }

                using (var fileStream = new FileStream(path5, FileMode.Create))
                {
                    await rentHouse.RImageFile5.CopyToAsync(fileStream);
                }

                using (var fileStream = new FileStream(path6, FileMode.Create))
                {
                    await rentHouse.RImageFile6.CopyToAsync(fileStream);
                }

                _context.Add(rentHouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentHouse);
        }

        // GET: RentHouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentHouse = await _context.RentHouse.FindAsync(id);
            if (rentHouse == null)
            {
                return NotFound();
            }
            return View(rentHouse);
        }

        // POST: RentHouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleId,UserName,TipRent,KolKomnat,Price,TipStroenie,Year,Floor,Ploshad,City,PhoneNumber,Street,Sostoyanie,Internet,Bolkony,Uchastok,Text,RImageName1,RImageName2,RImageName3,RImageName4,RImageName5,RImageName6")] RentHouse rentHouse)
        {
            if (id != rentHouse.SaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentHouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentHouseExists(rentHouse.SaleId))
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
            return View(rentHouse);
        }

        // GET: RentHouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentHouse = await _context.RentHouse
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (rentHouse == null)
            {
                return NotFound();
            }

            return View(rentHouse);
        }

        // POST: RentHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentHouse = await _context.RentHouse.FindAsync(id);

            var imagePath1 = Path.Combine(_hostEnvironment.WebRootPath, "image", rentHouse.RImageName1);
            if (System.IO.File.Exists(imagePath1))
                System.IO.File.Delete(imagePath1);
            var imagePath2 = Path.Combine(_hostEnvironment.WebRootPath, "image", rentHouse.RImageName2);
            if (System.IO.File.Exists(imagePath2))
                System.IO.File.Delete(imagePath2);
            var imagePath3 = Path.Combine(_hostEnvironment.WebRootPath, "image", rentHouse.RImageName3);
            if (System.IO.File.Exists(imagePath3))
                System.IO.File.Delete(imagePath3);
            var imagePath4 = Path.Combine(_hostEnvironment.WebRootPath, "image", rentHouse.RImageName4);
            if (System.IO.File.Exists(imagePath4))
                System.IO.File.Delete(imagePath4);
            var imagePath5 = Path.Combine(_hostEnvironment.WebRootPath, "image", rentHouse.RImageName5);
            if (System.IO.File.Exists(imagePath5))
                System.IO.File.Delete(imagePath5);
            var imagePath6 = Path.Combine(_hostEnvironment.WebRootPath, "image", rentHouse.RImageName6);
            if (System.IO.File.Exists(imagePath6))
                System.IO.File.Delete(imagePath6);

            _context.RentHouse.Remove(rentHouse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentHouseExists(int id)
        {
            return _context.RentHouse.Any(e => e.SaleId == id);
        }
    }
}
