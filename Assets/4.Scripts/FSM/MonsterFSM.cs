using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFSM : MonoBehaviour
{

    protected StateMachine<MonsterFSM> fsmManager; //클래스에 관리자를 생성
    public StateMachine<MonsterFSM> FsmManager => fsmManager;

    protected UnityEngine.AI.NavMeshAgent agent;
    protected Animator animator;

    protected FieldOfView fov;
    public Transform target => fov?.FirstTarget;
      
    protected virtual void Start()
    {

        fsmManager = new StateMachine<MonsterFSM>(this, new stateIdle());
        fsmManager.AddStateList(new stateMove());
        fsmManager.AddStateList(new stateAtk());


        fov = GetComponent<FieldOfView>();
    }

    protected virtual void Update()
    {
        fsmManager.Update(Time.deltaTime);  
    }

    public virtual Transform SearchMonster()
    {
        return target;
    }

    public float atkRange;

    public virtual bool getFlagAtk
    {
        get
        {
            if (!target)
            {
                return false;
            }

            float distance = Vector3.Distance(transform.position, target.position);
            Debug.Log("=======atkRange" + atkRange);
            return (distance <= atkRange);
        }
    }
}





