using System.Collections;
using System.Collections.Generic;
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
    
}
