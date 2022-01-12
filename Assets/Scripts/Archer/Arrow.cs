using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    private float speed;
    private int damage;

    private float inactiveTime;

    private Vector2 target;

    private Rigidbody2D rigid;

    [SerializeField] float y = 30.25f;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }

    public void SetArrow(float speed, int damage, Vector3 target)
    {
        this.speed = speed;
        this.damage = damage;
       
        this.target = target;

        inactiveTime = Time.time + 1f;
    }

    private void LateUpdate()
    {
 
        //±¸±Û¸µ
        Vector2 position = transform.position;

        Vector2 d = target - position;
        float angle = Vector2.SignedAngle(Vector2.right, d.normalized) + y;

        Vector2 p1 = new Vector2(position.x, 0f);
        Vector2 d1 = new Vector2(target.x, 0f);

        float r = Vector2.Distance(p1, d1);
        float t = Mathf.Tan(angle * Mathf.Deg2Rad);
        float h = target.y - position.y;

        float vx = Mathf.Sqrt(Physics2D.gravity.y * r * r / (2.0f * (h - r + t)) * speed);
        float vy = t * vx;

        //Debug.Log(vx + " " + vy);
        
        rigid.velocity = new Vector2(vx, vy);

        transform.rotation = Quaternion.Euler(0,0, Mathf.Atan2(vy , vx) * Mathf.Rad2Deg );


        if(Time.time>inactiveTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //collision.GetComponent<Monster.Monster>().GetDamaged(damage);
            gameObject.SetActive(false);
        }
    }
}
