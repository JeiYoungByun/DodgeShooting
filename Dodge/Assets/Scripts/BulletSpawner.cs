using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        //누적시간 0으로 초기화
        timeAfterSpawn = 0f;
        //탄알 생성 간격을 min과 max사이에서 랜덤 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //playercontroller 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
        target = FindObjectOfType<PlayerController>().transform;

    }

    void Update()
    {
        //timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;

        //최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if (timeAfterSpawn >= spawnRate)
        {
            //누적된 시간을 리셋
            timeAfterSpawn = 0f;

            //bulletPrefab의 복제본을 transform.position위치와 transform.rotation 회전으로 생성
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            bullet.transform.LookAt(target);
            //다음번 생성 간격을 spawnRateMin, spawnRateMax사이에서 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

    }
}
