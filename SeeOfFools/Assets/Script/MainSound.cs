using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSound : MonoBehaviour
{

    public AudioClip[] Bgm;

    bool sound1;
    bool sound2;
    bool sound3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Round == 1 && sound1 == false)
        {
            AudioClip audio = Bgm[0];

            GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);
            sound1 = true;
        }

        if (GameManager.Instance.Round == 2 && sound2 == false)
        {
            AudioClip audio = Bgm[1];

            GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);
            sound2 = true;
        }
        if (GameManager.Instance.Round == 3 && sound3 == false)
        {
            AudioClip audio = Bgm[2];

            GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);
            sound3 = true;
        }
    }


}
