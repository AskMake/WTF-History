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
    
    public GameObject pauseScreen;
    public GameObject slider;
    public GameObject exitMenu;
    public GameObject exit;

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
        if (Player.clip != null)
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
            Player.clip= null;
            topicsGO.SetActive(true);
            videoScroll.value = 0;
            slider.SetActive(false);
            exitMenu.SetActive(false);
            exit.SetActive(true);
        }
    }
    public void PauseUnpause()
    {
        if (Player.clip != null && !Player.isPaused && Player.frame > 0)
        {
            pauseScreen.SetActive(true);
            Player.Pause();
            videoScroll.interactable = true;
        }
        else if (Player.clip != null && Player.isPaused && !Quiz.Instance.displayQ)
        {
            pauseScreen.SetActive(false);
            videoScroll.interactable = false;
            Player.Play();
        }
    }
    public void ScrollSetTime()
    {
        Player.time = (double)videoScroll.value;
    }
    public void MainMenu()
    {
        Player.Stop();
        Player.clip = null;
        topicsGO.SetActive(true);
        videoScroll.value = 0;
        slider.SetActive(false);
        exitMenu.SetActive(false);
        exit.SetActive(true);
    }
}