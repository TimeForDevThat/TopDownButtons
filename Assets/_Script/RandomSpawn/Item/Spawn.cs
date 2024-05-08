using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] obj;
    private GameObject _Iteam;

    private List<Transform> spawnerPoints;

    public float timeSpawnAidKit = 10;
    public float timeSpawnAidKitMax = 15;

    private void Start()
        => spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());

    private void Update()
    {
        if (_Iteam != null) return;
        if (IsInvoking()) return;

        Invoke("SpawnItem", Random.Range(timeSpawnAidKit, timeSpawnAidKitMax));
    }

    public void SpawnItem()
    {
        int random = Random.Range(0, obj.Length - 1);
        _Iteam = Instantiate(obj[random]);
        _Iteam.transform.position = spawnerPoints[Random.Range(0, spawnerPoints.Count)].position;
    }

}
