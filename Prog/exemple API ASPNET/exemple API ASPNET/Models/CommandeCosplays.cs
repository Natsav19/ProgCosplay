namespace ProjectCosplay.Models
{
    public class CommandeCosplays
    {
        public int CommandeCosplaysID { get; set; }
        public int CosplayID { get; set; }
        public double Prix { get; set; }
        public string Titre { get; set; }
        public int Quantite { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string ClientNom { get; set; }
    }
}
