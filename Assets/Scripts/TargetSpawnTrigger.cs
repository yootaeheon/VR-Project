using System.Collections;
using UnityEngine;

public class TargetSpawnTrigger : MonoBehaviour
{
    public GameObject[] target;
    [SerializeField] float delayTime = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SpawnTarget());
        }
    }

    Coroutine spawnTarget;
    IEnumerator SpawnTarget()
    {
        WaitForSeconds delay = new(delayTime);

        for (int i = 0; i < target.Length; i++)
        {
            target[i].SetActive(true);
            target[i+1].SetActive(true);
            yield return delay;
        }
        StopCoroutine(spawnTarget);
    }
}
