using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellReceiver : MonoBehaviour,IPointerClickHandler
{
    public Structure building;
    public Vector2Int pos;

   // public bool FreeCell;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            if (building==null)
            {
                UIController.instance.ShowPanelBilding(this);
            }
            else
            {
               if(building is Interactive)
                {
                    UIController.instance.ShowPanelUpdates(this);
                }
                else if (building is Special)
                {
                    UIController.instance.ShowPanelDescription(this);
                }
              
            }
        }
    }

    // Start is called before the first frame update

    void Start()
    {
        
    }

}
