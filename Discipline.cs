using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innuendo
{
    [Serializable]
    class Discipline
    {
        public ArrayList discipline_list = new ArrayList();

        public void AddDiscipline(string name, int value)
        {
            Attribute power = new Attribute();

            power.Title = "Discipline";
            power.Text = name;
            power.Numeric = value;
            power.Description = null;

            discipline_list.Add(power);
        }

        public void RemoveDisipline(string name)
        {
            int index = -1;

            foreach (Attribute a in discipline_list)
            {
                if (a.Text.Equals(name))
                {
                    index = discipline_list.IndexOf(a);
                }
            }

            if (index > -1)
            {
                discipline_list.RemoveAt(index);
            }
        }
    }

    
}
