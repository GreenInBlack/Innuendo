using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Innuendo
{
    public delegate void CriteriaDelegate(string criteria);

    public partial class MainForm : Form
    {
        Database theDataBase;
        ArrayList labels;
        ArrayList boxes;
        ArrayList comboPowers_list;
        ArrayList comboPowers_values;
        ArrayList comboBackground_list;
        ArrayList comboBackground_values;
        ArrayList comboAbility_list;
        ArrayList comboAbility_values;
        ArrayList comboTalent_list;
        ArrayList comboTalent_values;
        ArrayList comboKnowledge_list;
        ArrayList comboKnowledge_values;
        ArrayList comboMerits_list;
        ArrayList comboMerits_values;
        ArrayList comboFlaws_list;
        ArrayList comboFlaws_values;

        ArrayList removedBackground = new ArrayList();
        ArrayList removedAbility = new ArrayList();
        ArrayList removedTalent = new ArrayList();
        ArrayList removedKnowledge = new ArrayList();
        ArrayList removedPower = new ArrayList();
        ArrayList removedMerits = new ArrayList();
        ArrayList removedFlaws = new ArrayList();

        ArrayList meritTotal = new ArrayList();

        public MainForm()
        {
            InitializeComponent();
            theDataBase = new Database();
            SetLabelsAndBoxes("vampire");
            PopulateComboBoxOptions();

            dataGridView1.Columns.Add("entryLocation", "Entry #");
            dataGridView1.Columns.Add("playerName", "Player Name");
            dataGridView1.Columns.Add("charName", "Character Name");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = ".DAT File| *.dat";
            saveDialog.ShowDialog();
            string savelocation = saveDialog.FileName;

            theDataBase.WriteDatabase(savelocation);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = ".DAT File| *.dat";
            openDialog.ShowDialog();
            string openlocation = openDialog.FileName;
            theDataBase.ReadDatabase(openlocation);
            FillData();
        }

        private void SetLabelsAndBoxes(string the_genre)
        {
            // This'll set up all of the lists for labels, and boxes, to allow me to clear out the text and combo boxes when I need to.

            labels = new ArrayList();
            boxes = new ArrayList();

            labels.Add(characterName);
            labels.Add(playerName);
            labels.Add(strength);
            labels.Add(stamina);
            labels.Add(dexterity);
            labels.Add(wit);
            labels.Add(intellect);
            labels.Add(resolve);
            labels.Add(charisma);
            labels.Add(manipulation);
            labels.Add(composure);
            labels.Add(morality);
            labels.Add(willpower);
            labels.Add(tempWillpower);
            labels.Add(age);
            labels.Add(gender);
            labels.Add(genre);
            labels.Add(nature);
            labels.Add(demeanor);
            labels.Add(virtueSelfControl);
            labels.Add(virtueCourage);
            labels.Add(virtueConscience);
            labels.Add(faction);

            boxes.Add(characterTextBox);
            boxes.Add(playerTextBox);
            boxes.Add(strengthTextBox);
            boxes.Add(staminaTextBox);
            boxes.Add(dexterityTextBox);
            boxes.Add(witTextBox);
            boxes.Add(intellectTextBox);
            boxes.Add(resolveTextBox);
            boxes.Add(charismaTextBox);
            boxes.Add(manipulationTextBox);
            boxes.Add(composureTextBox);
            boxes.Add(moralityTextBox);
            boxes.Add(tWillpowerTextBox);
            boxes.Add(pWillpowerTextBox);
            boxes.Add(ageTextBox);
            boxes.Add(genderTextBox);
            boxes.Add(natureTextBox);
            boxes.Add(demeanorTextBox);
            boxes.Add(virtueSelfTextBox);
            boxes.Add(virtueCourageTextBox);
            boxes.Add(virtueConscienceTextBox);

            comboPowers_list = new ArrayList();
            comboPowers_values = new ArrayList();

            comboPowers_list.Add(comboPower1Text);
            comboPowers_list.Add(comboPower2Text);
            comboPowers_list.Add(comboPower3Text);
            comboPowers_list.Add(comboPower4Text);
            comboPowers_list.Add(comboPower5Text);
            comboPowers_list.Add(comboPower6Text);
            comboPowers_list.Add(comboPower7Text);

            comboPowers_values.Add(characterPower1Value);
            comboPowers_values.Add(characterPower2Value);
            comboPowers_values.Add(characterPower3Value);
            comboPowers_values.Add(characterPower4Value);
            comboPowers_values.Add(characterPower5Value);
            comboPowers_values.Add(characterPower6Value);
            comboPowers_values.Add(characterPower7Value);

            comboBackground_list = new ArrayList();
            comboBackground_values = new ArrayList();

            comboBackground_list.Add(comboBackground1Text);
            comboBackground_list.Add(comboBackground2Text);
            comboBackground_list.Add(comboBackground3Text);
            comboBackground_list.Add(comboBackground4Text);
            comboBackground_list.Add(comboBackground5Text);
            comboBackground_list.Add(comboBackground6Text);
            comboBackground_list.Add(comboBackground7Text);

            comboBackground_values.Add(comboBackground1Value);
            comboBackground_values.Add(comboBackground2Value);
            comboBackground_values.Add(comboBackground3Value);
            comboBackground_values.Add(comboBackground4Value);
            comboBackground_values.Add(comboBackground5Value);
            comboBackground_values.Add(comboBackground6Value);
            comboBackground_values.Add(comboBackground7Value);

            comboAbility_list = new ArrayList();
            comboAbility_values = new ArrayList();


            comboAbility_list.Add(comboAbility1Text);
            comboAbility_list.Add(comboAbility2Text);
            comboAbility_list.Add(comboAbility3Text);
            comboAbility_list.Add(comboAbility4Text);
            comboAbility_list.Add(comboAbility5Text);
            comboAbility_list.Add(comboAbility6Text);
            comboAbility_list.Add(comboAbility7Text);

            comboAbility_values.Add(comboAbility1Value);
            comboAbility_values.Add(comboAbility2Value);
            comboAbility_values.Add(comboAbility3Value);
            comboAbility_values.Add(comboAbility4Value);
            comboAbility_values.Add(comboAbility5Value);
            comboAbility_values.Add(comboAbility6Value);
            comboAbility_values.Add(comboAbility7Value);

            comboTalent_list = new ArrayList();
            comboTalent_values = new ArrayList();

            comboTalent_list.Add(comboTalent1Text);
            comboTalent_list.Add(comboTalent2Text);
            comboTalent_list.Add(comboTalent3Text);
            comboTalent_list.Add(comboTalent4Text);
            comboTalent_list.Add(comboTalent5Text);
            comboTalent_list.Add(comboTalent6Text);
            comboTalent_list.Add(comboTalent7Text);

            comboTalent_values.Add(comboTalent1Value);
            comboTalent_values.Add(comboTalent2Value);
            comboTalent_values.Add(comboTalent3Value);
            comboTalent_values.Add(comboTalent4Value);
            comboTalent_values.Add(comboTalent5Value);
            comboTalent_values.Add(comboTalent6Value);
            comboTalent_values.Add(comboTalent7Value);

            comboKnowledge_list = new ArrayList();
            comboKnowledge_values = new ArrayList();

            comboKnowledge_list.Add(comboKnowledge1Text);
            comboKnowledge_list.Add(comboKnowledge2Text);
            comboKnowledge_list.Add(comboKnowledge3Text);
            comboKnowledge_list.Add(comboKnowledge4Text);
            comboKnowledge_list.Add(comboKnowledge5Text);
            comboKnowledge_list.Add(comboKnowledge6Text);
            comboKnowledge_list.Add(comboKnowledge7Text);

            comboKnowledge_values.Add(comboKnowledge1Value);
            comboKnowledge_values.Add(comboKnowledge2Value);
            comboKnowledge_values.Add(comboKnowledge3Value);
            comboKnowledge_values.Add(comboKnowledge4Value);
            comboKnowledge_values.Add(comboKnowledge5Value);
            comboKnowledge_values.Add(comboKnowledge6Value);
            comboKnowledge_values.Add(comboKnowledge7Value);

            comboMerits_list = new ArrayList();
            comboMerits_values = new ArrayList();
            comboMerits_list.Add(comboMerit1Text);
            comboMerits_list.Add(comboMerit2Text);
            comboMerits_list.Add(comboMerit3Text);
            comboMerits_list.Add(comboMerit4Text);
            comboMerits_list.Add(comboMerit5Text);
            comboMerits_list.Add(comboMerit6Text);
            comboMerits_list.Add(comboMerit7Text);

            comboMerits_values.Add(comboMerit1Value);
            comboMerits_values.Add(comboMerit2Value);
            comboMerits_values.Add(comboMerit3Value);
            comboMerits_values.Add(comboMerit4Value);
            comboMerits_values.Add(comboMerit5Value);
            comboMerits_values.Add(comboMerit6Value);
            comboMerits_values.Add(comboMerit7Value);

            comboFlaws_list = new ArrayList();
            comboFlaws_values = new ArrayList();
            comboFlaws_list.Add(comboFlaw1Text);
            comboFlaws_list.Add(comboFlaw2Text);
            comboFlaws_list.Add(comboFlaw3Text);
            comboFlaws_list.Add(comboFlaw4Text);
            comboFlaws_list.Add(comboFlaw5Text);
            comboFlaws_list.Add(comboFlaw6Text);
            comboFlaws_list.Add(comboFlaw7Text);

            comboFlaws_values.Add(comboFlaw1Value);
            comboFlaws_values.Add(comboFlaw2Value);
            comboFlaws_values.Add(comboFlaw3Value);
            comboFlaws_values.Add(comboFlaw4Value);
            comboFlaws_values.Add(comboFlaw5Value);
            comboFlaws_values.Add(comboFlaw6Value);
            comboFlaws_values.Add(comboFlaw7Value);

            try

            {
                if (the_genre.ToLower().Equals("vampire"))
                {
                    // Genre-specific labels to add.
                    labels.Add(genrePower1);
                    labels.Add(genrePower2);
                    labels.Add(genreFlaws);

                    // Genre specific boxes to add.
                    boxes.Add(genrePower1Value);
                    boxes.Add(genrePower2Value);
                    boxes.Add(genreFlawsValue);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "ERROR", MessageBoxButtons.OK);
            }
            if (the_genre.ToLower().Equals("mortal"))
            {
                groupGenre.Text = "Mortal Character";

                genreType1.Text = "N/A";
                genreType1Value.Enabled = false;
                genreType1Value.Text = "";

                genreType2.Text = "N/A";
                genreType2Value.Enabled = false;
                genreType2Value.Text = "";

                genrePower1.Text = "N/A";
                genrePower1Value.Enabled = false;
                genrePower1Value.Text = "";

                genrePower2.Text = "N/A";
                genrePower2Value.Enabled = false;
                genrePower2Value.Text = "";

                genreFlaws.Text = "N/A";
                genreFlawsValue.Enabled = false;
                genreFlawsValue.Text = "";
            }

        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            int char_total = 0;
            int result = 0;
            int STANDARD_CHAR_TOTAL = 57;

            foreach (TextBox b in boxes)
            {
                // The way that this should work is that it will look at each box in the Boxes Arraylist and try to parse an integer from it.
                // If it can, it'll save that value to the char_total variable.
                if (int.TryParse(b.Text, out result))
                {
                    char_total += result;
                }
                else { char_total += 0; }
            }

            if (char_total == STANDARD_CHAR_TOTAL)
            {
                MessageBox.Show("This character's stat values are in line with a standard character sheet.", "VALID", MessageBoxButtons.OK);
            }
            else if (char_total > STANDARD_CHAR_TOTAL)
            {
                int diff = char_total - STANDARD_CHAR_TOTAL;
                MessageBox.Show("This character's stat values are over by " + diff + ".", "STATS OVERAGE", MessageBoxButtons.OK);
            }
            else
            {
                int diff = STANDARD_CHAR_TOTAL - char_total;
                MessageBox.Show("This character's stat values are under by " + diff + ".", "UNASSIGNED STATS", MessageBoxButtons.OK);
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            // This resets all of the relevant boxes in the character form so that a new character can be entered into the database.

            SetLabelsAndBoxes("vampire");

            foreach (TextBox b in boxes)
            {
                b.Text = "";
            }

            meritTextBox.Text = "0";
            flawTextBox.Text = "0";

            removedBackground.Clear();
            removedKnowledge.Clear();
            removedTalent.Clear();
            removedAbility.Clear();
            removedPower.Clear();
            ComboAndTextBoxClear();
            PopulateComboBoxOptions();

            genreTextBox.Text = "- Select Genre - ";
            factionTextBox.Text = "- Select Faction - ";
            genreType1Value.Text = "- Select Clan - ";
            genreType2Value.Text = "- Select Bloodline - ";
            morality.Text = "- Select Morality - ";
            StoryTextBox.Text = "";

            dtpCreation.Value = DateTime.Today;
            dtpLastModified.Value = DateTime.Today;

            groupGenre.Text = "Input Values";

            factionTextBox.Enabled = false;
            morality.Enabled = false;
            genreType1Value.Enabled = false;
            genreType2Value.Enabled = false;
        }

        private void saveToDatabaseButton_Click(object sender, EventArgs e)
        {
            // This is the second biggest pain in the software that I've devised, considering the dataGridView craziness I endured for weeks.
            // I need to manually enter the data from the text boxes into an entry file, coded below depending on the genre of the game
            // the character will be participating in.

            Mortal mortalentry = new Mortal(false);
            Vampire vampentry = new Vampire(false);

            int entry_index = -1;

            if (genreTextBox.Text.ToLower().Equals("mortal"))
            {
                mortalentry.char_Name.Text = characterTextBox.Text;
                mortalentry.player_Name.Text = playerTextBox.Text;
                mortalentry.nature.Text = natureTextBox.Text;
                mortalentry.age.Numeric = int.Parse(ageTextBox.Text);
                mortalentry.genre.Text = genreTextBox.Text;
                mortalentry.demeanor.Text = demeanorTextBox.Text;
                mortalentry.gender.Text = genderTextBox.Text;
                mortalentry.faction.Text = factionTextBox.Text;
                mortalentry.phy_Strength.Numeric = int.Parse(strengthTextBox.Text);
                mortalentry.phy_Stamina.Numeric = int.Parse(staminaTextBox.Text);
                mortalentry.phy_Dexterity.Numeric = int.Parse(dexterityTextBox.Text);
                mortalentry.men_Wit.Numeric = int.Parse(witTextBox.Text);
                mortalentry.men_Intellect.Numeric = int.Parse(intellectTextBox.Text);
                mortalentry.men_Resolve.Numeric = int.Parse(resolveTextBox.Text);
                mortalentry.soc_Charisma.Numeric = int.Parse(charismaTextBox.Text);
                mortalentry.soc_Manipulation.Numeric = int.Parse(manipulationTextBox.Text);
                mortalentry.soc_Composure.Numeric = int.Parse(composureTextBox.Text);
                mortalentry.temp_Willpower.Numeric = int.Parse(tWillpowerTextBox.Text);
                mortalentry.perm_Willpower.Numeric = int.Parse(pWillpowerTextBox.Text);
                mortalentry.virtue_Self_Control.Numeric = int.Parse(virtueSelfTextBox.Text);
                mortalentry.virtue_Courage.Numeric = int.Parse(virtueCourageTextBox.Text);
                mortalentry.virtue_Conscience.Numeric = int.Parse(virtueConscienceTextBox.Text);
                mortalentry.morality.Text = morality.Text;
                mortalentry.morality.Numeric = int.Parse(moralityTextBox.Text);
                mortalentry.merits.Numeric = int.Parse(meritTextBox.Text);
                mortalentry.flaws.Numeric = int.Parse(flawTextBox.Text);
                mortalentry.background_story.Description = StoryTextBox.Text;
                mortalentry.spent_xp.Numeric = int.Parse(txtSpentXP.Text);
                mortalentry.unspent_xp.Numeric = int.Parse(txtUnspentXP.Text);


                int counterAbility = 0;
                int counterBackground = 0;
                int counterTalent = 0;
                int counterKnowledge = 0;
                int counterMerit = 0;
                int counterFlaw = 0;

                foreach (TextBox t in comboMerits_values)
                {
                    foreach (ComboBox c in comboMerits_list)
                    {
                        if (comboMerits_values.IndexOf(t) == comboMerits_list.IndexOf(c))
                        {
                            if (!t.Text.Equals(""))
                            {
                                counterMerit += 1;
                            }
                        }
                    }
                }

                for (int i = 0; i < counterMerit; i++)
                {
                    ComboBox entry = comboMerits_list[i] as ComboBox;
                    TextBox value = comboMerits_values[i] as TextBox;
                    if (!entry.Text.Equals(null) && !value.Text.Equals(null))
                    {
                        Attribute merit = new Attribute();
                        merit.Title = "Merit";
                        merit.Text = entry.Text;
                        merit.Numeric = int.Parse(value.Text);
                        merit.Description = null;

                        mortalentry.meritList.Add(merit);
                    }
                }

                // Flaws subroutine

                foreach (TextBox t in comboFlaws_values)
                {
                    foreach (ComboBox c in comboFlaws_list)
                    {
                        if (comboFlaws_values.IndexOf(t) == comboFlaws_list.IndexOf(c))
                        {
                            if (!t.Text.Equals(""))
                            {
                                counterFlaw += 1;
                            }
                        }
                    }
                }

                for (int i = 0; i < counterFlaw; i++)
                {
                    ComboBox entry = comboFlaws_list[i] as ComboBox;
                    TextBox value = comboFlaws_values[i] as TextBox;
                    if (!entry.Text.Equals(null) && !value.Text.Equals(null))
                    {
                        Attribute flaw = new Attribute();
                        flaw.Title = "Flaw";
                        flaw.Text = entry.Text;
                        flaw.Numeric = int.Parse(value.Text);
                        flaw.Description = null;

                        mortalentry.flawList.Add(flaw);
                    }
                }

                // Skills subroutine

                foreach (TextBox t in comboAbility_values)
                {
                    foreach (ComboBox c in comboAbility_list)
                    {
                        if (comboAbility_values.IndexOf(t) == comboAbility_list.IndexOf(c))
                        {
                            if (!t.Text.Equals(""))
                            {
                                counterAbility += 1;
                            }
                        }
                    }
                }

                for (int i = 0; i < counterAbility; i++)
                {
                    Attribute ability = new Attribute();
                    ComboBox entry = comboAbility_list[i] as ComboBox;
                    TextBox value = comboAbility_values[i] as TextBox;
                    if (!entry.Text.Equals(null) && !value.Text.Equals(null))
                    {
                        ability.Title = "Skill";
                        ability.Text = entry.Text;
                        ability.Numeric = int.Parse(value.Text);
                        ability.Description = null;

                        mortalentry.abilitiesList.Add(ability);
                    }
                }

                // Background and Influence subroutine

                foreach (TextBox t in comboBackground_values)
                {
                    foreach (ComboBox c in comboBackground_list)
                    {
                        if (comboBackground_values.IndexOf(t) == comboBackground_list.IndexOf(c))
                        {
                            if (!t.Text.Equals(""))
                            {
                                counterBackground += 1;
                            }
                        }
                    }
                }

                for (int i = 0; i < counterBackground; i++)
                {
                    Attribute background = new Attribute();
                    ComboBox entry = comboBackground_list[i] as ComboBox;
                    TextBox value = comboBackground_values[i] as TextBox;
                    if (!entry.Text.Equals(null) && !value.Text.Equals(null))
                    {
                        background.Title = "Background";
                        background.Text = entry.Text;
                        background.Numeric = int.Parse(value.Text);
                        background.Description = null;

                        mortalentry.backgroundList.Add(background);
                    }
                }

                // Knowledge subroutine

                foreach (TextBox t in comboKnowledge_values)
                {
                    foreach (ComboBox c in comboKnowledge_list)
                    {
                        if (comboKnowledge_values.IndexOf(t) == comboKnowledge_list.IndexOf(c))
                        {
                            if (!t.Text.Equals(""))
                            {
                                counterKnowledge += 1;
                            }
                        }
                    }
                }

                for (int i = 0; i < counterKnowledge; i++)
                {
                    Attribute knowledge = new Attribute();
                    ComboBox entry = comboKnowledge_list[i] as ComboBox;
                    TextBox value = comboKnowledge_values[i] as TextBox;
                    if (!entry.Text.Equals(null) && !value.Text.Equals(null))
                    {

                        knowledge.Title = "Background";
                        knowledge.Text = entry.Text;
                        knowledge.Numeric = int.Parse(value.Text);
                        knowledge.Description = null;

                        mortalentry.knowledgesList.Add(knowledge);
                    }
                }

                // Talent subroutine

                foreach (TextBox t in comboTalent_values)
                {
                    foreach (ComboBox c in comboTalent_list)
                    {
                        if (comboTalent_values.IndexOf(t) == comboTalent_list.IndexOf(c))
                        {
                            if (!t.Text.Equals(""))
                            {
                                counterTalent += 1;
                            }
                        }
                    }
                }

                for (int i = 0; i < counterTalent; i++)
                {
                    Attribute talent = new Attribute();
                    ComboBox entry = comboTalent_list[i] as ComboBox;
                    TextBox value = comboTalent_values[i] as TextBox;
                    if (!entry.Text.Equals(null) && !value.Text.Equals(null))
                    {
                        talent.Title = "Background";
                        talent.Text = entry.Text;
                        talent.Numeric = int.Parse(value.Text);
                        talent.Description = null;

                        mortalentry.talentsList.Add(talent);
                    }
                }

                // Creation and Last Modified Dates saved

                if (dtpCreation.Value.Equals(dtpLastModified.Value))
                {
                    mortalentry.creation = DateTime.Today;
                }
                mortalentry.last_modified = DateTime.Today;

                // Check to see if there is a duplicate character with the same requirements in the database already.

                foreach (Character c in theDataBase.characterList)
                {


                    if (c.char_Name.Text.Equals(characterTextBox.Text))
                    {
                        if (c.player_Name.Text.Equals(playerTextBox.Text))
                        {
                            if (c.gender.Text.Equals(genderTextBox.Text))
                            {
                                if (c.genre.Text.Equals(genreTextBox.Text))
                                {
                                    entry_index = theDataBase.characterList.IndexOf(c);
                                }
                            }
                        }
                    }


                }

                if (entry_index > -1)
                {
                    theDataBase.characterList.RemoveAt(entry_index);
                    theDataBase.characterList.Insert(entry_index, mortalentry);
                    theDataBase.characterList.Sort();
                }
                else
                {
                    theDataBase.characterList.Add(mortalentry);
                    theDataBase.characterList.Sort();
                }

                FillData();

            }

            else if (genreTextBox.Text.ToLower().Equals("vampire"))
            {
                try
                {
                    // Assigning values from the text boxes in the form to the variables for the character stored in the database array.
                    vampentry.char_Name.Text = characterTextBox.Text;
                    vampentry.player_Name.Text = playerTextBox.Text;
                    vampentry.nature.Text = natureTextBox.Text;
                    vampentry.age.Numeric = int.Parse(ageTextBox.Text);
                    vampentry.genre.Text = genreTextBox.Text;
                    vampentry.demeanor.Text = demeanorTextBox.Text;
                    vampentry.gender.Text = genderTextBox.Text;
                    vampentry.faction.Text = factionTextBox.Text;
                    vampentry.phy_Strength.Numeric = int.Parse(strengthTextBox.Text);
                    vampentry.phy_Stamina.Numeric = int.Parse(staminaTextBox.Text);
                    vampentry.phy_Dexterity.Numeric = int.Parse(dexterityTextBox.Text);
                    vampentry.men_Wit.Numeric = int.Parse(witTextBox.Text);
                    vampentry.men_Intellect.Numeric = int.Parse(intellectTextBox.Text);
                    vampentry.men_Resolve.Numeric = int.Parse(resolveTextBox.Text);
                    vampentry.soc_Charisma.Numeric = int.Parse(charismaTextBox.Text);
                    vampentry.soc_Manipulation.Numeric = int.Parse(manipulationTextBox.Text);
                    vampentry.soc_Composure.Numeric = int.Parse(composureTextBox.Text);
                    vampentry.temp_Willpower.Numeric = int.Parse(tWillpowerTextBox.Text);
                    vampentry.perm_Willpower.Numeric = int.Parse(pWillpowerTextBox.Text);
                    vampentry.virtue_Self_Control.Numeric = int.Parse(virtueSelfTextBox.Text);
                    vampentry.virtue_Courage.Numeric = int.Parse(virtueCourageTextBox.Text);
                    vampentry.virtue_Conscience.Numeric = int.Parse(virtueConscienceTextBox.Text);
                    vampentry.morality.Text = morality.Text;
                    vampentry.morality.Numeric = int.Parse(moralityTextBox.Text);
                    vampentry.clan.Text = genreType1Value.Text;
                    vampentry.bloodline.Text = genreType2Value.Text;
                    vampentry.merits.Numeric = int.Parse(meritTextBox.Text);
                    vampentry.flaws.Numeric = int.Parse(flawTextBox.Text);
                    vampentry.background_story.Description = StoryTextBox.Text;

                    if (dtpCreation.Value.Equals(dtpLastModified.Value))
                    {
                        vampentry.creation = DateTime.Today;
                    }
                    vampentry.last_modified = DateTime.Today;

                    vampentry.spent_xp.Numeric = int.Parse(txtSpentXP.Text);
                    vampentry.unspent_xp.Numeric = int.Parse(txtUnspentXP.Text);

                    int counterPower = 0;
                    int counterMerit = 0;
                    int counterFlaw = 0;
                    int counterBackground = 0;
                    int counterAbility = 0;
                    int counterTalent = 0;
                    int counterKnowledge = 0;

                    // Disciplines subroutine

                    foreach (TextBox t in comboPowers_values)
                    {
                        foreach (ComboBox c in comboPowers_list)
                        {
                            if (comboPowers_values.IndexOf(t) == comboPowers_list.IndexOf(c))
                            {
                                if (!t.Text.Equals(""))
                                {
                                    counterPower += 1;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < counterPower; i++)
                    {
                        ComboBox entry = comboPowers_list[i] as ComboBox;
                        TextBox value = comboPowers_values[i] as TextBox;
                        if (!entry.Text.Equals(null) && !value.Text.Equals(null))
                        {
                            Attribute power = new Attribute();
                            power.Title = "Discipline";
                            power.Text = entry.Text;
                            power.Numeric = int.Parse(value.Text);
                            power.Description = null;

                            vampentry.disiplines_list.Add(power);
                        }
                    }

                    // Merits subroutine

                    foreach (TextBox t in comboMerits_values)
                    {
                        foreach (ComboBox c in comboMerits_list)
                        {
                            if (comboMerits_values.IndexOf(t) == comboMerits_list.IndexOf(c))
                            {
                                if (!t.Text.Equals(""))
                                {
                                    counterMerit += 1;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < counterMerit; i++)
                    {
                        ComboBox entry = comboMerits_list[i] as ComboBox;
                        TextBox value = comboMerits_values[i] as TextBox;
                        if (!entry.Text.Equals(null) && !value.Text.Equals(null))
                        {
                            Attribute merit = new Attribute();
                            merit.Title = "Merit";
                            merit.Text = entry.Text;
                            merit.Numeric = int.Parse(value.Text);
                            merit.Description = null;

                            vampentry.meritList.Add(merit);
                        }
                    }

                    // Flaws subroutine

                    foreach (TextBox t in comboFlaws_values)
                    {
                        foreach (ComboBox c in comboFlaws_list)
                        {
                            if (comboFlaws_values.IndexOf(t) == comboFlaws_list.IndexOf(c))
                            {
                                if (!t.Text.Equals(null) && !c.Text.Equals(null))
                                {
                                    counterFlaw += 1;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < counterFlaw; i++)
                    {
                        ComboBox entry = comboFlaws_list[i] as ComboBox;
                        TextBox value = comboFlaws_values[i] as TextBox;
                        if (!entry.Text.Equals(null) && !value.Text.Equals(null))
                        {
                            Attribute flaw = new Attribute();
                            flaw.Title = "Flaw";
                            flaw.Text = entry.Text;
                            flaw.Numeric = int.Parse(value.Text);
                            flaw.Description = null;

                            vampentry.flawList.Add(flaw);
                        }
                    }

                    // Skills subroutine

                    foreach (TextBox t in comboAbility_values)
                    {
                        foreach (ComboBox c in comboAbility_list)
                        {
                            if (comboAbility_values.IndexOf(t) == comboAbility_list.IndexOf(c))
                            {
                                if (!t.Text.Equals(""))
                                {
                                    counterAbility += 1;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < counterAbility; i++)
                    {
                        Attribute ability = new Attribute();
                        ComboBox entry = comboAbility_list[i] as ComboBox;
                        TextBox value = comboAbility_values[i] as TextBox;
                        if (!entry.Text.Equals(null) && !value.Text.Equals(null))
                        {
                            ability.Title = "Skill";
                            ability.Text = entry.Text;
                            ability.Numeric = int.Parse(value.Text);
                            ability.Description = null;

                            vampentry.abilitiesList.Add(ability);
                        }
                    }

                    // Background and Influence subroutine

                    foreach (TextBox t in comboBackground_values)
                    {
                        foreach (ComboBox c in comboBackground_list)
                        {
                            if (comboBackground_values.IndexOf(t) == comboBackground_list.IndexOf(c))
                            {
                                if (!t.Text.Equals(""))
                                {
                                    counterBackground += 1;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < counterBackground; i++)
                    {
                        Attribute background = new Attribute();
                        ComboBox entry = comboBackground_list[i] as ComboBox;
                        TextBox value = comboBackground_values[i] as TextBox;
                        if (!entry.Text.Equals(null) && !value.Text.Equals(null))
                        {
                            background.Title = "Background";
                            background.Text = entry.Text;
                            background.Numeric = int.Parse(value.Text);
                            background.Description = null;

                            vampentry.backgroundList.Add(background);
                        }
                    }

                    // Knowledge subroutine

                    foreach (TextBox t in comboKnowledge_values)
                    {
                        foreach (ComboBox c in comboKnowledge_list)
                        {
                            if (comboKnowledge_values.IndexOf(t) == comboKnowledge_list.IndexOf(c))
                            {
                                if (!t.Text.Equals(""))
                                {
                                    counterKnowledge += 1;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < counterKnowledge; i++)
                    {
                        Attribute knowledge = new Attribute();
                        ComboBox entry = comboKnowledge_list[i] as ComboBox;
                        TextBox value = comboKnowledge_values[i] as TextBox;
                        if (!entry.Text.Equals(null) && !value.Text.Equals(null))
                        {

                            knowledge.Title = "Knowledge";
                            knowledge.Text = entry.Text;
                            knowledge.Numeric = int.Parse(value.Text);
                            knowledge.Description = null;

                            vampentry.knowledgesList.Add(knowledge);
                        }
                    }

                    // Talent subroutine

                    foreach (TextBox t in comboTalent_values)
                    {
                        foreach (ComboBox c in comboTalent_list)
                        {
                            if (comboTalent_values.IndexOf(t) == comboTalent_list.IndexOf(c))
                            {
                                if (!t.Text.Equals(""))
                                {
                                    counterTalent += 1;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < counterTalent; i++)
                    {
                        Attribute talent = new Attribute();
                        ComboBox entry = comboTalent_list[i] as ComboBox;
                        TextBox value = comboTalent_values[i] as TextBox;
                        if (!entry.Text.Equals(null) && !value.Text.Equals(null))
                        {
                            talent.Title = "Background";
                            talent.Text = entry.Text;
                            talent.Numeric = int.Parse(value.Text);
                            talent.Description = null;

                            vampentry.talentsList.Add(talent);
                        }
                    }

                    groupGenre.Text = "Vampire Character";
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString(), "Error: Empty or inaccurate value", MessageBoxButtons.OK);
                }

                foreach (Character c in theDataBase.characterList)
                {


                    if (c.char_Name.Text.Equals(characterTextBox.Text))
                    {
                        if (c.player_Name.Text.Equals(playerTextBox.Text))
                        {
                            if (c.gender.Text.Equals(genderTextBox.Text))
                            {
                                if (c.genre.Text.Equals(genreTextBox.Text))
                                {
                                    entry_index = theDataBase.characterList.IndexOf(c);
                                }
                            }
                        }
                    }


                }

                if (entry_index > -1)
                {
                    theDataBase.characterList.RemoveAt(entry_index);
                    theDataBase.characterList.Insert(entry_index, vampentry);
                    theDataBase.characterList.Sort();
                }
                else
                {
                    theDataBase.characterList.Add(vampentry);
                    theDataBase.characterList.Sort();
                }

                FillData();
            }

            else { MessageBox.Show("One or more fields are empty, or have incorrect information.  Please try again.", "ERROR", MessageBoxButtons.OK); }
        }

        public void FillData()
        {
            dataGridView1.Rows.Clear();
            theDataBase.characterList.Sort();

            foreach (Character c in theDataBase.characterList)
            {
                if (!c.player_Name.Text.Equals("") && !c.char_Name.Text.Equals(""))
                {
                    string[] entry = { (theDataBase.characterList.LastIndexOf(c) + 1).ToString(), c.player_Name.Text, c.char_Name.Text };
                    dataGridView1.Rows.Add(entry);
                }
            }

        }

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Here's where the magic happens.  In this block, the character chosen by the user is loaded into the form on the right side.
                // All relevant information is then added to the form each time the character row is chosen.
                morality.Items.Clear();

                removedBackground.Clear();
                removedKnowledge.Clear();
                removedTalent.Clear();
                removedAbility.Clear();
                removedPower.Clear();
                ComboAndTextBoxClear();
                PopulateComboBoxOptions();

                int choice = (Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()) - 1);

                try
                {
                    

                    if (theDataBase.characterList[choice] is Mortal)
                    {
                        Mortal mortalEntry;

                        mortalEntry = theDataBase.characterList[choice] as Mortal;

                        characterTextBox.Text = mortalEntry.char_Name.Text;
                        playerTextBox.Text = mortalEntry.player_Name.Text;
                        natureTextBox.Text = mortalEntry.nature.Text;
                        ageTextBox.Text = mortalEntry.age.Numeric.ToString();
                        genreTextBox.Text = mortalEntry.genre.Text;
                        demeanorTextBox.Text = mortalEntry.demeanor.Text;
                        genderTextBox.Text = mortalEntry.gender.Text;
                        strengthTextBox.Text = mortalEntry.phy_Strength.Numeric.ToString();
                        staminaTextBox.Text = mortalEntry.phy_Stamina.Numeric.ToString();
                        dexterityTextBox.Text = mortalEntry.phy_Dexterity.Numeric.ToString();
                        witTextBox.Text = mortalEntry.men_Wit.Numeric.ToString();
                        intellectTextBox.Text = mortalEntry.men_Intellect.Numeric.ToString();
                        resolveTextBox.Text = mortalEntry.men_Resolve.Numeric.ToString();
                        charismaTextBox.Text = mortalEntry.soc_Charisma.Numeric.ToString();
                        manipulationTextBox.Text = mortalEntry.soc_Manipulation.Numeric.ToString();
                        composureTextBox.Text = mortalEntry.soc_Composure.Numeric.ToString();
                        tWillpowerTextBox.Text = mortalEntry.temp_Willpower.Numeric.ToString();
                        pWillpowerTextBox.Text = mortalEntry.perm_Willpower.Numeric.ToString();
                        virtueSelfTextBox.Text = mortalEntry.virtue_Self_Control.Numeric.ToString();
                        virtueCourageTextBox.Text = mortalEntry.virtue_Courage.Numeric.ToString();
                        virtueConscienceTextBox.Text = mortalEntry.virtue_Conscience.Numeric.ToString();
                        StoryTextBox.Text = mortalEntry.background_story.Description;
                        dtpCreation.Value = mortalEntry.creation;
                        dtpLastModified.Value = mortalEntry.last_modified;
                        morality.Text = mortalEntry.morality.Text;
                        moralityTextBox.Text = mortalEntry.morality.Numeric.ToString();
                        factionTextBox.Text = mortalEntry.faction.Text;
                        txtSpentXP.Text = mortalEntry.spent_xp.Numeric.ToString();
                        txtUnspentXP.Text = mortalEntry.unspent_xp.Numeric.ToString();


                        groupGenre.Text = "Mortal Character";

                        comboBackground1Value.Enabled = true;

                        genreType1.Text = "Not Applicable";
                        genreType1Value.Text = "";

                        genreType2.Text = "Not Applicable";
                        genreType2Value.Text = "";

                        genrePower1.Text = "Not Applicable";
                        genrePower1Value.Text = "";

                        genrePower2.Text = "Blood Pool";
                        genrePower2Value.Enabled = true;

                        genreFlawsValue.Text = "";

                        genreFlaws2Value.Text = "";

                        BackgroundRead(mortalEntry);
                        AbilityRead(mortalEntry);
                        TalentRead(mortalEntry);
                        KnowledgeRead(mortalEntry);
                        MeritRead(mortalEntry);
                        FlawRead(mortalEntry);

                    }
                    else if (theDataBase.characterList[choice] is Vampire)
                    {
                        Vampire vampEntry;

                        vampEntry = theDataBase.characterList[choice] as Vampire;

                        characterTextBox.Text = vampEntry.char_Name.Text;
                        playerTextBox.Text = vampEntry.player_Name.Text;
                        natureTextBox.Text = vampEntry.nature.Text;
                        ageTextBox.Text = vampEntry.age.Numeric.ToString();
                        demeanorTextBox.Text = vampEntry.demeanor.Text;
                        genderTextBox.Text = vampEntry.gender.Text;
                        strengthTextBox.Text = vampEntry.phy_Strength.Numeric.ToString();
                        staminaTextBox.Text = vampEntry.phy_Stamina.Numeric.ToString();
                        dexterityTextBox.Text = vampEntry.phy_Dexterity.Numeric.ToString();
                        witTextBox.Text = vampEntry.men_Wit.Numeric.ToString();
                        intellectTextBox.Text = vampEntry.men_Intellect.Numeric.ToString();
                        resolveTextBox.Text = vampEntry.men_Resolve.Numeric.ToString();
                        charismaTextBox.Text = vampEntry.soc_Charisma.Numeric.ToString();
                        manipulationTextBox.Text = vampEntry.soc_Manipulation.Numeric.ToString();
                        composureTextBox.Text = vampEntry.soc_Composure.Numeric.ToString();
                        tWillpowerTextBox.Text = vampEntry.temp_Willpower.Numeric.ToString();
                        pWillpowerTextBox.Text = vampEntry.perm_Willpower.Numeric.ToString();
                        virtueSelfTextBox.Text = vampEntry.virtue_Self_Control.Numeric.ToString();
                        virtueCourageTextBox.Text = vampEntry.virtue_Courage.Numeric.ToString();
                        virtueConscienceTextBox.Text = vampEntry.virtue_Conscience.Numeric.ToString();
                        StoryTextBox.Text = vampEntry.background_story.Description;
                        txtSpentXP.Text = vampEntry.spent_xp.Numeric.ToString();
                        txtUnspentXP.Text = vampEntry.unspent_xp.Numeric.ToString();

                        // This information will be relevant to determine the different moralities than be chosen.
                        genreTextBox.Text = vampEntry.genre.Text;
                        factionTextBox.Text = vampEntry.faction.Text;
                        genreType1Value.Text = vampEntry.clan.Text;
                        if (vampEntry.bloodline.Text != null)
                        {
                            genreType2Value.Text = vampEntry.bloodline.Text;
                        }
                        dtpCreation.Value = vampEntry.creation;
                        dtpLastModified.Value = vampEntry.last_modified;
                        morality.Text = vampEntry.morality.Text;
                        moralityTextBox.Text = vampEntry.morality.Numeric.ToString();
                        // This will display the bloodline of the vampire if a bloodline was chosen when entered into the database.


                        genrePower1Value.Text = vampEntry.generation.Numeric.ToString();
                        genrePower2Value.Text = vampEntry.bloodpool.Numeric.ToString();

                        groupGenre.Text = "Vampire Character";

                        genreType1.Text = "Clan";
                        genreType1Value.Enabled = true;

                        genreType2.Text = "Bloodline";
                        genreType2Value.Enabled = true;

                        genrePower1.Text = "Generation";
                        genrePower1Value.Enabled = true;

                        genrePower2.Text = "Blood Pool";
                        genrePower2Value.Enabled = true;

                        comboBackground1Value.Enabled = true;

                        genreFlawsValue.Enabled = true;

                        foreach (ComboBox c in comboPowers_list)
                        {
                            c.ResetText();
                        }

                        foreach (TextBox t in comboPowers_values)
                        {
                            t.ResetText();
                        }

                        PowerRead(vampEntry);
                        BackgroundRead(vampEntry);
                        AbilityRead(vampEntry);
                        TalentRead(vampEntry);
                        KnowledgeRead(vampEntry);
                        MeritRead(vampEntry);
                        FlawRead(vampEntry);

                    }

                    tabControl.SelectTab(0);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString(), "Error while Reading Data Entry", MessageBoxButtons.OK);
                }
            }
        }

        private void deleteFromDatabaseButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = -1;
                if (!characterTextBox.Text.Equals(""))
                {
                    if (!playerTextBox.Text.Equals(""))
                    {

                        foreach (Character c in theDataBase.characterList)
                        {
                            if (characterTextBox.Text.Equals(c.char_Name.Text))
                            {
                                if (playerTextBox.Text.Equals(c.player_Name.Text))
                                {
                                    if (genreTextBox.Text.Equals(c.genre.Text))
                                    {
                                        if (genderTextBox.Text.Equals(c.gender.Text))
                                        {
                                            index = theDataBase.characterList.IndexOf(c);
                                        }
                                    }
                                }
                            }
                        }

                        theDataBase.DeleteCharacter(index);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "ERROR", MessageBoxButtons.OK);
            }

            FillData();
        }

        private void aboutInnuendoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void frequentlyAskedQuestionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAQForm faq = new FAQForm();
            faq.ShowDialog();
        }

        // This is the fun part; I have different combo boxes set up, so that if a box has a specific value as the selected text, other combo boxes will have
        // specific options assigned to them so that I can ensure that a user can't make an inaccurate or illegal combination of different abilities, skills,
        // or clans.

        private void genreTextBox_SelectionMade(object sender, EventArgs e)
        {
            if (genreTextBox.Text.ToLower().Equals("vampire"))
            {
                genreType1Value.Enabled = true;
                genreType2Value.Enabled = true;
                genrePower1Value.ReadOnly = false;
                genrePower2Value.ReadOnly = false;
                genrePower2Value.Text = "";
                morality.Enabled = true;
                factionTextBox.Enabled = true;
                this.BackColor = Color.DarkRed;
            }
            else if (genreTextBox.Text.ToLower().Equals("mortal"))
            {
                genreType1Value.Enabled = false;
                genreType2Value.Enabled = false;
                genrePower1Value.ReadOnly = true;
                genrePower2Value.ReadOnly = true;
                genrePower2Value.Text = "10";
                morality.Text = "Humanity";
                morality.Enabled = false;
                this.BackColor = Color.LightSkyBlue;
            }
        }

        private void genreType1Value_SelectionMade(object sender, EventArgs e)
        {
            // In this, once we know they're entering a vampire character into the database, we can then set up the defaults for displines the user can choose from.
            // As these defaults are considered in-clan disiplines, these will have the in-clan cost algorithm applied to them.  The other disiplines, unless they are a bloodline
            // and have the bloodline disipline, will be considered out-of-clan and use the out-of-clan cost algorithym instead.

            switch (genreType1Value.Text)
            {
                case "Assamite":
                    foreach (ComboBox c in comboPowers_list)
                    {
                        // In-clan disiplines: 
                        c.Items.Clear();
                        c.Items.Add("Celerity");
                        c.Items.Add("Obfuscate");
                        c.Items.Add("Quietus");
                    }

                    // Assigning the Assamite bloodlines available to the genreType2Value combo box
                    genreType2Value.Items.Clear();
                    genreType2Value.Items.Add("None");
                    genreType2Value.Items.Add("Antitribu");
                    genreType2Value.Items.Add("Bedouins");
                    genreType2Value.Items.Add("Courtiers");
                    genreType2Value.Items.Add("Sorcerer");
                    genreType2Value.Items.Add("Vizier");
                    genreType2Value.Items.Add("Baali Apostate");

                    genreFlawsValue.Text = "Assamites have a penalty to resist diablerie when feeding from another vampire, or when smelling the blood of another vampire.";

                    break;

                case "Baali":
                    foreach (ComboBox c in comboPowers_list)
                    {
                        c.Items.Clear();
                        c.Items.Add("Daimonion");
                        c.Items.Add("Presence");
                        c.Items.Add("Obfuscate");
                    }

                    // Assigning the Baali bloodlines available to the genreType2Value combo box
                    genreType2Value.Items.Clear();
                    genreType2Value.Items.Add("None");
                    genreType2Value.Items.Add("Azaneali");
                    genreType2Value.Items.Add("Avatar of the Swarm");
                    genreType2Value.Items.Add("Celestial");
                    genreType2Value.Items.Add("Children of Enigma");
                    genreType2Value.Items.Add("Destroyer");

                    genreFlawsValue.Text = "Baali have a penalty against locations that are blessed.  They suffer when in contests against an individual who has the 'True Faith' merit.";

                    break;

                case "Brujah":
                    foreach (ComboBox c in comboPowers_list)
                    {
                        c.Items.Clear();
                        c.Items.Add("Celerity");
                        c.Items.Add("Potence");
                        c.Items.Add("Presence");
                    }

                    // Assigning the Brujah bloodlines available to the genreType2Value combo box
                    genreType2Value.Items.Clear();
                    genreType2Value.Items.Add("None");
                    genreType2Value.Items.Add("Antitribu");
                    genreType2Value.Items.Add("True Brujah");
                    genreType2Value.Items.Add("Baali Apostate");

                    genreFlawsValue.Text = "Brujah have a penalty to resist frenzy.";

                    break;

                case "Gangrel":
                    foreach (ComboBox c in comboPowers_list)
                    {
                        c.Items.Clear();
                        c.Items.Add("Animalism");
                        c.Items.Add("Fortitude");
                        c.Items.Add("Protean");
                    }

                    // Assigning the Gangrel bloodlines available to the genreType2Value combo box
                    genreType2Value.Items.Clear();
                    genreType2Value.Items.Add("None");
                    genreType2Value.Items.Add("Antitribu");
                    genreType2Value.Items.Add("Ahrimanes");
                    genreType2Value.Items.Add("Anda");
                    genreType2Value.Items.Add("Mariner Gangrel");
                    genreType2Value.Items.Add("Lhiannon");
                    genreType2Value.Items.Add("Noiad");
                    genreType2Value.Items.Add("Baali Apostate");

                    genreFlawsValue.Text = "After frenzying, Gangrel gain a Beastial trait; enough of these will change a Gangrel's nature or demeanor.";

                    break;

                case "Followers of Set":
                    foreach (ComboBox c in comboPowers_list)
                    {
                        c.Items.Clear();
                        c.Items.Add("Obfuscate");
                        c.Items.Add("Presence");
                        c.Items.Add("Serpentis");
                    }

                    // Assigning the Followers of Set bloodlines available to the genreType2Value combo box
                    genreType2Value.Items.Clear();
                    genreType2Value.Items.Add("None");
                    genreType2Value.Items.Add("Antitribu");
                    genreType2Value.Items.Add("Warrior Setite");
                    genreType2Value.Items.Add("Tlacique");
                    genreType2Value.Items.Add("Baali Apostate");

                    genreFlawsValue.Text = "Followers of Set suffer in the presence of any bright light.  Direct sunlight causes damage.";

                    break;

                case "Giovanni":
                    foreach (ComboBox c in comboPowers_list)
                    {
                        c.Items.Clear();
                        c.Items.Add("Dominate");
                        c.Items.Add("Necromancy");
                        c.Items.Add("Potence");
                    }

                    // Assigning the Giovanni bloodlines available to the genreType2Value combo box
                    genreType2Value.Items.Clear();
                    genreType2Value.Items.Add("None");
                    genreType2Value.Items.Add("Antitribu");
                    genreType2Value.Items.Add("Milliner");
                    genreType2Value.Items.Add("David");
                    genreType2Value.Items.Add("Richards");
                    genreType2Value.Items.Add("Baali Apostate");

                    genreFlawsValue.Text = "Giovanni cannot drink freely from mortals, as their bite causes intense pain.";

                    break;

                case "Lasombra":
                    foreach (ComboBox c in comboPowers_list)
                    {
                        c.Items.Clear();
                        c.Items.Add("Dominate");
                        c.Items.Add("Obtenebration");
                        c.Items.Add("Potence");
                    }

                    // Assigning the Lasombra bloodlines available to the genreType2Value combo box
                    genreType2Value.Items.Clear();
                    genreType2Value.Items.Add("None");
                    genreType2Value.Items.Add("Antitribu");
                    genreType2Value.Items.Add("Angelis Ater");
                    genreType2Value.Items.Add("Kiasyd");
                    genreType2Value.Items.Add("Baali Apostate");

                    genreFlawsValue.Text = "Lasombra do not have a reflection in mirrors.";

                    break;

                case "Malkavian":
                    foreach (ComboBox c in comboPowers_list)
                    {
                        c.Items.Clear();
                        c.Items.Add("Celerity");
                        c.Items.Add("Dominate");
                        c.Items.Add("Dementation");
                        c.Items.Add("Obfuscate");
                    }

                    // Assigning the Malkavian bloodlines available to the genreType2Value combo box
                    genreType2Value.Items.Clear();
                    genreType2Value.Items.Add("None");
                    genreType2Value.Items.Add("Antitribu");
                    genreType2Value.Items.Add("Baali Apostate");

                    genreFlawsValue.Text = "Malkavians have a derangement that cannot be bought off in any way.";

                    break;

                case "Nosferatu":
                    foreach (ComboBox c in comboPowers_list)
                    {
                        c.Items.Clear();
                        c.Items.Add("Animalism");
                        c.Items.Add("Obfuscate");
                        c.Items.Add("Fortitude");
                    }

                    // Assigning the Nosferatu bloodlines available to the genreType2Value combo box
                    genreType2Value.Items.Clear();
                    genreType2Value.Items.Add("None");
                    genreType2Value.Items.Add("Antitribu");
                    genreType2Value.Items.Add("Nictuku");
                    genreType2Value.Items.Add("Baali Apostate");

                    genreFlawsValue.Text = "Nosferatu cannot have an appearance rating above 0, except in the case of specific Merits or the usage of Disciplines.";

                    break;

                case "Ravnos":
                    foreach (ComboBox c in comboPowers_list)
                    {
                        c.Items.Clear();
                        c.Items.Add("Animalism");
                        c.Items.Add("Fortitude");
                        c.Items.Add("Chimerstry");
                    }

                    // Assigning the Ravnos bloodlines available to the genreType2Value combo box
                    genreType2Value.Items.Clear();
                    genreType2Value.Items.Add("None");
                    genreType2Value.Items.Add("Antitribu");
                    genreType2Value.Items.Add("Brahman");
                    genreType2Value.Items.Add("Phuri Dae");
                    genreType2Value.Items.Add("Baali Apostate");

                    genreFlawsValue.Text = "Each Ravnos has a specific vice ranging from plagiarism to mass murder. When the opportunity to indulge that vice is present, Ravnos must succeed in a self-control check to avoid indulging it.";

                    break;

                case "Salubri":
                    foreach (ComboBox c in comboPowers_list)
                    {
                        c.Items.Clear();
                        c.Items.Add("Auspex");
                        c.Items.Add("Fortitude");
                        c.Items.Add("Obeah");
                    }

                    // Assigning the Salubri bloodlines available to the genreType2Value combo box
                    genreType2Value.Items.Clear();
                    genreType2Value.Items.Add("None");
                    genreType2Value.Items.Add("Antitribu");
                    genreType2Value.Items.Add("Warrior");
                    genreType2Value.Items.Add("Healer");
                    genreType2Value.Items.Add("Watcher");
                    genreType2Value.Items.Add("Wu Zao");

                    genreFlawsValue.Text = "Salubri cannot drink from an unwilling mortal; any vitae that was drawn from an unwilling source is vomited immediately after.";

                    break;

                case "Toreador":
                    foreach (ComboBox c in comboPowers_list)
                    {
                        c.Items.Clear();
                        c.Items.Add("Celerity");
                        c.Items.Add("Auspex");
                        c.Items.Add("Presence");
                    }

                    // Assigning the Toreador bloodlines available to the genreType2Value combo box
                    genreType2Value.Items.Clear();
                    genreType2Value.Items.Add("None");
                    genreType2Value.Items.Add("Antitribu");
                    genreType2Value.Items.Add("Daughter of Cacophony");
                    genreType2Value.Items.Add("Baali Apostate");

                    genreFlawsValue.Text = "Toreador have difficulty to avoid entering a fugue when viewing any object with a Crafts rating of 4 or higher.";

                    break;

                case "Tremere":
                    foreach (ComboBox c in comboPowers_list)
                    {
                        c.Items.Clear();
                        c.Items.Add("Auspex");
                        c.Items.Add("Fortitude");
                        c.Items.Add("Thaumaturgy");
                    }

                    // Assigning the Tremere bloodlines available to the genreType2Value combo box
                    genreType2Value.Items.Clear();
                    genreType2Value.Items.Add("None");
                    genreType2Value.Items.Add("Antitribu");
                    genreType2Value.Items.Add("Telyavelic");
                    genreType2Value.Items.Add("Baali Apostate");

                    genreFlawsValue.Text = "Tremere have a Blood Bond to the Council of Seven.";

                    break;

                case "Tzimisce":
                    foreach (ComboBox c in comboPowers_list)
                    {
                        c.Items.Clear();
                        c.Items.Add("Potence");
                        c.Items.Add("Auspex");
                        c.Items.Add("Vicissitude");
                    }

                    // Assigning the Tzimisce bloodlines available to the genreType2Value combo box
                    genreType2Value.Items.Clear();
                    genreType2Value.Items.Add("None");
                    genreType2Value.Items.Add("Antitribu");
                    genreType2Value.Items.Add("Old Clan");
                    genreType2Value.Items.Add("Baali Apostate");

                    genreFlawsValue.Text = "Whenever a Tzimisce sleeps, they must surround themselves with at least two handfuls of earth from a place important to them as a mortal. Failure to meet this requirement reduces the Tzimisce's dice pools every 24 hours, until all their actions use only one die.";

                    break;

                case "Ventrue":
                    foreach (ComboBox c in comboPowers_list)
                    {
                        c.Items.Clear();
                        c.Items.Add("Animalism");
                        c.Items.Add("Dominate");
                        c.Items.Add("Fortitude");
                    }

                    // Assigning the Ventrue bloodlines available to the genreType2Value combo box
                    genreType2Value.Items.Clear();
                    genreType2Value.Items.Add("None");
                    genreType2Value.Items.Add("Antitribu");
                    genreType2Value.Items.Add("Danava");
                    genreType2Value.Items.Add("Baali Apostate");

                    genreFlawsValue.Text = "Ventrue have only one type of blood that they can draw sustinence from, or while in frenzy.  Any other source of vitae is vomited up immediately after any attempt to ingest it.";

                    break;

                case "Caitiff":
                    foreach (ComboBox c in comboPowers_list)
                    {
                        c.Items.Clear();
                        c.Items.Add("Yes");
                        c.Items.Add("Yes, Indeed");
                        c.Items.Add("Yes, Indeedy, Dooby");
                    }

                    // Assigning the Caitiff bloodlines available to the genreType2Value combo box
                    genreType2Value.Items.Clear();
                    genreType2Value.Items.Add("None");
                    genreType2Value.Items.Add("Pander");
                    genreType2Value.Items.Add("Baali Apostate");

                    genreFlawsValue.Text = "Caitiff powers are always considered out-of-clan in terms of experience costs.";

                    break;

            }

            morality.Enabled = true;

        }

        private void genreType2Value_SelectionMade(object sender, EventArgs e)
        {
            genreFlaws2Value.Text = "";
            switch (genreType2Value.Text)
            {
                case "Antitribu":
                    if (genreType1Value.Text == "Toreador")
                    {
                        genreFlaws2Value.Text = "Toreador's clan flaw is warped; instead of something of beauty, the object of fugue must be something that inflicts violence.";
                    }
                    else if (genreType1Value.Text == "Gangrel")
                    {
                        genreFlaws2Value.Text = "Gangrel gain animal traits that are typically those found in the cities and towns that humanity lives in, such as spiders, dogs, etc.";
                    }
                    else
                    {
                        genreFlaws2Value.Text = "Antitribu do not have an additional flaw.";
                    }
                    break;

                case "Bedouins":
                    genreFlaws2Value.Text = "Bedouins ... stuff.";

                    break;

                case "Courtiers":
                    genreFlaws2Value.Text = "Courtiers ... stuff.";

                    break;

                case "Sorcerer":
                    genreFlaws2Value.Text = "Sorcerers ... stuff.";

                    break;

                case "Danava":
                    genreFlaws2Value.Text = "Danava must consecrate the vessel in a ritual before feeding. Failure to do so causes the vampire gain limited sustenence.";
                    break;

                case "Azaneali":
                    genreFlaws2Value.Text = "Azaneali ... stuff.";

                    break;

                case "Avatar of the Swarm":
                    genreFlaws2Value.Text = "Avatars of the Swarm ... stuff.";

                    break;

                case "Celestial":
                    genreFlaws2Value.Text = "";

                    break;

                case "Children of Enigma":
                    genreFlaws2Value.Text = "";

                    break;

                case "Destroyer":
                    genreFlaws2Value.Text = "Each Ravnos has a specific vice ranging from plagiarism to mass murder. When the opportunity to indulge that vice is present, Ravnos must succeed in a self-control check to avoid indulging it.";

                    break;

                case "True Brujah":
                    genreFlaws2Value.Text = "True Brujah suffer a penalty to Charisma challenges.";

                    break;

                case "Ahrimanes":
                    genreFlaws2Value.Text = "Ahrimanes cannot Embrace nor Blood Bond other vampires.";
                    foreach (ComboBox c in comboPowers_list)
                    {
                        // In-clan disiplines: 
                        if (!c.Items.Contains("Spiritus"))
                        { c.Items.Add("Spiritus"); }
                    }
                    break;

                case "Anda":
                    genreFlaws2Value.Text = "Anda have a penalty in Social challenges.";
                    break;

                case "Mariner Gangrel":
                    genreFlaws2Value.Text = "Mariner Gangrel will always gain Beast Traits that are tied to marine animals.";

                    break;

                case "Lhiannon":
                    genreFlaws2Value.Text = "Lhiannon lose challenge dice the longer they are away from their haven location until they return to it.";

                    break;

                case "Noiad":
                    genreFlaws2Value.Text = "Noiad cannot gain Vitae from animals; any attempt will result in vomiting the Vitae immediately.";
                    foreach (ComboBox c in comboPowers_list)
                    {
                        if (c.Items.Contains("Fortitude"))
                        {
                            c.Items.Remove("Fortitude");
                            c.Items.Add("Auspex");
                        }
                    }
                    break;

                case "Warrior":
                    genreFlaws2Value.Text = "Warriors suffer a penalty when resisting the urge to remove corruption, as determined by their Morality.";
                    foreach (ComboBox c in comboPowers_list)
                    {
                        if (c.Items.Contains("Obeah"))
                        {
                            c.Items.Remove("Obeah");
                            c.Items.Add("Valeren - Warrior");
                        }
                    }
                    break;

                case "Healer":
                    genreFlaws2Value.Text = "Healers suffer a penalty when resisting the urge to allow harm to come to an innocent, as determined by their Morality.";
                    break;

                case "Watcher":
                    genreFlaws2Value.Text = "Watchers suffer a penalty when resisting the urge to uncover any knowledge pertaining to surpassing the vampiric condition.";
                    foreach (ComboBox c in comboPowers_list)
                    {
                        if (c.Items.Contains("Obeah"))
                        {
                            c.Items.Remove("Obeah");
                            c.Items.Add("Valeren - Watcher");
                        }
                    }
                    break;

                case "Tlacique":
                    genreFlaws2Value.Text = "Tlacique are more vulnerable to supernatural damage.";
                    foreach (ComboBox c in comboPowers_list)
                    {
                        if (c.Items.Contains("Serpentis"))
                        {
                            c.Items.Remove("Serpentis");
                            c.Items.Add("Protean");
                        }
                    }

                    break;

                case "Daughter of Cacophony":
                    genreFlaws2Value.Text = "Daughters of Cacophony have a penalty for Perception challenges.";

                    break;

                case "Phuri Dae":
                    genreFlaws2Value.Text = "Phuri Dae struggle with a more powerful version of the parent clan's flaw.";
                    foreach (ComboBox c in comboPowers_list)
                    {
                        if (c.Items.Contains("Fortitude"))
                        {
                            c.Items.Remove("Fortitude");
                            c.Items.Add("Auspex");
                        }
                    }
                    break;

            }
        }

        private void factionTextBox_SelectionMade(object sender, EventArgs e)
        {
            // This will be where I determine the point values of the character that's being entered, validated, or chosen.
            morality.Items.Clear();
            // Here is where I assign the starting morality paths available to each character, based on if they're a vampire, what faction they're in, 
            // what clan they're in, or what bloodline they are a part of.
            morality.Items.Add("Humanity");

            switch (genreTextBox.Text)
            {
                case "Mortal":
                    break;
                case "Vampire":
                    morality_list_FactionOptions();
                    morality_list_ClanOptions();
                    break;
            }

        }

        private void morality_list_FactionOptions()
        {
            switch (factionTextBox.Text)
            {
                case "Camarilla":
                    break;
                case "Sabbat":
                    morality.Items.Add("Path of Honorable Accord");
                    morality.Items.Add("Path of Caine");
                    morality.Items.Add("Path of Cathari");
                    morality.Items.Add("Path of Lilith");
                    morality.Items.Add("Path of Power and the Inner Voice");
                    break;
                case "Inconnu":
                    break;
                case "Anarch":
                    morality.Items.Add("Path of Enlightenment");
                    break;
                case "Tal'Mahe'Ra":
                    morality.Items.Add("Path of Enlightenment");
                    break;
            }
        }

        private void morality_list_ClanOptions()
        {

            switch (genreType1Value.Text)
            {
                case "Assamite":
                    if (!morality.Items.Contains("Path of Blood"))
                    {
                        morality.Items.Add("Path of Blood");
                    }
                    break;

                case "Baali":
                    if (!morality.Items.Contains("Path of the Hive"))
                    {
                        morality.Items.Add("Path of the Hive");
                    }
                    break;

                case "Cappadocian":
                    if (!morality.Items.Contains("Path of Bones"))
                    {
                        morality.Items.Add("Path of Bones");
                    }
                    break;


                case "Followers of Set":
                    if (!morality.Items.Contains("Path of Typhon"))
                    {
                        morality.Items.Add("Path of Typhon");
                    }
                    break;


                case "Lasombra":
                    if (!morality.Items.Contains("Path of Night"))
                    {
                        morality.Items.Add("Path of Night");
                    }
                    break;

                case "Ravnos":
                    if (!morality.Items.Contains("Path of Paradox"))
                    {
                        morality.Items.Add("Path of Paradox");
                    }

                    break;
                case "Tzimisce":
                    if (!morality.Items.Contains("Path of Metamorphosis"))
                    {
                        morality.Items.Add("Path of Metamorphosis");
                    }

                    break;
            }
        }

        private void ComboAndTextBoxClear()
        {
            foreach (ComboBox plist in comboPowers_list)
            {
                plist.Text = "";
                plist.Items.Clear();
            }

            foreach (TextBox pvalue in comboPowers_values)
            {
                pvalue.Text = "";
            }

            foreach (ComboBox alist in comboAbility_list)
            {
                alist.Text = "";
                alist.Items.Clear();
            }

            foreach (TextBox avalue in comboAbility_values)
            {
                avalue.Text = "";
            }

            foreach (ComboBox blist in comboBackground_list)
            {
                blist.Text = "";
                blist.Items.Clear();
            }

            foreach (TextBox bvalue in comboBackground_values)
            {
                bvalue.Text = "";
            }

            foreach (ComboBox tlist in comboTalent_list)
            {
                tlist.Text = "";
                tlist.Items.Clear();
            }

            foreach (TextBox tvalue in comboTalent_values)
            {
                tvalue.Text = "";
            }

            foreach (ComboBox klist in comboKnowledge_list)
            {
                klist.Text = "";
                klist.Items.Clear();
            }

            foreach (TextBox kvalue in comboKnowledge_values)
            {
                kvalue.Text = "";
            }

            foreach (ComboBox mlist in comboMerits_list)
            {
                mlist.Text = "";
                mlist.Items.Clear();
            }

            foreach (TextBox mvalue in comboMerits_values)
            {
                mvalue.Text = "0";

            }

            foreach (ComboBox flist in comboFlaws_list)
            {
                flist.Text = "";
                flist.Items.Clear();
            }

            foreach (TextBox fvalue in comboFlaws_values)
            {
                fvalue.Text = "0";
            }
        }

        /* 
         * The BackgroundRead, TalentRead, AbilityRead, KnowledgeRead, and PowerRead methods
         * will read from the character saved in the database and puts the saved data into the 
         * appropriate combobox and textbox for each.
         * 
         * MeritRead, FlawRead, BackgroundRead, TalentRead, AbilityRead, and KnowledgeRead will work for any character; PowerRead
         * will work for characters that are Vampires.  I will work out an alternative method that determines if
         * the character parameter is not a mortal.
         */

        private void ListRead(Character c, ArrayList list, string criteria)
        {
            foreach (Attribute a in list)
            {
                if (a.Text.Contains(criteria))
                {
                    string[] entry = { (theDataBase.characterList.LastIndexOf(c) + 1).ToString(), c.player_Name.Text, c.char_Name.Text };
                    dataGridView1.Rows.Add(entry);
                }
            }
        }

        private void SkillRead(Character entry, ArrayList list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Attribute power = list[i] as Attribute;

                if (!power.Text.Equals(null))
                {
                    string text = power.Text;
                    string value = power.Numeric.ToString();
                }
            }
        }

        private void BackgroundRead(Character entry)
        {
            for (int i = 0; i < entry.backgroundList.Count; i++)
            {
                Attribute power = entry.backgroundList[i] as Attribute;
                ComboBox combo_box = comboBackground_list[i] as ComboBox;
                TextBox value = comboBackground_values[i] as TextBox;

                if (!power.Text.Equals(null))
                {
                    combo_box.Text = power.Text;
                    value.Text = power.Numeric.ToString();
                }
            }
        }

        private void AbilityRead(Character entry)
        {
            for (int i = 0; i < entry.abilitiesList.Count; i++)
            {
                Attribute power = entry.abilitiesList[i] as Attribute;
                ComboBox combo_box = comboAbility_list[i] as ComboBox;
                TextBox value = comboAbility_values[i] as TextBox;

                if (!power.Text.Equals(null))
                {
                    combo_box.Text = power.Text;
                    value.Text = power.Numeric.ToString();
                }
            }
        }

        private void TalentRead(Character entry)
        {
            for (int i = 0; i < entry.talentsList.Count; i++)
            {
                Attribute power = entry.talentsList[i] as Attribute;
                ComboBox combo_box = comboTalent_list[i] as ComboBox;
                TextBox value = comboTalent_values[i] as TextBox;

                if (!power.Text.Equals(null))
                {
                    combo_box.Text = power.Text;
                    value.Text = power.Numeric.ToString();
                }
            }
        }

        private void KnowledgeRead(Character entry)
        {
            for (int i = 0; i < entry.knowledgesList.Count; i++)
            {
                Attribute power = entry.knowledgesList[i] as Attribute;
                ComboBox combo_box = comboKnowledge_list[i] as ComboBox;
                TextBox value = comboKnowledge_values[i] as TextBox;

                if (!power.Text.Equals(null))
                {
                    combo_box.Text = power.Text;
                    value.Text = power.Numeric.ToString();
                }
            }
        }

        private void MeritRead(Character entry)
        {

            for (int i = 0; i < entry.meritList.Count; i++)
            {
                Attribute power = entry.meritList[i] as Attribute;
                ComboBox combo_box = comboMerits_list[i] as ComboBox;
                TextBox value = comboMerits_values[i] as TextBox;

                if (!power.Text.Equals(null))
                {
                    combo_box.Text = power.Text;
                    value.Text = power.Numeric.ToString();
                }
            }
        }

        private void FlawRead(Character entry)
        {

            for (int i = 0; i < entry.flawList.Count; i++)
            {
                Attribute power = entry.flawList[i] as Attribute;
                ComboBox combo_box = comboFlaws_list[i] as ComboBox;
                TextBox value = comboFlaws_values[i] as TextBox;

                if (!power.Text.Equals(null))
                {
                    combo_box.Text = power.Text;
                    value.Text = power.Numeric.ToString();
                }
            }
        }

        private void PowerRead(Vampire entry)
        {

            for (int i = 0; i < entry.disiplines_list.Count; i++)
            {
                Attribute power = entry.disiplines_list[i] as Attribute;
                ComboBox combo_box = comboPowers_list[i] as ComboBox;
                TextBox value = comboPowers_values[i] as TextBox;

                if (!power.Text.Equals(null))
                {
                    combo_box.Text = power.Text;
                    value.Text = power.Numeric.ToString();
                }
            }
        }

        private void PopulateComboBoxOptions()
        {
            foreach (ComboBox skill in comboAbility_list)
            {
                skill.Items.Add("Animal Ken");
                skill.Items.Add("Drive");
                skill.Items.Add("Etiquette");
                skill.Items.Add("Firearms");
                skill.Items.Add("Melee");
                skill.Items.Add("Music");
                skill.Items.Add("Repair");
                skill.Items.Add("Security");
                skill.Items.Add("Stealth");
                skill.Items.Add("Survival");
            }
            foreach (ComboBox background in comboBackground_list)
            {
                background.Items.Add("Allies");
                background.Items.Add("Contacts");
                background.Items.Add("Fame");
                background.Items.Add("Generation");
                background.Items.Add("Herd");
                background.Items.Add("Influence");
                background.Items.Add("Mentor");
                background.Items.Add("Resources");
                background.Items.Add("Retainers");
                background.Items.Add("Status");

            }
            foreach (ComboBox talent in comboTalent_list)
            {
                talent.Items.Add("Acting");
                talent.Items.Add("Alertness");
                talent.Items.Add("Athletics");
                talent.Items.Add("Brawl");
                talent.Items.Add("Dodge");
                talent.Items.Add("Empathy");
                talent.Items.Add("Intimidation");
                talent.Items.Add("Leadership");
                talent.Items.Add("Streetwise");
                talent.Items.Add("Subterfuge");
            }
            foreach (ComboBox knowledge in comboKnowledge_list)
            {
                knowledge.Items.Add("Bureaucracy");
                knowledge.Items.Add("Computer");
                knowledge.Items.Add("Finance");
                knowledge.Items.Add("Investigation");
                knowledge.Items.Add("Law");
                knowledge.Items.Add("Linguistics");
                knowledge.Items.Add("Medicine");
                knowledge.Items.Add("Occult");
                knowledge.Items.Add("Politics");
                knowledge.Items.Add("Science");
            }
            foreach (ComboBox merit in comboMerits_list)
            {
                merit.Items.Add("Acute Sense - 2 pt");
                merit.Items.Add("Ambidexterous - 1 pt");
                merit.Items.Add("Huge Size - 3 pt");
                merit.Items.Add("Medium - 3 pt");
                merit.Items.Add("Iron Will - 2 pt");

            }
            foreach (ComboBox flaw in comboFlaws_list)
            {
                flaw.Items.Add("Color Blindness - 1 pt");
                flaw.Items.Add("Child - 3 pt");
                flaw.Items.Add("Dark Fate - 5 pt");
                flaw.Items.Add("Enemy - 4 pt");
                flaw.Items.Add("Haunted - 2 pt");
            }
        }

        private void ComboBox_SelectionMade(object sender, EventArgs e)
        {
            // Step one   - Get the index value of the ComboBox that was modified.
            // Step two   - Remove the value that was chosen in the modified box from all other choices.
            // Step three - Restore the value if no boxes have it chosen or available as a choice.
            // Step four - Profit.

            ComboBox choice = sender as ComboBox;

            if (comboPowers_list.Contains(choice))
            {
                foreach (ComboBox power in comboPowers_list)
                {
                    if (!sender.Equals(power))
                    {
                        power.Items.Remove(choice.Text);

                        if (!removedPower.Contains(choice.Text))
                        {
                            removedPower.Add(choice.Text);
                        }
                    }
                }
                if (removedPower.Count > 0)
                {
                    bool choice_not_found = false;
                    foreach (ComboBox power in comboPowers_list)
                    {

                        if (power.Text.Contains(removedPower[0] as string))
                        {
                            break;
                            /* In theory, this should break the loop entirely so that once this removed
                             * entry is found in one of the ComboBoxes, it won't attempt to repopulate 
                             * the option back into the drop-down lists.*/

                        }
                        else
                        {
                            if (!power.Text.Contains(removedPower[0] as string))
                            {
                                /* If the text in the Combo box doesn't have the removed list item, it'll then check to 
                                 see if the item is in the list itself.*/
                                if (!power.Items.Contains(removedPower[0] as string))
                                {
                                    /*Now, if the item isn't in the ComboBox's list either, it'll make a note of it
                                     in the boolean choice_found. */
                                    choice_not_found = true;
                                }
                            }
                        }
                    }
                    if (choice_not_found)
                    {
                        foreach (ComboBox power in comboPowers_list)
                        {
                            power.Items.Add(removedPower[0] as string);
                        }
                        removedPower.RemoveAt(0);
                    }
                }
            }

            else if (comboTalent_list.Contains(choice))
            {
                foreach (ComboBox talent in comboTalent_list)
                {
                    if (!sender.Equals(talent))
                    {
                        talent.Items.Remove(choice.Text);
                        if (!removedTalent.Contains(choice.Text))
                        {
                            removedTalent.Add(choice.Text);
                        }
                    }
                }

                if (removedTalent.Count > 0)
                {
                    bool choice_not_found = false;
                    foreach (ComboBox talent in comboTalent_list)
                    {

                        if (talent.Text.Contains(removedTalent[0] as string))
                        {
                            break;
                            /* In theory, this should break the loop entirely so that once this removed
                             * entry is found in one of the ComboBoxes, it won't attempt to repopulate 
                             * the option back into the drop-down lists.*/

                        }
                        else
                        {
                            if (!talent.Text.Contains(removedTalent[0] as string))
                            {
                                /* If the text in the Combo box doesn't have the removed list item, it'll then check to 
                                 see if the item is in the list itself.*/
                                if (!talent.Items.Contains(removedTalent[0] as string))
                                {
                                    /*Now, if the item isn't in the ComboBox's list either, it'll make a note of it
                                     in the boolean choice_found. */
                                    choice_not_found = true;
                                }
                            }
                        }
                    }
                    if (choice_not_found)
                    {
                        foreach (ComboBox talent in comboTalent_list)
                        {
                            talent.Items.Add(removedBackground[0] as string);
                        }
                        removedTalent.RemoveAt(0);
                    }
                }

            }

            else if (comboKnowledge_list.Contains(choice))
            {
                foreach (ComboBox knowledge in comboKnowledge_list)
                {
                    if (!sender.Equals(knowledge))
                    {
                        knowledge.Items.Remove(choice.Text);

                        if (!removedKnowledge.Contains(choice.Text))
                        {
                            removedKnowledge.Add(choice.Text);
                        }
                    }
                }
            }

            else if (comboAbility_list.Contains(choice))
            {
                foreach (ComboBox ability in comboAbility_list)
                {
                    if (!sender.Equals(ability))
                    {
                        ability.Items.Remove(choice.Text);

                        if (!removedAbility.Contains(choice.Text))
                        {
                            removedAbility.Add(choice.Text);
                        }
                    }
                }
                if (removedAbility.Count > 0)
                {
                    bool choice_not_found = false;
                    foreach (ComboBox ability in comboAbility_list)
                    {

                        if (ability.Text.Contains(removedAbility[0] as string))
                        {
                            break;
                            /* In theory, this should break the loop entirely so that once this removed
                             * entry is found in one of the ComboBoxes, it won't attempt to repopulate 
                             * the option back into the drop-down lists.*/

                        }
                        else
                        {
                            if (!ability.Text.Contains(removedAbility[0] as string))
                            {
                                /* If the text in the Combo box doesn't have the removed list item, it'll then check to 
                                 see if the item is in the list itself.*/
                                if (!ability.Items.Contains(removedAbility[0] as string))
                                {
                                    /*Now, if the item isn't in the ComboBox's list either, it'll make a note of it
                                     in the boolean choice_found. */
                                    choice_not_found = true;
                                }
                            }
                        }
                    }
                    if (choice_not_found)
                    {
                        foreach (ComboBox ability in comboAbility_list)
                        {
                            ability.Items.Add(removedAbility[0] as string);
                        }
                        removedAbility.RemoveAt(0);
                    }
                }
            }

            else if (comboBackground_list.Contains(choice))
            {
                foreach (ComboBox background in comboBackground_list)
                {
                    if (!sender.Equals(background))
                    {
                        background.Items.Remove(choice.Text);

                        if (!removedBackground.Contains(choice.Text))
                        {
                            removedBackground.Add(choice.Text);
                        }
                    }
                }

                if (removedBackground.Count > 0)
                {
                    bool choice_not_found = false;
                    foreach (ComboBox background in comboBackground_list)
                    {

                        if (background.Text.Contains(removedBackground[0] as string))
                        {
                            choice_not_found = false;
                            break;
                            /* In theory, this should break the loop entirely so that once this removed
                             * entry is found in one of the ComboBoxes, it won't attempt to repopulate 
                             * the option back into the drop-down lists.*/

                        }
                        else
                        {
                            if (!background.Text.Contains(removedBackground[0] as string))
                            {
                                /* If the text in the Combo box doesn't have the removed list item, it'll then check to 
                                 see if the item is in the list itself.*/
                                if (!background.Items.Contains(removedBackground[0] as string))
                                {
                                    /*Now, if the item isn't in the ComboBox's list either, it'll make a note of it
                                     in the boolean choice_found. */
                                    choice_not_found = true;
                                }
                            }
                        }
                    }
                    if (choice_not_found)
                    {
                        foreach (ComboBox background in comboBackground_list)
                        {
                            background.Items.Add(removedBackground[0] as string);
                        }
                        removedBackground.RemoveAt(0);
                    }
                }
            }

            else if (comboMerits_list.Contains(choice))
            {

                foreach (ComboBox merit in comboMerits_list)
                {
                    if (!sender.Equals(merit))
                    {
                        merit.Items.Remove(choice.Text);

                        if (!removedMerits.Contains(choice.Text))
                        {
                            removedMerits.Add(choice.Text);
                        }
                    }

                    if (sender.Equals(merit))
                    {
                        int index = comboMerits_list.IndexOf(merit);
                        TextBox value = comboMerits_values[index] as TextBox;

                        switch (choice.Text)
                        {
                            case "Acute Sense - 2 pt":
                                value.Text = "2";
                                break;
                            case "Ambidexterous - 1 pt":
                                value.Text = "1";
                                break;
                            case "Huge Size - 3 pt":
                                value.Text = "3";
                                break;
                            case "Medium - 3 pt":
                                value.Text = "3";
                                break;
                            case "Iron Will - 2 pt":
                                value.Text = "2";
                                break;
                        }
                    }

                    if (choice.Text.Equals("Huge Size - 3 pt"))
                    {
                        foreach (ComboBox flaw in comboFlaws_list)
                        {
                            flaw.Items.Remove("Child - 3 pt");

                            if (!removedFlaws.Contains("Child - 3 pt"))
                            {
                                removedFlaws.Add("Child - 3 pt");
                            }
                        }
                    }

                    if (removedMerits.Count > 0)
                    {
                        bool choice_not_found = false;
                        foreach (ComboBox merits in comboMerits_list)
                        {

                            if (merits.Text.Contains(removedMerits[0] as string))
                            {
                                choice_not_found = false;
                                break;
                                /* In theory, this should break the loop entirely so that once this removed
                                 * entry is found in one of the ComboBoxes, it won't attempt to repopulate 
                                 * the option back into the drop-down lists.*/

                            }
                            else
                            {
                                if (!merits.Text.Contains(removedMerits[0] as string))
                                {
                                    /* If the text in the Combo box doesn't have the removed list item, it'll then check to 
                                     see if the item is in the list itself.*/
                                    if (!merits.Items.Contains(removedMerits[0] as string))
                                    {
                                        /*Now, if the item isn't in the ComboBox's list either, it'll make a note of it
                                         in the boolean choice_found. */
                                        choice_not_found = true;
                                    }
                                }
                            }
                        }
                        if (choice_not_found)
                        {
                            foreach (ComboBox merited in comboMerits_list)
                            {
                                merited.Items.Add(removedMerits[0] as string);
                            }
                            removedMerits.RemoveAt(0);
                        }
                    }

                }


            }

            else if (comboFlaws_list.Contains(choice))
            {


                foreach (ComboBox flaw in comboFlaws_list)
                {
                    if (!sender.Equals(flaw))
                    {
                        flaw.Items.Remove(choice.Text);

                        if (!removedFlaws.Contains(choice.Text))
                        {
                            removedFlaws.Add(choice.Text);
                        }
                    }

                    if (sender.Equals(flaw))
                    {
                        int index = comboFlaws_list.IndexOf(flaw);
                        TextBox value = comboFlaws_values[index] as TextBox;

                        switch (choice.Text)
                        {
                            case "Color Blindness - 1 pt":
                                value.Text = "1";
                                break;
                            case "Child - 3 pt":
                                value.Text = "3";
                                break;
                            case "Dark Fate - 5 pt":
                                value.Text = "5";
                                break;
                            case "Enemy - 4 pt":
                                value.Text = "4";
                                break;
                            case "Haunted - 2 pt":
                                value.Text = "2";
                                break;
                        }
                    }

                    if (choice.Text.Equals("Child - 3 pt"))
                    {
                        foreach (ComboBox merit in comboMerits_list)
                        {
                            merit.Items.Remove("Huge Size - 3 pt");

                            if (!removedMerits.Contains("Huge Size - 3 pt"))
                            {
                                removedMerits.Add("Huge Size - 3 pt");
                            }
                        }
                    }

                    if (removedFlaws.Count > 0)
                    {
                        bool choice_not_found = false;
                        foreach (ComboBox flaws in comboFlaws_list)
                        {

                            if (flaws.Text.Contains(removedFlaws[0] as string))
                            {
                                choice_not_found = false;
                                break;
                                /* In theory, this should break the loop entirely so that once this removed
                                 * entry is found in one of the ComboBoxes, it won't attempt to repopulate 
                                 * the option back into the drop-down lists.*/

                            }
                            else
                            {
                                if (!flaws.Text.Contains(removedFlaws[0] as string))
                                {
                                    /* If the text in the Combo box doesn't have the removed list item, it'll then check to 
                                     see if the item is in the list itself.*/
                                    if (!flaws.Items.Contains(removedFlaws[0] as string))
                                    {
                                        /*Now, if the item isn't in the ComboBox's list either, it'll make a note of it
                                         in the boolean choice_found. */
                                        choice_not_found = true;
                                    }
                                }
                            }
                        }
                        if (choice_not_found)
                        {
                            foreach (ComboBox flawed in comboFlaws_list)
                            {
                                flawed.Items.Add(removedFlaws[0] as string);
                            }
                            removedFlaws.RemoveAt(0);
                        }
                    }
                }
            }
        }

        private void MeritFlawBox_EnableDisableBoxes(object sender, EventArgs e)
        {
            TextBox item = sender as TextBox;
            int total = 0;

            if (comboMerits_values.Contains(item))
            {
                foreach (TextBox t in comboMerits_values)
                {
                    int.TryParse(t.Text, out int result);
                    total += result;
                }

                meritTextBox.Text = total.ToString();

                if (int.Parse(meritTextBox.Text) >= 7)
                {
                    foreach (ComboBox c in comboMerits_list)
                    {
                        if (c.Text.Equals(""))
                        {
                            c.Enabled = false;
                        }
                    }
                }
                else
                {
                    foreach (ComboBox c in comboMerits_list)
                    {
                        if (c.Text.Equals(""))
                        {
                            c.Enabled = true;
                        }
                    }
                }
            }
            else if (comboFlaws_values.Contains(item))
            {
                foreach (TextBox t in comboFlaws_values)
                {
                    int.TryParse(t.Text, out int result);
                    total += result;
                }

                flawTextBox.Text = total.ToString();
            }
        }

        private void filterDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterForm filter = new FilterForm();
            filter.AddCriteriaCallback = new CriteriaDelegate(CriteriaCallbackFunction);
            filter.ShowDialog();
        }

        private void CriteriaCallbackFunction(string item)
        {
            FilterData(item);
        }

        public void FilterData(string criteria)
        {
            dataGridView1.Rows.Clear();
            theDataBase.characterList.Sort();
            int filterCount = 0;

            foreach (Character c in theDataBase.characterList)
            {

                if (c.player_Name.Text.Contains(criteria))
                {
                    string[] entry = { (theDataBase.characterList.LastIndexOf(c) + 1).ToString(), c.player_Name.Text, c.char_Name.Text };
                    dataGridView1.Rows.Add(entry);
                    filterCount += 1;
                }
                else if (c.char_Name.Text.Contains(criteria))
                {
                    string[] entry = { (theDataBase.characterList.LastIndexOf(c) + 1).ToString(), c.player_Name.Text, c.char_Name.Text };
                    dataGridView1.Rows.Add(entry);
                    filterCount += 1;
                }
                else if (c.morality.Text.Contains(criteria))
                {
                    string[] entry = { (theDataBase.characterList.LastIndexOf(c) + 1).ToString(), c.player_Name.Text, c.char_Name.Text };
                    dataGridView1.Rows.Add(entry);
                    filterCount += 1;
                }
                else if (c is Vampire)  // Search vampire characters for filter criteria
                {
                    Vampire v = c as Vampire;

                    if (v.clan.Text.Contains(criteria))
                    {
                        string[] entry = { (theDataBase.characterList.LastIndexOf(c) + 1).ToString(), c.player_Name.Text, c.char_Name.Text };
                        dataGridView1.Rows.Add(entry);
                        filterCount += 1;
                    }
                    else if (v.bloodline.Text.Contains(criteria))
                    {
                        string[] entry = { (theDataBase.characterList.LastIndexOf(c) + 1).ToString(), c.player_Name.Text, c.char_Name.Text };
                        dataGridView1.Rows.Add(entry);
                        filterCount += 1;
                    }
                    else if (v.disiplines_list.Count > 0)
                    {
                        foreach (Attribute a in v.disiplines_list)
                        {
                            if (a.Text.Contains(criteria))
                            {
                                string[] entry = { (theDataBase.characterList.LastIndexOf(c) + 1).ToString(), c.player_Name.Text, c.char_Name.Text };
                                dataGridView1.Rows.Add(entry);
                                filterCount += 1;
                            }
                        }
                    }
                }

                ListRead(c, c.abilitiesList, criteria);
                ListRead(c, c.talentsList, criteria);
                ListRead(c, c.knowledgesList, criteria);
                ListRead(c, c.backgroundList, criteria);
                ListRead(c, c.meritList, criteria);
                ListRead(c, c.flawList, criteria);

                
            }

            MessageBox.Show("Entries found: " + filterCount, "Filter Complete", MessageBoxButtons.OK);
        }

        private void restoreDatabaseEntriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillData();
        }
    }
}
