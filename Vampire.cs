using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innuendo
{
    [Serializable]
    class Vampire : Character
    {
        // Vampire-type character stats, specific to vampires only.
        public Attribute clan = new Attribute();
        public Attribute bloodline = new Attribute();
        public Attribute clan_flaw = new Attribute();
        public Attribute generation = new Attribute();
        public Attribute bloodpool = new Attribute();

        // Disiplines are the powers a vampire uses, so this will be the name for the powers that the primary Form will save the powers data to.

        public ArrayList disiplines_list = new ArrayList();

        public Vampire(bool test_mode)
        {
            // When a vampire object is created, all of the relevant stats will be entered into an ArrayList.

            theCharacter.Add(char_Name);
            theCharacter.Add(player_Name);
            theCharacter.Add(phy_Strength);
            theCharacter.Add(phy_Stamina);
            theCharacter.Add(phy_Dexterity);
            theCharacter.Add(men_Wit);
            theCharacter.Add(men_Intellect);
            theCharacter.Add(men_Resolve);
            theCharacter.Add(soc_Charisma);
            theCharacter.Add(soc_Manipulation);
            theCharacter.Add(soc_Composure);
            theCharacter.Add(temp_Willpower);
            theCharacter.Add(perm_Willpower);
            theCharacter.Add(morality);
            theCharacter.Add(gender);
            theCharacter.Add(age);
            theCharacter.Add(genre);
            theCharacter.Add(nature);
            theCharacter.Add(demeanor);
            theCharacter.Add(virtue_Conscience);
            theCharacter.Add(virtue_Courage);
            theCharacter.Add(virtue_Self_Control);
            theCharacter.Add(bloodline);

            // Vampire class-specific additions
            theCharacter.Add(clan);
            theCharacter.Add(clan_flaw);
            theCharacter.Add(faction);
            theCharacter.Add(generation);
            theCharacter.Add(bloodpool);

            if (test_mode)
            {
                char_Name.Title = "Character Name";
                char_Name.Text = "Alexander DuMayne";
                char_Name.Numeric = -1;

                player_Name.Title = "Player Name";
                player_Name.Text = "William Wallace";
                player_Name.Numeric = -1;

                phy_Strength.Title = "Strength";
                phy_Strength.Text = null;
                phy_Strength.Numeric = 1;

                phy_Stamina.Title = "Stamina";
                phy_Stamina.Text = null;
                phy_Stamina.Numeric = 1;

                phy_Dexterity.Title = "Dexterity";
                phy_Dexterity.Text = null;
                phy_Dexterity.Numeric = 1;

                men_Wit.Title = "Wit";
                men_Wit.Text = null;
                men_Wit.Numeric = 1;

                men_Intellect.Title = "Intellect";
                men_Intellect.Text = null;
                men_Intellect.Numeric = 1;

                men_Resolve.Title = "Resolve";
                men_Resolve.Text = null;
                men_Resolve.Numeric = 1;

                soc_Charisma.Title = "Charisma";
                soc_Charisma.Text = null;
                soc_Charisma.Numeric = 1;

                soc_Manipulation.Title = "Manipulation";
                soc_Manipulation.Text = null;
                soc_Manipulation.Numeric = 1;

                soc_Composure.Title = "Composure";
                soc_Composure.Text = null;
                soc_Composure.Numeric = 1;

                temp_Willpower.Title = "Temporary Willpower";
                temp_Willpower.Text = null;
                temp_Willpower.Numeric = -1;

                perm_Willpower.Title = "Permanent Willpower";
                perm_Willpower.Text = null;
                perm_Willpower.Numeric = -1;

                morality.Title = "Morality";
                morality.Text = "Humanity";
                morality.Numeric = 5;

                gender.Title = "Gender";
                gender.Text = "Male";
                gender.Numeric = -1;

                age.Title = "Age";
                age.Text = null;
                age.Numeric = 294;

                genre.Title = "Genre";
                genre.Text = "Vampire";
                genre.Numeric = -1;

                virtue_Conscience.Title = "Conscience";
                virtue_Conscience.Text = null;
                virtue_Conscience.Numeric = 1;

                virtue_Courage.Title = "Courage";
                virtue_Courage.Text = null;
                virtue_Courage.Numeric = 1;

                virtue_Self_Control.Title = "Self-Control";
                virtue_Self_Control.Text = null;
                virtue_Self_Control.Numeric = 1;

                nature.Title = "Nature";
                nature.Text = "Bon Vivant";
                nature.Numeric = -1;

                demeanor.Title = "Demeanor";
                demeanor.Text = "Leader";
                demeanor.Numeric = -1;

                clan.Title = "Clan";
                clan.Text = "Caitiff";
                clan.Numeric = -1;

                bloodline.Title = "Bloodline";
                bloodline.Text = "None";
                bloodline.Numeric = -1;

                clan_flaw.Title = "Clan Flaw";
                clan_flaw.Text = "";
                clan_flaw.Numeric = -1;

                faction.Title = "Faction";
                faction.Text = "Anarch";
                faction.Numeric = -1;

                generation.Title = "Generation";
                generation.Text = "";
                generation.Numeric = 13;

                bloodpool.Title = "Blood Pool";
                bloodpool.Text = null;
                bloodpool.Numeric = 10;

            }
            else
            {
                char_Name.Title = "Character Name";
                char_Name.Text = "";
                char_Name.Numeric = -1;

                player_Name.Title = "Player Name";
                player_Name.Text = "";
                player_Name.Numeric = -1;

                phy_Strength.Title = "Strength";
                phy_Strength.Text = null;
                phy_Strength.Numeric = 1;

                phy_Stamina.Title = "Stamina";
                phy_Stamina.Text = null;
                phy_Stamina.Numeric = 1;

                phy_Dexterity.Title = "Dexterity";
                phy_Dexterity.Text = null;
                phy_Dexterity.Numeric = 1;

                men_Wit.Title = "Wit";
                men_Wit.Text = null;
                men_Wit.Numeric = 1;

                men_Intellect.Title = "Intellect";
                men_Intellect.Text = null;
                men_Intellect.Numeric = 1;

                men_Resolve.Title = "Resolve";
                men_Resolve.Text = null;
                men_Resolve.Numeric = 1;

                soc_Charisma.Title = "Charisma";
                soc_Charisma.Text = null;
                soc_Charisma.Numeric = 1;

                soc_Manipulation.Title = "Manipulation";
                soc_Manipulation.Text = null;
                soc_Manipulation.Numeric = 1;

                soc_Composure.Title = "Composure";
                soc_Composure.Text = null;
                soc_Composure.Numeric = 1;

                temp_Willpower.Title = "Temporary Willpower";
                temp_Willpower.Text = null;
                temp_Willpower.Numeric = -1;

                perm_Willpower.Title = "Permanent Willpower";
                perm_Willpower.Text = null;
                perm_Willpower.Numeric = -1;

                morality.Title = "Morality";
                morality.Text = "Humanity";
                morality.Numeric = 1;

                gender.Title = "Gender";
                gender.Text = "Male";
                gender.Numeric = -1;

                age.Title = "Age";
                age.Text = null;
                age.Numeric = 1;

                genre.Title = "Genre";
                genre.Text = "Vampire";
                genre.Numeric = -1;

                virtue_Conscience.Title = "Conscience";
                virtue_Conscience.Text = null;
                virtue_Conscience.Numeric = 1;

                virtue_Courage.Title = "Courage";
                virtue_Courage.Text = null;
                virtue_Courage.Numeric = 1;

                virtue_Self_Control.Title = "Self-Control";
                virtue_Self_Control.Text = null;
                virtue_Self_Control.Numeric = 1;

                nature.Title = "Nature";
                nature.Text = "";
                nature.Numeric = -1;

                demeanor.Title = "Demeanor";
                demeanor.Text = "";
                demeanor.Numeric = -1;

                clan.Title = "Clan";
                clan.Text = "";
                clan.Numeric = -1;

                bloodline.Title = "Bloodline";
                bloodline.Text = null;
                bloodline.Numeric = -1;

                clan_flaw.Title = "";
                clan_flaw.Text = "";
                clan_flaw.Numeric = -1;

                faction.Title = "Faction";
                faction.Text = "";
                faction.Numeric = -1;

                generation.Title = "Generation";
                generation.Text = "";
                generation.Numeric = 13;

                bloodpool.Title = "Blood Pool";
                bloodpool.Text = null;
                bloodpool.Numeric = 10;
            }
        }

        // This method will allow me to modify stats based on the name; my hope here is to
        // automate the process by passing individual stat names and the new values 
        // for those stats on a 1-for-1 basis, modifying the entire character in one fell swoop.

        public override void ModifyValue(string name, string value)
        {
            foreach (Attribute a in theCharacter)
            {
                int numresult;
                string st_result = value;
                if (a.Title.ToLower() == name)
                {
                    if (int.TryParse(value, out numresult))
                    {
                        a.Numeric = numresult;
                    }
                    else
                    {
                        a.Text = st_result;
                    }
                }
                else if (a.Title.ToLower() == name && st_result.Length > 45)
                {
                    a.Description = st_result;
                }
            }
        }


        public override void ModifyDescription(string name, string desc)
        {
            foreach (Attribute a in theCharacter)
            {

                if (a.Title.ToLower() == name)
                {
                    a.Description = desc;
                }
            }
        }
    }

}
