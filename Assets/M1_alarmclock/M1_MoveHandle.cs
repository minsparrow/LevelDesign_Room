using DG.Tweening;
using UnityEngine;


public class M1_MoveHandle : MonoBehaviour
{
    public int CurrentCoorX = 0;
    public int CurrentCoorY = 1;
    public bool m_Activate;
    public bool m_Activate_y0;
    public bool m_Activate_y1;
    public bool m_Activate_y2;
    public float duration = 1.0f; // 이동에 걸리는 시간
    public float targetPositionX = 0.195f; // 목표 x 위치
    float targetPositionY0 = -0.09f; // 목표 y 위치
    float targetPositionY1 = -0.018f; // 목표 y 위치
    float targetPositionY2 = 0.055f; // 목표 y 위치
    float unitX = -0.081f;
    public GameObject[] HLC;
    AudioSource m_AS;
    public M1_SoundManager m_SM;
    // Start is called before the first frame update
    void Start()
    {
        m_AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Activate)
        {
            setInitialize();
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
    public void MoveSelectPostion(int cx, int cy)
    {

        if (cx == CurrentCoorX + 1 && cy == CurrentCoorY)
        {
            if (cx == 7)
                this.gameObject.transform.DOLocalMoveX(-0.25f, duration).SetEase(Ease.InOutQuad);
            else
                this.gameObject.transform.DOLocalMoveX(targetPositionX + (cx - 1) * unitX, duration).SetEase(Ease.InOutQuad);


            if (cx == 1) HLC[0].SetActive(true);
            else if (cx == 7)
            {
                HLC[16].SetActive(true);
                Invoke("setInitialize", 2f);
            }
            else HLC[(cx - 2) * 3 + cy + 1].SetActive(true);
            if (cy == 0) m_AS.clip = m_SM.AC[m_SM.InitialPitch-1];
            if (cy == 1) m_AS.clip = m_SM.AC[m_SM.InitialPitch];
            if (cy == 2) m_AS.clip = m_SM.AC[m_SM.InitialPitch+1];
            m_AS.Play();
            CurrentCoorX++;
        }

        if (cx == CurrentCoorX && cy != CurrentCoorY)
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

    void setInitialize()
    {
        CurrentCoorX = 0;
        CurrentCoorY = 1;
        for (int i = 0; i < 17; i++)
        {
            if (HLC[i] != null)
                HLC[i].SetActive(false);
        }
        this.gameObject.transform.DOLocalMoveX(0.24f, duration).SetEase(Ease.InOutQuad);
        StartCoroutine(m_SM.playGo());
    }
}
