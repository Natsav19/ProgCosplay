namespace ProjectCosplay.Models
{
    public class CommandeCosplay
    {
        public int CommandeCosplayID { get; set; }
        public Cosplay cosplay { get; set; }
        public int Quantité { get; set; }
        public int Prix { get; set; }
    }
}
