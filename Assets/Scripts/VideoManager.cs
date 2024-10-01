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
    private VideoPlayer player;
    public Material material;
    public Texture2D texture;
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
    public void ContinuePlay()
    {
        player.Play();
    }
    public void PlayVid(VideoClip clip)
    {
        if(clip != null){
        player.clip = clip;
        player.Play();
        }
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
    private void Update()
    {

        if(!player.isPlaying && player.clip != null && (ulong)player.frame == player.frameCount)
        {
            player.Stop();
            material.mainTexture = texture;
        }
    }
}