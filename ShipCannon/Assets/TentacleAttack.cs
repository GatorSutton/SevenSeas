using UnityEngine;
using System.Collections;

public class TentacleAttack : MonoBehaviour
{

    public float m_Speed;
    public Transform parentAnimTransform;

    private Animator anim;
    private Quaternion targetRotation;
    private Quaternion startRotation;
    private float x = 1;
    private float z = 1;
    private float t = 0;
    private bool retracting = false;

    enum states
    {
        idle,
        attacking
    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        startRotation = transform.rotation;
       // targetRotation = Quaternion.AngleAxis(90, new Vector3(x, 0, z)) * startRotation;
    }

    // Update is called once per frame
    void Update()
    {


        //transform.Rotate(new Vector3(x, 0, z), Time.deltaTime);

        transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);


        
        if (Input.GetButtonDown("Shoot"))
        {
            Vector2 point = Random.insideUnitCircle;
            float angle = Vector2.Angle(point, new Vector2(0, 1));
            print(angle);
            anim.Play("tentacleattack", -1, 0f);
            t = 0;
            retracting = false;
            targetRotation = Quaternion.AngleAxis(90, new Vector3(point.x, 0f, point.y)) * startRotation;
            //parentAnimTransform.Rotate(0, 30, 0);

            parentAnimTransform.LookAt(new Vector3(-point.x, 0f, -point.y));
        }

        if (t > .99) 
        {
            retracting = true;
        }

        if (retracting == false)
        {
            t += Time.deltaTime * m_Speed;
        }
        else
        {
            t -= Time.deltaTime * m_Speed;
        }


    }
}


    




   



 
    





 

