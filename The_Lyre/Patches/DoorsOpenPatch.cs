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

        }
    }         
}
