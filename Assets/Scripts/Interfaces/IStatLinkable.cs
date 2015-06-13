public interface IStatLinkable {
    int StatLinkerValue { get; }

    void AddLinker(RPGStatLinker linker);
    void RemoveLinker(RPGStatLinker linker);
    void ClearLinkers();
    void UpdateLinkerValue();
}