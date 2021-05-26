using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public enum ControlTypeEnum
    {
        Simple,
        Inertia
    }
    public ControlTypeEnum controlType = ControlTypeEnum.Simple;
    public bool enableBoostShake = false;
    
    public float shipSpeed;

    public SpriteRenderer boostEffect;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SimpleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Mathf.Abs(horizontal) > 0.01f || Mathf.Abs(vertical) > 0.01f)
        {
            if (Input.GetButton("Jump"))
            {
                shipSpeed = 6.0f;
            }
            else
            {
                shipSpeed = 2.0f;
            }

            Vector3 direction = new Vector3(horizontal, vertical, 0f);
            direction.Normalize();
            transform.Translate(direction * shipSpeed * Time.deltaTime, Space.World);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90.0f);

            boostEffect.color = Color.white;
        }
        else
        {
            boostEffect.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
    }

    void InertiaMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical, 0f);
        if (direction.magnitude > 0.1f)
        {
            boostEffect.color = Color.Lerp(boostEffect.color, new Color(1.0f, 1.0f, 1.0f, 1.0f), 0.01f);
        }
        else
        {
            boostEffect.color = Color.Lerp(boostEffect.color, new Color(1.0f, 1.0f, 1.0f, 0.0f), 0.01f);
        }

        direction.Normalize();

        velocity = velocity * 0.999f + direction * 10.0f * Time.deltaTime;
        if (Input.GetButton("Jump"))
        {
            velocity *= 2.0f;
            shipSpeed = 6.0f;
        }
        else
        {
            shipSpeed = 2.0f;
        }

        if (velocity.magnitude > shipSpeed)
        {
            velocity = velocity.normalized * shipSpeed;
        }            
        transform.Translate(velocity * Time.deltaTime, Space.World);

        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90.0f);
    }

    void BoostShake()
    {
        if (Input.GetButton("Jump"))
        {
            Transform shipSprite = transform.GetChild(0);
            float t = Time.time * 10.0f;
            float px = Mathf.PerlinNoise(t, 0.0f) - 0.5f;
            float py = Mathf.PerlinNoise(0.0f, t) - 0.5f;
            shipSprite.localPosition = new Vector3(px, py, 0.0f) * 0.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (controlType == ControlTypeEnum.Simple)
        {
            SimpleMovement();
        }
        else if (controlType == ControlTypeEnum.Inertia)
        {
            InertiaMovement();
        }

        // Boost
        if (enableBoostShake)
        {
            BoostShake();
        }
    }
}
