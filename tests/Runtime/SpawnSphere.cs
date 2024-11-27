using DevPanel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSphere : MonoBehaviour
{
    [SerializeField] GameObject spherePrefab;


    private void Start()
    {
        DebugPanel.Make.Button(new("SpawnSphere"), () => Instantiate(spherePrefab));
    }
}
