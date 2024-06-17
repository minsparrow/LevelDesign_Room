using System.Collections;
using UnityEngine;

public class M1_SoundManager : MonoBehaviour
{
    public bool m_Activate;
    AudioSource AS;
    public AudioClip[] AC;
    public M1_MoveHandle m_MH;
    public int InitialPitch;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        AS.Play();

        StartCoroutine(playGo());
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Activate)
        {
            int a, b, c, d, e;
            InitialPitch = Random.Range(1, 12);
            a = InitialPitch + Random.Range(-1, 2);
            b = InitialPitch + Random.Range(-1, 2);
            c = InitialPitch + Random.Range(-1, 2);
            d = InitialPitch + Random.Range(-1, 2);
            e = InitialPitch + Random.Range(-1, 2);
            StartCoroutine(playSound(InitialPitch, a, b, c, d, e, InitialPitch));
            m_Activate = false;
        }
    }

    IEnumerator playSound(int a1, int a2, int a3, int a4, int a5, int a6, int a7)
    {

        if (a1 != -1)
        {
            AS.clip = AC[a1];
            AS.Play();
            yield return new WaitUntil(() => !AS.isPlaying);
        }
        if (a2 != -1)
        {
            AS.clip = AC[a2];
            AS.Play();
            yield return new WaitUntil(() => !AS.isPlaying);
        }
        if (a3 != -1)
        {
            AS.clip = AC[a3];
            AS.Play();
            yield return new WaitUntil(() => !AS.isPlaying);
        }
        if (a4 != -1)
        {
            AS.clip = AC[a4];
            AS.Play();
            yield return new WaitUntil(() => !AS.isPlaying);
        }
        if (a5 != -1)
        {
            AS.clip = AC[a5];
            AS.Play();
            yield return new WaitUntil(() => !AS.isPlaying);
        }
        if (a6 != -1)
        {
            AS.clip = AC[a6];
            AS.Play();
            yield return new WaitUntil(() => !AS.isPlaying);
        }
        if (a7 != -1)
        {
            AS.clip = AC[a7];
            AS.Play();
            yield return new WaitUntil(() => !AS.isPlaying);
        }

        yield return 0;
    }


    public IEnumerator playGo()
    {
        yield return new WaitUntil(() => !AS.isPlaying);
        yield return new WaitForSeconds(2f);
        m_Activate = true;

    }


}
