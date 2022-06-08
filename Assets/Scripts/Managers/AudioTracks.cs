using UnityEngine;
using System;
using System.Linq;

[CreateAssetMenu(menuName = "ScriptableObjects/AudioStore")]

public class AudioTracks : ScriptableObject
{
    [SerializeField, ArrayElementTitle("audioType")] private AudioField[] audioField;

    public AudioClip GetAudioClipByType(AudioType audioType)
    {
        return audioField.First(x => x.audioType == audioType).audioClip;
    }
}

public enum AudioType
{
    ClickButton,
    MeowMenu,
    DoorOpen,
    DoorClose,
    ChestOpen,
    ChestClose,
    KeyLock,
    MeowHouseCat,
    LaptopOpen,
    LaptopClose,
    ShelfOpen,
    ShelfClose,
    KitchenDoorOpen,
    KitchenDoorClose
}

[Serializable]
public class AudioField
{
    public AudioType audioType;
    public AudioClip audioClip;
}