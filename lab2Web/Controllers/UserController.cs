using lab2Web.Data;
using lab2Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.Office.Server.UserProfiles;

namespace lab2Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        //public int id1;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        //[Authorize]
        public IActionResult Index()
        {
            IEnumerable<User> objUserList = _db.Users;
            return View(objUserList);
        }

        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {
            if (obj.UserName == obj.Address.ToString())
            {
                ModelState.AddModelError("Address", "The Address cannot excatly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Users.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var userFromDbSingle = _db.Users.SingleOrDefault(u => u.UserId == id);
            //var userFromDbFirst=_db.Users.FirstOrDefault(u=u => u.UserId == id);
            var userFromDb = _db.Users.Find(id);

            if (userFromDb == null)
            {
                return NotFound();
            }
            //id1 = id;

            return View(userFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User obj)
        {

            //obj.UserId = id1;
            if (obj.UserName == obj.Address.ToString())
            {
                ModelState.AddModelError("Address", "The Address cannot excatly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Users.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }


        //GET
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var userFromDbSingle = _db.Users.SingleOrDefault(u => u.UserId == id);

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

        public IActionResult DeletePOST(User obj)
        {

            //obj.UserId = id1;
            int id = obj.UserId;

            _db.Users.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
