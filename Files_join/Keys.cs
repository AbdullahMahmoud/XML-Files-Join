using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Files_join
{
    public class Keys
    {
        private int primary_Key_index;

        public int Primary_Key_index_property
        {
            get { return primary_Key_index; }
            set { primary_Key_index = value; }
        }
        private int Foregin_Key_index;

        public int Foregin_Key_index_property
        {
            get { return Foregin_Key_index; }
            set { Foregin_Key_index = value; }
        }
        private int Related_table_index;

        public int Related_table_index_property
        {
            get { return Related_table_index; }
            set { Related_table_index = value; }
        }
        public Keys(int PK , int FK , int RTK)
        {
            primary_Key_index = PK;
            Foregin_Key_index = FK;
            Related_table_index = RTK;
        }
    }
}
