﻿using System;
using Unity.Netcode;
using UnityEngine;

public class LyreNetworker : NetworkBehaviour
{
    public LyreNetworker Instance { get; private set; }

    private LyreAI ThisLyreAI;

    public override void OnNetworkSpawn()
    {
        //Remove previously existing network object
        if (NetworkManager.Singleton.IsHost || NetworkManager.Singleton.IsServer)
            Instance?.gameObject.GetComponent<NetworkObject>().Despawn();
        
        //set variables
        Instance = this;
        ThisLyreAI = GetComponent<LyreAI>();

        base.OnNetworkSpawn();
    }



    [ServerRpc(RequireOwnership = false)]
    public void BeginChasingPlayerServerRpc(int playerObjectId)
    {
        BeginChasingPlayerClientRpc(playerObjectId);
    }

    [ClientRpc]
    public void BeginChasingPlayerClientRpc(int playerObjectId)
    {
        ThisLyreAI.MakeScreech();
        ThisLyreAI.SwitchToBehaviourStateOnLocalClient(1);
        ThisLyreAI.SetMovingTowardsTargetPlayer(StartOfRound.Instance.allPlayerScripts[playerObjectId]);
    }
}

