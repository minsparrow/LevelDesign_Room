using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Color;

public class Flicker : MonoBehaviour
{
    public Camera cam;
    private RaycastHit hit;

    public Vector3 emissionColor = new Vector3(2.0f, 2.0f, 2.0f);
    public float emissionIntensity = 1.0f;
    public float flikerPeriod = 0.5f;

    private bool isFlikering = false;
    private static readonly int OutlineSize = Shader.PropertyToID("_OutlineSize");
    private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

    void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                hit.collider.gameObject.GetComponent<Renderer>().material.SetFloat(OutlineSize,8.0f);
                gameObject.GetComponent<Renderer>().sharedMaterial.SetVector(EmissionColor, new Vector4(1.0f, 1.0f, 1.0f, 1.0f));

            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray, out hit))
            {
                hit.collider.gameObject.GetComponent<Renderer>().material.SetFloat(OutlineSize,0f);
                gameObject.GetComponent<Renderer>().sharedMaterial.SetVector(EmissionColor, new Vector4(0, 0, 0, 1.0f));
            }
        }
    }

    public void FlickerOn()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat(OutlineSize, 8.0f);

        StartCoroutine(Flickering());
    }

    public void FlickerOff()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat(OutlineSize, 0);
        
        gameObject.GetComponent<Renderer>().material.SetVector(EmissionColor, new Vector4(0, 0, 0, 1.0f));
    }

    IEnumerator Flickering()
    {
        while (isFlikering)
        {
            gameObject.GetComponent<Renderer>().material.SetVector(EmissionColor, new Vector4(1.0f, 1.0f, 1.0f, 1.0f));

            yield return new WaitForSeconds(flikerPeriod);
            
            gameObject.GetComponent<Renderer>().material.SetVector(EmissionColor, new Vector4(0, 0, 0, 1.0f));
        }
        yield return null;
    }
}
