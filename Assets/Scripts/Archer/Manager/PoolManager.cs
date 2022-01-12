using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace One
{
    public class PoolManager
    {
        public static Dictionary<string, Pool> poolDic = new Dictionary<string, Pool>();

        public static void CreatePool(GameObject prefab, Transform parent, int count)
        {
            if(!poolDic.ContainsKey(prefab.name))
            {
                poolDic.Add(prefab.name, new Pool(prefab,parent,count));
                Debug.Log(prefab.name);
            }
        }

        public static GameObject GetItem(string key) => poolDic[key].GetItem();

        public static void ClearPool()
        {
            poolDic.Clear();
        }
    }

    public class Pool
    {
        private Queue<GameObject> queue = new Queue<GameObject>();
        private Transform parent;
        private GameObject prefab;

        public Pool(GameObject prefab, Transform parent, int count)
        {
            this.prefab = prefab;
            this.parent = parent;
            for(int i=0; i<count; i++)
            {
                GameObject o = GameObject.Instantiate(prefab, parent);
                o.SetActive(false);
                queue.Enqueue(o);
            }
        }

        public GameObject GetItem()
        {
            GameObject o = queue.Peek();
            if(o.activeSelf)
            {
                o = GameObject.Instantiate(prefab, parent);
            }
            else
            {
                o = queue.Dequeue();
                o.SetActive(true);
            }
            
            queue.Enqueue(o);
            return o;
        }

       
    }
}