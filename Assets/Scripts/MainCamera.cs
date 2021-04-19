using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;      //相対距離取得用

    // Start is called before the first frame update
    void Start()
    {
        // MainCamera(自分自身)とplayerとの相対距離を求める
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        //// 補完スピードを決める
        //float speed = 0.1f;
        //// ターゲット方向のベクトルを取得
        //Vector3 relativePos = player.transform.position - this.transform.position;
        //// 方向を、回転情報に変換
        //Quaternion rotation = Quaternion.LookRotation(relativePos);
        //// 現在の回転情報と、ターゲット方向の回転情報を補完する
        //transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, speed);

        //新しいトランスフォームの値を代入する
        transform.position = player.transform.position + offset;
    }
}
