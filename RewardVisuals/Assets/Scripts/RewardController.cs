using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardController : MonoBehaviour
{
    public List<AudioClip> audioClips = new List<AudioClip>();
    private ParticleSystem confettiParticleSystem = null;

    // Start is called before the first frame update
    void Start()
    {
        GameObject confettiGameObject = GameObject.Find("ConfettiParticleSystem");
        if (confettiGameObject != null)
        {
            confettiParticleSystem = confettiGameObject.GetComponent<ParticleSystem>();
        }
    }

    void PlaySound(int soundNumber)
    {
        GetComponent<AudioSource>().PlayOneShot(audioClips[soundNumber]);
    }

    void StartConfettiParticleSystem(int notUsed)
    {
        confettiParticleSystem.Play(true);
    }
    void StopConfettiParticleSystem(int notUsed)
    {
        confettiParticleSystem.Stop(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animator>().Play("RewardStartup");
        }
    }
}
