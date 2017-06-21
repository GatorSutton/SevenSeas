using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrellExplosion : MonoBehaviour {

    public float radius = 5;
    public float power = 10;
    

    // Use this for initialization
    void Start () {
		
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Explode();
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach(Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius, 0f);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
