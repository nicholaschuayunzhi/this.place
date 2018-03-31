using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{

    public string Unload;
    public string Load;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SendMessageUpwards("Load", Load);
        }

        if (other.CompareTag("Player"))
        {
            SendMessageUpwards("Unload", Unload);
        }
    }
}
