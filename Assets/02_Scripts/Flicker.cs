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

    public void SetFlicker()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("_OutlineSize", 8.0f);

        StartCoroutine(Flickering());
    }

    IEnumerator Flickering()
    {
        yield return null;
    }
}
