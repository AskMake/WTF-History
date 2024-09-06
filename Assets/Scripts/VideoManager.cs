using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Utilities;

[RequireComponent(typeof(VideoPlayer))]
public class  VideoManager: Singleton<VideoManager>
{
    private VideoPlayer player;
    private void OnEnable()
    {
        if(player == null)
        {
            player = GetComponent<VideoPlayer>();
        }
    }
    public void PlayVid(VideoClip clip)
    {
        player.clip = clip;
        player.Play();
    }
    public void StopVid()
    {
        player.Stop();
    }
    public double VidDuration => player.time;
    public void PauseVid()
    {
        if(player.clip != null)
        {
            player.Pause();
        }
    }
    

}
