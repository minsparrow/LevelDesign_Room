using System;
using UnityEngine;

public class Outline : MonoBehaviour
{
    private Material[] mats;
    public float outlineSize = 10.0f;

    private static readonly int OutlineSize = Shader.PropertyToID("_OutlineSize");

    private void Start()
    {
        mats = gameObject.GetComponent<Renderer>().materials;
    }

    public void OutlineOn()
    {
        foreach (var mat in mats)
        {
            mat.SetFloat(OutlineSize, outlineSize);
        }
    }

    public void OutlineOff()
    {
        foreach (var mat in mats)
        {
            mat.SetFloat(OutlineSize, 0);
        }
    }
}
