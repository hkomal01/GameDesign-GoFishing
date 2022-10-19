using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
    [System.Serializable]

    public class Wave 
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;

    public Transform start_spawn;
    public Transform end_spawn;


    void Start() {

        for (int i = 0; i < waves.Length; i++) {
            StartCoroutine (SpawnWave(waves[i]));
        }
    }

    IEnumerator SpawnWave(Wave _wave) {

        Debug.Log("Spawning wave: " + _wave.name);
        Debug.Log("Wave Count: " + _wave.count);

        for(int i = 0; i < _wave.count; i++) {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        yield break;
    }

    void SpawnEnemy (Transform _enemy) {

        Debug.Log("Spawning enemy" + _enemy.name);
        float x_pos = Random.Range(start_spawn.transform.position.x, end_spawn.transform.position.x);
        float y_pos = Random.Range(start_spawn.transform.position.y, end_spawn.transform.position.y);
        Instantiate(_enemy, new Vector3(x_pos, y_pos, 0.0f), start_spawn.rotation);
    }

}