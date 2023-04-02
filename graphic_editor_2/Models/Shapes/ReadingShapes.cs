using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;
using System;

namespace graphic_editor_2.Models.Shapes
{
    public static class GeometryDop
    {
        public static string Stringify(this Geometry figureGeometry)
        {
            if (figureGeometry is not ReadingShapes @shake) throw new Exception("Geometry не является объектом класса GeometryParsing");
            return @shake.saved_path;
        }
        public static Geometry MyParse(this Geometry _, string s) => ReadingShapes.Parse(s);
    }

    public class ReadingShapes : Geometry
    {
        IStreamGeometryImpl? _impl;
        public string saved_path;

        public ReadingShapes(string path = "") { saved_path = path; }

        private ReadingShapes(string path, IStreamGeometryImpl impl) { saved_path = path; _impl = impl; }

        public static new ReadingShapes Parse(string s)
        {
            var geometryShake = new ReadingShapes(s);

            using (var context = geometryShake.Open())
            using (var parser = new PathMarkupParser(context)) parser.Parse(s);

            return geometryShake;
        }

        public override Geometry Clone()
        {
            return new ReadingShapes(saved_path, ((IStreamGeometryImpl)PlatformImpl).Clone());
        }

        public StreamGeometryContext Open()
        {
            return new StreamGeometryContext(((IStreamGeometryImpl)PlatformImpl).Open());
        }

        protected override IGeometryImpl CreateDefiningGeometry()
        {
            if (_impl == null)
            {
                var factory = AvaloniaLocator.Current.GetService<IPlatformRenderInterface>() ?? throw new Exception("Factory not found");
                _impl = factory.CreateStreamGeometry();
            }
            return _impl;
        }
    }
}