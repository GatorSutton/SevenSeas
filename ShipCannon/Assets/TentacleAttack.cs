using UnityEngine;
using System.Collections;

public class TentacleAttack : MonoBehaviour {

    public float m_Speed;

    private Quaternion targetRotation;
    private Quaternion startRotation;
    private Quaternion resetRotation;
    private float x =1;
    private float z = 1;

	// Use this for initialization
	void Start () {
        startRotation = transform.rotation;
        targetRotation = Quaternion.AngleAxis(90, new Vector3(x, 0, z)) * startRotation;
        resetRotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));

        InvokeRepeating("Switch", 5, 5);
	}
	
	// Update is called once per frame
	void Update () {


        //transform.Rotate(new Vector3(x, 0, z), Time.deltaTime);

        transform.rotation = Quaternion.Lerp(startRotation, targetRotation, Time.time * m_Speed);



    }

    void Switch()
    {
        targetRotation = resetRotation;
    }

 
    





 
}
