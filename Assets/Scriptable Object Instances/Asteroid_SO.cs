using UnityEngine;


[CreateAssetMenu(fileName = "Asteroid_SO", menuName = "Asteroid_SO", order = 0)]
public class Asteroid_SO : ScriptableObject
{
    [SerializeField] GameObject AstroidA_Prefab;
    [SerializeField] GameObject AstroidB_Prefab;
    [SerializeField] GameObject AstroidC_Prefab;

    [SerializeField] Mesh AstroidA_Mesh;
    [SerializeField] Mesh AstroidB_Mesh;
    [SerializeField] Mesh AstroidC_Mesh;

    public GameObject GetAstroid()
    {
        int index = Random.Range(0, 3);
        switch (index)
        {
            case 0: AstroidA_Prefab.GetComponent<MeshFilter>().mesh = AstroidA_Mesh; return AstroidA_Prefab;
            case 1: AstroidB_Prefab.GetComponent<MeshFilter>().mesh = AstroidB_Mesh; return AstroidB_Prefab;
            case 2: AstroidC_Prefab.GetComponent<MeshFilter>().mesh = AstroidC_Mesh; return AstroidC_Prefab;
            default: AstroidA_Prefab.GetComponent<MeshFilter>().mesh = AstroidA_Mesh; return AstroidA_Prefab;
        }
    }

    public GameObject GetAstroid(char type)
    {
        switch (type)
        {
            case 'A': AstroidA_Prefab.GetComponent<MeshFilter>().mesh = AstroidA_Mesh; return AstroidA_Prefab;
            case 'B': AstroidB_Prefab.GetComponent<MeshFilter>().mesh = AstroidB_Mesh; return AstroidB_Prefab;
            case 'C': AstroidC_Prefab.GetComponent<MeshFilter>().mesh = AstroidC_Mesh; return AstroidC_Prefab;
            default: return null;
        }
    }
    
}
