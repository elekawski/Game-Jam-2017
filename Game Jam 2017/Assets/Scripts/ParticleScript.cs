using UnityEngine;
using System.Collections;
using UnityEditor; // Need this to access SerializedObject

public class ParticleScript : MonoBehaviour
{
    SerializedObject particle; // This will be our modifiable particle system

    void Start()
    {
        /* Initialize and assign particle as a SerializedObject that takes properties from the ParticleSystem attached to this game object. */
        particle = new SerializedObject(GetComponent<ParticleSystem>());
        particle.FindProperty("Speed").floatValue += 10;
        particle.ApplyModifiedProperties();
    }

    void Update()
    {

    }

}