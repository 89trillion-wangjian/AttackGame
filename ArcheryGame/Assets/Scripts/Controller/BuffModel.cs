using System;
using System.Collections.Generic;
using TableConfig;

namespace Model
{
    [Serializable]
    public class BuffModel : BaseModel
    {
        public int id;
        public int Name;
        public int Note;
        public int MaxHp;
        public int Atk;
        public int Def;
        public int ShootSpeed;
        public Dictionary<string, string> ParsePerValue { get; set; }
        public override object Key()
        {
            throw new NotImplementedException();
        }
    }
}