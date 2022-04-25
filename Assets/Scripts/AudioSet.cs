
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioSourceInfo
{
    private float playTime = 0;
    public AudioSource AudioSource { get; private set; }
    public AudioState AudioState = AudioState.Idle;
    public Action AfterPlaying { get; set; }
    public int ID = 0;
    public AudioSourceInfo(GameObject go)
    {
        this.AudioSource = go.AddComponent<AudioSource>();
    }
    public AudioClip Clip
    {
        get
        {
            return this.AudioSource.clip;
        }
        set
        {
            this.AudioSource.clip = value;
            playTime = 0;
        }
    }
    public bool Loop
    {
        get
        {
            return this.AudioSource.loop;
        }
        set
        {
            this.AudioSource.loop = value;
        }
    }
    public float Volume
    {
        get
        {
            return this.AudioSource.volume;
        }
        set
        {
            this.AudioSource.volume = value;
        }
    }
    public void Play()
    {
        if (null == this.AudioSource)
        {
            return;
        }
        this.AudioState = AudioState.IsPlaying;
        this.AudioSource.Play();
    }
    public void Pause()
    {
        if (null == this.AudioSource)
        {
            return;
        }
        if (this.AudioSource.isPlaying)
        {
            this.AudioState = AudioState.Pause;
            this.AudioSource.Pause();
        }
    }
    public void Stop()
    {
        if (null == this.AudioSource)
        {
            return;
        }
        this.AudioState = AudioState.Stop;
        this.AudioSource.Stop();
        if (AfterPlaying != null)
        {
            this.AfterPlaying();
        }
    }
    private void Update()
    {
        if (this.AudioSource != null && this.AudioSource.clip != null && this.AudioState == AudioState.IsPlaying)
        {
            playTime += Time.fixedDeltaTime;
            if (playTime >= this.Clip.length)
            {
                playTime = 0;
                this.Stop();
            }
        }
    }
}
public enum AudioState
{
    Idle,
    IsPlaying,
    Pause,
    Stop,
}
