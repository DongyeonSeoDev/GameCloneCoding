using UnityEngine;

public static class MonsterStatesCheck
{
    public static bool CanAttackCastle(MonsterData monsterData) =>
        Mathf.Abs(monsterData.enemyObj.transform.position.x - monsterData.castleObject.transform.position.x) <= monsterData.castleAttackableDistance;
}