using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectWithinAreaAction : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabsToSpawn;
    [SerializeField] private Area area;

    public void SpawnMultipleObjects(int number)
    {
        for (int i = 0; i < number; i++)
        {
            SpawnObject();
        }
    }

    public void SpawnObject()
    {
        Vector3 pos = area.GetRandomPointInBounds();
        pos.y = 0;
        Instantiate(Utility.Choose(prefabsToSpawn), pos, Quaternion.identity);
    }

    private void SpawnObjectAtTransform(Transform spawnTransform)
    {
        Instantiate(Utility.Choose(prefabsToSpawn), spawnTransform.position, spawnTransform.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(area.position, area.size);
    }
} 

[System.Serializable]
public class Area
{
    public Vector3 position;
    public Vector3 size;

    public Area(Vector3 pos, Vector3 size)
    {
        this.position = pos;
        this.size = size;
    }

    public Vector3 GetRandomPointInBounds()
    {
        return new Vector3(
            Random.Range(-0.5f * size.x, 0.5f * size.x) + position.x, 
            Random.Range(-0.5f * size.y, 0.5f * size.y) + position.y, 
            Random.Range(-0.5f * size.z, 0.5f * size.z) + position.z);
    }

    public float Width => size.x;
    public float Height => size.y;
    public float Depth => size.z;
}
