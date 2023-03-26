using Avalonia.Media;

namespace graphic_editor_2.Models {
    internal interface ISafe 
    {

        public string Value { get; set; }
        public bool Valid { get; }
        public void Set(string str);
        public IBrush Color { get; }
    }
}
