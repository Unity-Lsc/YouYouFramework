using System.Collections;
using UnityEngine;
using YouYou;

public class PoolExample : MonoBehaviour
{

    public Transform Tran01;
    public Transform Tran02;

    private void Update() {

        if(Input.GetKeyUp(KeyCode.A)) {
            GameEntry.Pool.SetClassObjectResidentCount<ExampleData>(3);
        }

        if(Input.GetKeyUp(KeyCode.W)) {
            //ExampleData data = GameEntry.Pool.DequeueClassObject<ExampleData>();

            //ExampleData1 data1 = GameEntry.Pool.DequeueClassObject<ExampleData1>();

            //ExampleData2 data2 = GameEntry.Pool.DequeueClassObject<ExampleData2>();

            //ExampleData3 data3 = GameEntry.Pool.DequeueClassObject<ExampleData3>();

            //StartCoroutine(EnqueueClassObject(data));
            //StartCoroutine(EnqueueClassObject(data1));
            //StartCoroutine(EnqueueClassObject(data2));
            //StartCoroutine(EnqueueClassObject(data3));
            StartCoroutine(CreateObj());
        }
    }

    private IEnumerator EnqueueClassObject(object obj) {
        yield return new WaitForSeconds(5);
        GameEntry.Pool.EnqueueClassObject(obj);
    }

    private IEnumerator CreateObj() {
        for (int i = 0; i < 20; i++) {
            yield return new WaitForSeconds(0.5f);
            GameEntry.Pool.GameObjectSpawn(1, Tran01, (instance) => {
                instance.localPosition += new Vector3(0, 0, i * 3);
                instance.gameObject.SetActive(true);
                StartCoroutine(DespawnObj(1, instance));
            });
            GameEntry.Pool.GameObjectSpawn(2, Tran02, (instance) => {
                instance.gameObject.SetActive(true);
                instance.localPosition += new Vector3(0, 5, i * 3);
                StartCoroutine(DespawnObj(2, instance));
            });
        }
    }

    private IEnumerator DespawnObj(byte poolId, Transform instance) {
        yield return new WaitForSeconds(20);
        GameEntry.Pool.GameObjectDespawn(poolId, instance);
    }

    public class ExampleData
    {

    }

    public class ExampleData1
    {

    }
    public class ExampleData2
    {

    }
    public class ExampleData3
    {

    }

}


