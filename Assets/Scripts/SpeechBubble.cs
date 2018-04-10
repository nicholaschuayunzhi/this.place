using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{

    public GameObject SpeechCanvasRoot;

    private GameObject _player;
    private Vector3 _translate;
    public bool apply = true;


    void Start()
    {
        SpeechCanvasRoot.SetActive(false);
        //_translate = SpeechCanvasRoot.transform.position - transform.position;
    }

    void Update()
    {
        if (SpeechCanvasRoot.activeSelf)
        {
            SpeechCanvasRoot.transform.forward = Camera.main.transform.forward;
            Vector3 parentPos = _player.transform.position;
            SpeechCanvasRoot.transform.position = _player.transform.position;
        }


        if (apply)
        {
            apply = false;
            Debug.Log("Updated material val");
            Image image = GetComponentInChildren<Image>();
            Material existingGlobalMat = image.materialForRendering;
            Material updatedMaterial = new Material(existingGlobalMat);
            updatedMaterial.SetInt("unity_GUIZTestMode", (int)comparison);
            image.material = updatedMaterial;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpeechCanvasRoot.SetActive(true);
            _player = other.gameObject;
            StartCoroutine(WaitThenDestroy());
        }
    }

    public UnityEngine.Rendering.CompareFunction comparison = UnityEngine.Rendering.CompareFunction.Always;


    IEnumerator WaitThenDestroy()
    {
        yield return new WaitForSeconds(100);
        Destroy(gameObject);
        Destroy(SpeechCanvasRoot);
    }
}
