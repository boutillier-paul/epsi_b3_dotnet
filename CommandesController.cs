using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


public class Commande
{
    public int Id { get; set; }
    public List<Plat> Plats { get; set; }
    public bool Livre { get; set; }
}

public class Plat
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public EtatPlat Etat { get; set; }
}

public enum EtatPlat
{
    CommandeEnregistree,
    EnPreparation,
    Livre
}

[Route("api/[controller]")]
[ApiController]
public class CommandesController : ControllerBase
{
    private readonly SqlLiteDbContext _dbContext;

    public CommandesController(SqlLiteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET api/commandes
    [HttpGet]
    public ActionResult<IEnumerable<Commande>> GetCommandes()
    {
        var commandes = _dbContext.Commandes.ToList();
        return commandes;
    }

    // POST api/commandes
    [HttpPost]
    public ActionResult<Commande> PostCommande([FromBody] List<Plat> plats)
    {
        var commande = new Commande
        {
            Id = _dbContext.Commandes.Count() + 1,
            Plats = plats,
            Livre = false
        };

        _dbContext.Commandes.Add(commande);
        _dbContext.SaveChanges();

        return CreatedAtAction(nameof(GetCommande), new { id = commande.Id }, commande);
    }

    // GET api/commandes/{id}
    [HttpGet("{id}")]
    public ActionResult<Commande> GetCommande(int id)
    {
        var commande = _dbContext.Commandes.FirstOrDefault(c => c.Id == id);

        if (commande == null)
        {
            return NotFound();
        }

        return commande;
    }

    // PUT api/commandes/{id}/livre
    [HttpPut("{id}/livre")]
    public IActionResult MarkCommandeLivre(int id)
    {
        var commande = _dbContext.Commandes.FirstOrDefault(c => c.Id == id);

        if (commande == null)
        {
            return NotFound();
        }

        commande.Livre = true;
        _dbContext.SaveChanges();

        return NoContent();
    }

    // PUT api/commandes/{id}/plats/{platId}/etat
    [HttpPut("{id}/plats/{platId}/etat")]
    public IActionResult UpdateEtatPlat(int id, int platId, [FromBody] EtatPlat etat)
    {
        var commande = _dbContext.Commandes.FirstOrDefault(c => c.Id == id);

        if (commande == null)
        {
            return NotFound();
        }

        var plat = commande.Plats.FirstOrDefault(p => p.Id == platId);

        if (plat == null)
        {
            return NotFound();
        }

        plat.Etat = etat;
        _dbContext.SaveChanges();

        return NoContent();
    }
}
