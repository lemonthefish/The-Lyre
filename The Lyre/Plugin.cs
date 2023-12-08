using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Lyre.Patches;

namespace The_Lyre
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class TestClass : BaseUnityPlugin
    {
        private const string modGUID = "Lemons.TheLyre";
        private const string modName = "The Lyre";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static TestClass Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("The test mod has awoken \r");

            harmony.PatchAll(typeof(TestClass));
            harmony.PatchAll(typeof(StartofRoundPatch));
            harmony.PatchAll(typeof(DoorsOpenPatch));
            //harmony.PatchAll(typeof(StartofRoundPatch));
        }
    }
}
