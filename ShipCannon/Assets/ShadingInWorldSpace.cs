using UnityEngine;

[ExecuteInEditMode]
public class ShadingInWorldSpace : MonoBehaviour
{
    public GameObject other;
    public GameObject other2;
    public GameObject other3;
    public GameObject other4;

    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (other != null)
        {
            rend.sharedMaterial.SetVector("_Center", other.transform.position);
        }

        if (other2 != null)
        {
            rend.sharedMaterial.SetVector("_Center2", other2.transform.position);
        }

        if (other3 != null)
        {
            rend.sharedMaterial.SetVector("_Center3", other3.transform.position);
        }

        if (other4 != null)
        {
            rend.sharedMaterial.SetVector("_Center4", other4.transform.position);
        }
    }
}