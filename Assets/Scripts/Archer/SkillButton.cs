using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using One;

public class SkillButton : MonoBehaviour
{
    private Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
    }

    public void SetSkillInfo(int mp,Sprite sprite ,System.Action a /*Command cmd*/)
    {
        transform.GetChild(0).GetComponent<Text>().text = mp.ToString();
        btn.image.sprite = sprite;
        btn.onClick.AddListener(()=>a());
        //cmd.Execute();
        //btn.onClick.AddListener(() => cmd.Execute());
    }
}
