using UnityEngine;
using System.Collections;


public class LaunchArcRenderer2 : MonoBehaviour
{


    public Transform Cannon;
    public float velocity;
    public int resolution;
    public GameObject sphere;

    public GameObject m_landingSpot;

    private GameObject[] spheres;
    private float gravity;
    private float radianAngle;

    void Awake()
    {
        gravity = Mathf.Abs(Physics.gravity.y);

        spheres = new GameObject[resolution + 1];
        for(int i=0; i<=resolution; i++)
        {
            GameObject clone = (GameObject) Instantiate(sphere, new Vector3(i * 10,100,0), Quaternion.identity);
            clone.transform.parent = gameObject.transform;
            Renderer r = clone.GetComponent<Renderer>();
            Color color = r.material.color;
            //color.a = 1 - (float)i / (float)resolution;
            color.a = .5f;
            r.material.color = color;
            spheres[i] = clone;
        }

    }

    void Update()
    {
        RenderArc();
        
    }

    void RenderArc()
    {
        Vector3[] arcArray = CalculateArcArray();

        for (int i = 0; i <= resolution; i++)
        {
            spheres[i].transform.position = arcArray[i];
        }

        m_landingSpot.transform.position = arcArray[arcArray.Length - 1];
    }

    Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];

        radianAngle = CalculateAngle();

        //float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / gravity;   equation if the launcher is grounded
        float maxDistance = (velocity * Mathf.Cos(radianAngle) / gravity) * (velocity * Mathf.Sin(radianAngle) + Mathf.Sqrt((velocity * velocity * Mathf.Sin(radianAngle) * Mathf.Sin(radianAngle) + 2 * gravity * transform.position.y)));

        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance, transform.position.y);
        }

        return arcArray;

    }

    Vector3 CalculateArcPoint(float t, float maxDistance, float initialY)
    {
        float distance = t * maxDistance;
        float y = distance * Mathf.Tan(radianAngle) - ((gravity * distance * distance) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle))) + initialY;


        float cannonRotation = Cannon.eulerAngles.y;

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
