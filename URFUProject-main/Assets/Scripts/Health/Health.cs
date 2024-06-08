using System;

public class Health
{
   public float MaxHealth { get; private set; }
   public float CurrentHealth { get; private set; }

   public Health(float value)
   {
      MaxHealth = value;
      CurrentHealth = value;
   }
   public Action Die;
   
   public void DecreaseHealth(float damage)
   {
      CurrentHealth -= damage;
      
      if(CurrentHealth <= 0)
         Die?.Invoke();
   }
}
