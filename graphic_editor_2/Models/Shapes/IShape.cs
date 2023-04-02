using Avalonia.Controls.Shapes;
using System;
using System.Collections.Generic;
using Avalonia;

namespace graphic_editor_2.Models.Shapes {

    public enum PropsN 
    {
        PName, PColor, PFillColor, PThickness,
        PWidth, PHeight, PHorizDiagonal, PVertDiagonal,
        PStartDot, PEndDot, PCenterDot, PDots, PCommands
    }
    internal interface IShape {

        public string Name { get; }
        public PropsN[] Props { get; }

        public bool Load(Mapper map, Shape shape);
        public Shape? Build(Mapper map);
        public Shape? Import(Dictionary<string, object?> data);
        public bool SetPos(Shape shape, int x, int y);
        public Dictionary<string, object?>? Export(Shape shape);
        
        public Point? GetPos(Shape shape);
        
    }
}
