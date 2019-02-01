using DesertImage.Managers;
using UnityEngine;

namespace DesertImage.Systems
{
    public class InitFactoriesSystem : ManagerBase, IAwake
    {
        public void onAwake()
        {
            var factories = Resources.LoadAll<Factory>("Factories/");

            foreach (var factory in factories)
            {
                Core.Instance.add(factory);
            }
        }
    }
}