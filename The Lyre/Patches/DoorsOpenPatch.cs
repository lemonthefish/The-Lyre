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

namespace The_Lyre.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    internal class DoorsOpenPatch
    {

        [HarmonyPatch("OpenShipDoors")]
        [HarmonyPostfix]
        
        static void ShipDoorsPatch(ref PlayerControllerB[] ___allPlayerScripts)
        {
            AudioSource temp = ___allPlayerScripts[0].currentVoiceChatAudioSource;
            ___allPlayerScripts[0].currentVoiceChatAudioSource = ___allPlayerScripts[1].currentVoiceChatAudioSource;
            ___allPlayerScripts[1].currentVoiceChatAudioSource = temp;

            PlayerVoiceIngameSettings temp2 = ___allPlayerScripts[0].currentVoiceChatIngameSettings;
            ___allPlayerScripts[0].currentVoiceChatIngameSettings = ___allPlayerScripts[1].currentVoiceChatIngameSettings;
            ___allPlayerScripts[1].currentVoiceChatIngameSettings = temp2;
        }
    }         
}
