using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innuendo
{

        [Serializable]
        class Mortal : Character
        {
            

        public Mortal(bool test_mode)
            {
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
                theCharacter.Add(faction);
                theCharacter.Add(nature);
                theCharacter.Add(demeanor);
                theCharacter.Add(virtue_Conscience);
                theCharacter.Add(virtue_Courage);
                theCharacter.Add(virtue_Self_Control);

            if (test_mode)
            {
                char_Name.Title = "Character Name";
                char_Name.Text = "Jacob Frye";
                char_Name.Numeric = -1;

                player_Name.Title = "Player Name";
                player_Name.Text = "Bill Schafer";
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
                temp_Willpower.Numeric = 5;

                perm_Willpower.Title = "Permanent Willpower";
                perm_Willpower.Text = null;
                perm_Willpower.Numeric = 5;

                morality.Title = "Morality";
                morality.Text = "Humanity";
                morality.Numeric = 5;

                gender.Title = "Gender";
                gender.Text = "Female";
                gender.Numeric = -1;

                age.Title = "Age";
                age.Text = null;
                age.Numeric = 18;

                genre.Title = "Genre";
                genre.Text = "Mortal";
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
                nature.Text = "Leader";
                nature.Numeric = -1;

                demeanor.Title = "Demeanor";
                demeanor.Text = "Survivor";
                demeanor.Numeric = -1;

                faction.Title = "Faction";
                faction.Text = "None";
                faction.Numeric = -1;
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
                temp_Willpower.Numeric = 5;

                perm_Willpower.Title = "Permanent Willpower";
                perm_Willpower.Text = null;
                perm_Willpower.Numeric = 5;

                morality.Title = "Morality";
                morality.Text = "Humanity";
                morality.Numeric = 1;

                gender.Title = "Gender";
                gender.Text = "";
                gender.Numeric = -1;

                age.Title = "Age";
                age.Text = null;
                age.Numeric = 18;

                genre.Title = "Genre";
                genre.Text = "Mortal";
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

                faction.Title = "Faction";
                faction.Text = "";
                faction.Numeric = -1;
            }
            }

            

        public override void ModifyValue(string name, string num)
            {
                foreach (Attribute a in theCharacter)
                {
                    int numresult;
                    string st_result = num;
                    if (a.Title.ToLower() == name)
                    {
                        if (int.TryParse(num, out numresult))
                        {
                            a.Numeric = numresult;
                        }
                        else
                        {
                            a.Text = st_result;
                        }
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
