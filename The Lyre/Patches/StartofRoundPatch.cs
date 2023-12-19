using BepInEx;
using DunGen;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Linq;
using Unity.Netcode;
using UnityEngine;


namespace The_Lyre.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    internal class StartofRoundPatch
    {


        [HarmonyPatch("LoadUnlockables")]
        [HarmonyPostfix]

        static void SpawnLyrePatch()
        {
            /*
            //Some setup required so we can utilize pre-made spawning methods
            EnemyType LyreEnemyType = ScriptableObject.CreateInstance<EnemyType>();

            LyreEnemyType.name = "Lyre";
            LyreEnemyType.MaxCount = 10;
            LyreEnemyType.enemyPrefab = TheLyre.LyrePrefab;

            SpawnableEnemyWithRarity Lyre = new SpawnableEnemyWithRarity()
            {
                enemyType = LyreEnemyType,
                rarity = 1
            };



            RoundManager.Instance.currentLevel.Enemies.Add(Lyre);
            Debug.Log($"********Attempting to spawn enemy {RoundManager.Instance.currentLevel.Enemies[RoundManager.Instance.currentLevel.Enemies.Count - 1].enemyType.name}");
            RoundManager.Instance.SpawnEnemyOnServer(new Vector3(0.73f, 0.35f, -13.03f), 90f, RoundManager.Instance.currentLevel.Enemies.Count - 1);




            GameObject[] enemyObjs = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] playerObjs = GameObject.FindGameObjectsWithTag("Player");
            GameObject playerObj = null;

            //grab lyre object and save a reference
            if (TheLyre.lyreGameObject == null)
            {
                foreach (GameObject obj in enemyObjs)
                {
                    if (obj.name == "ScavengerModel")
                    {
                        TheLyre.lyreGameObject = obj.transform.root.gameObject;
                        break;
                    }
                }
            }

            //grab player object
            foreach (GameObject obj in playerObjs)
            {
                if (obj.name == "Player")
                {
                    playerObj = obj.transform.root.gameObject;
                    break;
                }
            }

            // since the player has a set up shader, copy it into lyre.
            if (TheLyre.lyreGameObject != null)
            {
                MeshRenderer[] meshes = TheLyre.lyreGameObject.GetComponentsInChildren<MeshRenderer>();
                Debug.Log($"Mesh count is {meshes.Count()}");
                Debug.Log($"Object material is {playerObj.GetComponentInChildren<MeshRenderer>(true).material.name}");
                foreach (MeshRenderer mesh in meshes)
                {
                    foreach (Material mat in mesh.materials)
                    {
                        Debug.Log($"Setting shader for {mat.name} from {playerObj.GetComponentInChildren<MeshRenderer>(true).material.name}");
                        mat.shader = playerObj.GetComponentInChildren<MeshRenderer>(true).material.shader; 
                        mat.renderQueue = playerObj.GetComponentInChildren<MeshRenderer>(true).material.renderQueue;
                    }
                }
            }

            // Do the same but for skinned mesh
            if (TheLyre.lyreGameObject != null)
            {
                SkinnedMeshRenderer[] meshes = TheLyre.lyreGameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
                Debug.Log($"Mesh count is {meshes.Count()}");
                Debug.Log($"Object material is {playerObj.GetComponentInChildren<SkinnedMeshRenderer>(true).material.name}");
                foreach (SkinnedMeshRenderer mesh in meshes)
                {
                    foreach (Material mat in mesh.materials)
                    {
                        Debug.Log($"Setting shader for {mat.name} from {playerObj.GetComponentInChildren<SkinnedMeshRenderer>(true).material.name}");
                        mat.shader = playerObj.GetComponentInChildren<SkinnedMeshRenderer>(true).material.shader;
                        mat.renderQueue = playerObj.GetComponentInChildren<SkinnedMeshRenderer>(true).material.renderQueue;
                    }
                }
            }
            */
        }
            
    }
}
