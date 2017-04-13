using UnityEngine;
using System.Collections;

public class ShipDetection : MonoBehaviour {

    public float m_CoolDownPeriod;

    private TentacleAttack TA;
    private float timeStamp = 0;

	// Use this for initialization
	void Start () {
        TA = GetComponentInParent<TentacleAttack>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "player")
        {
            if (timeStamp <= Time.time)
            {
                float x = collider.transform.position.x;
                float z = collider.transform.position.z;
                timeStamp = Time.time + m_CoolDownPeriod;
                TA.Attack(x, z);
            }
        }
    }
}
