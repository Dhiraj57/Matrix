using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixEditor.Utilities
{
    public interface IUndoRedo
    {
        string Name { get; }
        void Undo();
        void Redo();
    }

    public class UndoRedoAction : IUndoRedo
    {
        private Action _undoAction;
        private Action _redoAction;

        public string Name { get; }

        public void Redo()
        {
            _redoAction?.Invoke();
        }

        public void Undo()
        {
            _undoAction?.Invoke();
        }

        public UndoRedoAction(string name)
        {
            Name = name;
        }

        public UndoRedoAction(Action undoAction, Action redoAction, string name): this(name)
        {
            Debug.Assert(undoAction != null && redoAction != null);
            _undoAction = undoAction;
            _redoAction = redoAction;
        }
    }

    public class UndoRedo
    {
        private readonly ObservableCollection<IUndoRedo> _undoList = new ObservableCollection<IUndoRedo>();
        private readonly ObservableCollection<IUndoRedo> _redoList = new ObservableCollection<IUndoRedo>();

        public ReadOnlyObservableCollection<IUndoRedo> UndoList { get; }
        public ReadOnlyObservableCollection <IUndoRedo> RedoList { get; }

        public void Reset()
        {
            _undoList.Clear();
            _redoList.Clear();
        }

        public void Add(IUndoRedo command)
        {
            _undoList.Add(command);
            _redoList.Clear();
        }

        public void Undo()
        {
            if(UndoList.Any())
            {
                var command = _undoList.Last();
                _undoList.RemoveAt(_undoList.Count - 1);

                command.Undo();
                _redoList.Insert(0, command);
            }
        }

        public void Redo()
        {
            if(RedoList.Any())
            {
                var commmad = _redoList.First();
                _redoList.RemoveAt(0);

                commmad.Redo();
                _undoList.Add(commmad);
            }  
        }

        public UndoRedo()
        {
            UndoList = new ReadOnlyObservableCollection<IUndoRedo>(_undoList);
            RedoList = new ReadOnlyObservableCollection<IUndoRedo>(_redoList);
        }
    }
}
