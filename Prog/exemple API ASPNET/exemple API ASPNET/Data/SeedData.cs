using ProjectCosplay.Controllers;
using Microsoft.EntityFrameworkCore;

namespace ProjectCosplay.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ProjectCosplayContext(
                        serviceProvider.GetRequiredService<DbContextOptions
                        <ProjectCosplayContext>>());
                SeedDB(context);
        }
        public static void SeedDB(ProjectCosplayContext context)
        {
            if (!context.Cosplay.Any())
            {
                context.Cosplay.AddRange(
                new Models.Cosplay { Titre = "Tenu de Goku", Contenu = "YXHZVON Costume de Manga Cosplay, Déguisement pour Saiyan Dragon ball pour Halloween Fête Carnaval Party.", Image = "./image_cosplay/goku.jpg", Prix = 30.99, nbInventaire = 10, Quantite = 1, ProprietaireId = "alice" },
                new Models.Cosplay { Titre = "Tenu de Dracaufeu", Contenu = "Amscan Combinaison à capuche unisexe sous licence officielle Pokémon Charizard pour enfants.", Image = "./image_cosplay/dracaufeu.jpg", Prix = 15.55, nbInventaire = 10, Quantite = 1, ProprietaireId = "alice" },
                new Models.Cosplay { Titre = "Zyimsva Maid Outfit", Contenu = " Femme Lolita FrançAis Maid Cosplay Costume Maid Dress - Costume de maid - Costume sexy et chaussettes.", Image = "./image_cosplay/maid.jpg", Prix = 16.79, nbInventaire = 10, Quantite = 1, ProprietaireId = "alice" },
                new Models.Cosplay { Titre = "Déguisement Akatsuki", Contenu = "Adulte Enfant Cape, Akatsuki Cosplay Anneau Bandeau Bague Collier Accessoires Carnaval Tenue Manga pour Homme Femme Fille Garcon.", Image = "./image_cosplay/akatsuki.jpg", Prix = 21.66, nbInventaire = 10, Quantite = 1, ProprietaireId = "alice" },
                new Models.Cosplay { Titre = "JYakeji", Contenu = "10 pièces de cosplay japonais Demon Slayer : Kimetsu no Yaiba Nezuko Kamado Cosplay Kimono avec perruque, convient pour le cosplay.", Image = "./image_cosplay/nezuko.jpg", Prix = 49.99, nbInventaire = 10, Quantite = 1, ProprietaireId = "alice" },
                new Models.Cosplay { Titre = "GRACEART", Contenu = "Japonais Yukata Kimono Costume.", Image = "./image_cosplay/yukata.jpg", Prix = 42.99, nbInventaire = 10, Quantite = 1, ProprietaireId = "alice" });
                context.SaveChanges();
            } 
            return;
        }
    }
}
