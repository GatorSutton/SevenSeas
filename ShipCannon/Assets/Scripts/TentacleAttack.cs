using UnityEngine;
using System.Collections;

public class TentacleAttack : MonoBehaviour
{

    private Animator anim;

    public Transform ship;


    // Use this for initialization
    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    void Update()
    {
      //  transform.LookAt(ship);
      //  transform.Rotate(0f, -90f, 0f);
    }

    public void Attack(float x, float z)
    {

        transform.LookAt(new Vector3(x, 0f, z));
        transform.Rotate(0f, -90f, 0f);
        anim.Play("tentacleattack", -1, 0f);
        print(x);
        print(z);
    }
}


    




   



 
    





 

