namespace GhostEvilRation.GameojbectSysteam
{
    using GhostEvilRation.Character.Player;
    using UnityEngine;

    /// <summary>
    /// �� ���� �Դϴ�.
    /// �浹���� ��ü���� �̵��ӵ��� ���Դϴ�.
    /// </summary>
    public class SwampTerrain : MonoBehaviour
    {
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private float decrease;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other != null)
            {
                //������ �÷��̾�� ������� ������ ���͸� ���鶩 ���̾ �����Ͽ� ����.
                PlayerController controller = other.gameObject.GetComponent<PlayerController>();
                if (controller != null)
                {
                    //�÷��̾� ��� �÷��̾� �Ӱ�
                }
                //else if (other.transform.gameObject.GetComponent<EnemyBody>() != null)
                //{
                //    //���Ͷ�� �Ӱ�
                //}
                else
                {
                    //�ƹ��͵� �ƴ϶�� �׳� ����.
                    return;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other != null)
            {
                //������ �÷��̾�� ������� ������ ���͸� ���鶩 ���̾ �����Ͽ� ����.
                //else if (other.transform.gameObject.GetComponent<EnemyBody>() != null)
                //{
                //    //���Ͷ�� ���� �ӵ� ����
                //}
                {
                    //�ƹ��͵� �ƴ϶�� �׳� ����.
                    return;
                }
            }
        }
    }
}
