using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Netcode;

public class NetworkStore : NetworkBehaviour
{
    public NetworkVariable<NetString> username = new NetworkVariable<NetString>(new NetString()
    {
        st = ""
    });
}

public struct NetString : INetworkSerializable, System.IEquatable<NetString>{
    public string st;
    
    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter{
        if (serializer.IsReader){
            var reader = serializer.GetFastBufferReader();
            reader.ReadValueSafe(out st);
        }
        else{
            var writer =serializer.GetFastBufferWriter();
            writer.WriteValueSafe(st);
        }
    }
    
    public bool Equals(NetString other){
        if(String.Equals(other.st, st, StringComparison.CurrentCultureIgnoreCase))
            return true;
        return false;
    }
}