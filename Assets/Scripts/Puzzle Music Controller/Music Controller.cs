using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField]
    private PuzzleGameSaver PuzzleGameSaver;
    private AudioSource bgMusicClip;
    private float musicVolume;
    private void Awake()
    {
        GetAudioSource();
    }
    private void Start()
    {
        musicVolume = PuzzleGameSaver.musicVolume;
    }
    void GetAudioSource()
    {
        bgMusicClip = GetComponent<AudioSource>();
    }
    public void SetMusicVolume(float volume)
    {
        PlayOrTurnOffMusic(volume);

    }
    void PlayOrTurnOffMusic(float volume)
    {
        musicVolume = volume;
        bgMusicClip.volume = musicVolume;
        if(bgMusicClip.volume > 0)
        {
            if(!bgMusicClip.isPlaying) bgMusicClip.Play();
            PuzzleGameSaver.musicVolume = musicVolume;
            PuzzleGameSaver.SaveGameData();
        }
        else if(bgMusicClip.volume == 0)
        {
            if (bgMusicClip.isPlaying) bgMusicClip.Stop();
            PuzzleGameSaver.musicVolume = musicVolume;
            PuzzleGameSaver.SaveGameData();
        }
    }
}
