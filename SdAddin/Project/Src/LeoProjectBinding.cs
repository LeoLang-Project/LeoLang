// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Daniel Grunwald" email="daniel@danielgrunwald.de"/>
//     <version>$Revision$</version>
// </file>

using ICSharpCode.SharpDevelop.Project;

namespace ICSharpCode.LeoBinding
{
    public class LeoProjectBinding : IProjectBinding
    {
        public const string LanguageName = "Leo";

        public bool HandlingMissingProject
        {
            get { return false; }
        }

        public string Language
        {
            get
            {
                return LanguageName;
            }
        }

        public IProject CreateProject(ProjectCreateInformation info)
        {
            return new LeoProject(info);
        }

        public IProject LoadProject(ProjectLoadInformation loadInformation)
        {
            return new LeoProject(loadInformation);
        }
    }
}