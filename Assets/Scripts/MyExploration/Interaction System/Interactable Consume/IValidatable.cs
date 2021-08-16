public enum InteractionState
{
    LOCKED,
    UNLOCKED
}
public interface IValidatable
{
    InteractionState StateOfInteraction { get; set; }
    public string ID { get; }
}
