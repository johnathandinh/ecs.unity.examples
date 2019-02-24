//  Project : Actors-Examples
// Contacts : Pixeye - info@pixeye.games
//     Date : 2/20/2019 

namespace Pixeye
{
   [System.Serializable]
   public class ComponentWeapon : IComponent
   {
       public string name;
   }
    
  public static class ExtensionComponentWeapon
    {
        public static ComponentWeapon ComponentWeapon(this int entity)
        {
            return Storage<ComponentWeapon>.Instance.components[entity];
        }

        public static bool TryGetComponentWeapon(this int entity, out ComponentWeapon component)
        {
            component = Storage<ComponentWeapon>.Instance.TryGet(entity);
            return component != null;
        }

        public static bool HasComponentWeapon(this int entity)
        {
            return Storage<ComponentWeapon>.Instance.HasComponent(entity);
        }
    }
    
    
}