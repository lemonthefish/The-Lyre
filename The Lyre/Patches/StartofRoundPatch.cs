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
            List<SpawnableEnemyWithRarity> enemylist = RoundManager.Instance.currentLevel.Enemies;
            for (int i = 0; i < RoundManager.Instance.currentLevel.Enemies.Count; i++)
            {
                Debug.Log($"Enemy type is: {RoundManager.Instance.currentLevel.Enemies[i].enemyType.enemyName}");
                if (RoundManager.Instance.currentLevel.Enemies[i].enemyType.enemyName == "Hoarding bug")
                {
                    Debug.Log($"Enemy type is: {RoundManager.Instance.currentLevel.Enemies[i].enemyType.enemyName}, attempting to spawn at -2.45f, 2.75f, -8.41f");
                    RoundManager.Instance.SpawnEnemyOnServer(new Vector3(0.73f, 0.35f, -13.03f), 90f, i);
                }
            }
        }
    }         
}
