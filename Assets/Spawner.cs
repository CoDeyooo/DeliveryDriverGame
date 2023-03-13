using UnityEngine;

public class Spawner : MonoBehaviour 
{
    public static GameObject Package;
    public static GameObject Customer;

    public static Vector2 SpawnMinimum;
    public static Vector2 SpawnMaximum;

    private static GameObject[] houses;

    private void Start()
    {
        houses = GameObject.FindGameObjectsWithTag("House");
        SpawnPackage();
        Customer.SetActive(false);
    }

    public static void SpawnPackage()
    {
        var spawnPosition = new Vector2(
            Random.Range(SpawnMinimum.x, SpawnMaximum.x),
            Random.Range(SpawnMinimum.y, SpawnMaximum.y));

        Package.transform.position = spawnPosition;
        Package.SetActive(true);
    }

    public static void SpawnCustomer()
    {
        var house = houses[Random.Range(0, houses.Length)];
        var spawnPosition = house.transform.position;
        Customer.transform.position = spawnPosition;
        Customer.SetActive(true);
    }
}
