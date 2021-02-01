using Flunt.Notifications;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public abstract class  EntityBase : Notifiable
{
    public Guid Id { get; private set; }

    public EntityBase()
    {
        Id = Guid.NewGuid();
    }
}