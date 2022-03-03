using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FunWithXaml
{
    public class Person
    {
        public HumanName DisplayName { get; set; }

        public double Age { get; set; }

        public Color FavoriteColor { get; set; }

        public List<Person> Children { get; set; }

        public Dictionary<string, Person> RoleOwners { get; set; }

        public string Phrase { get; set; }

        public Person()
        {
            Children = new List<Person>();
            RoleOwners = new Dictionary<string, Person>();
        }
    }
}
