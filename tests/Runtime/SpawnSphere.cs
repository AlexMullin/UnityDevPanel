using UnityEngine;
namespace DeveloperMenu.Tests 
{
    public class SpawnSphere : MonoBehaviour
    {
        [SerializeField] GameObject spherePrefab;


        private void Start()
        {
            DevMenu.Make.Button(new("SpawnSphere"), () => Instantiate(spherePrefab));
        }
    }
}
