using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class ObjectPool
    {
        private static ObjectPool singleton;

        private readonly Dictionary<string, List<GameObject>> pool;

        private readonly Dictionary<string, GameObject> prefabs;

        public static ObjectPool CreateInstance()
        {
            return singleton ?? (singleton = new ObjectPool());
        }

        private ObjectPool()
        {
            pool = new Dictionary<string, List<GameObject>>();
            prefabs = new Dictionary<string, GameObject>();
        }


        /// <summary>
        /// 从对象池中获取对象
        /// </summary>
        /// <param name="objName"></param>
        /// <returns></returns>
        public GameObject GetObj(string objName)
        {
            GameObject result = null;
            if (pool.ContainsKey(objName) && pool[objName].Count > 0)
            {
                result = pool[objName][0];
                result.SetActive(true);
                pool[objName].Remove(result);
                return result;
            }

            GameObject prefab = null;
            if (prefabs.ContainsKey(objName))
            {
                prefab = prefabs[objName];
            }
            else //如果没有加载过该预设体
            {
                prefab = Resources.Load<GameObject>($"Prefabs/{objName}");
                prefabs.Add(objName, prefab);
            }

            result = Object.Instantiate(prefab);
            result.name = objName;
            return result;
        }

        /// <summary>
        /// 回收对象到对象池
        /// </summary>
        public void RecycleObj(GameObject obj)
        {
            obj.SetActive(false);
            if (pool.ContainsKey(obj.name))
            {
                pool[obj.name].Add(obj);
            }
            else
            {
                pool.Add(obj.name, new List<GameObject>() {obj});
            }
        }
    }
}