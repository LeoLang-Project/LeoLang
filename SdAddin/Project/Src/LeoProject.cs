// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Daniel Grunwald" email="daniel@danielgrunwald.de"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.IO;
using ICSharpCode.SharpDevelop.Project;

namespace ICSharpCode.LeoBinding
{
    public class LeoProject : CompilableProject
    {
        public override string Language
        {
            get { return LeoProjectBinding.LanguageName; }
        }

        public LeoProject(ProjectLoadInformation info)
                    : base(info)
        {
        }

        public LeoProject(ProjectCreateInformation info)
            : base(info)
        {
            this.AddImport(@"$(LeoAddInPath)\SharpDevelop.Build.MSIL.Targets", null);
        }

        public override ItemType GetDefaultItemType(string fileName)
        {
            if (string.Equals(".leo", Path.GetExtension(fileName), StringComparison.OrdinalIgnoreCase))
                return ItemType.Compile;
            else
                return base.GetDefaultItemType(fileName);
        }
    }
}