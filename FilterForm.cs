using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Innuendo
{


    public partial class FilterForm : Form
    {
        public CriteriaDelegate AddCriteriaCallback;

        List<string> category = new List<string>() {
            "Custom",
            "Background",
            "Discipline",
            "Faction", "Flaw",
            "Genre",
            "Knowledge",
            "Merit",
            "Skill",
            "Talent"
        };

        List<string> typeMeritFlaw = new List<string>() {
            "Mental",
            "Physical",
            "Social",
            "Supernatural"
        };

        List<string> typeDisciplines = new List<string>() {
            "Animalism", "Auspex",
            "Bardo",
            "Celerity", "Chimerstry",
            "Dementation", "Dominate", 
            "Fortitude",
            "Melpominee",
            "Obeah", "Obfuscate", "Obtenebration",
            "Potence", "Presence","Protean",
            "Serpentis",
            "Temporsis", "Thaumaturgy",
            "Valeren", "Vicissitude"
        };

        List<string> typeBackground = new List<string>()
        {
            "Allies",
            "Contacts",
            "Fame",
            "Herd",
            "Generation",
            "Resources",
            "Retainers",
            "Status"
        };

        List<string> typeFaction = new List<string>() {
            "Anarch",
            "Camarilla",
            "Inconnu","Independent",
            "Sabbat"
        };

        List<string> typeGenre = new List<string>() {
            "Changeling",
            "Demon",
            "Garou",
            "Hunter",
            "Kuei-Jin",
            "Mage","Mortal",
            "Shifter",
            "Vampire",
            "Wraith"
        };


        public FilterForm()
        {
            InitializeComponent();

            foreach (string s in category)
            {
                CategoryChoice.Items.Add(s);
            }

        }

        private void CategoryChoice_TextChanged(object sender, EventArgs e)
        {
            switch (CategoryChoice.Text)
            {
                case "Discipline":
                    CategoryCriteria.Enabled = true;
                    EntryCriteria.Enabled = false;
                    CategoryCriteria.Items.Clear();
                    foreach (string s in typeDisciplines)
                    {
                        CategoryCriteria.Items.Add(s);
                    }
                    break;
                case "Genre":
                    CategoryCriteria.Enabled = true;
                    EntryCriteria.Enabled = false;
                    CategoryCriteria.Items.Clear();
                    foreach (string s in typeGenre)
                    {
                        CategoryCriteria.Items.Add(s);
                    }
                    break;
                case "Merit":
                    CategoryCriteria.Enabled = true;
                    EntryCriteria.Enabled = false;
                    CategoryCriteria.Items.Clear();
                    foreach (string s in typeMeritFlaw)
                    {
                        CategoryCriteria.Items.Add(s);
                    }
                    break;
                case "Flaw":
                    CategoryCriteria.Enabled = true;
                    EntryCriteria.Enabled = false;
                    CategoryCriteria.Items.Clear();
                    foreach (string s in typeMeritFlaw)
                    {
                        CategoryCriteria.Items.Add(s);
                    }
                    break;
                case "Custom":
                    CategoryCriteria.Enabled = false;
                    EntryCriteria.Enabled = true;
                    EntryCriteria.Text = null;
                    break;
                default:
                    break;
            }
        }

        private void btnFilterData_Click(object sender, EventArgs e)
        {
            if (CategoryCriteria.Enabled && !EntryCriteria.Enabled)
            {
                AddCriteriaCallback(CategoryCriteria.Text);
            }
            else if (CategoryCriteria.Enabled && EntryCriteria.Enabled)
            {
                AddCriteriaCallback(EntryCriteria.Text);
            }
            else
            {
                AddCriteriaCallback(EntryCriteria.Text);
            }
            this.Hide();
        }

        private void btnCancelFilter_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
