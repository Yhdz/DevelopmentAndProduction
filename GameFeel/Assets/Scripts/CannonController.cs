using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject barrel = null;
    public CannonBall cannonBallPrefab = null;
    public ParticleSystem shootParticle = null;
    public float ballForce = 1000.0f;

    private AudioSource audioSource = null;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CannonBall ball = Instantiate<CannonBall>(cannonBallPrefab, barrel.transform.position, barrel.transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(-Vector3.forward * ballForce);
            shootParticle.Play();
            Destroy(ball.gameObject, 2.0f);
            if (audioSource.clip != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
            GetComponent<Animator>().Play("CannonAnimation");
        }
    }
}
