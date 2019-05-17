using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innuendo
{
    [Serializable]
    class Attribute
    {
        private string title;
        private string val1;
        private int val2;
        private string description;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Text
        {
            get { return val1; }
            set { val1 = value; }
        }

        public int Numeric
        {
            get { return val2; }
            set { val2 = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
