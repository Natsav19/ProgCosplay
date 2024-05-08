namespace ProjectCosplay.Models
{
    public class Cosplay
    {
        public int CosplayID { get; set; }
        public string Titre { get; set; }
        public string Contenu { get; set; }
        public string Image { get; set; }
        public double Prix { get; set; }
        public int nbInventaire { get; set; }
        public int Quantite { get; set; }
        public string? ProprietaireId { get; set; }
    }
}
