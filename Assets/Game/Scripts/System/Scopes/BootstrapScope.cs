using Game.Scripts.Enums;
using Game.Scripts.Libraries;
using Game.Scripts.System.Logger;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.System.Scopes
{
    public class BootstrapScope : LifetimeScope
    {
        [SerializeField] 
        private LibrariesContainer _librariesContainer;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject); 
            GameLogger.Log(ELogChannel.System, "[BootstrapScope] Bootstrap Scope has been initialized");
        }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Bootstrapper>();
            
            builder.Register<SceneLoader>(Lifetime.Singleton); 

            RegisterLibraries(builder); 
        }

        private void RegisterLibraries(IContainerBuilder builder)
        {
            foreach (var library in _librariesContainer.GetLibraries())
            {
               builder.RegisterInstance(library).AsSelf(); 
            }
        }
    }
}
