//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyManager : MonoBehaviour
//{
//    [Header("敌人刷新点")] 
//    public Transform[] spawnPoints;
//    [Header("敌人巡逻点")] 
//    public Transform[] patrolPoints;

//    [Header("该关卡的敌人")] 
//    public List<EnemyWave> enemyWaves;
//    public int currentWaveIndex = 0;//当前波数的索引
//    public int EnemyCount =0;//敌人数量
//    IEnumerator startNextWaveCoroutine()
//    {
//        if (currentWaveIndex >= enemyWaves.Count) yield break;//已经没有更多波数，直接退出协程
//        List<EnemyData> enemies = enemyWaves[currentWaveIndex].enemies;//获取当前波数对应的敌人列表
//    }
//}
