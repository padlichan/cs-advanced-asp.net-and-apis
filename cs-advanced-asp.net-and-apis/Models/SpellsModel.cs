using System.Text.Json;

namespace cs_advanced_asp.net_and_apis.Models;

public class SpellsModel
{
    public List<Spell> GetAllSpells()
    {
        var data = File.ReadAllText("Resources/Spells.json");
        var spells = JsonSerializer.Deserialize<List<Spell>>(data);
        return spells ?? [];
    }
}
