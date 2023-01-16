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
                Color = Color.FromArgb(240, 150, 150);
            }
            else if(Name == "Destroyer")
            {
                Color = Color.FromArgb(210, 135, 235);
            }
            else if(Name == "Military")
            {
                Color = Color.FromArgb(150,255,255);
            }
            else
            {
                Color = Color.FromArgb(245,200,135);
            }
        }
    }
}
