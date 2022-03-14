using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflect : MonoBehaviour
{
    // デバック用の円画像
    [SerializeField]
    private GameObject debugObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // プレイヤーのTransform情報を取得
        Transform playerTrn = gameObject.GetComponent<Transform>();
        // 風船のTransform情報を取得
        Transform balloonTrn = collision.gameObject.GetComponent<Transform>();
        // 風船のCollider情報(CircleColliderでも可)を取得
        SphereCollider balloonCol = collision.collider.GetComponent<SphereCollider>();

        // 風船の半径をColliderとオブジェクトのスケールから取得する
        float bRadius = balloonCol.radius * balloonTrn.localScale.x;

        // 風船とプレイヤーの2点間の距離
        float point = Mathf.Sqrt(Mathf.Pow(playerTrn.position.x - balloonTrn.position.x, 2)
            + Mathf.Pow(playerTrn.position.y - balloonTrn.position.y, 2));
    
        // プレイヤーが風船に接した点を演算する
        debugObj.transform.position
            = new Vector3(bRadius / point * (playerTrn.position.x + balloonTrn.position.x),
                        bRadius / point * (playerTrn.position.y + balloonTrn.position.y),
                        debugObj.transform.position.z);
    }
}
