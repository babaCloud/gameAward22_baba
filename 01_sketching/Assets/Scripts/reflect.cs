using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflect : MonoBehaviour
{
    // �f�o�b�N�p�̉~�摜
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
        // �v���C���[��Transform�����擾
        Transform playerTrn = gameObject.GetComponent<Transform>();
        // ���D��Transform�����擾
        Transform balloonTrn = collision.gameObject.GetComponent<Transform>();
        // ���D��Collider���(CircleCollider�ł���)���擾
        SphereCollider balloonCol = collision.collider.GetComponent<SphereCollider>();

        // ���D�̔��a��Collider�ƃI�u�W�F�N�g�̃X�P�[������擾����
        float bRadius = balloonCol.radius * balloonTrn.localScale.x;

        // ���D�ƃv���C���[��2�_�Ԃ̋���
        float point = Mathf.Sqrt(Mathf.Pow(playerTrn.position.x - balloonTrn.position.x, 2)
            + Mathf.Pow(playerTrn.position.y - balloonTrn.position.y, 2));
    
        // �v���C���[�����D�ɐڂ����_�����Z����
        debugObj.transform.position
            = new Vector3(bRadius / point * (playerTrn.position.x + balloonTrn.position.x),
                        bRadius / point * (playerTrn.position.y + balloonTrn.position.y),
                        debugObj.transform.position.z);
    }
}
