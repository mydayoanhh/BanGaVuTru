using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Section3
{
    public class Spawnmanager : MonoBehaviour
    {
        [SerializeField] private bool m_Active;
        [SerializeField] private Enemy m_EnemyPrefab;
        [SerializeField] private int m_TotalEnemy;
        [SerializeField] private float m_EnemySpawnerInterval;
        [SerializeField] private EnemyPath m_Path;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(IESpawner());
        }

        // Update is called once per frame
        void Update()
        {

        }
        private IEnumerator IESpawner()

        {
            
            
            for (int i = 0; i < m_TotalEnemy; i++)
            {
                yield return new WaitForSeconds(m_EnemySpawnerInterval);
                Enemy enemy = Instantiate(m_EnemyPrefab, null);
                enemy.Init(m_Path.WayPoints);
            }
        }
    }
}
