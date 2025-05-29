using UnityEngine;

[CreateAssetMenu(fileName = "DataCollection", menuName = "ScriptableObjects/DataCollection")]
public class DataCollection : ScriptableObject
{
    public static string path = "Data/DataCollection";

    public PlayerData playerData;
    public NetworkData networkData;
    public GameData gameData;
}
