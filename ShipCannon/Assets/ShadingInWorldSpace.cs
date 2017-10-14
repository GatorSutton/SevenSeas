using UnityEngine;

[ExecuteInEditMode]
public class ShadingInWorldSpace : MonoBehaviour
{
    public GameObject other;
    public GameObject other2;

    public GameObject[] landingPoints;
    public Vector4[] landingPointsPositions;


    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < landingPoints.Length; i++)
        {
            landingPointsPositions[i] = landingPoints[i].transform.position;
        }
        
        if (other != null)
        {
            rend.sharedMaterial.SetVector("_Center", other.transform.position);
        }

        if (other2 != null)
        {
            rend.sharedMaterial.SetVector("_Center2", other2.transform.position);
        }

        rend.sharedMaterial.SetVectorArray("_Array", landingPointsPositions);
    }
}