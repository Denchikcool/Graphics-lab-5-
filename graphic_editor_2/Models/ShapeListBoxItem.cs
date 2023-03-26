using ReactiveUI;
using System;
using System.Reactive;

namespace graphic_editor_2.Models {
    public class ShapeListBoxItem {

        public string Name { get; }
        public ShapeListBoxItem(string name, Mapper map) 
        {
            Name = name;
            Remove = ReactiveCommand.Create<Unit, Unit>(_ => { map.Remove(this); return new Unit(); });
        }

        public ReactiveCommand<Unit, Unit> Remove { get; }
    }
}
