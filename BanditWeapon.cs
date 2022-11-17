using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditWeapon : MonoBehaviour
{
	public int damage = 20;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;
		FindObjectOfType<audioManager>().Play("Attack");

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{	

			Debug.Log("hit");
			colInfo.GetComponent<HeroKnight>().TakeDamage(damage);
		
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}