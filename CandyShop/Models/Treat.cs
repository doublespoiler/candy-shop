using System.Collections.Generic;

namespace CandyShop.Models
{
  public class Treat
  {
    public Treat()
    {
      this.JoinEntities = new HashSet<TreatFlavor>();
    }

    public int TreatId { get; set; }
    public string TreatName { get; set; }
    public string TreatDescription { get; set; }
    public int TreatCost { get; set; }
    public virtual ICollection<TreatFlavor> JoinEntities { get; }
  }
}