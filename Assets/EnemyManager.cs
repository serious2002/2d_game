//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyManager : MonoBehaviour
//{
//    [Header("����ˢ�µ�")] 
//    public Transform[] spawnPoints;
//    [Header("����Ѳ�ߵ�")] 
//    public Transform[] patrolPoints;

//    [Header("�ùؿ��ĵ���")] 
//    public List<EnemyWave> enemyWaves;
//    public int currentWaveIndex = 0;//��ǰ����������
//    public int EnemyCount =0;//��������
//    IEnumerator startNextWaveCoroutine()
//    {
//        if (currentWaveIndex >= enemyWaves.Count) yield break;//�Ѿ�û�и��ನ����ֱ���˳�Э��
//        List<EnemyData> enemies = enemyWaves[currentWaveIndex].enemies;//��ȡ��ǰ������Ӧ�ĵ����б�
//    }
//}
