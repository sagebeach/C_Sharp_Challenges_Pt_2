namespace ChallengeWarCardGame
{
    public class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }

        public int CardValue()
        {
            int value = 0;

            switch (this.Rank) //since deck lists are built using string values, this switch reads the card and assigns a int value for use in performEvaluation(). See Battle.cs
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
                    value = int.Parse(this.Rank); //if not a face card this parses the current card for its face value
                    break;
            }

            return value;
        }
    }
}

    
