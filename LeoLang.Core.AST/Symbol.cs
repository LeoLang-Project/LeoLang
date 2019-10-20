using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LeoLang.Core.AST
{
    /// <summary>This class produces global symbols.</summary>
    /// <remarks>
    /// Call GSymbol.Get() to create a Symbol from a string, or GSymbol.GetIfExists()
    /// to find a Symbol that has already been created.
    /// </remarks>
    public class GSymbol
    {
        #region Public static members

        static public readonly Symbol Empty;

        static public readonly SymbolPool Pool;

        static GSymbol()
        {
            Pool = new SymbolPool(0, 0);
            Empty = Pool.Get("");
            Debug.Assert(Empty.Id == 0 && Empty.Name == "");
            Debug.Assert(((Symbol)Empty).Pool == Pool);
        }

        static public Symbol Get(string name)
        {
            return Pool.Get(name);
        }

        static public Symbol GetById(int id)
        {
            return Pool.GetById(id);
        }

        static public Symbol GetIfExists(string name)
        {
            return Pool.GetIfExists(name);
        }

        #endregion Public static members
    }

    /// <summary>Represents a symbol, like the feature offered in Ruby.</summary>
    /// <remarks>
    /// Call GSymbol.Get() to create a Symbol from a string, or GSymbol.GetIfExists()
    /// to find a Symbol that has already been created.
    /// <para/>
    /// Symbols can be used like a global, extensible enumeration. Comparing symbols
    /// is as fast as comparing two integers; this is because '==' is not
    /// overloaded--equality is defined as reference equality, as there is only one
    /// instance of a given Symbol.
    /// <para/>
    /// Symbols can also be produced in namespaces called "pools". Two Symbols with
    /// the same name, but in different pools, are considered to be different
    /// symbols. Using a derived class D of Symbol and a SymbolPool&lt;D&gt;,
    /// you can make Symbols that are as type-safe as enums.
    /// <para/>
    /// A Symbol's ToString() function returns the symbol name prefixed with a colon
    /// (:), following the convention of the Ruby language, from which I got the
    /// idea of Symbols in the first place. The Name property returns the original
    /// string without the colon.
    /// <para/>
    /// Note: Symbol can represent any string, not just identifiers.
    /// </remarks>
    public class Symbol
    {
        #region Public instance members

        public int Id { [DebuggerStepThrough] get { return _id; } }
        public bool IsGlobal { [DebuggerStepThrough] get { return _pool == GSymbol.Pool; } }
        public string Name { [DebuggerStepThrough] get { return _name; } }
        public SymbolPool Pool { [DebuggerStepThrough] get { return _pool; } }

        public static implicit operator Symbol(string src)
        {
            return GSymbol.Get(src);
        }

        public override bool Equals(object b)
        {
            return ReferenceEquals(this, b);
        }

        public override int GetHashCode()
        {
            return 5432 + _id ^ (_pool.PoolId << 16);
        }

        [DebuggerStepThrough]
        public override string ToString()
        {
            if (_id == 0)
                return string.Empty;
            else
                return ":" + Name;
        }

        #endregion Public instance members

        #region Protected & private members

        /// <summary>For internal use only. Call GSymbol.Get() instead!</summary>
        internal Symbol(int id, string name, SymbolPool pool)
        { _id = id; _name = name; _pool = pool; }

        /// <summary>For use by a derived class to produce a statically-typed
        /// enumeration in a private pool. See the example under SymbolPool
        /// (of SymbolEnum)</summary>
        /// <param name="prototype">A strictly temporary Symbol that is used
        /// to initialize this object. The derived class should discard the
        /// prototype after calling this constructor.</param>
        protected Symbol(Symbol prototype)
        {
            _id = prototype._id;
            _name = prototype._name;
            _pool = prototype._pool;
        }

        private readonly int _id;
        private readonly string _name;
        private readonly SymbolPool _pool;

        #endregion Protected & private members
    }

    /// <summary>Tracks a set of symbols.</summary>
    /// <remarks>
    /// There is one global symbol pool (GSymbol.Pool) and you can create an
    /// unlimited number of private pools, each with an independent namespace.
    /// <para/>
    /// Methods of this class are synchronized, so a SymbolPool can be used from
    /// multiple threads.
    /// <para/>
    /// Symbols can be allocated, but they cannot be garbage-collected until the
    /// pool in which the symbols were created is garbage-collected. Therefore, one
    /// should avoid creating global Symbols based on user input, except in a short-
    /// running program. It is safer to create such symbols in a private pool, and
    /// to free the pool when it is no longer needed.
    /// <para/>
    /// Symbols from private pools have positive IDs (normally starting at 1 and
    /// proceeding up), and two private pools produce duplicate IDs even though
    /// Symbols in the two pools compare unequal. Symbols from the global pool
    /// have non-positive IDs. GSymbol.Empty, whose Name is "", has an ID of
    /// 0. In a private pool, a new ID will be allocated for ""; it is not treated
    /// differently than any other name.
    /// </remarks>
    public class SymbolPool : IEnumerable<Symbol>
    {
        /// <summary>Returns the number of Symbols created in this pool.</summary>
        public int TotalCount
        {
            get { return _list.Count; }
        }

        public SymbolPool() : this(1, _nextPoolId++)
        {
        }

        /// <summary>Initializes a new Symbol pool.</summary>
        /// <param name="firstID">The first Symbol created in the pool will have
        /// the specified ID, and IDs will proceed downward from there.</param>
        public SymbolPool(int firstID) : this(firstID, _nextPoolId++) { }

        /// <summary>Gets a symbol from this pool, or creates it if it does not
        /// exist in this pool already.</summary>
        /// <param name="name">Name to find or create.</param>
        /// <returns>A symbol with the requested name, or null if the name was null.</returns>
        /// <remarks>
        /// If Get("foo") is called in two different pools, two Symbols will be
        /// created, each with the Name "foo" but not necessarily with the same
        /// IDs. Note that two private pools re-use the same IDs, but this
        /// generally doesn't matter, as Symbols are compared by reference, not by
        /// ID.
        /// </remarks>
        public Symbol Get(string name)
        {
            Symbol result;
            Get(name, out result);
            return result;
        }

        /// <summary>Gets a symbol by its ID, or null if there is no such symbol.</summary>
        /// <param name="id">ID of a symbol. If this is a private pool and the
        /// ID does not exist in the pool, the global pool is searched instead.
        /// </param>
        /// <returns>The requested Symbol</returns>
        /// <exception cref="ArgumentException">The specified ID does not exist
        /// in this pool or in the global pool.</exception>
        public Symbol GetById(int id)
        {
            int index = id - _firstId;
            if (this == GSymbol.Pool || unchecked((uint)index >= (uint)TotalCount))
            {
                index = -id;
                lock (GSymbol.Pool._map)
                {
                    if (unchecked((uint)index < (uint)GSymbol.Pool._list.Count))
                        return GSymbol.Pool._list[index];
                }
            }
            else
            {
                lock (_map)
                {
                    return _list[index];
                }
            }
            throw new ArgumentException("Invalid Symbol ID " + id.ToString(), "id");
        }

        public IEnumerator<Symbol> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>Gets a symbol from the global pool, if it exists there already;
        /// otherwise, creates a Symbol in this pool.</summary>
        /// <param name="name">Name of a symbol to get or create</param>
        /// <returns>A symbol with the requested name</returns>
        public Symbol GetGlobalOrCreateHere(string name)
        {
            Symbol sym = GSymbol.Pool.GetIfExists(name);
            return sym ?? Get(name);
        }

        /// <summary>Gets a symbol from this pool, if the name exists already.</summary>
        /// <param name="name">Symbol Name to find</param>
        /// <returns>Returns the existing Symbol if found; returns null if the name
        /// was not found, or if the name itself was null.</returns>
        public Symbol GetIfExists(string name)
        {
            Symbol sym;
            if (name == null)
                return null;
            else lock (_map)
                {
                    _map.TryGetValue(name, out sym);
                    return sym;
                }
        }

        protected internal readonly int _firstId;
        protected internal List<Symbol> _list;
        protected internal Dictionary<string, Symbol> _map;

        protected internal int PoolId
        {
            get { return _poolId; }
        }

        protected internal SymbolPool(int firstID, int poolId)
        {
            _map = new Dictionary<string, Symbol>();
            _list = new List<Symbol>();
            _firstId = firstID;
            _poolId = poolId;
        }

        protected static int _nextPoolId = 1;
        protected readonly int _poolId;

        /// <summary>Workaround for lack of covariant return types in C#</summary>
        protected virtual void Get(string name, out Symbol sym)
        {
            if (name == null)
                sym = null;
            else lock (_map)
                {
                    if (!_map.TryGetValue(name, out sym))
                    {
                        int newId = _firstId + _list.Count;
                        if (this == GSymbol.Pool)
                        {
                            newId = -newId;
                            name = string.Intern(name);
                        }
                        sym = NewSymbol(newId, name);
                        _list.Add(sym);
                        _map.Add(name, sym);
                    }
                }
        }

        /// <summary>Factory method to create a new Symbol.</summary>
        protected virtual Symbol NewSymbol(int id, string name)
        {
            return new Symbol(id, name, this);
        }
    }
}