using UnityEngine;

public class MonsterData
{
    public Animator enemyAnimator;
    public GameObject castleObject;
    public GameObject enemyObj;
    public CONEntity conEntity;

    public float moveSpeed;
    public int hp;
    public int attackValue;
    public float castleAttackableDistance;

    public int damagedValue;
    public bool isDamaged;

    public readonly int hashDie = Animator.StringToHash("die");
    public readonly int hashIsDead = Animator.StringToHash("idDead");
    public readonly int hashHurt = Animator.StringToHash("hurt");
    public readonly int hashRun = Animator.StringToHash("run");
    public readonly int hashAttack = Animator.StringToHash("attack");
}
