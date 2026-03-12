using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Factories;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class TestScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<UnitFactory>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        builder.Register<ComponentFactory>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
    }
}