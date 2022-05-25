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
    public class SaleHousesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SaleHousesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: SaleHouses
        public async Task<IActionResult> Index()
        {
            return View(await _context.SaleHouse.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Index(string Salesearch)
        {
            var salequery = from x in _context.SaleHouse select x;
            if (!String.IsNullOrEmpty(Salesearch))
            {
                salequery = salequery.Where(x => x.Street.Contains(Salesearch) || x.Price.Contains(Salesearch) || x.City.Contains(Salesearch) );
            }
            return View(await salequery.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Index1(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.SaleHouse
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }
        public async Task<IActionResult> Index2()
        {
            return View(await _context.SaleHouse.ToListAsync());
        }

        // GET: SaleHouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleHouse = await _context.SaleHouse
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (saleHouse == null)
            {
                return NotFound();
            }

            return View(saleHouse);
        }

        // GET: SaleHouses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaleHouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleId,UserName,KolKomnat,Price,TipStroenie,Year,Floor,Ploshad,City,PhoneNumber,Street,Sostoyanie,Internet,Bolkony,Uchastok,Text,SImageFile1,SImageFile2,SImageFile3,SImageFile4,SImageFile5,SImageFile6")] SaleHouse saleHouse)
        {
            if (ModelState.IsValid)
            {

                string wwwRootPath = _hostEnvironment.WebRootPath;

                string fileName1 = Path.GetFileNameWithoutExtension(saleHouse.SImageFile1.FileName);
                string extension1 = Path.GetExtension(saleHouse.SImageFile1.FileName);

                string fileName2 = Path.GetFileNameWithoutExtension(saleHouse.SImageFile2.FileName);
                string extension2 = Path.GetExtension(saleHouse.SImageFile2.FileName);

                string fileName3 = Path.GetFileNameWithoutExtension(saleHouse.SImageFile3.FileName);
                string extension3 = Path.GetExtension(saleHouse.SImageFile3.FileName);

                string fileName4 = Path.GetFileNameWithoutExtension(saleHouse.SImageFile4.FileName);
                string extension4 = Path.GetExtension(saleHouse.SImageFile4.FileName);

                string fileName5 = Path.GetFileNameWithoutExtension(saleHouse.SImageFile5.FileName);
                string extension5 = Path.GetExtension(saleHouse.SImageFile5.FileName);

                string fileName6 = Path.GetFileNameWithoutExtension(saleHouse.SImageFile6.FileName);
                string extension6 = Path.GetExtension(saleHouse.SImageFile6.FileName);

                saleHouse.SImageName1 = fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension1;
                string path1 = Path.Combine(wwwRootPath + "/Image/", fileName1);

                saleHouse.SImageName2 = fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension2;
                string path2 = Path.Combine(wwwRootPath + "/Image/", fileName2);

                saleHouse.SImageName3 = fileName3 = fileName3 + DateTime.Now.ToString("yymmssfff") + extension3;
                string path3 = Path.Combine(wwwRootPath + "/Image/", fileName3);

                saleHouse.SImageName4 = fileName4 = fileName4 + DateTime.Now.ToString("yymmssfff") + extension4;
                string path4 = Path.Combine(wwwRootPath + "/Image/", fileName4);

                saleHouse.SImageName5 = fileName5 = fileName5 + DateTime.Now.ToString("yymmssfff") + extension5;
                string path5 = Path.Combine(wwwRootPath + "/Image/", fileName5);

                saleHouse.SImageName6 = fileName6 = fileName6 + DateTime.Now.ToString("yymmssfff") + extension6;
                string path6 = Path.Combine(wwwRootPath + "/Image/", fileName6);



                using (var fileStream = new FileStream(path1, FileMode.Create))
                {
                    await saleHouse.SImageFile1.CopyToAsync(fileStream);
                }

                using (var fileStream = new FileStream(path2, FileMode.Create))
                {
                    await saleHouse.SImageFile2.CopyToAsync(fileStream);
                }

                using (var fileStream = new FileStream(path3, FileMode.Create))
                {
                    await saleHouse.SImageFile3.CopyToAsync(fileStream);
                }

                using (var fileStream = new FileStream(path4, FileMode.Create))
                {
                    await saleHouse.SImageFile4.CopyToAsync(fileStream);
                }

                using (var fileStream = new FileStream(path5, FileMode.Create))
                {
                    await saleHouse.SImageFile5.CopyToAsync(fileStream);
                }

                using (var fileStream = new FileStream(path6, FileMode.Create))
                {
                    await saleHouse.SImageFile6.CopyToAsync(fileStream);
                }


                _context.Add(saleHouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleHouse);
        }

        // GET: SaleHouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleHouse = await _context.SaleHouse.FindAsync(id);
            if (saleHouse == null)
            {
                return NotFound();
            }
            return View(saleHouse);
        }

        // POST: SaleHouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleId,UserName,KolKomnat,Price,TipStroenie,Year,Floor,Ploshad,City,PhoneNumber,Street,Sostoyanie,Internet,Bolkony,Uchastok,Text,SImageName1,SImageName2,SImageName3,SImageName4,SImageName5,SImageName6")] SaleHouse saleHouse)
        {
            if (id != saleHouse.SaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleHouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleHouseExists(saleHouse.SaleId))
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
            return View(saleHouse);
        }

        // GET: SaleHouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleHouse = await _context.SaleHouse
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (saleHouse == null)
            {
                return NotFound();
            }

            return View(saleHouse);
        }

        // POST: SaleHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleHouse = await _context.SaleHouse.FindAsync(id);

            //delete Image from wwwroot/Image
            var imagePath1 = Path.Combine(_hostEnvironment.WebRootPath, "image", saleHouse.SImageName1);
            if (System.IO.File.Exists(imagePath1))
                System.IO.File.Delete(imagePath1);
            var imagePath2 = Path.Combine(_hostEnvironment.WebRootPath, "image", saleHouse.SImageName2);
            if (System.IO.File.Exists(imagePath2))
                System.IO.File.Delete(imagePath2);
            var imagePath3 = Path.Combine(_hostEnvironment.WebRootPath, "image", saleHouse.SImageName3);
            if (System.IO.File.Exists(imagePath3))
                System.IO.File.Delete(imagePath3);
            var imagePath4 = Path.Combine(_hostEnvironment.WebRootPath, "image", saleHouse.SImageName4);
            if (System.IO.File.Exists(imagePath4))
                System.IO.File.Delete(imagePath4);
            var imagePath5 = Path.Combine(_hostEnvironment.WebRootPath, "image", saleHouse.SImageName5);
            if (System.IO.File.Exists(imagePath5))
                System.IO.File.Delete(imagePath5);
            var imagePath6 = Path.Combine(_hostEnvironment.WebRootPath, "image", saleHouse.SImageName6);
            if (System.IO.File.Exists(imagePath6))
                System.IO.File.Delete(imagePath6);

            _context.SaleHouse.Remove(saleHouse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleHouseExists(int id)
        {
            return _context.SaleHouse.Any(e => e.SaleId == id);
        }
    }
}
