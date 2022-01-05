using System;
using System.Collections.Generic;
using TableConfig;
using UnityEngine.Serialization;

namespace Entity
{
    [Serializable]
    public class BuffModel : BaseModel
    {
        public int id;

        public int name;
        
        public int note;
        
        public int maxHp;
        
        public int atk;
        
        public int def;
        
        public int shootSpeed;
        
        public Dictionary<string, string> ParsePerValue { get; set; }

        public override object Key()
        {
            throw new NotImplementedException();
        }
    }
    
    public class Player
    {
        public int ID;
        public int Name;
        public int Note;
        public int MaxHp;
        public int Atk;
        public int Def;
        public int ShootSpeed;

        public Player(BuffModel buf)
        {
            ID = buf.id;
            Name = buf.name;
            Note = buf.note;
            MaxHp = buf.maxHp;
            Atk = buf.atk;
            Def = buf.def;
            ShootSpeed = buf.shootSpeed;
        }
    }
}