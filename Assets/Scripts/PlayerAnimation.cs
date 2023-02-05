using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimation : MonoBehaviour
{
    public float multiplier;
    public GameObject[] parts;
    PlayerController player;

    public float particleSpeeds;
    public ParticleSystem[] wakeParticles;
    public GameObject upgradeParticles;

    public float[] scoreThresholds;
    int currentThreshold = 0;

    Animator anim;
    public GameManager gm;
    public Camera cam;
    public Slider pointsSlider;

    void Start()
    {
        // Gets the animator and player controller components from the gameobjects
        player = GetComponent<PlayerController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Moves the sprites of the boat to an offset to make it look like the boats leaning
        for(int i = 0; i < parts.Length; i++)
        {
            parts[i].transform.localPosition = new Vector3(player.angVelocity * (i+1) * multiplier, 0, transform.position.z);
        }

        // Sets the speed of the wake particles to a multiplier of the player speed
        foreach(ParticleSystem particles in wakeParticles)
        {
            var main = particles.main;

            main.startSpeed = particleSpeeds * (player.Velocity - 0.15f);

            if(player.Velocity-0.15 <= 0.15f)
            {
                particles.gameObject.SetActive(false);
            }
            else
            {
                particles.gameObject.SetActive(true);
            }
        }

        if(currentThreshold <= scoreThresholds.Length-1)
        {
            // Calls an upgrade function when the players point value equals the next upgrade point threshold
            if (gm.Points >= scoreThresholds[currentThreshold])
            {
                Upgrade();
            }

            // Sets the points slider to the fraction that is the the amount of points that the player has past last threshold divided by amount of points needed;
            float value;
            if(currentThreshold >= 1 && currentThreshold < scoreThresholds.Length)
            {
                value = (gm.Points - scoreThresholds[currentThreshold-1]) / (scoreThresholds[currentThreshold] - scoreThresholds[currentThreshold - 1]);
            }
            else if(currentThreshold < 1)
            {
                value = gm.Points / scoreThresholds[currentThreshold];
            }
            else
            {
                value = 1;
            }
            pointsSlider.value = value;
        }
    }

    void Upgrade()
    {
        currentThreshold++;
        anim.SetTrigger("Upgrade");
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.size += new Vector2(0.6f,0);
        cam.orthographicSize += 1;

        Instantiate(upgradeParticles, player.transform.position + transform.up.normalized * 3, transform.rotation);
    }
}
