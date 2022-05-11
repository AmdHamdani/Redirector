using UnityEngine;

public static class RedirectorExtension
{
    public static GameObject FindByName(this GameObject gameObject, string name) => Redirector.FindByName(name);
}
