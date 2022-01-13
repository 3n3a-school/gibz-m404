using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class Player
    {
        private string _name = null;
        private int _points = 0;

        public string Name { get => _name; set => _name = value; }
        public int Points { get => _points; set => _points = value; }
        public void AddPoint()
        {
            Points += 1;
        }
    }

}
