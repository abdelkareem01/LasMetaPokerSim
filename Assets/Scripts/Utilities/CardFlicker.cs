using Fusion;
using UnityEngine;

public class CardFlicker : NetworkBehaviour
{
    [SerializeField]
    private AudioClip flicker;

    void Awake()
    {
        Main.instance.audio.clip = flicker;
        Main.instance.audio.Play();
    }
}
