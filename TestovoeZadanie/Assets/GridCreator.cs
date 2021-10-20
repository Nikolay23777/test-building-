using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    public static GridCreator instance { get; private set; }

    [Header("Размер сетки")]
    public Vector2Int SizeMap = new Vector2Int(5,5);
    [Header("Префаб клетки")]
    [SerializeField]
    private GameObject TileGrass;
    [Header("Контейнер всей карты")]
    [SerializeField]
    private Transform ParentTiles;

    public CellReceiver[,] GridCell;

    private SaveLoader SaveLoader;
    /// <summary>
    /// Создает сетку необходимого размера
    /// </summary>
    /// <param name="size">Размер сетки Vector2Int</param>
    public void MapCreator(Vector2Int size)
    {
        GameObject clone;
        CellReceiver cell;
        for(int i = 0;  i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                clone=Instantiate(TileGrass,new Vector3(i,0,j),Quaternion.identity);
                clone.name = "Cell [ " + i + " : " + j + " ]";
                cell = clone.GetComponent<CellReceiver>();
                cell.pos = new Vector2Int(i, j);
                GridCell[i, j] = cell;
                //clone.GetComponent<CellReceiver>().pos = new Vector2Int(i,j);
                clone.transform.SetParent(ParentTiles);
            }
        }
    }
    /// <summary>
    /// Метод находит ячейку по её позиции
    /// </summary>
    /// <param name="vector2"> Позиция искомой ячейки</param>
    /// <returns></returns>
    public CellReceiver GetCellToPosition(Vector2Int vector2)
    {
        CellReceiver cellReceiver=null;
        for (int i = 0; i < GridCell.GetLength(0); i++)
        {
            for (int j = 0; j < GridCell.GetLength(1); j++)
            {
                if (GridCell[i, j].pos == vector2)
                {
                    return GridCell[i, j];
                }
            }
        }
        return cellReceiver;
    }/// <summary>
    /// Удаляет все с поля
    /// </summary>
    public void ResetAll()
    {
       
        foreach (Transform child in UIController.instance.ConteunerBild) {
            Destroy(child.gameObject);
        }

    }

    public void SaveMap()
    {
        /*
        Vector2Int[,] posbild = new Vector2Int[SizeMap.x, SizeMap.y];
        for (int i = 0; i < SizeMap.x; i++)
        {
            for (int j = 0; j < SizeMap.y; j++)
            {
                posbild[i, j] = GridCell[i, j].pos;
            }
        }
        */


                SaveLoader.SaveMap(GridCell);
       
    }
    public void LoadMap()
    {

        List<BuildingDataSerialization> structures = SaveLoader.LoadMap();

        if (structures != null)
        {
            foreach (BuildingDataSerialization building in structures)
            {
                GameObject clone;
                CellReceiver cellReceiver;
                clone = Instantiate(buildingAll[building.buildingPrefabindex], new Vector3(building.position.GetValue().x, 0, building.position.GetValue().y), Quaternion.identity);
                clone.transform.SetParent(UIController.instance.ConteunerBild);
                cellReceiver = GetCellToPosition(building.position.GetValue());
               
               
                cellReceiver.building = clone.GetComponent<Structure>();
                if (cellReceiver.building as Interactive)
                {
                    
                    Interactive interactive = cellReceiver.building as Interactive;
                    interactive.lvl = building.buildingLevel;
                    interactive.ApplyChanges();
                }
            }
        }
        

    }
    [SerializeField]
    private GameObject[] buildingAll;
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
        SaveLoader = GetComponent<SaveLoader>();
        
        GridCell = new CellReceiver[SizeMap.x, SizeMap.y];
        MapCreator(SizeMap);
        LoadMap();
       
    }
    /*
    private int CoinSosed(int[,] chisla,int i, int j)
    {
        int sosed = 0;
        if ( chisla[i+1,j]==1)
        {
            sosed++;
        }
        if (chisla[i - 1, j] == 1)
        {
            sosed++;
        }
        if (chisla[i , j+1] == 1)
        {
            sosed++;
        }
        if (chisla[i , j-1] == 1)
        {
            sosed++;
        }
        return sosed;
    }
    public void RoadСorrection()
    {
        /*
        int[,] indexerRoad= new int[GridCell.GetLength(0)+2,GridCell.GetLength(1)+2];
        for (int i = 1; i < indexerRoad.GetLength(0)-1; i++)
        {
            for (int j = 1; j < indexerRoad.GetLength(1)-1; j++)
            {
                if (GridCell[i-1, j-1].building != null && GridCell[i-1, j-1].building.buildingPrefabindex == 5)
                {
                    indexerRoad[i, j] = 1;
                  //  print("222");
                }
                else
                {
                    indexerRoad[i, j] = 0;
                }
            }
        }
                

                for (int i = 1; i < indexerRoad.GetLength(0)-1; i++)
                {
                    for (int j = 1; j < indexerRoad.GetLength(1)-1; j++)
                    {

                        if (indexerRoad[i, j] == 1) { 

                            if(CoinSosed(indexerRoad,i,j)==4)
                            {
                        GridCell[i - 1, j - 1].building.gameObject.GetComponent<MeshFilter>().mesh = MeshVisualizer.instance.GetMeshRoad(2);
                               print("*****");
                            }
                        }
                    }
                }
        
                

            }
    */
    // Update is called once per frame
    void Update()
    {
        
    }
}
