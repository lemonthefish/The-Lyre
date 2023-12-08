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
    internal class StartofRoundPatch
    {

        [HarmonyPatch("LoadUnlockables")]
        [HarmonyPostfix]
        
        static void SpawnGooPatch()
        {

            for (int i = 0; i < RoundManager.Instance.currentLevel.Enemies.Count; i++)
            {
                if (RoundManager.Instance.currentLevel.Enemies[i].enemyType.enemyName == "Crawler")
                {
                    RoundManager.Instance.SpawnEnemyOnServer(new Vector3(0.73f, 0.35f, -13.03f), 90f, i);
                }
            }
        }
    }         
}
