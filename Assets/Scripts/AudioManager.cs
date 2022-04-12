using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonBase<AudioManager>
{
    [SerializeField] private float timeStartMusicBg;
    [SerializeField] private AudioSource blast, iAmRobot, moveTank, 
        shot, spawn, energy, buttonBuy,blastCamp,startMusicBg;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(timeStartMusicBg);
        startMusicBg.Play();
    }
    /// <summary>
    /// blast, iAmRobot, moveTank, shot, spawn, energy, buttonBuy,blastCamp
    /// </summary>
    /// <param name="nameAudio"></param>
    public void AudioPlay(string nameAudio)
    {
        switch(nameAudio)
        {
            case "blast":
                blast.Play();
                break;
            case "iAmRobot":
                iAmRobot.Play();
                break;
            case "moveTank":
                moveTank.Play();
                break;
            case "shot":
                shot.Play();
                break;
            case "spawn":
                spawn.Play();
                break;
            case "energy":
                energy.Play();
                break;
            case "buttonBuy":
                buttonBuy.Play();
                break;
            case "blastCamp":
                blastCamp.Play();
                break;
        }
    }
    /// <summary>
    /// blast, iAmRobot, moveTank, shot, spawn, energy, buttonBuy
    /// </summary>
    /// <param name="nameAudio"></param>
    public void AudioStop(string nameAudio)
    {
        switch (nameAudio)
        {
            case "blast":
                blast.Stop();
                break;
            case "iAmRobot":
                iAmRobot.Stop();
                break;
            case "moveTank":
                moveTank.Stop();
                break;
            case "shot":
                shot.Stop();
                break;
            case "spawn":
                spawn.Stop();
                break;
            case "energy":
                energy.Stop();
                break;
            case "buttonBuy":
                buttonBuy.Stop();
                break;
        }
    }
}
