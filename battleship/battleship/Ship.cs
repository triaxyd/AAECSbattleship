using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    class Ship
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int Hits { get; set; }
        public bool IsVertical { get; set; }
        public bool isSunk { get; set; }
        public Color Color { get; set; }

        public Ship(string name, int size)
        {
            Name = name;
            Size = size;
            isSunk = false;
            Hits = 0;
            if (Name == "AirCraft")
            {
                Color = Color.FromArgb(165, 15, 140);
            }
            else if(Name == "Destroyer")
            {
                Color = Color.FromArgb(15, 50, 160);
            }
            else if(Name == "Military")
            {
                Color = Color.FromArgb(50,180,15);
            }
            else
            {
                Color = Color.FromArgb(255,190,5);
            }
        }
    }
}
