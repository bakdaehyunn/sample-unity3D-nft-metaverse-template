using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class NetworkManagerGUI : MonoBehaviour
{
    public Button HostBtn;

    public Button ClientBtn;
    
    private void Start()
    {
        HostBtn.onClick.AddListener(StartHost);
        ClientBtn.onClick.AddListener(StartClient);
    }

    public void StartHost(){
        NetworkManager.Singleton.StartHost();
    }

    public void StartClient(){
        NetworkManager.Singleton.StartClient();
    }
}
