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
        public bool IsSunk { get; set; }
        private Color color;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public Ship(string name, int size)  //Constructor with 2 args name and size 
        {
            Name = name;
            Size = size;
            IsSunk = false;
            Hits = 0;
            if (Name == "AirCraft")
            {
                color = Color.FromArgb(165, 110, 5);
            }
            else if(Name == "Destroyer")
            {
                color = Color.FromArgb(10, 165, 80);
            }
            else if(Name == "Military")
            {
                color = Color.FromArgb(10,90,165);
            }
            else
            {
                color = Color.FromArgb(130,10,165);
            }
        }
    }
}
