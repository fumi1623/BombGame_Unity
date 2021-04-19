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

        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = cameraForward * cameraZ + Camera.main.transform.right * cameraX;

        // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
        rb.velocity = moveForward * speed + new Vector3(0, rb.velocity.y, 0);

        // �L�����N�^�[�̌�����i�s������
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
