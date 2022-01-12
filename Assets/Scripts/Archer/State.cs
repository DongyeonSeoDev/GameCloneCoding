
using System.Collections.Generic;
using UnityEngine;

namespace One
{
    public class State 
    {
        public enum eState
        {
            PATROL, ATTACK
        };

        public enum eEvent
        {
            ENTER, UPDATE, EXIT
        }

        public eState stateName;

        protected eEvent curEvent;

        protected GameObject myObj;
        protected Animator myAnim;

        protected State nextState;

        public State(GameObject obj, Animator anim)
        {
            myObj = obj;
            myAnim = anim;
            
            curEvent = eEvent.ENTER;
        }

        public virtual void Enter() { curEvent = eEvent.UPDATE; }
        public virtual void MyUpdate() { curEvent = eEvent.UPDATE; }
        public virtual void Exit() { curEvent = eEvent.EXIT; }

        public State Process()
        {
            if (curEvent == eEvent.ENTER) Enter();
            if (curEvent == eEvent.UPDATE) MyUpdate();
            if (curEvent == eEvent.EXIT)
            {
                Exit();
                return nextState;
            }

            return this;
        }

        public Transform CanSeeEnemy()
        {
            Collider2D hit = Physics2D.OverlapBox(myObj.transform.position, new Vector2(10, 10), 0);

            return (hit && hit.CompareTag("Enemy")) ? hit.transform : null;
        }

    }

    public class Patrol : State
    {
        static int curIndex = 0;
        float speed;

        public Patrol(GameObject obj, Animator anim, float speed)
            : base(obj, anim)
        {
            stateName = eState.PATROL;
            this.speed = speed;
        }

        public override void Enter()
        {
           
            base.Enter();
        }

        public override void MyUpdate()
        {
            Vector2 d = ArcherGameManager.Instance.waypoints[curIndex].position - myObj.transform.position;
            myObj.transform.position += new Vector3(d.x, 0).normalized * speed * Time.deltaTime;

            myObj.GetComponent<SpriteRenderer>().flipX = myObj.transform.position.x > ArcherGameManager.Instance.waypoints[curIndex].position.x;
            if (Mathf.Abs(d.x) < 1f)
            {
                curIndex = (++curIndex) % ArcherGameManager.Instance.waypoints.Count;
               
            }


            Transform target = CanSeeEnemy();
            if (target)
            {
                myObj.GetComponent<Hero>().SetTarget(target);
                nextState = new Attack(myObj, myAnim, speed,target);
                curEvent = eEvent.EXIT;
            }
        }

        public override void Exit()
        {
           
            base.Exit();
        }
    }

    public class Attack : State
    {

        float speed;
        Transform target;

        public Attack(GameObject obj, Animator anim, float speed, Transform target)
            : base(obj, anim)
        {
            stateName = eState.ATTACK;
            this.speed = speed;
            this.target = target;
        }

        public override void Enter()
        {
            myAnim.SetTrigger("atk");
   
            base.Enter();
        }

        public override void MyUpdate()
        {
            myObj.GetComponent<SpriteRenderer>().flipX = myObj.transform.position.x > target.position.x;
            myObj.GetComponent<Hero>().attackCmd.Execute();

            target = CanSeeEnemy();
            if(!target)
            {
                nextState = new Patrol(myObj, myAnim, speed);
                curEvent = eEvent.EXIT;
            }
        }

        public override void Exit()
        {
            myAnim.ResetTrigger("atk");
            
            base.Exit();
        }
    }
}

