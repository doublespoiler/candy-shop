using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CandyShop.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CandyShop.Controllers
{
  [Authorize]
  public class TreatsController : Controller
  {
    private readonly CandyShopContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public TreatsController(UserManager<ApplicationUser> userManager, CandyShopContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [AllowAnonymous]
    public ActionResult Index()
    {
      List<Treat> model = _db.Treats.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Treat treat)
    {
      _db.Treats.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      var thisTreat = _db.Treats
          .Include(treat => treat.JoinEntities)
          .ThenInclude(join => join.Flavor)
          .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    public ActionResult Edit(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      _db.Entry(treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddFlavor(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int FlavorId)
    {
      if (FlavorId != 0)
      {
        _db.TreatFlavor.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = treat.TreatId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      List<TreatFlavor> thisTreatJoins = _db.TreatFlavor.ToList();
      foreach(TreatFlavor tf in thisTreatJoins)
      {
        if(tf.TreatId == id)
        {
          _db.TreatFlavor.Remove(tf);
        }
      }
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Remove(int id)
    {
      var thisJoin = _db.TreatFlavor.FirstOrDefault(treatflavor => treatflavor.TreatFlavorId == id);
      return View(thisJoin);
    }

    [HttpPost, ActionName("Remove")]
    public ActionResult RemoveConfirm(int id)
    {
      var thisJoin = _db.TreatFlavor.FirstOrDefault(treatflavor => treatflavor.TreatFlavorId == id);
      _db.TreatFlavor.Remove(thisJoin);
      _db.SaveChanges();
      return RedirectToAction("Details", new{ id = thisJoin.TreatId});
    }
  }
}