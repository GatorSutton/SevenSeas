using UnityEngine;
using System.Collections;

public class TentacleColliders : MonoBehaviour {



    private Component[] transforms;

	// Use this for initialization
	void Start () {


        transforms = GetComponentsInChildren(typeof(Transform));
        /*
        int count = 0;
        foreach(Transform transform in transforms)
        {
            if (count % 7 == 0 || count == 0)
            {
                transform.gameObject.AddComponent<BoxCollider>();
                BoxCollider col = transform.gameObject.GetComponent<BoxCollider>();
                col.size = new Vector3(.005f, .025f, .005f);
                transform.gameObject.tag = "tentacle";
                col.isTrigger = true;
            }
            count++;
        }
        */
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "player")
        {
            Invoke("SpawnPlayer", 5);
            Destroy(collision.gameObject);
        }
    }


}
