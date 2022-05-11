using System.Linq;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class HierarchyMonitor
{
    private static GameObjectNameConfig _nameConfig;
    
    static HierarchyMonitor()
    {
        EditorApplication.hierarchyChanged += OnHierarchyChanged;
    }

    static void OnHierarchyChanged()
    {
        if (_nameConfig == null)
        {
            _nameConfig = GameObjectNameConfig.Load();
        }
        
        var all = Resources.FindObjectsOfTypeAll(typeof(GameObject));

        all.ToList().ForEach(go =>
        {
            foreach (var config in _nameConfig.Configs)
            {
                if (config.CheckHashCode(go.GetHashCode()))
                {
                    if (!config.IsOldName(go.name))
                    {
                        config.newName = go.name;
                    }
                    else
                    {
                        config.newName = string.Empty;
                    }
                }
            }
        });
    }

    [MenuItem("Redirector/Register All GameObjects")]
    static void RegisterGameObjects()
    {
        if (_nameConfig == null)
        {
            _nameConfig = GameObjectNameConfig.Load();
        }
        
        _nameConfig.Configs.Clear();
        _nameConfig.Names.Clear();

        var all = Resources.FindObjectsOfTypeAll(typeof(GameObject));

        all.ToList().ForEach(go =>
        {
            if (!_nameConfig.Names.ContainsKey(go.GetHashCode()))
            {
                _nameConfig.Configs.Add(new NameConfig(go.GetHashCode(), go.name));
                _nameConfig.Names.Add(go.GetHashCode(), new NameConfig(go.GetHashCode(), go.name));
                Debug.Log($"{go.name} - {go.GetHashCode()}");
            }
        });
        
        Debug.LogFormat("{0} GameObjects are registered.", _nameConfig.Configs.Count);
    }
}
