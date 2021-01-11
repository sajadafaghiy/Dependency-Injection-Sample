using System;
using DependencyInjectionSample.Interfaces;

namespace DependencyInjectionSample.Classes
{
    public class Operation : IOperationSingleton, IOperationSingletonInstance, IOperationScoped, IOperationTransient
    {
        public Guid Id { get; set; }

        public Operation() : this(Guid.NewGuid())
        {

        }

        public Operation(Guid id)
        {
            Id = id;
        }

        public Guid OperationId => Id;
    }
}
