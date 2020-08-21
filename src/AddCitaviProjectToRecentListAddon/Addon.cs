using AddCitaviProjectToRecentList.Properties;
using SwissAcademic.Citavi.Shell;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AddCitaviProjectToRecentList
{
    public class Addon : CitaviAddOn<MainForm>
    {
        public override void OnHostingFormLoaded(MainForm mainForm)
        {
            var project = Program.Engine.Settings.General.KnownProjects.FirstOrDefault();

            if (project != null && !string.IsNullOrEmpty(project.ConnectionString) && project.ProjectType == SwissAcademic.Citavi.ProjectType.DesktopSQLite)
            {
                try
                {
                    Shell32Api.AddToRecentDocs(project.ConnectionString);
                }
                catch (Exception e)
                {
                    MessageBox.Show(mainForm, e.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
