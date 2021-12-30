using System.Collections.Generic;
using TableConfig;
using UnityEngine;

namespace Model
{
    public class GameModelManager : MonoBehaviour
    {
        public static GameModelManager Instance;

        private void Awake()
        {
            Instance = this;
        }
    }
}