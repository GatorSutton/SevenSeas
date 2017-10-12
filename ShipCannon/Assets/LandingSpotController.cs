using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingSpotController : MonoBehaviour {


    public Transform Cannon;
    public Transform FireTransform;
    public float velocity;

    private float gravity;
    private float radianAngle;


    // Use this for initialization
    void Start () {
        gravity = Mathf.Abs(Physics.gravity.y);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = CalculateLandingPoint(CalculateLandingDistance(), FireTransform.position.y);
	}

    float CalculateLandingDistance()
    {
        radianAngle = CalculateAngle();
        float maxDistance = (velocity * Mathf.Cos(radianAngle) / gravity) * (velocity * Mathf.Sin(radianAngle) + Mathf.Sqrt((velocity * velocity * Mathf.Sin(radianAngle) * Mathf.Sin(radianAngle) + 2 * gravity * FireTransform.position.y)));
        return maxDistance;
    }

    Vector3 CalculateLandingPoint(float distance, float initialY)
    {
        //float y = distance * Mathf.Tan(radianAngle) - ((gravity * distance * distance) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle))) + initialY;

        float cannonRotation = Cannon.eulerAngles.y;

        float x = Mathf.Sin(Mathf.Deg2Rad * cannonRotation) * distance + FireTransform.position.x;                
        float z = Mathf.Cos(Mathf.Deg2Rad * cannonRotation) * distance + FireTransform.position.z;

        return new Vector3(x, 0, z);
    }

    float CalculateAngle()
    {
        float angle;
        angle = Cannon.eulerAngles.x;
        angle = 360 - angle;
        angle = Mathf.Deg2Rad * angle;
        return angle;
    }


}
