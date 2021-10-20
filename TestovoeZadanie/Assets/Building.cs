using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Structure : MonoBehaviour
{
    public GameObject building;
    public int buildingPrefabindex;
   // public Vector2Int Pos;


}
public abstract class Decorative:Structure
{

}
public abstract class Special : Structure
{
    public string Description { get; set; }
}
public abstract class Interactive:Structure
{
   public int lvl{ get; set; }//текущий уровень постройки

   public int Maxlvl;//максимальный уровень постройки
    public  Interactive()
    {
        lvl = 1;
    }
    //метод улучшить постройку
    public void LevelUp() {

        if (lvl < Maxlvl)
        {
            lvl++;
            ApplyChanges();
        }
    }
    //применить изменения
    public abstract void ApplyChanges();



}
