namespace Database.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int AttackModifer { get; set; }
        public int AttackPerRound { get; set; }
        public int Damage { get; set; }
        public int DamageModifer { get; set; }
        public int Weapon { get; set; }
        public int ArmorClass { get; set; }
    }
}