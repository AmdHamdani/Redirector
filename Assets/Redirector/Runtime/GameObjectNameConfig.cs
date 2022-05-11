using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameObjectNameConfig", menuName = "Redirector/GameObject Name Config")]
public class GameObjectNameConfig : ScriptableObject
{
    public List<NameConfig> Configs;
    public Dictionary<int, NameConfig> Names { get; set; } = new Dictionary<int, NameConfig>();

    public static GameObjectNameConfig Load(string path = "GameObjectNameConfig") =>
        Resources.Load<GameObjectNameConfig>(path);

    private void OnEnable()
    {
        Names.Clear();
        Configs.ForEach(config =>
        {
            if (!Names.ContainsKey(config.hashCode))
            {
                Names.Add(config.hashCode, config);
            }
        });
    }
}

[System.Serializable]
public class NameConfig
{
    public int hashCode;
    public string oldName;
    public string newName;

    public NameConfig(int hash, string old)
    {
        hashCode = hash;
        oldName = old;
        newName = string.Empty;
    }

    public  bool CheckHashCode(int hash) => hashCode == hash;
    public bool IsOldName(string name) => oldName == name;
    public bool IsNewName(string name) => newName == name;
}
