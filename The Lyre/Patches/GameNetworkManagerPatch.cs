using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;

namespace The_Lyre.Patches
{
    [HarmonyPatch(typeof(GameNetworkManager))]
    internal class GameNetworkManagerPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void StartPatch()
        {
            //Register the networker prefab, whatever that means
            GameNetworkManager.Instance.GetComponent<NetworkManager>().AddNetworkPrefab(TheLyre.LyreNetworkerPrefab);
        }
    }
}
