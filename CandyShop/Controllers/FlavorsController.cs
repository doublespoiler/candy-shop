using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CandyShop.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace CandyShop.Controllers
{
  [Authorize]
  public class FlavorsController : Controller
  {
    private readonly CandyShopContext _db;

    public FlavorsController(CandyShopContext db)
    {
      _db = db;
    }

    [AllowAnonymous]
    public ActionResult Index()
    {
      List<Flavor> model = _db.Flavors.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      var thisFlavor = _db.Flavors
          .Include(flavor => flavor.JoinEntities)
          .ThenInclude(join => join.Treat)
          .FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    public ActionResult Edit(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      List<TreatFlavor> thisFlavorJoins = _db.TreatFlavor.ToList();
      foreach(TreatFlavor tf in thisFlavorJoins)
      {
        if(tf.FlavorId == id)
        {
          _db.TreatFlavor.Remove(tf);
        }
      }
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddTreat(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(f => f.FlavorId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int TreatId)
    {
      if (TreatId != 0)
      {
        _db.TreatFlavor.Add(new TreatFlavor() { TreatId = TreatId, FlavorId = flavor.FlavorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new{ id = flavor.FlavorId});
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
      return RedirectToAction("Details", new{ id = thisJoin.FlavorId});
    }
  }
}