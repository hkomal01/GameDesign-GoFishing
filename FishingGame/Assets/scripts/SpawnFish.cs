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
        public GameObject obj;
        public int count;
        public float rate;
        public Transform start_spawn;
    }

    public Wave[] waves;

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
            // SpawnEnemy(_wave.enemy);
            SpawnEnemy(_wave.obj, _wave.start_spawn);

            // SpawnEnemy(_wave.prefab, _wave.enemy);
            
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        yield break;
    }

    // void SpawnEnemy (GameObject _enemy) {

    //     Debug.Log("Spawning enemy" + _enemy.name);
    //     float x_pos = Random.Range(start_spawn.transform.position.x, end_spawn.transform.position.x);
    //     float y_pos = Random.Range(start_spawn.transform.position.y, end_spawn.transform.position.y);
    //     Instantiate(_enemy, new Vector3(x_pos, y_pos, 0.0f), start_spawn.rotation);
    // }
    void SpawnEnemy (GameObject _obj, Transform _start_spawn) {

        Debug.Log("Spawning fish " + _obj.name);
        float x_pos = Random.Range(_start_spawn.transform.position.x, end_spawn.transform.position.x);
        float y_pos = Random.Range(_start_spawn.transform.position.y, end_spawn.transform.position.y);
        Instantiate(_obj, new Vector3(x_pos, y_pos, 0.0f), _start_spawn.rotation);
    }


}