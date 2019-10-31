using System.Collections.Generic;

namespace LeoLang.Library
{
    /// <summary>This type of SymbolPool helps create more strongly typed Symbols
    /// that simulate enums, but provide extensibility. Specifically, it
    /// creates SymbolE objects, where SymbolE is some derived class of Symbol.
    /// </summary>
    /// <typeparam name="SymbolE">
    /// A derived class of Symbol that owns the pool. See the example below.
    /// </typeparam>
    /// <example>
    /// public class ShapeType : Symbol
    /// {
    ///     private ShapeType(Symbol prototype) : base(prototype) { }
    ///     public static new readonly SymbolPool<ShapeType> Pool
    ///                          = new SymbolPool<ShapeType>(p => new ShapeType(p));
    ///
    ///     public static readonly ShapeType Circle  = Pool.Get("Circle");
    ///     public static readonly ShapeType Rect    = Pool.Get("Rect");
    ///     public static readonly ShapeType Line    = Pool.Get("Line");
    ///     public static readonly ShapeType Polygon = Pool.Get("Polygon");
    /// }
    /// </example>
    public class SymbolPool<SymbolE> : SymbolPool, IEnumerable<SymbolE>
        where SymbolE : Symbol
    {
        public SymbolPool(SymbolFactory factory)
        {
            _factory = factory;
        }

        public SymbolPool(SymbolFactory factory, int firstID) : base(firstID)
        {
            _factory = factory;
        }

        public delegate SymbolE SymbolFactory(Symbol prototype);

        public new SymbolE Get(string name)
        {
            return (SymbolE)base.Get(name);
        }

        public new SymbolE GetById(int id)
        {
            return (SymbolE)base.GetById(id);
        }

        public new IEnumerator<SymbolE> GetEnumerator()
        {
            foreach (SymbolE symbol in _list)
                yield return symbol;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public new SymbolE GetIfExists(string name)
        {
            return (SymbolE)base.GetIfExists(name);
        }

        protected SymbolFactory _factory;

        protected override Symbol NewSymbol(int id, string name)
        {
            return _factory(new Symbol(id, name, this));
        }
    }
}