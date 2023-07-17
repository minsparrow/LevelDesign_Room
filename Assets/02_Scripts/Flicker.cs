using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public Camera cam;
    private RaycastHit hit;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                hit.collider.gameObject.GetComponent<Renderer>().material.SetFloat("_OutlineSize",8.0f);
            }
        }
    }

    public void FlickerOn()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("_OutlineSize", 8.0f);

        StartCoroutine(Flickering());
    }

    public void FlickerOff()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("_OutlineSize", 0);
    }

    IEnumerator Flickering()
    {
        yield return null;
    }
}
