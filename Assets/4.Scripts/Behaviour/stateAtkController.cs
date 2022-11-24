using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class stateAtkController : MonoBehaviour
{  
    public delegate void OnStartStateAtkController(); 
    public OnStartStateAtkController stateAtkControllerStartHandler; //이거 왜한겨

    public delegate void OnEndStateAtkController(); 
    public OnEndStateAtkController stateAtkControllerEndHandler; //이것도 왜한겨
     
    public bool getFlagStateAtkController
    {
        get; 
        private set;
    }

    private void Start()
    { 
        stateAtkControllerStartHandler
            = new OnStartStateAtkController(stateAtkControllerStart); 
        stateAtkControllerEndHandler
            = new OnEndStateAtkController(stateAtkControllerEnd);
    }
     
    private void stateAtkControllerStart()
    {
        //뭔가가 뭔가 하는건가
    }

    private void stateAtkControllerEnd()
    {
        //끝나면 뭐뭐뭐
    }
     
    public void EventStateAtkStart() //함수 실행할려고 
    { 
        getFlagStateAtkController = true; 
        stateAtkControllerStartHandler();
    }
      
    public void EventStateAtkEnd()
    { 
        getFlagStateAtkController = false; 
        stateAtkControllerEndHandler();
    }
     
    public void OnCheckAttackCollider(int attackIndex)
    {
        Debug.Log("---------------------attackIndex : " + attackIndex);
        GetComponent<IAtkAble>()?.OnExecuteAttack(attackIndex);
    }
}
