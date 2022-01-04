using UnityEngine;
using View;

namespace Controller
{
    public class FightDisplayHpController : MonoBehaviour
    {
        [SerializeField] private FightDisplayHpView view;

        public static FightDisplayHpController Singleton;

        public void Awake()
        {
            Singleton = this;
        }
    }
}