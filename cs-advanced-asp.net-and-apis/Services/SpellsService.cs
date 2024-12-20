using cs_advanced_asp.net_and_apis.Models;

namespace cs_advanced_asp.net_and_apis.Services;

public class SpellsService(SpellsModel spellsModel)
{
    private readonly SpellsModel spellsModel = spellsModel;

    public List<Spell> GetSpells()
    {
        return spellsModel.GetAllSpells();
    }

    public Spell? GetSpell()
    {
        return spellsModel.GetRandomSpell();
    }
}
