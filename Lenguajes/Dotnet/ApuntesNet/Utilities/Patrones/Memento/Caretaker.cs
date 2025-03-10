﻿namespace Memento;


// The Caretaker doesn't depend on the Concrete Memento class. Therefore, it
// doesn't have access to the originator's state, stored inside the memento.
// It works with all mementos via the base Memento interface.
internal class Caretaker(Originator originator)
{
    private readonly List<IMemento> _mementos = [];

    public void Backup()
    {
        Console.WriteLine("\nCaretaker: Saving Originator's state...");
        _mementos.Add(originator.Save());
    }

    public void Undo()
    {
        if (_mementos.Count == 0)
        {
            return;
        }

        IMemento? memento = _mementos.Last();
        _mementos.Remove(memento);

        Console.WriteLine("Caretaker: Restoring state to: " + memento.GetName());

        try
        {
            originator.Restore(memento);
        }
        catch (Exception)
        {
            Undo();
        }
    }

    public void ShowHistory()
    {
        Console.WriteLine("Caretaker: Here's the list of mementos:");

        foreach (IMemento? memento in _mementos)
        {
            Console.WriteLine(memento.GetName());
        }
    }
}
