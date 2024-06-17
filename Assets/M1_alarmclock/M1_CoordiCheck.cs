using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1_CoordiCheck : MonoBehaviour
{
    public int coordi_x;
    public int coordi_y;
    public M1_MoveHandle m_MH;

    // Start is called before the first frame update
    void Start()
    {
        m_MH = GameObject.Find("RedHandle").GetComponent<M1_MoveHandle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("sdtfsdfsdf");
        if (other.tag == "FingerTip")
        {
            Debug.Log("sdtfsdfs2df");
            m_MH.MoveSelectPostion(coordi_x, coordi_y);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("sdtfsdfsdf");
    }
}
