using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Interactive
{

    public override void ApplyChanges()
    {
        MeshFilter meshFilter = gameObject.GetComponentInChildren<MeshFilter>();
         meshFilter.mesh=MeshVisualizer.instance.GetMeshFactory(lvl);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
