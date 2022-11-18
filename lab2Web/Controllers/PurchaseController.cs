using lab2Web.Data;
using lab2Web.Models;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Office.Server.UserProfiles;

namespace lab2Web.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ApplicationDbContext _db;

        //public int id1;
        public PurchaseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Purchase> objPurchaseList = _db.Purchases;
            return View(objPurchaseList);
        }

        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Purchase obj)
        {
            if (obj.PurchaseNumber.ToString() == obj.SupplierId.ToString())
            {
                ModelState.AddModelError("PurchaseNumber", "The Purhcase Number cannot excatly match the SupplierId");
            }
            if (ModelState.IsValid)
            {
                _db.Purchases.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Purchase");
            }
            return View(obj);
        }

        ////GET
        //public IActionResult Edit(int? id)
        //{

        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    //var userFromDbSingle = _db.Users.SingleOrDefault(u => u.UserId == id);
        //    //var userFromDbFirst=_db.Users.FirstOrDefault(u=u => u.UserId == id);
        //    var userFromDb = _db.Purchases.Find(id);

        //    if (userFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    //id1 = id;

        //    return View(userFromDb);
        //}

        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(User obj)
        //{

        //    //obj.UserId = id1;
        //    if (obj.UserName == obj.Address.ToString())
        //    {
        //        ModelState.AddModelError("Address", "The Address cannot excatly match the Name");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        _db.Users.Update(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");

        //    }
        //    return View(obj);
        //}


        //GET
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var userFromDbSingle = _db.Purchases.SingleOrDefault(u => u.UserId == id);

            //var userFromDb = _db.Users.Find(id);

            if (userFromDbSingle == null)
            {
                return NotFound();
            }
            //id1 = id;

            return View(userFromDbSingle);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult DeletePOST(int? id)
        //{

        //    //obj.UserId = id1;
        //    //var obj = _db.Users.Find(id);
        //    var obj = _db.Users.SingleOrDefault(u => u.UserId == id);

        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Users.Remove(obj);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public IActionResult DeletePOST(Purchase obj)
        {

            //obj.UserId = id1;
            //int id = obj.UserId;

            _db.Purchases.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
