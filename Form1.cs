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
    public partial class Form1 : Form
    {
        Database theDataBase;
        ArrayList labels;
        ArrayList boxes;
        ArrayList combobox_list;
        ArrayList combobox_values;
        ArrayList background_list;
        ArrayList background_values;

        public Form1()
        {
            InitializeComponent();
            theDataBase = new Database();
            SetLabelsAndBoxes("vampire");

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
            boxes.Add(meritTextBox);
            boxes.Add(flawTextBox);

            combobox_list = new ArrayList();
            combobox_values = new ArrayList();

            combobox_list.Add(comboPower1Text);
            combobox_list.Add(comboPower2Text);
            combobox_list.Add(comboPower3Text);
            combobox_list.Add(comboPower4Text);

            combobox_values.Add(characterPower1Value);
            combobox_values.Add(characterPower2Value);
            combobox_values.Add(characterPower3Value);
            combobox_values.Add(characterPower4Value);

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

            foreach (ComboBox c in combobox_list)
            {
                c.Text = "";
                c.Items.Clear();
            }

            foreach (TextBox d in combobox_values)
            {
                d.Text = "";
            }
        
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

                if (dtpCreation.Value.Equals(dtpLastModified.Value))
                {
                    mortalentry.creation = DateTime.Today;
                }
                mortalentry.last_modified = DateTime.Today;
                

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
                    vampentry.creation = dtpCreation.Value;
                    vampentry.last_modified = DateTime.Today;

                    int power_counter = 0;

                    foreach (TextBox t in combobox_values)
                    {
                        foreach (ComboBox c in combobox_list)
                        {
                            if (combobox_values.IndexOf(t) == combobox_list.IndexOf(c))
                            {
                                if (!t.Text.Equals(""))
                                {
                                    power_counter += 1;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < power_counter; i++)
                    {
                        ComboBox entry = combobox_list[i] as ComboBox;
                        TextBox value = combobox_values[i] as TextBox;
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

                    groupGenre.Text = "Vampire Character";
                }
                catch (ArgumentNullException error)
                {
                    MessageBox.Show("No appropriate value entered.  Please enter a correct value.", error.ToString(), MessageBoxButtons.OK);
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

                try
                {
                    int choice = (Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()) - 1);

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

                        groupGenre.Text = "Mortal Character";

                        genreBackgroundTextBox.Enabled = true;

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

                        try
                        { meritTextBox.Text = vampEntry.merits.Numeric.ToString(); }
                        catch (Exception error)
                        {
                            MessageBox.Show("No value defined, resetting to 0.", error.ToString(), MessageBoxButtons.OK);
                            meritTextBox.Text = "0";
                        }

                        try
                        { flawTextBox.Text = vampEntry.flaws.Numeric.ToString(); }
                        catch (Exception error)
                        {
                            MessageBox.Show("No value defined, resetting to 0.", error.ToString(), MessageBoxButtons.OK);
                            flawTextBox.Text = "0";
                        }

                        groupGenre.Text = "Vampire Character";

                        genreType1.Text = "Clan";
                        genreType1Value.Enabled = true;

                        genreType2.Text = "Bloodline";
                        genreType2Value.Enabled = true;

                        genrePower1.Text = "Generation";
                        genrePower1Value.Enabled = true;

                        genrePower2.Text = "Blood Pool";
                        genrePower2Value.Enabled = true;

                        genreBackgroundTextBox.Enabled = true;

                        genreFlawsValue.Enabled = true;

                        foreach (ComboBox c in combobox_list)
                        {
                            c.ResetText();
                        }

                        foreach (TextBox t in combobox_values)
                        {
                            t.ResetText();
                        }

                        for(int i = 0; i < vampEntry.disiplines_list.Count; i++)
                        {
                            Attribute power = vampEntry.disiplines_list[i] as Attribute;
                            ComboBox combo_box = combobox_list[i] as ComboBox;
                            TextBox value = combobox_values[i] as TextBox;

                            if (!power.Text.Equals(null))
                            {
                                combo_box.Text = power.Text;
                                value.Text = power.Numeric.ToString();
                            }
                        }

                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString(), "No such character in database.", MessageBoxButtons.OK);
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
                                    index = theDataBase.characterList.IndexOf(c);
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
            }
            else if (genreTextBox.Text.ToLower().Equals("mortal"))
            {
                genreType1Value.Enabled = false;
                genreType2Value.Enabled = false;
                genrePower1Value.ReadOnly = true;
                genrePower2Value.ReadOnly = true;
                genrePower2Value.Text = "10";
                morality.Enabled = true;
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
                    foreach (ComboBox c in combobox_list)
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

                    genreFlawsValue.Text = "Assamites have a -1 penalty to resist diablerie when feeding from another vampire, or when smelling the blood of another vampire.";

                    break;

                case "Baali":
                    foreach (ComboBox c in combobox_list)
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

                    genreFlawsValue.Text = "Baali have a -1 penalty against locations that are blessed.  They suffer an additional -1 when in contests against an individual who has the 'True Faith' merit.";

                    break;

                case "Brujah":
                    foreach (ComboBox c in combobox_list)
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

                    genreFlawsValue.Text = "Brujah have a -1 penalty to resist frenzy.";

                    break;

                case "Gangrel":
                    foreach (ComboBox c in combobox_list)
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

                    genreFlawsValue.Text = "After frenzying, Gangrel gain a negative Social trait; enough of these will change a Gangrel's nature or demeanor.";

                    break;

                case "Followers of Set":
                    foreach (ComboBox c in combobox_list)
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
                    genreType2Value.Items.Add("Warrior");
                    genreType2Value.Items.Add("Tlacique");
                    genreType2Value.Items.Add("Baali Apostate");

                    genreFlawsValue.Text = "";

                    break;

                case "Giovanni":
                    foreach (ComboBox c in combobox_list)
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

                    genreFlawsValue.Text = "";

                    break;

                case "Lasombra":
                    foreach (ComboBox c in combobox_list)
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

                    genreFlawsValue.Text = "";

                    break;

                case "Malkavian":
                    foreach (ComboBox c in combobox_list)
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

                    genreFlawsValue.Text = "";

                    break;

                case "Nosferatu":
                    foreach (ComboBox c in combobox_list)
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

                    genreFlawsValue.Text = "";

                    break;

                case "Ravnos":
                    foreach (ComboBox c in combobox_list)
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
                    foreach (ComboBox c in combobox_list)
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
                    genreType2Value.Items.Add("Wu Zao");

                    genreFlawsValue.Text = "Salubri cannot use the Kiss on an unwilling mortal; any vitae that was drawn from an unwilling source is vomited immediately after.";

                    break;

                case "Toreador":
                    foreach (ComboBox c in combobox_list)
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

                    genreFlawsValue.Text = "Toreador have a -2 difficulty to avoid entering a fugue when viewing any object with a Crafts rating of 4 or higher.";

                    break;

                case "Tremere":
                    foreach (ComboBox c in combobox_list)
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

                    genreFlawsValue.Text = "Tremere have a 1 point Blood Bond to the Council of Seven.";

                    break;

                case "Tzimisce":
                    foreach (ComboBox c in combobox_list)
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

                    genreFlawsValue.Text = "Whenever a Tzimisce sleeps, they must surround themselves with at least two handfuls of earth from a place important to them as a mortal. Failure to meet this requirement halves the Tzimisce's dice pools every 24 hours, until all their actions use only one die.";

                    break;

                case "Ventrue":
                    foreach (ComboBox c in combobox_list)
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
                    foreach (ComboBox c in combobox_list)
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
                        genreFlaws2Value.Text = "Toreador's clan flaw is warped; instead of something of beauty, the object of fugue can be something that inflicts violence.";
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
                    genreFlaws2Value.Text = "Salubri cannot use the Kiss on an unwilling mortal; any vitae that was drawn from an unwilling source is vomited immediately after.";

                    break;

                case "Ahrimanes":
                    genreFlaws2Value.Text = "Ahrimanes cannot Embrace nor Blood Bond other vampires.";
                    foreach (ComboBox c in combobox_list)
                    {
                        // In-clan disiplines: 
                        if (!c.Items.Contains("Spiritus"))
                        { c.Items.Add("Spiritus"); }
                    }
                    break;

                case "Anda":
                    genreFlaws2Value.Text = "Tremere have a 1 point Blood Bond to the Council of Seven.";

                    break;

                case "Mariner Gangrel":
                    genreFlaws2Value.Text = "Whenever a Tzimisce sleeps, they must surround themselves with at least two handfuls of earth from a place important to them as a mortal. Failure to meet this requirement halves the Tzimisce's dice pools every 24 hours, until all their actions use only one die.";

                    break;

                case "Lhiannon":
                    genreFlaws2Value.Text = "Ventrue have only one type of blood that they can draw sustinence from, or while in frenzy.  Any other source of vitae is vomited up immediately after any attempt to ingest it.";

                    break;

                case "Noiad":
                    genreFlaws2Value.Text = "Caitiff powers are always considered out-of-clan in terms of experience costs.";

                    break;

                case "Warrior":
                    genreFlaws2Value.Text = "Caitiff powers are always considered out-of-clan in terms of experience costs.";

                    break;

                case "Healer":
                    genreFlaws2Value.Text = "Caitiff powers are always considered out-of-clan in terms of experience costs.";

                    break;

                case "Watcher":
                    genreFlaws2Value.Text = "Caitiff powers are always considered out-of-clan in terms of experience costs.";

                    break;

                case "Tlacique":
                    genreFlaws2Value.Text = "Caitiff powers are always considered out-of-clan in terms of experience costs.";

                    break;

                case "Daughter of Cacophony":
                    genreFlaws2Value.Text = "Daughters of Cacophony have a -2 penalty for Perception challenges.";

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
                    morality.Items.Add("Derp");
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
                    if(!morality.Items.Contains("Path of Typhon"))
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

        private void ComboPower_SelectionMade(object sender, EventArgs e)
        {
            // Step one   - Get the index value of the ComboBox that was modified.
            // Step two   - Remove the value that was chosen in the modified box from all other choices.
            // Step three - Profit.

            ComboBox choice = sender as ComboBox;

            foreach (ComboBox c in combobox_list)
            {
                if (!sender.Equals(c))
                {
                    c.Items.Remove(choice.Text);
                }
            }
        }

        // Below this point will carry code that will determine values based on information from each area.

        //This will calculate the total xp cost of all the backgrounds/influences that a character sheet has.
        private int character_Background_totals()
        {
            int result = 0;

            foreach (TextBox t in background_values)
            {
                int value = int.Parse(t.Text);

                if (value > 1)
                {
                    result += value * (7 * (value - 1));
                }
            }
            return result;
        }
        
        //This will calculate the total xp cost of all of the disiplines on the character sheet.
        private int character_Power_totals()
        {
            int result = 0;

            foreach (TextBox t in combobox_values)
            {
                int value = int.Parse(t.Text);

                if (value > 1)
                {
                    result += value * (3 * (value - 1));
                }
            }
            return result;
        }
    }
}
