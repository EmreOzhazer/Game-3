using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    public RenderTexture renderTexture;
    public Material material;

    void OnCollisionEnter(Collision collision)
    {
        // Capture the intersecting area to a temporary RenderTexture
        RenderTexture tempRenderTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32);
        tempRenderTexture.Create();
        Graphics.SetRenderTarget(tempRenderTexture);
        GL.Clear(true, true, Color.clear);
        Graphics.Blit(null, tempRenderTexture);

        // Apply a color or a texture to the captured RenderTexture
        material.SetTexture("_MainTex", tempRenderTexture);
        material.SetColor("_Color", Color.red);

        // Render the modified RenderTexture back to the screen
        Graphics.Blit(tempRenderTexture, null as RenderTexture);
    }

}
