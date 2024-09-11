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
    public void SetClip(VideoClip clip)
    {
        player.clip = clip;;
    }
    public void PlayVid()
    {
        if(player.clip != null){
        player.Play();}
    }
    public void StopVid()
    {
        player.Stop();
        player.clip = null;
    }
    public double VidDuration => player.time;
    public void PauseVid()
    {
        if(player.clip != null)
        {
            player.Pause();
        }
    }
    public double[] quizManagerTime;
    
    void Update()
    {
        for(int i = 0; i < quizManagerTime.Length; i++)
        {
            if(VidDuration >= quizManagerTime[i] && VidDuration > 0 && quizManagerTime[i] != -1)
            {
                PauseVid();
                quizManagerTime[i] = -1;
            }
        }
    }

}
