using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class LocalizationExample : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W)) {
            string str = GameEntry.Localization.GetString("Loading.ChangeScene", 30);
            Debug.Log(str);
        }
    }

}
