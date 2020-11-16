using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Event
    {
        private State state;

        public State stateOfLibrary
        {
            get { return state; }
            set { state = value; }
        }

        private Users users_of_library;
        public Users usersOfLibrary
        {
            get { return users_of_library; }
            set { users_of_library = value; }
        }

        private StateType state_type;
        public StateType stateType
        {
            get { return state_type; }
            set { state_type = value; }
        }

        private Books book;
        public Books Book
        {
            get { return book; }
            set { book = value; }
        }

        private DateTime day;
        public DateTime Day
        {
            get { return day; }
            set { day = value; }
        }
        private int price;
        public int penaltyPrice
        {
            get { return price; }
            set { price = value; }
        }
        public Event(State s, Users ul, Books b, StateType st, DateTime d)
        {
            this.state = s;
            this.book = b;
            this.users_of_library = ul;
            this.state_type = st;
            this.day = d;
            this.price = 0;
        }
    }
    public enum StateType
    {
        taking,
        returning
    }
}
