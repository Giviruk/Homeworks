using System.ComponentModel.DataAnnotations;

namespace UserInterface.Models
{
    public class CreateCharacterViewModel
    {
        [Required]
        public string Name { get; set; }
        
        [Display(Name = "Hit points" )]
        public int HitPoints { get; set; }
        
        [Display(Name = "AttackModifer")]
        public int AttackModifer { get; set; }
        
        [Display(Name = "Attack per round")]
        public int AttackPerRound { get; set; }
        
        public int Damage { get; set; }
        
        [Display(Name = "Damage modifer")]
        public int DamageModifer { get; set; }
        public int Weapon { get; set; }
        
        [Display(Name = "Armor class")]
        public int ArmorClass { get; set; }
    }
}