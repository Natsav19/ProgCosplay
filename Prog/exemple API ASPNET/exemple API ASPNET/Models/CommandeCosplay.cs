using ProjectCosplay.Models;

namespace exemple_API_ASPNET.Models
{
    public class CommandeCosplay
    {
        public int CommandeCosplayID { get; set; }
        public List<Cosplay> LstCosplay { get; set; }
        public double Prix { get; set; }
    }
}
