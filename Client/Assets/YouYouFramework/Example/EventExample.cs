using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class EventExample : MonoBehaviour
{

    void Start()
    {
        
    }

    private void OnRegComplete(object param) {
        Debug.Log(param);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A)) {
            GameEntry.Event.CommonEvent.AddListener(CommonEventId.RegComplete, OnRegComplete);
        }

            if (Input.GetKeyUp(KeyCode.W)) {
            GameEntry.Event.CommonEvent.Dispatch(CommonEventId.RegComplete, "EventExample");
        }
    }

    private void OnDestroy() {
        GameEntry.Event.CommonEvent.RemoveListener(CommonEventId.RegComplete, OnRegComplete);
    }

}
