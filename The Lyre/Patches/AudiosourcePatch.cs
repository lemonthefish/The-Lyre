using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Unity.Netcode;
using System.Collections;
using Dissonance.Integrations.Unity_NFGO;
using System.Runtime.CompilerServices;

namespace The_Lyre.Patches
{
    [HarmonyPatch(typeof(NfgoPlayer))]
    internal class AudiosourcePatch
    {

        [HarmonyPatch("Position")]
        [HarmonyPostfix]
        
        public static void Postfix(ref Vector3 __result)
        {
            Debug.Log($"Current audio pos = {__result}; New audio pos = {__result + new Vector3(10f, 0f, 0f)}");
            __result = new Vector3(__result.x + 10f, __result.y, __result.z);
        }
    }         
}
