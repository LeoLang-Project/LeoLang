//
// IronMeta LeoParser Parser; Generated 2019-09-30 17:36:05Z UTC
//

using System;
using System.Collections.Generic;
using System.Linq;

using IronMeta.Matcher;

#pragma warning disable 0219
#pragma warning disable 1591

namespace LeoLang.Core
{

    using _LeoParser_Inputs = IEnumerable<char>;
    using _LeoParser_Results = IEnumerable<SyntaxNode>;
    using _LeoParser_Item = IronMeta.Matcher.MatchItem<char, SyntaxNode>;
    using _LeoParser_Args = IEnumerable<IronMeta.Matcher.MatchItem<char, SyntaxNode>>;
    using _LeoParser_Memo = IronMeta.Matcher.MatchState<char, SyntaxNode>;
    using _LeoParser_Rule = System.Action<IronMeta.Matcher.MatchState<char, SyntaxNode>, int, IEnumerable<IronMeta.Matcher.MatchItem<char, SyntaxNode>>>;
    using _LeoParser_Base = IronMeta.Matcher.Matcher<char, SyntaxNode>;

    public partial class LeoParser : IronMeta.Matcher.Matcher<char, SyntaxNode>
    {
        public LeoParser()
            : base()
        {
            _setTerminals();
        }

        public LeoParser(bool handle_left_recursion)
            : base(handle_left_recursion)
        {
            _setTerminals();
        }

        void _setTerminals()
        {
            this.Terminals = new HashSet<string>()
            {
            };
        }


    } // class LeoParser

} // namespace LeoLang.Core

