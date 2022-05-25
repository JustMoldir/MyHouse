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
    public class CreditHousesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CreditHousesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: CreditHouses
        public async Task<IActionResult> Index()
        {
            return View(await _context.CreditHouse.ToListAsync());
        }

        public async Task<IActionResult> Index1(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.CreditHouse
                .FirstOrDefaultAsync(m => m.CreditId == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }


        // GET: CreditHouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditHouse = await _context.CreditHouse
                .FirstOrDefaultAsync(m => m.CreditId == id);
            if (creditHouse == null)
            {
                return NotFound();
            }

            return View(creditHouse);
        }

        // GET: CreditHouses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CreditHouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreditId,UserName,KolKomnat,Price,TipStroenie,Year,Floor,Ploshad,City,PhoneNumber,Street,Sostoyanie,Internet,Bolkony,Uchastok,Text,CImageFile1,CImageFile2,CImageFile3,CImageFile4,CImageFile5,CImageFile6")] CreditHouse creditHouse)
        {
            if (ModelState.IsValid)
            {


                string wwwRootPath = _hostEnvironment.WebRootPath;

                string fileName1 = Path.GetFileNameWithoutExtension(creditHouse.CImageFile1.FileName);
                string extension1 = Path.GetExtension(creditHouse.CImageFile1.FileName);

                string fileName2 = Path.GetFileNameWithoutExtension(creditHouse.CImageFile2.FileName);
                string extension2 = Path.GetExtension(creditHouse.CImageFile2.FileName);

                string fileName3 = Path.GetFileNameWithoutExtension(creditHouse.CImageFile3.FileName);
                string extension3 = Path.GetExtension(creditHouse.CImageFile3.FileName);

                string fileName4 = Path.GetFileNameWithoutExtension(creditHouse.CImageFile4.FileName);
                string extension4 = Path.GetExtension(creditHouse.CImageFile4.FileName);

                string fileName5 = Path.GetFileNameWithoutExtension(creditHouse.CImageFile5.FileName);
                string extension5 = Path.GetExtension(creditHouse.CImageFile5.FileName);

                string fileName6 = Path.GetFileNameWithoutExtension(creditHouse.CImageFile6.FileName);
                string extension6 = Path.GetExtension(creditHouse.CImageFile6.FileName);

                creditHouse.CImageName1 = fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension1;
                string path1 = Path.Combine(wwwRootPath + "/Image/", fileName1);

                creditHouse.CImageName2 = fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension2;
                string path2 = Path.Combine(wwwRootPath + "/Image/", fileName2);

                creditHouse.CImageName3 = fileName3 = fileName3 + DateTime.Now.ToString("yymmssfff") + extension3;
                string path3 = Path.Combine(wwwRootPath + "/Image/", fileName3);

                creditHouse.CImageName4 = fileName4 = fileName4 + DateTime.Now.ToString("yymmssfff") + extension4;
                string path4 = Path.Combine(wwwRootPath + "/Image/", fileName4);

                creditHouse.CImageName5 = fileName5 = fileName5 + DateTime.Now.ToString("yymmssfff") + extension5;
                string path5 = Path.Combine(wwwRootPath + "/Image/", fileName5);

                creditHouse.CImageName6 = fileName6 = fileName6 + DateTime.Now.ToString("yymmssfff") + extension6;
                string path6 = Path.Combine(wwwRootPath + "/Image/", fileName6);



                using (var fileStream = new FileStream(path1, FileMode.Create))
                {
                    await creditHouse.CImageFile1.CopyToAsync(fileStream);
                }

                using (var fileStream = new FileStream(path2, FileMode.Create))
                {
                    await creditHouse.CImageFile2.CopyToAsync(fileStream);
                }

                using (var fileStream = new FileStream(path3, FileMode.Create))
                {
                    await creditHouse.CImageFile3.CopyToAsync(fileStream);
                }

                using (var fileStream = new FileStream(path4, FileMode.Create))
                {
                    await creditHouse.CImageFile4.CopyToAsync(fileStream);
                }

                using (var fileStream = new FileStream(path5, FileMode.Create))
                {
                    await creditHouse.CImageFile5.CopyToAsync(fileStream);
                }

                using (var fileStream = new FileStream(path6, FileMode.Create))
                {
                    await creditHouse.CImageFile6.CopyToAsync(fileStream);
                }


                _context.Add(creditHouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(creditHouse);
        }

        // GET: CreditHouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditHouse = await _context.CreditHouse.FindAsync(id);
            if (creditHouse == null)
            {
                return NotFound();
            }
            return View(creditHouse);
        }

        // POST: CreditHouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreditId,UserName,KolKomnat,Price,TipStroenie,Year,Floor,Ploshad,City,PhoneNumber,Street,Sostoyanie,Internet,Bolkony,Uchastok,Text,CImageName1,CImageName2,CImageName3,CImageName4,CImageName5,CImageName6")] CreditHouse creditHouse)
        {
            if (id != creditHouse.CreditId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creditHouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditHouseExists(creditHouse.CreditId))
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
            return View(creditHouse);
        }

        // GET: CreditHouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditHouse = await _context.CreditHouse
                .FirstOrDefaultAsync(m => m.CreditId == id);
            if (creditHouse == null)
            {
                return NotFound();
            }

            return View(creditHouse);
        }

        // POST: CreditHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creditHouse = await _context.CreditHouse.FindAsync(id);



            var imagePath1 = Path.Combine(_hostEnvironment.WebRootPath, "image", creditHouse.CImageName1);
            if (System.IO.File.Exists(imagePath1))
                System.IO.File.Delete(imagePath1);
            var imagePath2 = Path.Combine(_hostEnvironment.WebRootPath, "image", creditHouse.CImageName2);
            if (System.IO.File.Exists(imagePath2))
                System.IO.File.Delete(imagePath2);
            var imagePath3 = Path.Combine(_hostEnvironment.WebRootPath, "image", creditHouse.CImageName3);
            if (System.IO.File.Exists(imagePath3))
                System.IO.File.Delete(imagePath3);
            var imagePath4 = Path.Combine(_hostEnvironment.WebRootPath, "image", creditHouse.CImageName4);
            if (System.IO.File.Exists(imagePath4))
                System.IO.File.Delete(imagePath4);
            var imagePath5 = Path.Combine(_hostEnvironment.WebRootPath, "image", creditHouse.CImageName5);
            if (System.IO.File.Exists(imagePath5))
                System.IO.File.Delete(imagePath5);
            var imagePath6 = Path.Combine(_hostEnvironment.WebRootPath, "image", creditHouse.CImageName6);
            if (System.IO.File.Exists(imagePath6))
                System.IO.File.Delete(imagePath6);


            _context.CreditHouse.Remove(creditHouse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditHouseExists(int id)
        {
            return _context.CreditHouse.Any(e => e.CreditId == id);
        }
    }
}
