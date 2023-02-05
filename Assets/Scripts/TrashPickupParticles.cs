using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPickupParticles : MonoBehaviour
{
    public GameManager gm;
    public float pointValue;

    ParticleSystem ps;


    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void OnParticleTrigger()
    {
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        // Adds points for every trash collected
        for (int i = 0; i < numEnter; i++)
        {
            gm.Points += pointValue;
            AudioManager.instance.PlayPickupSFX();
        }
    }
}
