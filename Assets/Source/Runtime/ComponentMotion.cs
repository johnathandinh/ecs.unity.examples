//  Project : ecs.examples
// Contacts : Pix - info@pixeye.games
//     Date : 3/7/2019 

 

namespace Pixeye
{
   [System.Serializable]
   public class ComponentMotion : IComponent
   {
       public float speed;
       public float direction = 1;
   }
    
  public static class ExtensionComponentMotion
    {
        public static ComponentMotion ComponentMotion(this int entity)
        {
            return Storage<ComponentMotion>.Instance.components[entity];
        }

        public static bool TryGetComponentMotion(this int entity, out ComponentMotion component)
        {
            component = Storage<ComponentMotion>.Instance.TryGet(entity);
            return component != null;
        }

        public static bool HasComponentMotion(this int entity)
        {
            return Storage<ComponentMotion>.Instance.HasComponent(entity);
        }
    }
    
    
}