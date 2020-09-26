using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    public AudioSource start, end;
    public float time = -1f;

    private void Awake()
    {
        start.Stop();
        end.Stop();

        start.playOnAwake = false;
        end.playOnAwake = false;

        end.loop = true;

        if (time == -1)
        {
            time = start.clip.length;
        }

        start.Play();

        StartCoroutine(wait());
    }

    IEnumerator wait()
    {

        yield return new WaitForSeconds(time);
        end.Play();
        start.Stop();

    }

}
