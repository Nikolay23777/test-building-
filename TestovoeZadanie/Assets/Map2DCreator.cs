using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2DCreator : MonoBehaviour
{
    public Camera TargetCamera;
   
   
    public void MakeDrow2Dmap()
    {
        int width = this.TargetCamera.pixelWidth;
        int height = this.TargetCamera.pixelHeight;
        Texture2D texture = new Texture2D(width, height);

        RenderTexture targetTexture = RenderTexture.GetTemporary(width, height);

        this.TargetCamera.targetTexture = targetTexture;
        this.TargetCamera.Render();


        RenderTexture.active = targetTexture;

        Rect rect = new Rect(0, 0, width, height);
        texture.ReadPixels(rect, 0, 0);
        texture.Apply();
        UIController.instance.Show2Dmap(texture);
    }
}
