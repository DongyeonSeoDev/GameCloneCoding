using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public int castleHP;

    private void Start()
    {
        castleHP = 500;
    }

    public void IsDamaged(int damagedValue)
    {
        castleHP -= damagedValue;
        castleHP = Mathf.Clamp(castleHP, 0, int.MaxValue);

        SetHpBar();

        if (castleHP <= 0)
        {
            GameOver();
        }
    }

    private void SetHpBar()
    {

    }

    private void GameOver()
    {

    }
}
