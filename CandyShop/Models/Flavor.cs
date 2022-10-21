using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
  public class Flavor
  {
    public Flavor()
    {
      this.JoinEntities = new HashSet<TreatFlavor>();
    }

    public int FlavorId { get; set; }
    public string FlavorName { get; set; }
    public string FlavorDescription { get; set; }
    public int FlavorCost { get; set; }
    public int FlavorColor { get; set; }
    public virtual ICollection<TreatFlavor> JoinEntities { get; }
  }
}