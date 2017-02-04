using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Files_join
{
    class Related_DataSet
    {
        private DataSet DS;

        public DataSet DS_property
        {
            get { return DS; }
            set { DS = value; }
        }

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
        public Related_DataSet(int PK , int FK , DataSet DS)
        {
            primary_Key_index = PK;
            Foregin_Key_index = FK;
            this.DS = DS;
        }
    }
}
