using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAudio : MonoBehaviour
{
    public AudioClip pushButton;
    public AudioClip MusicClip;
    public AudioClip MusicClip2;
    public AudioClip GolbinLaugh;
    public AudioClip Swing;
    public AudioClip goblinDies;
    public AudioClip woodSound;
    public AudioClip grassSound;
    public AudioClip concreteSound;
    public AudioClip levelUp;
    public AudioClip goblinTakesDamage;
    public AudioSource MusicSource;
    public AudioSource MusicSource2;
    public AudioSource buttonSource;
    public AudioSource GoblinSource;
    public AudioSource SwingSource;
    public AudioSource RandomSource;
    public AudioSource GoblinDiesSource;
    public AudioSource LevelUpSource;
    public AudioSource PlayerSwingSource;
    public AudioSource GoblinDamageNoiseSource;
    public AudioSource playerDamageNoiseSource;
    public AudioSource playerDiesSource;

    // Use this for initialization
    void Start()
    {
        buttonSource.clip = pushButton;
        MusicSource.clip = MusicClip;
        MusicSource2.clip = MusicClip2;
        GoblinSource.clip = GolbinLaugh;
        SwingSource.clip = Swing;
    }

    // Update is called once per frame
    public void buttonNoise()
    {
        buttonSource.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MusicSource.Play();
            MusicSource2.Play();
        }
    }

    public void GoblinSwing()
    {
        SwingSource.Play();
    }

    public void GoblinLaugh()
    {
        int randomNumber = Random.Range(1, 100);
        if (randomNumber < 10)
        {
            GoblinSource.Play();
        }
    }

    public void GoblinDies()
    {
        GoblinDiesSource.clip = goblinDies;
        GoblinDiesSource.Play();
    }

    public void PlayWoodNoise()
    {
        RandomSource.clip = woodSound;
        RandomSource.Play();
    }

    public void PlayGrassNoise()
    {
        RandomSource.clip = grassSound;
        RandomSource.Play();
    }

    public void PlayConcreteNoise()
    {
        RandomSource.clip = concreteSound;
        RandomSource.Play();
    }

    public void StopWalkingRelatedNoises()
    {
        RandomSource.Stop();
    }
    public void LevelUpNoise()
    {
        LevelUpSource.clip = levelUp;
        LevelUpSource.Play();
    }

    public void PlayerSwing()
    {
        PlayerSwingSource.clip = Swing;
        PlayerSwingSource.pitch = .5f;
        PlayerSwingSource.Play();
        PlayerSwingSource.pitch = 1f;
    }

    public void GoblinDamageNoise()
    {
        GoblinDamageNoiseSource.clip = goblinTakesDamage;
        GoblinDamageNoiseSource.Play();
    }

    public void PlayerDamageNoise()
    {
        playerDamageNoiseSource.Play();
    }

    public void PlayerDies()
    {
        playerDiesSource.Play();
    }
}
