using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volum;
    [Range(0.1f, 3)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;


}
