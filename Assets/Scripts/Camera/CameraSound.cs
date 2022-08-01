using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSound : MonoBehaviour
{
    AudioSource loopBody;
    AudioSource loopHead;

    bool canPlayLoop;
    void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        loopBody = (sources[0].clip.name.Contains("Body")) ? sources[0] : sources[1];

        loopHead = (sources[0].clip.name.Contains("Body")) ? sources[1] : sources[0];
        // loopHead.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!canPlayLoop)
        {
            if(!loopHead.isPlaying)
            {
                canPlayLoop = true;
                loopBody.loop = true;
                loopBody.Play();
            }
        }
    }
}
