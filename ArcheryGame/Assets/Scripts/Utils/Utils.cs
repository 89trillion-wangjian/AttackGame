using System;
using System.Collections;
using System.Collections.Generic;
using Model;
using TableConfig;
using UnityEngine;

public class Utils
{
        private Utils() { }
        private static Utils _Singleton = null;
        public static Utils CreateInstance()
        {
            if (_Singleton == null)
            {
                _Singleton = new Utils();
            }
            return _Singleton;
        }

      
}
