using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redirector
{
    private static GameObjectNameConfig _nameConfig;
    
    public static GameObject FindByName(string name)
    {
        if (_nameConfig == null)
        {
            _nameConfig = GameObjectNameConfig.Load();
        }
        
        foreach (var config in _nameConfig.Names)
        {
            if (config.Value.IsOldName(name))
            {
                if (string.IsNullOrEmpty(config.Value.newName))
                {
                    return GameObject.Find(name);
                }
                return GameObject.Find(config.Value.newName);
            }
        }

        return null;
    }
}
