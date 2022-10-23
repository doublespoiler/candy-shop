using System.Collections.Generic;

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
    public string FlavorColor { get; set; }
    public virtual ICollection<TreatFlavor> JoinEntities { get; }
  }
}