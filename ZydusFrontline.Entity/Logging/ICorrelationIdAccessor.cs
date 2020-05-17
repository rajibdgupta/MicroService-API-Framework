namespace ZydusFrontline.Entity.Logging
{
    public interface ICorrelationIdAccessor
    {
        string GetCorrelationId();
    }
}