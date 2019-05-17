using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innuendo

    /*  This is a character template that can be used for different genres of the White Wolf series of games.
     *  All of the genres utilize these attributes, but there are unique attributes that do not apply or translate
     *  into equivalents in other genres; therefore those attributes are not included here.  Instead they will be 
     *  assigned to specific templates that will inherit the base attributes from this template. */
{
    [Serializable]

    class Character : IComparable
    {
        // This arraylist will store the character attributes for each character, as well as the stats for the last recorded version of it.
        public ArrayList theCharacter = new ArrayList();
        public ArrayList theLastVersion = new ArrayList();
        public ArrayList backgroundList = new ArrayList();
        public ArrayList abilitiesList = new ArrayList();
        public ArrayList talentsList = new ArrayList();
        public ArrayList knowledgesList = new ArrayList();
        public ArrayList meritList = new ArrayList();
        public ArrayList flawList = new ArrayList();
        public Attribute merits = new Attribute();
        public Attribute flaws = new Attribute();

        /* Primary attributes; there are three (or more) sub-categories, 
         * so there are three elements for each primary type to record this. */
        public Attribute phy_Strength = new Attribute();
        public Attribute phy_Stamina = new Attribute();
        public Attribute phy_Dexterity = new Attribute();
        public Attribute soc_Charisma = new Attribute();
        public Attribute soc_Manipulation = new Attribute();
        public Attribute soc_Composure = new Attribute();
        public Attribute men_Intellect = new Attribute();
        public Attribute men_Wit = new Attribute();
        public Attribute men_Resolve = new Attribute();

        /* Simple attributes; these are standalone, so only one element is needed.  
         * I want to maintain arrays for code versatility. EDIT:  As getting too deep into arrays became
         * too difficult to navigate, I simplified them down to single attributes.  I'm hoping when I become
         * more proficient in them I can add them back in.*/
        public Attribute temp_Willpower = new Attribute();// Subcategories - Temporary and Permanent Willpower -   
        public Attribute perm_Willpower = new Attribute();// range - 1-10; saved in val2.

        // These are the virtues that get used in White Wolf games as the equivalent to 'saving throws'
        // in Dungeons and Dragons.
        public Attribute virtue_Self_Control = new Attribute();
        public Attribute virtue_Courage = new Attribute();
        public Attribute virtue_Conscience = new Attribute();

        // Morality determines the maximum capacity for your virtues.  High morality is good.
        public Attribute morality = new Attribute();// Morality range - 1-10; saved in numeric.

        // Standard fare for attributes here.
        public Attribute gender = new Attribute();    // Gender, saved as label in numeric.
        public Attribute age = new Attribute();       // Age; saved in val2.

        /* These attributes will be used as primary keys within the databases, to be set up later,
         * to ensure that each player can have multiple characters entered.  The ultimate primary
         * key will be the player name, to ensure all characters are unique to the players. */
        public Attribute char_Name = new Attribute();   // Character name
        public Attribute player_Name = new Attribute(); // Player name
        public Attribute genre = new Attribute();
        public Attribute genreFlaw1 = new Attribute();
        public Attribute genreFlaw2 = new Attribute();
        public Attribute faction = new Attribute();

        //Nature and Demeanor are role-playing guides for the character's player.

        public Attribute nature = new Attribute();
        public Attribute demeanor = new Attribute();

        // Background story for the character that the user can write in; that will be saved here.

        public Attribute background_story = new Attribute();

        // These will be time-stamps to allow a player to know when they've created or last modified a character in the database.

        public DateTime creation;
        public DateTime last_modified;

        // These will be xp values saved to the character, determining the total xp allotted to the character, the amount spent, and the amount still unused.

        public Attribute spent_xp = new Attribute();
        public Attribute unspent_xp = new Attribute();

        // ModifyValue will allow me to modify any character's value.
        virtual public void ModifyValue(string name, string num) { }

        // ModifyDescription will allow me to modify descriptions for different stats.
        virtual public void ModifyDescription(string name, string desc){}

        // DisplayCharacter was designed to test the database in a console setting;
        // this will be modified to deliver information to a character screen after a user has chosen
        // a character from the main list.

        public string DisplayStatInfo(string name)
        {
            string result = null;
            foreach (Attribute a in theCharacter)
            {
                if (a.Title.Equals(name))
                {
                    if (!string.IsNullOrEmpty(a.Text))
                    {
                        if (a.Numeric >= 0)
                        {
                            result = a.Numeric.ToString();
                        }
                        else
                        {
                            result = a.Text;
                        }
                        
                    }
                    else if (string.IsNullOrEmpty(a.Text))
                    {
                        if (a.Numeric >= 0)
                        {
                            result = a.Numeric.ToString();
                        }
                    }
                }
            }

            return result;
        }

        public string DisplayStatName(string name)
        {
            string result = null;
            foreach (Attribute a in theCharacter)
            {
                if (a.Title.Equals(name))
                {
                    if (a.Text != null)
                    {
                        if (a.Numeric == -1)
                        { result = a.Title; }
                        else { result = a.Text; }
                    }

                    else { result = a.Title; }
                    
                }
            }

            return result;
        }

        public int CompareTo(object obj)
        {
            // This value needs to return something that can 
            int result = 0;

            if (obj is Character)
            {
                result = this.char_Name.Text.CompareTo(obj.ToString());
            }

            return result;
        }
    }
}
