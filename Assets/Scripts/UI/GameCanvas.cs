using UnityEngine;

namespace GameCanvas
{
    public class GameCanvas : MonoBehaviour
    {
        private Canvas gameCanvas;
        private Camera mainCam;

        private void Start()
        {
            mainCam = Camera.main;
            gameCanvas = GetComponent<Canvas>();

            gameCanvas.worldCamera = mainCam;
        }
    }
}