using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class ProcedureExample : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.W)) {
            Debug.Log("当前的流程:" + GameEntry.Procedure.CurProcedure);
            Debug.Log("当前的流程状态:" + GameEntry.Procedure.CurProcedureState);
        }

        if (Input.GetKeyUp(KeyCode.A)) {
            GameEntry.Procedure.ChangeState(ProcedureState.Preload);
        }

        if (Input.GetKeyUp(KeyCode.S)) {
            GameEntry.Procedure.ChangeState(ProcedureState.WorldMap);
        }

    }

}
