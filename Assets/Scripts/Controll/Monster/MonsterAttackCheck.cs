using UnityEngine;

namespace Monster
{
    public class MonsterAttackCheck : MonoBehaviour
    {
        private int attackValue = 0;

        public void SetAttackValue(int value)
        {
            attackValue = value;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Castle"))
            {
                collision.GetComponent<Castle>().IsDamaged(attackValue);
            }
        }
    }
}