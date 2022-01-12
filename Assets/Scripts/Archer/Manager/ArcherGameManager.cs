using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using One;

public class ArcherGameManager : MonoBehaviour
{
    public static ArcherGameManager Instance { get; private set; }

    [SerializeField] private float maxMp = 10;
    private float currentMp = 0;

    public GameObject arrowPrefab;
    public Transform arrowParent;

    public List<Transform> waypoints = new List<Transform>();
    

    private void Awake()
    {
        Instance = this;

        PoolManager.CreatePool(arrowPrefab, transform, 15);
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            waypoints.Add(o.transform);
        }
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
        }
    }
}
