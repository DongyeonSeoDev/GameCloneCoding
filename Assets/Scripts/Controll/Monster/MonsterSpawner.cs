using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster
{
    public class MonsterSpawner : MonoBehaviour
    {
        private MGPool mgPool;

        private void Start()
        {
            mgPool = FindObjectOfType<MGPool>();

            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
        {
            while (true)
            {
                CONEntity enemy = mgPool.CreateObj(ePrefabs.Monster, new Vector2(32f, Random.Range(-4f, 4f)));
                enemy.GetComponent<SpriteRenderer>().sortingOrder = (int)(enemy.transform.position.y * -100f);

                yield return new WaitForSeconds(Random.Range(0.1f, 1f));
            }
        }
    }
}