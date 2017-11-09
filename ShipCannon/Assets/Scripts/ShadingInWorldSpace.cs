using UnityEngine;

[ExecuteInEditMode]
public class ShadingInWorldSpace : MonoBehaviour
{

    public GameObject[] landingPoints;
    public Vector4[] landingPointsPositions;

    private int m_LandingPointCount;


    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        m_LandingPointCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < landingPoints.Length; i++)
        {
            landingPointsPositions[i] = landingPoints[i].transform.position;
        }

        rend.sharedMaterial.SetVectorArray("_Array", landingPointsPositions);
    }

    
    public void addLandingPoint(GameObject landingPoint)
    {
        landingPoints[m_LandingPointCount] = landingPoint;
        m_LandingPointCount++;
    }
    
}