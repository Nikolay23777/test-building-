using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshVisualizer : MonoBehaviour
{
    public static MeshVisualizer instance { get; private set; }
    // Start is called before the first frame update
    public Mesh[] MeshsHouses;
    public Mesh[] MeshsFactory;
    public Mesh[] MeshsRoad;

    public Mesh GetMeshHouse(int lvl)
    {
        return MeshsHouses[lvl - 1];
    }

    public Mesh GetMeshFactory(int lvl)
    {
        return MeshsFactory[lvl - 1];
    }
    public Mesh GetMeshRoad(int number)
    {
        return MeshsRoad[number - 1];
    }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

   
}
