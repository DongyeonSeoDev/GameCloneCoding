using UnityEngine;
using One;

public class NormalArcher : Archer
{

    [SerializeField] private Vector2 targetOffset;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Attack()
    {
        anim.SetTrigger(atkInt);
        Arrow arrow = PoolManager.GetItem("Arrow").GetComponent<Arrow>();
        arrow.transform.position = transform.position;
        arrow.SetArrow(archerSO.arrowSpeed, archerSO.strength, (Vector2)ArcherController.Instance.target.position + targetOffset);
    }
}
