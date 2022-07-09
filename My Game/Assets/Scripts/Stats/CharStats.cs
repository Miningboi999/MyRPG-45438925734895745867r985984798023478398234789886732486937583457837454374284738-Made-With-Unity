using UnityEngine;

public class CharStats : MonoBehaviour
{

public int maxHealth = 100;
public int currrentHealth { get; private set;}


public Stat damage;
public Stat armor;

void Awake ()
{
    currrentHealth = maxHealth;
}

void Update ()
{
if (Input.GetKeyDown(KeyCode.T))
{
    takeDamage(10);
}
}


public void takeDamage (int damage)
{
    damage -= armor.GetValue();
    damage = Mathf.Clamp(damage, 0, int.MaxValue);

    currrentHealth -= damage;
    Debug.Log(transform.name + " takes " + damage + " damage.");

    if (currrentHealth <= 0)
    {
        Die();
    }
}


public virtual void Die ()
{
    Debug.Log(transform.name + " died.");
}

}
