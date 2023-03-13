using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] GameObject package;
    [SerializeField] GameObject customer;

    [SerializeField] Vector2 spawnMinimum;
    [SerializeField] Vector2 spawnMaximum;

    void Start()
    {
        Spawner.Package = package;
        Spawner.Customer = customer;
        Spawner.SpawnMinimum = spawnMinimum;
        Spawner.SpawnMaximum = spawnMaximum;
    }
}
