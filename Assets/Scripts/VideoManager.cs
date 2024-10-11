using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Utilities;

[RequireComponent(typeof(VideoPlayer))]
public class  VideoManager: Singleton<VideoManager>
{
    public VideoPlayer Player { get; private set;}
    public GameObject topicsGO;

    private void OnEnable()
    {
        if(Player == null)
        {
            Player = GetComponent<VideoPlayer>();
        }
    }
    public void SetClip(VideoClip clip)
    {
        Player.clip = clip;;
    }
    public void ContinuePlay()
    {
        Player.Play();
    }
    public void PlayVid(VideoClip clip)
    {
        if(clip != null){
        Player.clip = clip;
        Player.Play();
        }
    }
    public void StopVid()
    {
        Player.Stop();
        Player.clip = null;
    }
    public double VidDuration => Player.time;
    public void PauseVid()
    {
        if(Player.clip != null)
        {
            Player.Pause();
        }
    }
    private void Update()
    {

        if(!Player.isPlaying && Player.clip != null && (ulong)Player.frame == Player.frameCount-1)
        {
            Player.Stop();
            topicsGO.SetActive(true);
        }
    }
    public void PauseUnpause()
    {
        if (Player.clip != null && !Player.isPaused)
        {
            Player.Pause();
        }
        else if (Player.clip != null && Player.isPaused)
        {
            Player.Play();
        }
    }
}