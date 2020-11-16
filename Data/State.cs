using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class State
    {
        private List<Books> states;
        public List<Books> States
        {
            get { return states; }
            set { states = value; }
        }
        public State(List<Books> lob)
        {
            this.states = lob;
        }
    }
}
