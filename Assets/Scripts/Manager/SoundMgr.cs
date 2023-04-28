using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    NormalStart,
    NormalOuch,
    NormalAfter,
    BadyStart,
    BadyOuch,
    BadyAfter
}


public class SoundMgr : MonoBehaviour
{
    public AudioSource auNormalStart;
    public AudioSource auNormalOuch;
    public AudioSource auNormalAfter;
    public AudioSource auBadyStart;
    public AudioSource auBadyOuch;
    public AudioSource auBadyAfter;


    public Dictionary<SoundType, AudioSource> dicSoundAudio = new Dictionary<SoundType, AudioSource>();
    public Dictionary<SoundType, float> dicSoundTime = new Dictionary<SoundType, float>();


    public void Init()
    {
        dicSoundAudio.Clear();
        dicSoundAudio.Add(SoundType.NormalStart, auNormalStart);
        dicSoundAudio.Add(SoundType.NormalOuch, auNormalStart);
        dicSoundAudio.Add(SoundType.NormalAfter, auNormalStart);
        dicSoundAudio.Add(SoundType.BadyStart, auBadyStart);
        dicSoundAudio.Add(SoundType.BadyOuch, auBadyOuch);
        dicSoundAudio.Add(SoundType.BadyAfter, auBadyAfter);

        dicSoundTime.Clear();

    }

    public void PlaySound(SoundType soundType)
    {
        if (dicSoundAudio.ContainsKey(soundType))
        {
            AudioSource targetSound = dicSoundAudio[soundType];

            float playTime = 0.5f;
            if (dicSoundTime.ContainsKey(soundType))
            {
                playTime = dicSoundTime[soundType];
            }

            targetSound.time = playTime;
            targetSound.Play();
        }
    }

}
