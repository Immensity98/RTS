using Game.Scripts.Factories;
using Game.Scripts.System;
using Game.Scripts.Systems;
using Game.Scripts.Systems.Filters;
using VContainer;
using VContainer.Unity;

public class TestScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<SystemsRunner>();
        builder.RegisterEntryPoint<FilterService>();
        
        builder.Register<UnitFactory>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        builder.Register<ComponentFactory>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

        builder.Register<FiltersStorage>(Lifetime.Singleton);
        builder.Register<FilterMask>(Lifetime.Transient);
        builder.Register<Filter>(Lifetime.Transient);
        builder.Register<FilterBuilder>(Lifetime.Transient);
        
        RegisterSystems(builder);
    }

    private void RegisterSystems(IContainerBuilder builder)
    {
        builder.Register<MovementSystem>(Lifetime.Singleton).As<ISystem>().AsSelf();
    }
}