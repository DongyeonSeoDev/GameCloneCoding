using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{
    public static ArcherController Instance { get; private set; }

    [SerializeField] private List<NormalArcher> archerList = new List<NormalArcher>();

    private float atkDelay;
    private float enableTime;

    [HideInInspector] public Transform target;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        atkDelay = archerList[0].archerSO.attackDelay;
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if(Time.time>enableTime)
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position, new Vector2(20, 20), 0);

            if (!hit || !hit.CompareTag("Enemy")) return;

            target = hit.transform;

            enableTime = Time.time + atkDelay;

            archerList.ForEach(x => x.attackCmd.Execute());
        }
    }

}
