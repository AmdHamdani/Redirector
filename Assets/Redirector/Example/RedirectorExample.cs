using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedirectorExample : MonoBehaviour
{
    [SerializeField] private string renamed;
    [SerializeField] private string notRenamed;
    [SerializeField] private GameObject go;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Reference => {go.name} - {go.GetHashCode()}");

        var renamedGo = gameObject.FindByName(renamed);
        Debug.Log($"Redirector => {renamedGo.name} - {renamedGo.GetHashCode()}");
        var notRenamedGo = gameObject.FindByName(notRenamed);
        Debug.Log($"Redirector => {notRenamedGo.name} - {renamedGo.GetHashCode()}");
    }
}
