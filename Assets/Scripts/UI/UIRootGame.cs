using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRootGame : MonoBehaviour
{
    void Awake()
    {
        GameSceneClass.gUiRootGame = this;
    }

    private void Start()
    {
        Canvas canvas = transform.GetComponentInParent<Canvas>();

        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;
    }
}
