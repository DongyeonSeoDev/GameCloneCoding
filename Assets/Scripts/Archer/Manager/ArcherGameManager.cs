using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using One;

public class ArcherGameManager : MonoBehaviour
{
    public static ArcherGameManager Instance { get; private set; }

    [SerializeField] private float maxMp = 10;
    private float currentMp = 0;

    public GameObject arrowPrefab, skillBtnPrefab;
    public Transform arrowParent, skillBtnParent;

    public List<Transform> waypoints = new List<Transform>();
    

    public Text mpText;
    public Image mpImage;


    private void Awake()
    {
        PoolManager.ClearPool();

        Instance = this;

        PoolManager.CreatePool(arrowPrefab, transform, 15);
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            waypoints.Add(o.transform);
        }

       
    }

    public bool CanUseSkill(int mp)
    {
        if (currentMp < mp) return false;

        currentMp -= mp;

        return true;
    }
    
    private void Update()
    {
        RecoveryMP();
    }

    private void RecoveryMP()
    {
        if(currentMp<maxMp)
        {
            currentMp += Time.deltaTime;
            if(Mathf.Floor(currentMp)>=maxMp)
            {
                currentMp = maxMp;
            }
            mpImage.fillAmount = currentMp / maxMp;
            mpText.text = string.Format("{0}/{1}", Mathf.FloorToInt(currentMp), (int)maxMp);
        }
    }
}
