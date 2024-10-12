using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncExample : MonoBehaviour
{

    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            TestMethodAsync();
        }
    }

    public async void TestMethodAsync()
    {
        for (int i = 0; i < 20000; i++)
        {
            Debug.Log(i);
            await Task.Delay(1);
        }
    }

    private void OnDestroy() {
        
    }

}
