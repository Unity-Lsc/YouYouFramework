using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class TimeExample : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.W)) {
            var action = GameEntry.Time.CreateTimeAction();
            action.Init(3, 1, 5,
                () => {
                    Debug.Log("开始执行...");
                },
                (int loop) => {
                    Debug.Log("运行中,剩余次数:" + loop);
                },
                () => {
                    Debug.Log("运行结束...");
                });
            action.Run();
        }
    }

}
