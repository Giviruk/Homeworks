namespace UserInterface.Models
{
    public class GameViewModel
    {
        public GameViewModel(MonsterViewModel monsterViewModel, CharacterViewModel characterViewModel)
        {
            MonsterViewModel = monsterViewModel;
            CharacterViewModel = characterViewModel;
        }
        
        public GameViewModel(){}
        public readonly MonsterViewModel MonsterViewModel;
        public readonly CharacterViewModel CharacterViewModel;
    }
}