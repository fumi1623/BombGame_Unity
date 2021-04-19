using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float x;
    float z;
    float cameraX;
    float cameraZ;
    public float speed;

    Rigidbody rb;

    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        cameraX = Input.GetAxisRaw("Horizontal");
        cameraZ = Input.GetAxisRaw("Vertical");

        Clamp();
    }

    private void FixedUpdate() {

        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * cameraZ + Camera.main.transform.right * cameraX;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * speed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

    void Clamp() {
        playerPos = transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, -9.4f, 9.4f);
        playerPos.z = Mathf.Clamp(playerPos.z, -9.4f, 9.4f);
        transform.position = new Vector3(playerPos.x, playerPos.y, playerPos.z);
        transform.position = playerPos;
    }

}
