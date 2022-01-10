using System.ComponentModel.DataAnnotations;

namespace UserInterface.Models
{
    public class CharacterViewModel : CreateCharacterViewModel
    {
        [Display(Name = "Min armor class always hit")]
        public int MinArmorClassToAlwaysHit => AttackModifer + Weapon + 1;
        
        [Display(Name = "Damage per round")]
        public int DamagePerRound => (Damage + Weapon + DamageModifer) * AttackPerRound;
    }
}