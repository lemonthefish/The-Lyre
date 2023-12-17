using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using The_Lyre.Patches;
using UnityEngine;


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

        //logging
        internal ManualLogSource mls;

        private void Awake()
        {
            AssetBundle lyreAssetBundle = AssetBundle.LoadFromMemory(The_Lyre.Properties.Resources.customplayerbundle);
            LyrePrefab = lyreAssetBundle.LoadAsset<GameObject>("Assets/TheLyre.prefab");
            LyreNetworkerPrefab = lyreAssetBundle.LoadAsset<GameObject>("Assets/TheLyreNetworker.prefab");

            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("The test mod has awoken \r");

            harmony.PatchAll(typeof(TestClass));
            harmony.PatchAll(typeof(AudiosourcePatch));
            //harmony.PatchAll(typeof(DoorsOpenPatch));
            //harmony.PatchAll(typeof(StartofRoundPatch));
        }
    }
}
