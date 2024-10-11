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
    [SerializeField]
    private Slider videoScroll;

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
        videoScroll.SetValueWithoutNotify(0);
        videoScroll.maxValue = (float)clip.length;
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
        if(Input.GetMouseButtonUp(0))
        { 
            PauseUnpause();
        }
        if(Player.isPlaying)
        {
            videoScroll.SetValueWithoutNotify((float)Player.time);
        }
        if(!Player.isPlaying && Player.clip != null && (ulong)Player.frame == Player.frameCount-1)
        {
            Player.Stop();
            topicsGO.SetActive(true);
            videoScroll.value = 0;
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
    public void ScrollSetTime()
    {
        Player.time = (double)videoScroll.value;
    }
}