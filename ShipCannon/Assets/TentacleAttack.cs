using UnityEngine;
using System.Collections;

public class TentacleAttack : MonoBehaviour
{

    public float m_Speed;

    private Quaternion targetRotation;
    private Quaternion startRotation;
    private float x = 1;
    private float z = 1;
    private float t = 0;

    enum states
    {
        idle,
        attacking
    }

    // Use this for initialization
    void Start()
    {
        startRotation = transform.rotation;
        targetRotation = Quaternion.AngleAxis(90, new Vector3(x, 0, z)) * startRotation;
    }

    // Update is called once per frame
    void Update()
    {


        //transform.Rotate(new Vector3(x, 0, z), Time.deltaTime);

        transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t * m_Speed);


        
        if (Input.GetButtonDown("Shoot"))
        {
            t = 0;
            x = Random.Range(-1f, 1f);
            z = Random.Range(-1f, 1f);
            targetRotation = Quaternion.AngleAxis(90, new Vector3(x, 0f, z)) * startRotation;
            


        }


        t += Time.deltaTime;



    }
}


    




   



 
    





 

