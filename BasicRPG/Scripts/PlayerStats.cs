using UnityEngine;
using System.Collections;

public class PlayerStats {
	public string name;
	public int power;
	public int defense;
	public float maxHealth;
	public float curHealth;

	public PlayerStats(string myName, int pow,int def, int hp){
		name = myName;
		power = pow;
		defense = def;
		maxHealth = curHealth = hp;
	}

	public void UpdatePower(int amt, bool dir){
		if(dir)
			power += amt;
		else
			power -= amt;
	}

	public void UpdateDefense(int amt, bool dir){
		if(dir)
			defense += amt;
		else
			defense -= amt;
	}

	public void UpdateHealth(int amt, bool dir){
		if(dir){
			maxHealth += amt;
			curHealth += amt;
		}else{
			maxHealth -= amt;
			curHealth -= amt;
		}
	}

	public void RenewHealth(int amt){
		curHealth += amt;
		if(curHealth > maxHealth)
			curHealth = maxHealth;
	}

	public string GetName(){
		return name;
	}

	public int GetPower(){
		return power;
	}

	public int GetDefense(){
		return defense;
	}

	public float GetHealth(){
		return curHealth;
	}

}
