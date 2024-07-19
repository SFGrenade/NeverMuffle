using HutongGames.PlayMaker;
using Modding;
using UnityEngine;

namespace NeverMuffle
{
    public class NeverMuffle : Mod
    {
        public override void Initialize()
        {
            On.GameManager.Start += OnGameManagerStart;

            ChangeMuffle(Object.FindObjectOfType<AudioManager>());
        }

        private void OnGameManagerStart(On.GameManager.orig_Start orig, GameManager self)
        {
            orig(self);

            ChangeMuffle(Object.FindObjectOfType<AudioManager>());
        }

        private void ChangeMuffle(AudioManager self)
        {
            var hdeFsm = self.gameObject.LocateMyFSM("Hero Damaged Effects");
            var tlState = hdeFsm.Fsm.GetState("To Lowpass");
            tlState.Actions = new FsmStateAction[0];
        }
    }
}
