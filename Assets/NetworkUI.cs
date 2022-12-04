using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class NetworkUI : NetworkBehaviour
{
    [SerializeField] private TMP_Text userTypeText; 
    [SerializeField] private List<GameObject> disableOnRemote = new List<GameObject>();
    [SerializeField] private InputField inputField;
    [SerializeField] private Button submitButton;
    [SerializeField] private GameObject panel;
    [SerializeField] private Text text;


    private NetworkStore netStore{
        get{
            if (internalNetStore == null)
                internalNetStore = GameObject.Find("NetworkStore").GetComponent<NetworkStore>();
            return internalNetStore;
        }
    }

    private NetworkStore internalNetStore;

    public override void OnNetworkSpawn(){
        base.OnNetworkSpawn();

        if (IsServer){
            submitButton.onClick.AddListener(OnSubmit);
        }
        else{
            
            netStore.username.OnValueChanged += (oldVal, newVal) =>{
                panel.gameObject.SetActive(true);
                text.gameObject.SetActive(false);
                inputField.gameObject.SetActive(false);
                inputField.text = newVal.st;
               
            };
        }
        userTypeText.text = IsServer ? "Server" : "Client";
        
        if(IsOwner == false)
            foreach(GameObject o in disableOnRemote){
                o.SetActive(false);
            }
    }
    public void OnSubmit(){
        
        netStore.username.Value = new NetString(){ st = inputField.text};
    }

    
}
