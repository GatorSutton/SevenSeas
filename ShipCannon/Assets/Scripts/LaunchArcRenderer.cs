using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class LaunchArcRenderer : MonoBehaviour {

    private LineRenderer lr;

    public Transform Cannon;
    public Transform Ship;
    public float velocity;
    public int resolution;

    private float gravity;
    private float radianAngle;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        gravity = Mathf.Abs(Physics.gravity.y);
    }
    
    void Update()
    {
        RenderArc();
    }

    void RenderArc()
    {
        lr.SetVertexCount(resolution + 1);
        lr.SetPositions(CalculateArcArray());


    }

    Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];

        radianAngle = CalculateAngle();

        //float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / gravity;
        float maxDistance = (velocity * Mathf.Cos(radianAngle) / gravity) * (velocity * Mathf.Sin(radianAngle) + Mathf.Sqrt((velocity * velocity * Mathf.Sin(radianAngle) * Mathf.Sin(radianAngle) + 2 * gravity * transform.position.y)));

        for(int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance, transform.position.x, transform.position.y, transform.position.z);
        }

        return arcArray;
        
    }

    Vector3 CalculateArcPoint(float t, float maxDistance, float initialX, float initialY, float initalZ)
    {
        float distance = t * maxDistance;
        float y = distance * Mathf.Tan(radianAngle) - ((gravity * distance * distance) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle))) + initialY;


        float cannonRotation = Cannon.eulerAngles.y;
        print(cannonRotation);

        float x = Mathf.Sin(Mathf.Deg2Rad * cannonRotation) * distance + transform.position.x;                  //Keep up with cannon rotation and add the initial location of the cannon
        float z = Mathf.Cos(Mathf.Deg2Rad * cannonRotation) * distance + transform.position.z;

        return new Vector3(x, y, z);
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
