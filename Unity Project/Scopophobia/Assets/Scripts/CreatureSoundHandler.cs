using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSoundHandler : MonoBehaviour
{
    public AudioClip step1;
    public AudioClip step2;
    public AudioClip noticed;
    public AudioSource mySource;
    public bool justSeen = false;
    public void Start()
    {
        mySource = GetComponent<AudioSource>();
        StartCoroutine(SoundGo());
    }
    public IEnumerator SoundGo()
    {
        for (; ; )
        {
            Debug.Log("SoundGo");
            if (justSeen)
            {
                mySource.clip = noticed;
                mySource.PlayOneShot(noticed);
                ///while (mySource.isPlaying)
                ///{
                ///    yield return null;
                ///}
                ///mySource.clip = step1;
                justSeen = false;
                yield return null;
            }
            yield return null;
            ///if (mySource.clip)
            ///{
            ///    if (mySource.clip.name == step1.name)
            ///    {
            ///        while (mySource.isPlaying)
            ///        {
            ///            yield return null;
            ///        }
            ///        mySource.clip = step2;
            ///    }
            ///    if (mySource.clip.name == step2.name)
            ///    {
            ///        while (mySource.isPlaying)
            ///        {
            ///            yield return null;
            ///        }
            ///        mySource.clip = step1;
            ///    }
            ///}
        }
    }
}