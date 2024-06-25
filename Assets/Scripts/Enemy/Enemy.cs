using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Section3
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float m_MoveSpeed;
        [SerializeField] private Transform[] m_WayPoints;

        private int m_CurrentWayPointIndex;
        private bool m_Active;

        //dan  
        [SerializeField] private EnemyBullet m_EnemyBullet;
        [SerializeField] private Transform m_FiringPoint;
        [SerializeField] private float m_FiringCooldown;

        private float m_TempCooldown;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!m_Active)
                return;



            int nextWayPoints = m_CurrentWayPointIndex + 1;
            if (nextWayPoints > m_WayPoints.Length - 1)
                nextWayPoints = 0;


            transform.position = Vector3.MoveTowards(transform.position,
                m_WayPoints[nextWayPoints].position, m_MoveSpeed * Time.deltaTime);
            //enemy den điểm đích
            if (transform.position == m_WayPoints[nextWayPoints].position)
                m_CurrentWayPointIndex = nextWayPoints;
     /*   if (m_TempCooldown <= 0)
            {
                Fire();
                m_TempCooldown = m_FiringCooldown;
            }*/

            m_TempCooldown = Time.deltaTime;

        }
        public void Init(Transform[] wayPoints)
        {
            m_WayPoints = wayPoints;
            m_Active = true;
            transform.position = wayPoints[0].position;
            //TempCooldown = m_FiringCooldown;

        }
        /*ivate void Fire()
        {
            EnemyBullet tile = Instantiate(m_EnemyBullet, m_FiringPoint.position, Quaternion.identity, null);
            tile.Fire();
        }*/
    }
}
 
