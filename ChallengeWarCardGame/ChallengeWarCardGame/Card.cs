namespace ChallengeWarCardGame
{
    public class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }

        public int CardValue()
        {
            int value = 0;

            switch (this.Rank)
            {
                case "Jack":
                    value = 11;
                    break;
                case "Queen":
                    value = 12;
                    break;
                case "King":
                    value = 13;
                    break;
                case "Ace":
                    value = 14;
                    break;
                default:
                    value = int.Parse(this.Rank);
                    break;
            }

            return value;
        }
    }
}

    
