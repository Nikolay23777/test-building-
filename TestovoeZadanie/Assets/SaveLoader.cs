using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

public class SaveLoader : MonoBehaviour
{
    private SaveDataSerialization sv = new SaveDataSerialization();
    private string path;

    private void Start()
    {
         path = Path.Combine(Application.dataPath, "MapSave.json");
    }
    public List<BuildingDataSerialization> LoadMap()
    {
       
        if (File.Exists(path))
        {
            sv = JsonUtility.FromJson<SaveDataSerialization>(File.ReadAllText(path));
         return sv.structuresData;
            /*
            if (sv.GridCell!=null)
            {
                Structure[,] str = new Structure[sv.GridCell.GetLength(0), sv.GridCell.GetLength(1)];

                for (int i = 0; i < sv.GridCell.GetLength(0); i++)
                {
                    for (int j = 0; j < sv.GridCell.GetLength(1); j++)
                    {
                        str[i, j] = sv.GridCell[i, j];
                    }
                }
                return str;
            }
            */

        }
        return null;
       
    }

    public void SaveMap(CellReceiver[,] GridCell)
    {

        //sv.GridCell[,] = new Structure[GridCell.GetLength(0), GridCell.GetLength(1)];
        /*
          for (int i = 0; i < GridCell.GetLength(0); i++)
          {
              for (int j = 0; j < GridCell.GetLength(1); j++)
              {
                  sv.GridCell[i,j] = GridCell[i,j].building;
              }
          }

          sv.GridCell=GridCell;
        */
        /*
        for (int i = 0; i < GridCell.GetLength(0); i++)
        {
            for (int j = 0; j < GridCell.GetLength(1); j++)
            {
                sv.GridCell[i, j] = GridCell[i, j].building;
            }
        }
        */
        
           sv.DestroyStructureData();
        for (int i = 0; i < GridCell.GetLength(0); i++)
        {
            for (int j = 0; j < GridCell.GetLength(1); j++)
            {
                if (GridCell[i, j].building != null)
                {
              
                    if (GridCell[i, j].building as Interactive) {
                        Interactive interactive = GridCell[i, j].building as Interactive;
                        sv.AddStructureData(GridCell[i, j].pos, GridCell[i, j].building.buildingPrefabindex, interactive.lvl);
                    }
                    else
                    {
                        sv.AddStructureData(GridCell[i, j].pos, GridCell[i, j].building.buildingPrefabindex, 0);
                    }
                }

            }
        }



            }
    private void OnApplicationQuit()
    {
        File.WriteAllText(path, JsonUtility.ToJson(sv));
    }

  
}


[Serializable]
public class SaveDataSerialization
{
    public List<BuildingDataSerialization> structuresData = new List<BuildingDataSerialization>();

    public void AddStructureData(Vector2Int position, int buildingPrefabindex,int buildingLevel)
    {
        structuresData.Add(new BuildingDataSerialization(position, buildingPrefabindex, buildingLevel));
    }
    public void DestroyStructureData()
    {
        structuresData.Clear();
    }
}

[Serializable]
public class BuildingDataSerialization
{
    public Vector2Serialization position;
    public int buildingPrefabindex;
    public int buildingLevel;

    public BuildingDataSerialization(Vector2Int position, int buildingPrefabindex,int buildingLevel)
    {
        this.position = new Vector2Serialization(position);
        this.buildingPrefabindex = buildingPrefabindex;

        this.buildingLevel = buildingLevel;


    }
}

[Serializable]
public class Vector2Serialization
{
    public int x, y;

    public Vector2Serialization(Vector2Int position)
    {
        this.x = position.x;
        this.y = position.y;
       
    }

    public Vector2Int GetValue()
    {
        return new Vector2Int(x, y);
    }
}