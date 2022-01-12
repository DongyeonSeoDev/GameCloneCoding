using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Castle : MonoBehaviour
{
    public int castleHP;
    public int maxCastleHP;

    private GameObject castleHPUI;
    public Image fill;
    public TMP_Text value;

    private bool isGameOver = false;

    private GameObject gameOverObject;
    private Button waveContinueStartButton;
    private Button waveReStartButton;

    private void Awake()
    {
        Monster.WaveManager.castleResetHP = this;
    }

    private void Start()
    {
        castleHPUI = GameObject.FindGameObjectWithTag("CastleHP");
        fill = castleHPUI.transform.Find("Fill").GetComponent<Image>();
        value = castleHPUI.transform.Find("Value").GetComponent<TMP_Text>();

        gameOverObject = GameObject.FindGameObjectWithTag("GameOver");
        waveContinueStartButton = gameOverObject.transform.Find("Button").GetComponent<Button>();
        waveReStartButton = gameOverObject.transform.Find("Button2").GetComponent<Button>();

        gameOverObject.SetActive(false);

        waveContinueStartButton.onClick.AddListener(() =>
        {
            ResetSenen();
            Monster.WaveManager.waveManager.ResetScene();

            gameObject.SetActive(true);
        });

        waveReStartButton.onClick.AddListener(() =>
        {
            ResetSenen();
            Monster.WaveManager.waveManager.ResetScene();
            Monster.WaveManager.waveManager.WaveReStart();

            gameObject.SetActive(true);
        });

        SetHpBar();
    }

    public void IsDamaged(int damagedValue)
    {
        castleHP -= damagedValue;
        castleHP = Mathf.Clamp(castleHP, 0, int.MaxValue);

        SetHpBar();

        if (castleHP <= 0 && !isGameOver)
        {
            GameOver();
        }
    }

    private void SetHpBar()
    {
        fill.fillAmount = (float)castleHP / (float)maxCastleHP;
        value.text = castleHP.ToString();
    }

    private void GameOver()
    {
        isGameOver = true;
        gameOverObject.SetActive(true);
        gameObject.SetActive(false);

        Monster.WaveManager.waveManager.ResetScene();
    }

    private void ResetSenen()
    {
        isGameOver = false;
        gameOverObject.SetActive(false);

        ResetHP();
    }

    public void ResetHP()
    {
        castleHP = maxCastleHP;
        SetHpBar();
    }
}
