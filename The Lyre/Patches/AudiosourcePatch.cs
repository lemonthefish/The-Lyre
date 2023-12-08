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
    [HarmonyPatch(typeof(RoundManager))]
    internal class AudiosourcePatch
    {

        [HarmonyPatch(nameof(RoundManager.SpawnEnemyGameObject))]
        [HarmonyPostfix]
        
        public static void Postfix(ref List<EnemyAI> ___SpawnedEnemies, ref StartOfRound ___playersManager)
        {
            ___SpawnedEnemies.Last().creatureVoice = ___playersManager.allPlayerScripts[0].currentVoiceChatAudioSource;
        }
    }         
}
