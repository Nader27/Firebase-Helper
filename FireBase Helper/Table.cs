using System;
using System.Collections.Generic;

namespace FireBase_Helper
{
    public enum Relation_Type
    {
        One_to_One,
        One_to_Many,
        Many_to_One
    }
    public class Table
    {
        public string Name;
        public List<string> Columns;
        public Dictionary<int, Relation_Type> Relations;
        public TableProperites properites;

        public Table()
        {
            Columns = new List<string>();
            Relations = new Dictionary<int, Relation_Type>();
            properites = new TableProperites();
        }

        public class TableProperites
        {
            public bool has_Add;
            public bool has_Update;
            public bool has_Remove;
            public bool has_Find;
            public bool has_Where;
            public bool has_ToList;

            public TableProperites()
            {
                has_Add = true;
                has_Update = true;
                has_Remove = true;
                has_Find = true;
                has_Where = true;
                has_ToList = true;
            }
        }
    }
}