using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Characters
    {
        public Characters(string name, string weapon, string talant)
        {
            Name = name;
            Weapon = weapon;
            Talant = talant;
        }
        public string Name { get; set; }
        public string Weapon { get; set; }
        public string Talant { get; set; }

    }
}
