using System;
using Entity;
using TableConfig;
using UnityEngine;
using View;

namespace Controller
{
    public class ArcheryController : MonoBehaviour
    {
        [SerializeField] private ArcheryView view;

        public void Start()
        {
            Action<BuffModel[]> buf = ReadJson;
            try
            {
                TableParser<BuffModel>.Parse("ArmyModel", buf);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void ReadJson(BuffModel[] buf)
        {
            view.CreateRole(buf[0]);
        }
    }
}