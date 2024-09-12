namespace OhanaMembers.API.Tools
{
    public class HandlerFactory
    {
        public async Task<object> Run<T>(object parameters) where T : IRequestHandler
        {
            // Create an instance of T (which implements IRequestHandler)
            var instance = (T)(Activator.CreateInstance(typeof(T)) ?? throw new Exception($"Could not cast to handler type"));

            // Cast the parameter to the appropriate type based on the handler's generic arguments
            var paramType = instance.GetParameterType();

            var castedParams = Convert.ChangeType(parameters, paramType);

            // Call the Run method with the casted parameter and return the result
            return await instance.Run(castedParams);
        }

        public async Task<object> Run<T>() where T : IRequestHandler
        {
            // Create an instance of T (which implements IRequestHandler)
            var instance = (T)(Activator.CreateInstance(typeof(T)) ?? throw new Exception($"Could not cast to handler type"));

            // Call the Run method
            return await instance.Run();
        }
    }

    public interface IRequestHandler
    {
        Task<object> Run();
        Task<object> Run(object parameters);
        Type GetParameterType();
    }

    public interface IRequestHandler<U> : IRequestHandler
    {
        // Implementation of the generic Run method
        new Task<U> Run();

        // Default implementation of the parametered interface methods
        Task<object> IRequestHandler.Run(object parameters) => throw new Exception("This is defaulted away and should never be called");
        async Task<object> IRequestHandler.Run() => await Run();

        // There are no parameters to type
        Type IRequestHandler.GetParameterType() => typeof(void);
    }

    public interface IRequestHandler<U, K> : IRequestHandler
    {
        // Implementation of the generic Run method
        Task<U> Run(K parameters);

        // Default implementation of the non-generic interface methods
        Task<object> IRequestHandler.Run() => throw new Exception("This is defaulted away and should never be called");
        async Task<object> IRequestHandler.Run(object parameters) => await Run((K)parameters);

        // Expose the generic argument types for K and U
        Type IRequestHandler.GetParameterType() => typeof(K);
    }

}
