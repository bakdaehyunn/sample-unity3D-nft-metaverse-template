using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class NetworkPlayerInput : NetworkBehaviour
{
    private PlayerInput playerInput;
    [SerializeField]private InputActionAsset inputActionAsset;
    // Start is called before the first frame update
    private void Awake()
    {
        playerInput = gameObject.GetComponent<PlayerInput>();
    }

    public override void OnNetworkSpawn(){
        base.OnNetworkSpawn();
        if(!IsOwner){
            return;
        }
        if (playerInput.actions != inputActionAsset){
            playerInput.actions = inputActionAsset;
        }
    }
}
