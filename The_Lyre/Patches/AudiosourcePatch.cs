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
using System.Collections;
using Dissonance.Integrations.Unity_NFGO;
using System.Runtime.CompilerServices;

namespace The_Lyre.Patches
{
    [HarmonyPatch(typeof(NfgoPlayer))]
    
    class AudiosourcePatch
    {

        [HarmonyPatch("Position", MethodType.Getter)]
        static void Postfix(ref Vector3 __result)
        {
            __result.Set(0f,0f,0f);
        }
    }         
}
