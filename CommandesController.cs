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
    private static List<Commande> _commandes = new List<Commande>();
    private static int _commandeId = 1;

    // GET api/commandes
    [HttpGet]
    public ActionResult<IEnumerable<Commande>> GetCommandes()
    {
        return _commandes;
    }

    // POST api/commandes
    [HttpPost]
    public ActionResult<Commande> PostCommande([FromBody] List<Plat> plats)
    {
        var commande = new Commande
        {
            Id = _commandeId++,
            Plats = plats,
            Livre = false
        };

        _commandes.Add(commande);

        return CreatedAtAction(nameof(GetCommande), new { id = commande.Id }, commande);
    }

    // GET api/commandes/{id}
    [HttpGet("{id}")]
    public ActionResult<Commande> GetCommande(int id)
    {
        var commande = _commandes.FirstOrDefault(c => c.Id == id);

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
        var commande = _commandes.FirstOrDefault(c => c.Id == id);

        if (commande == null)
        {
            return NotFound();
        }

        commande.Livre = true;

        return NoContent();
    }

    // PUT api/commandes/{id}/plats/{platId}/etat
    [HttpPut("{id}/plats/{platId}/etat")]
    public IActionResult UpdateEtatPlat(int id, int platId, [FromBody] EtatPlat etat)
    {
        var commande = _commandes.FirstOrDefault(c => c.Id == id);

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

        return NoContent();
    }
}
