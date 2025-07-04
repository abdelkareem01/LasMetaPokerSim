namespace Scripts.Utilities
{
    using Fusion;
    using Scripts.Core;
    using UnityEngine;

    public class CardFlicker : NetworkBehaviour
    {
        [SerializeField]
        private AudioClip flicker;

        public override void Spawned()
        {
            if (!HasStateAuthority && !HasInputAuthority)
                return;

            var src = Main.instance.mainAudioSrc;
            src.PlayOneShot(flicker);
        }
    }
}
