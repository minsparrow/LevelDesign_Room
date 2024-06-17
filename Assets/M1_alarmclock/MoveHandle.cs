using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoveHandle : MonoBehaviour
{
    public int CurrentCoorX = 0;
    public int CurrentCoorY = 1;
    public bool m_Activate;
    public bool m_Activate_y0;
    public bool m_Activate_y1;
    public bool m_Activate_y2;
    public float duration = 1.0f; // 이동에 걸리는 시간
    public float targetPositionX = 0.195f; // 목표 x 위치
    public float targetPositionY0 = 0.055f; // 목표 y 위치
    public float targetPositionY1 = -0.018f; // 목표 y 위치
    public float targetPositionY2 = -0.09f; // 목표 y 위치
    float unitX = -0.081f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Activate)
        {
            this.gameObject.transform.DOLocalMoveX(targetPositionX, duration).SetEase(Ease.InOutQuad);
            targetPositionX -= 0.081f;
            m_Activate = false;
            
        }
        if (m_Activate_y0)
        {
            this.gameObject.transform.DOLocalMoveY(targetPositionY0, duration).SetEase(Ease.InOutQuad);
            m_Activate_y0 = false;

        }
        if (m_Activate_y1)
        {
            this.gameObject.transform.DOLocalMoveY(targetPositionY1, duration).SetEase(Ease.InOutQuad);
            m_Activate_y1 = false;

        }
        if (m_Activate_y2)
        {
            this.gameObject.transform.DOLocalMoveY(targetPositionY2, duration).SetEase(Ease.InOutQuad);
            m_Activate_y2 = false;

        }
    }
    private void MoveSelectPostion(int cx, int cy)
    {
        if (cx == CurrentCoorX + 1 && cy == CurrentCoorY) { 
            this.gameObject.transform.DOLocalMoveX(targetPositionX + cx * unitX, duration).SetEase(Ease.InOutQuad);
            CurrentCoorX++;
        }

        if (cy == CurrentCoorX && cy != CurrentCoorY)
        {
            switch (cy)
            {
                case 0:
                    this.gameObject.transform.DOLocalMoveY(targetPositionY0, duration).SetEase(Ease.InOutQuad);
                    CurrentCoorY = 0;
                    break;
                case 1:
                    this.gameObject.transform.DOLocalMoveY(targetPositionY1, duration).SetEase(Ease.InOutQuad);
                    CurrentCoorY = 1;
                    break;
                case 2:
                    this.gameObject.transform.DOLocalMoveY(targetPositionY2, duration).SetEase(Ease.InOutQuad);
                    CurrentCoorY = 2;
                    break;
            }
        }

    }
}
