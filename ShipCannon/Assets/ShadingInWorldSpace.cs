using UnityEngine;

[ExecuteInEditMode]
public class ShadingInWorldSpace : MonoBehaviour
{

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

        rend.sharedMaterial.SetVectorArray("_Array", landingPointsPositions);
    }
}