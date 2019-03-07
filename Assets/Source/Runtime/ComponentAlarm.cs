//  Project : ecs.examples
// Contacts : Pix - info@pixeye.games
//     Date : 3/7/2019 

namespace Pixeye
{
   [System.Serializable]
   public class ComponentAlarm : IComponent
   {
       public int target = -1;
       public float radius;
   }
    
  public static class ExtensionComponentAlarm
    {
        public static ComponentAlarm ComponentAlarm(this int entity)
        {
            return Storage<ComponentAlarm>.Instance.components[entity];
        }

        public static bool TryGetComponentAlarm(this int entity, out ComponentAlarm component)
        {
            component = Storage<ComponentAlarm>.Instance.TryGet(entity);
            return component != null;
        }

        public static bool HasComponentAlarm(this int entity)
        {
            return Storage<ComponentAlarm>.Instance.HasComponent(entity);
        }
    }
    
    
}