using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance {  get; private set; }

    [Header("����ˢ�µ�")]
    public Transform[] spawnPoints;
    [Header("����Ѳ�ߵ�")]
    public Transform[] patrolPoints;

    [Header("�ùؿ��ĵ���")]
    public List<EnemyWave> enemyWaves;
    public int currentWaveIndex = 0;//��ǰ����������
    public int enemyCount = 0;//��������

    [Header("�Ƿ����õ���ˢ��")]
    public bool refresh = false;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (enemyCount==0&&refresh)
        {
            Debug.Log("1");
            StartCoroutine(nameof(StartNextWaveCoroutine));//��ʼ��һ��
        }
    }

    
    IEnumerator StartNextWaveCoroutine()
    {
        if (currentWaveIndex >= enemyWaves.Count) 
            yield break;//�Ѿ�û�и��ನ����ֱ���˳�Э��
        List<EnemyData> enemies = enemyWaves[currentWaveIndex].enemies;//��ȡ��ǰ������Ӧ�ĵ����б�

        foreach (EnemyData enemyData in enemies)
        {
            for (int i = 0; i < enemyData.waveEnemyCount; i++)
            {
                GameObject enemy = Instantiate(enemyData.enemyPrefab, GetRandomSpawnPoint(), Quaternion.identity);

                if (patrolPoints != null)//Ѳ�ߵ��б�Ϊ�գ��Ͱ�Ѳ�ߵ��б�ֵ������Ԥ�����Ѳ�ߵ��б�
                {
                    //enemy.GetComponent < Enemy > ().patrolPoints = patrolPoints;
                }
                yield return new WaitForSeconds(enemyData.spawnInterval);
            }
        }
        currentWaveIndex++;
    }
    //�ӹ���ˢ�µ��λ���б������ѡ��һ��ˢ�µ�1������
    private Vector3 GetRandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex].position;
    }
}

//��Ϊû�̳�MonoBehaviour�������Ҫ���л������[System.Serializable]
[System.Serializable]
public class EnemyData
{
    public GameObject enemyPrefab;//����Ԥ����
    public float spawnInterval;//�������ɼ��
    public float waveEnemyCount;//��������
}
[System.Serializable]
public class EnemyWave
{
    public List<EnemyData> enemies;//ÿ�������б�
}