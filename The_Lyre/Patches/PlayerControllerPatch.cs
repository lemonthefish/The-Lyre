using System;
using System.Collections.Generic;
using HarmonyLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNetcodeStuff;
using UnityEngine;

namespace The_Lyre.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerPatch
    {
        [HarmonyPatch(nameof(PlayerControllerB.Crouch))]
        [HarmonyPostfix]
        static void PostFix(ref PlayerControllerB __instance)
        {
            //interesting note, isCrouching is only true when not crouching...
            if (__instance.isCrouching)
            {
                Transform playerTransform = __instance.transform;
                Vector3 forwardPosition = playerTransform.position + playerTransform.forward * 2f;

                Debug.Log($"Spawning Lyre at position: {forwardPosition}");
                TheLyre.SpawnLyre(forwardPosition, 0f);
            }
            
        }
    }


}



