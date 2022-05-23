using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAssetManager : Singleton<SoundAssetManager>
{
    [SerializeField] SoundAsset[] soundAssets;
    public SoundAsset FindSoundAsset(string assetName)
    {
        foreach(SoundAsset asset in soundAssets)
        {
            if (asset.GetName().Equals(assetName))
            {
                return asset;
            }
        }
        Debug.LogWarning("Asset with name: " + assetName + " not found.");
        return null;
    }
}
