using System;
using UnityEngine;

namespace GhostEvilRation.GameojbectSysteam.Buffe
{
    public abstract class GiveBuffeManager : MonoBehaviour , InBuffe
    {
        public void In_OutBuffe(int id, float durationTime)
        {
            GiveBuffe(id);
        }
        /// <summary>
        /// ȣ����� ��ü���� ����� id�� Ȯ���� �ش� id�� ������ ��ȯ �մϴ�.
        /// </summary>
        /// <param name="id"></param>
        private Buffe GiveBuffe(int id)
        {
            if(Enum.IsDefined(typeof(Buffe), id))
            {
                return (Buffe)id;
            }
            else
            {
                throw new ArgumentException("Not Thing");
            }
        }

    }

    public enum Buffe
    {
        /// <summary>
        /// �طο� ���� ��� �Դϴ�.
        /// </summary>
        weakness = 1,           // ���
        decreasedHealing,       // ġ������
        bleeding,               // ����
        poison,                 // ��
        panic,                  // �д�
        deceleration,           // ����
        disheveled,             // ��Ʈ����
        damageReduction,        // ���ؾ�ȭ
        weaknessDefense,        // ���� ��ȭ
        stiffness,              // ����
        
        /// <summary>
        /// �̷ο� ���� ��� �Դϴ�.
        /// </summary>
        courage = 24,
        fast,
        sap
    }
}
