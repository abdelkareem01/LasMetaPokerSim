using Fusion;
using UnityEngine;

public class CardFlicker : NetworkBehaviour
{
    [SerializeField]
    private AudioClip flicker;

    public override void Spawned()
    {
        Main.instance.audio.PlayOneShot(flicker);
    }
}
