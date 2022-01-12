using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Monster
{
    public static class WaveManager
    {
        public static MonsterSpawner waveManager;
        public static Castle castleResetHP;
    }

    public class MonsterSpawner : MonoBehaviour
    {
        private MGPool mgPool;
        private int currentWaveNumber = 10;
        private int monsterCount = 20;
        private float barSpeed = 15;
        private float currentTime;

        private GameObject waveUIObject;
        private Image waveImage;
        private TMP_Text waveText;

        private List<CONEntity> monsters = new List<CONEntity>();

        private void Awake()
        {
            WaveManager.waveManager = this;   
        }

        private void Start()
        {
            mgPool = FindObjectOfType<MGPool>();

            waveUIObject = GameObject.FindGameObjectWithTag("WaveUI");
            waveImage = waveUIObject.transform.Find("Fill").GetComponent<Image>();
            waveText = waveUIObject.transform.Find("Value").GetComponent<TMP_Text>();

            StartCoroutine(SpawnEnemy());
        }

        private void Update()
        {
            currentTime += Time.deltaTime;
            waveImage.fillAmount = Mathf.Lerp(0f, 1f, currentTime / barSpeed);
        }

        private IEnumerator SpawnEnemy()
        {
            currentTime = 0f;
            WaveTextChange();

            for (int i = 0; i < monsterCount; i++)
            {
                CONEntity enemy = mgPool.CreateObj(ePrefabs.Monster, new Vector2(32f, Random.Range(-4f, 4f)));
                enemy.GetComponent<SpriteRenderer>().sortingOrder = (int)(enemy.transform.position.y * -100f);

                monsters.Add(enemy);

                yield return new WaitForSeconds(Random.Range(0.1f, 1f));
            }
        }

        public void WaveClear()
        {
            currentWaveNumber++;
            monsterCount = currentWaveNumber * 2;
            barSpeed = (monsterCount * 0.5f) + 5f;

            WaveTextChange();
        }

        public void WaveReStart()
        {
            currentWaveNumber = 1;
            monsterCount = currentWaveNumber * 2;
            barSpeed = (monsterCount * 0.5f) + 5f;

            WaveTextChange();
        }

        private void WaveTextChange()
        {
            waveText.text = currentWaveNumber.ToString();
        }

        public void ResetScene()
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].SetActive(false);
            }
        }
    }
}