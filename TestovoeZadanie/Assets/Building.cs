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
   public int lvl{ get; set; }//������� ������� ���������

   public int Maxlvl;//������������ ������� ���������
    public  Interactive()
    {
        lvl = 1;
    }
    //����� �������� ���������
    public void LevelUp() {

        if (lvl < Maxlvl)
        {
            lvl++;
            ApplyChanges();
        }
    }
    //��������� ���������
    public abstract void ApplyChanges();



}
