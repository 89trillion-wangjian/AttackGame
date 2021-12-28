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

        #region BuffModel

        private ITable2Data<BuffModel> buffModelTable;
        private List<BuffModel> buffModel;

        private ITable2Data<BuffModel> BuffModelTable =>
            buffModelTable ?? (buffModelTable = new TableManager<BuffModel>());

        public List<BuffModel> GetBuffModel()
        {
            return buffModel ?? (buffModel = BuffModelTable.GetAllModel());
        }

        public BuffModel GetBuffModel(int id)
        {
            var modelDic = GetBuffModelDic();

            if (modelDic != null && modelDic.ContainsKey(id))
            {
                return modelDic[id];
            }

            return null;
        }

        private Dictionary<int, BuffModel> buffModelDic;

        public Dictionary<int, BuffModel> GetBuffModelDic()
        {
            if (buffModelDic == null)
            {
                buffModelDic = new Dictionary<int, BuffModel>();
                List<BuffModel> list = GetBuffModel();
                foreach (var item in list)
                {
                    buffModelDic.Add(item.id, item);
                }
            }

            return buffModelDic;
        }

        #endregion
    }
}