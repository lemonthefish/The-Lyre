using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using The_Lyre.Properties;
using The_Lyre.Patches;
using UnityEngine;
using UnityEngine.Rendering;


namespace The_Lyre
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class TheLyre : BaseUnityPlugin
    {
        //mod version info
        private const string modGUID = "Lemons.TheLyre";
        private const string modName = "The Lyre";
        private const string modVersion = "1.0.0";

        //Instantiate harmony
        private readonly Harmony harmony = new Harmony(modGUID);

        //Instantiate mod
        private static TheLyre Instance;

        //Lyre prefabs
        public static GameObject LyrePrefab;
        public static GameObject LyreNetworkerPrefab;

        public static EnemyType LyreEnemyType;
        public static SpawnableEnemyWithRarity Lyre;
        
        //logging
        internal ManualLogSource mls;

        //debug mode
        bool debugMode = true;

        private void Awake()
        {
            AssetBundle lyreAssetBundle = AssetBundle.LoadFromMemory(Properties.Resources.customplayerbundle);
            LyrePrefab = lyreAssetBundle.LoadAsset<GameObject>("Assets/_CustomPlayer/CustomPlayerAssets/Lyre.prefab");
            LyrePrefab.AddComponent<LyreAi>();
            //LyreNetworkerPrefab = lyreAssetBundle.LoadAsset<GameObject>("Assets/_CustomPlayer/CustomPlayerAssets/LyreNetworkPrefab.prefab");

            //Some setup required so we can utilize pre-made spawning methods
            LyreEnemyType = ScriptableObject.CreateInstance<EnemyType>();
            LyreEnemyType.name = "Lyre";
            LyreEnemyType.MaxCount = 10;
            LyreEnemyType.enemyPrefab = TheLyre.LyrePrefab;

            Lyre = new SpawnableEnemyWithRarity()
            {
                enemyType = LyreEnemyType,
                rarity = 1
            };

            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("The Lyre mod is awake \r");
            if (LyrePrefab == null)
            {
                mls.LogInfo("Prefab is null, something went wrong \r");
            }
            else
            {
                mls.LogInfo("The Lyre Asset Bundle succesfully loaded \r");
            }

            if (LyreNetworkerPrefab == null)
            {
                mls.LogInfo("Network Prefab is null, something went wrong \r");
            }
            else
            {
                mls.LogInfo("The Lyre Networker succesfully loaded \r");
            }
            if (debugMode)
            {
                harmony.PatchAll(typeof(PlayerControllerPatch));
            }
            harmony.PatchAll(typeof(TheLyre));
            harmony.PatchAll(typeof(AudiosourcePatch));
            //harmony.PatchAll(typeof(DoorsOpenPatch));
            //harmony.PatchAll(typeof(StartofRoundPatch));
            //harmony.PatchAll(typeof(RoundManagerPatch));
        }

        public class LyreAi : EnemyAI
        {
            public LyreAi()
            {

            }
        }

        //Method that handles spawning the custom enemy.
        public static void SpawnLyre(Vector3 spawnPosition, float yRot)
        {
            
            //TODO - This should be removed after writing procedural spawning logic, we shouldn't have to add him here
            if (!RoundManager.Instance.currentLevel.Enemies.Contains(Lyre))
            {
                RoundManager.Instance.currentLevel.Enemies.Add(Lyre);
            }
            Debug.Log($"********Attempting to spawn enemy {RoundManager.Instance.currentLevel.Enemies[RoundManager.Instance.currentLevel.Enemies.Count - 1].enemyType.name}");
            RoundManager.Instance.SpawnEnemyOnServer(spawnPosition, yRot, RoundManager.Instance.currentLevel.Enemies.IndexOf(Lyre));

            //Get player objects and most recent enemy
            GameObject[] playerObjs = GameObject.FindGameObjectsWithTag("Player");
            GameObject mostRecentEnemy = RoundManager.Instance.SpawnedEnemies.Last().transform.root.gameObject;

            //Make sure most recent enemy is lyre
            if (mostRecentEnemy.name.Substring(0, 4) != "Lyre")
            {
                Debug.Log("Error!!! Lyre is not the most recent spawned enemy. Cannot assign shaders.");
                return;
            }

            Debug.Log("Found most recent Lyre");

            GameObject playerObj = null;
            //grab player object
            foreach (GameObject obj in playerObjs)
            {
                if (obj.name == "Player")
                {
                    playerObj = obj.transform.root.gameObject;
                    break;
                }
            }

            Debug.Log("Attempting to assign shaders");
            // since the player has a set up shader, copy it into lyre.
            if (mostRecentEnemy != null)
            {
                MeshRenderer[] meshes = mostRecentEnemy.GetComponentsInChildren<MeshRenderer>();
                Debug.Log($"Mesh count is {meshes.Count()}");
                Debug.Log($"Object material is {playerObj.GetComponentInChildren<MeshRenderer>(true).material.name}");
                foreach (MeshRenderer mesh in meshes)
                {
                    foreach (Material mat in mesh.materials)
                    {
                        Debug.Log($"Setting shader for {mostRecentEnemy.transform.root.gameObject.name} from {playerObj.GetComponentInChildren<MeshRenderer>(true).material.name}");
                        mat.shader = playerObj.GetComponentInChildren<MeshRenderer>(true).material.shader;
                        mat.renderQueue = playerObj.GetComponentInChildren<MeshRenderer>(true).material.renderQueue;
                    }
                }
            }

            // Do the same but for skinned mesh
            if (mostRecentEnemy != null)
            {
                SkinnedMeshRenderer[] meshes = mostRecentEnemy.GetComponentsInChildren<SkinnedMeshRenderer>();
                Debug.Log($"Mesh count is {meshes.Count()}");
                Debug.Log($"Object material is {playerObj.GetComponentInChildren<SkinnedMeshRenderer>(true).material.name}");
                foreach (SkinnedMeshRenderer mesh in meshes)
                {
                    foreach (Material mat in mesh.materials)
                    {
                        Debug.Log($"Setting shader for {mostRecentEnemy.transform.root.gameObject.name} from {playerObj.GetComponentInChildren<SkinnedMeshRenderer>(true).material.name}");
                        mat.shader = playerObj.GetComponentInChildren<SkinnedMeshRenderer>(true).material.shader;
                        mat.renderQueue = playerObj.GetComponentInChildren<SkinnedMeshRenderer>(true).material.renderQueue;
                    }
                }
            }
        }
    }
}
