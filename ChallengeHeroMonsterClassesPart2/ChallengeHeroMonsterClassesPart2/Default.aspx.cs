using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void roundStats(int heroAttack, int monsterAttack, Character hero, Character monster)
        {
            //battleLabel.Text = String.Format("Hero does {0} damage | Monster does {1} damage", heroAttack, monsterAttack);
            battleLabel.Text +=
                String.Format("<br />Attack Results: <br />{0} attacks {1}, dealing {2} damage and leaving him with {3} health.<br /> {1} attacks {0}, dealing {4} damage and leaving him with {5} health<br />",
                monster.Name, hero.Name, monsterAttack, hero.Health, heroAttack, monster.Health); //this could be made better by creating a loop around the calls to monster and hero attack/defend that concatenate results onto the end of these strings?

        }

        private void displayResults(Character opponent1, Character opponent2)
        {
            if (opponent1.Health <= 0 && opponent2.Health <= 0)
                resultLabel.Text = String.Format("Both {0} and {1} have died.", opponent1.Name, opponent2.Name);
            else if (opponent1.Health <= 0)
                resultLabel.Text = String.Format("{0} gets the Cou de gras on {1}! {0} Wins!", opponent2.Name, opponent1.Name);
            else
                resultLabel.Text = String.Format("{0} gets the Cou de gras on {1}! {0} Wins!", opponent1.Name, opponent2.Name);
        }

        protected void battleButton_Click(object sender, EventArgs e)
        {
            resetBattlefield();
            Character hero = new Character
            {
                //set properties
                Name = "Drizzt",
                Health = 90,
                DamageMaximum = 15,
                AttackBonus = 2,
                SecondAttack = true //in this example, Drizzt has two swords so he gets two damage rolls
            };

            Character monster = new Character
            {
                //set properties
                Name = "Orc King",
                Health = 100,
                DamageMaximum = 20,
                AttackBonus = 4, //could be used to set a damage base for a character. If damage is randomized with a lower limit of 0 this could cause problems though. 
                SecondAttack = false
            };

            Dice dice = new Dice();

            //SecondAttack Logic
            


            while (hero.Health > 0 && monster.Health > 0)
            {   
                int heroAttack = hero.Attack(dice); //creates a damagetotal from the attack.
                int monsterAttack = monster.Attack(dice);

                if (hero.SecondAttack)
                monster.Defend(hero.Attack(dice));
                if (monster.SecondAttack)
                hero.Defend(hero.Attack(dice));

                hero.Defend(monsterAttack);
                monster.Defend(heroAttack); //passes the damagetotal to be subtracted from the health total.

                roundStats(heroAttack, monsterAttack, hero, monster);

            }
            displayResults(hero, monster);
            //int heroAttack = hero.Attack(dice); //creates a damagetotal from the attack.
            //monster.Defend(heroAttack); //passes the damagetotal to be subtracted from the health total.

            //int monsterAttack = monster.Attack(dice);
            //hero.Defend(monsterAttack);

            //printResults(heroAttack, monsterAttack, hero.Name, monster.Name, hero.Health, monster.Health);
        }

        private void resetBattlefield()
        {
            battleLabel.Text = "";
            resultLabel.Text = "";
        }
    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public int AttackBonus { get; set; } //setting property as a base assured damage to the attack roll.
        //if AttackBonus is declared as a bool, it could be used to determine if a character gets a second attack.
        public bool SecondAttack { get; set; }


        Random random = new Random();
        public int Attack(Dice dice) //randomly determine the amount of damage this Character object inflicted.
        {
            dice.Sides = this.DamageMaximum;
            int damage = (dice.Roll() + AttackBonus);
            return damage;
        }

        public int Defend(int damage) //deducts the damage from this Character's health
        {
            Health = Health - damage;
            return Health;
        }

    }

    class Dice
    {
        public int Sides { get; set; }

        Random random = new Random();
        public int Roll()
        {
            int diceRoll = random.Next(Sides);
            return diceRoll;
            //can also use: return random.Next(this.Sides);
        }
    }
}