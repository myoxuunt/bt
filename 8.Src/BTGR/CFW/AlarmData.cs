using System;

namespace CFW
{
    public class AlarmData: TimeSubObjectBase   {
        private string _name;
        private double _value;
        private string _unit;
        private string _description;


        public AlarmData( string name, double value, string unit, string description )
        {
            Name = name;
            Value = value;
            Unit = unit;
            Description = description;
        }

        public string Name
        {
            get 
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public string Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
    }
}
