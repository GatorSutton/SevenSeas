using UnityEngine;
using System.Collections;

public class TentacleAttack : MonoBehaviour
{

    public float m_Speed;
    public Transform parentAnimTransform;

    private Animator anim;
    private Quaternion targetRotation;
    private Quaternion startRotation;


    // Use this for initialization
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
 

        
        if (Input.GetButtonDown("Shoot"))
        {
            Vector2 point = Random.insideUnitCircle;
            float angle = Vector2.Angle(point, new Vector2(0, 1));
            anim.Play("tentacleattack", -1, 0f);
            targetRotation = Quaternion.AngleAxis(90, new Vector3(point.x, 0f, point.y)) * startRotation;
            parentAnimTransform.LookAt(new Vector3(-point.x + parentAnimTransform.position.x, 0f, -point.y + parentAnimTransform.position.z));
        }



    }
}


    




   



 
    





 

