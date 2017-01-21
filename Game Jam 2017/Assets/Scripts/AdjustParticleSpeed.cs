using UnityEngine;
using System.Collections;
public class AdjustParticleSpeed : MonoBehaviour
{
    public float speed = 10;
    ParticleSystem ps;
    void Start()
    {
        ps = GetComponent<ParticleSystem>() as ParticleSystem;
    }
    void Update()
    {
        ps.playbackSpeed = speed;
    }

    void modifySpeed(float speed)
    {
        ps.playbackSpeed = speed;
    }
}