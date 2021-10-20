using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance { get; private set; }
    private CellReceiver flyingCell;

    [SerializeField]
    private GameObject PanelBilding;
    [SerializeField]
    private GameObject PanelUpdate;
    [SerializeField]
    private GameObject PanelDescription;
    [SerializeField]
    private Text TextUpdateLevel;
    [SerializeField]
    private RawImage Map2d;
    
    public Transform ConteunerBild;

    [SerializeField]
    private Text TextDescription;
    public void ShowPanelBilding(CellReceiver cell)
    {
        flyingCell = cell;
        PanelBilding.SetActive(true);
    }
    public void ShowPanelUpdates(CellReceiver cell)
    {
        flyingCell = cell;
        Interactive interactive = flyingCell.building as Interactive;
        TextUpdateLevel.text = interactive.lvl.ToString();
        PanelUpdate.SetActive(true);
    }
    public void ShowPanelDescription(CellReceiver cell)
    {
        flyingCell = cell;
        Special interactive = flyingCell.building as Special;
        TextDescription.text = interactive.Description.ToString();
        PanelDescription.SetActive(true);

    }
    public void Show2Dmap(Texture texture)
    {
       
        Map2d.gameObject.SetActive(true);
        Map2d.texture = texture;
    }

    public void StartPlacingBilding(Structure bild)
    {
        PanelBilding.SetActive(false);
        flyingCell.building = PlacingBilding(bild.gameObject,flyingCell.pos);
    }
    public void StartUpdateBilding()
    {
        PanelUpdate.SetActive(false);
        Interactive interactive = flyingCell.building as Interactive;
        interactive.LevelUp();
        


    }

    public Structure PlacingBilding(GameObject bild,Vector2Int pos)
    {
        GameObject clone;
        clone=Instantiate(bild, new Vector3(pos.x, 0, pos.y), Quaternion.identity);
        clone.transform.SetParent(ConteunerBild);
        return clone.GetComponent<Structure>();
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
