using System;
using System.Collections.Generic;
using System.Text;

namespace EventImplementation
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);


    public class Dispatcher
    {
        public event NameChangeEventHandler NameChange;

        private string name;

        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                this.OnNameChange(new NameChangeEventArgs(value));
            }
        }


        public void OnNameChange(NameChangeEventArgs args)
        {
            this.NameChange?.Invoke(this, args);
        }


    }
}
