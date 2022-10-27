namespace dart_core_api.Services.System
{
    public interface IServiceTools
    {
        TModelOut? Map<TModelIn, TModelOut>(TModelIn from);
    }
    public class ServiceTools : IServiceTools
    {
        public TModelOut? Map<TModelIn, TModelOut>(TModelIn from)
        {
            var outInstance = Activator.CreateInstance<TModelOut>();
            if (outInstance == null) return default(TModelOut);
            var outInstanceType = outInstance.GetType();
            var outInstanceProperties = outInstanceType.GetProperties();
            if (outInstanceProperties == null) return default(TModelOut);

            if (from == null) return default(TModelOut);
            var inInstanceType = from.GetType();
            if (outInstance == null) return default(TModelOut);
            var inInstanceProperties = inInstanceType.GetProperties();
            if (inInstanceProperties == null) return default(TModelOut);

            for (int i = 0; i < outInstanceProperties.Length; i++)
            {
                var outPropToMap = outInstanceProperties[i];
                outPropToMap.SetValue(outInstance, from.GetType().GetProperty(outPropToMap.Name));
            }

            return outInstance;
        }
    }
}
