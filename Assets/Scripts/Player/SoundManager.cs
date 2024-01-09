using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public enum SoundType{
    Menu,
    GameMusic,
    GameOver,
    MissionStart,
    MissionComplete,

    Ok,
    Shoot,
    Melee,
    Explosion,
    BossLaser,
    Rescue,   
    Break,
    Heal,

    EnemyDead,
    BodyHit,
    EnemySpawn,
}

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource SFXSource;
    public AudioMixer mixer;
    //public volume saveVolume;
    
    [Header("Music")]
    public AudioClip audioMenu;
    public AudioClip audioGameMusic;
    public AudioClip audioGameOver;

    [Header("SFX")]
    public AudioClip SFX_MissionStart;
    public AudioClip SFX_MissionComplete;
    public AudioClip SFX_OK;
    public AudioClip SFX_Shoot;
    public AudioClip SFX_Melee;
    public AudioClip SFX_Explosion;
    public AudioClip SFX_BossLaser;
    public AudioClip SFX_Rescue;
    public AudioClip SFX_Break;

    public AudioClip SFX_Heal;

    public AudioClip SFX_EnemyDead;
    public AudioClip BodyHit_FX;
    public AudioClip EnemySpawn_FX;
    private Dictionary<SoundType, AudioClip> dictAudio;

    private void Awake() {
        dictAudio = new Dictionary<SoundType, AudioClip>
        {
            {SoundType.Menu, audioMenu},
            {SoundType.GameMusic, audioGameMusic},
            {SoundType.GameOver, audioGameOver},
            {SoundType.MissionStart, SFX_MissionStart},
            {SoundType.MissionComplete, SFX_MissionComplete},

            {SoundType.Ok, SFX_OK},
            {SoundType.Shoot, SFX_Shoot},
            {SoundType.Melee, SFX_Melee},
            {SoundType.Explosion, SFX_Explosion},
            {SoundType.BossLaser, SFX_BossLaser},
            {SoundType.Rescue, SFX_Rescue},
            {SoundType.Break, SFX_Break},
            {SoundType.Heal, SFX_Heal},
            {SoundType.EnemyDead, SFX_EnemyDead},
            {SoundType.BodyHit, BodyHit_FX},
            {SoundType.EnemySpawn, EnemySpawn_FX},
        };
    }

    private void Start() {
        //musicSource.clip = audioGameMusic;
        //musicSource.Play();
    }

    public void PlayMusic(SoundType sound, bool isLoop, float delayTime = 0)
    {
        musicSource.loop = isLoop;
        musicSource.clip = dictAudio[sound];
        musicSource.PlayDelayed(delayTime);
    }

    public void PlaySFX(SoundType sound)
    {
        SFXSource.PlayOneShot(dictAudio[sound]);
    }

    // public void PlaySound(AudioClip clip)
    // {
    //     SFXSource.PlayOneShot(clip);
    // }
}
