using System;
using System.Linq;
using System.Windows.Forms;
using SwissAcademic.Citavi.Shell;

namespace AddCitaviProjectToRecentList
{
    public class AddCitaviProjectToRecentListAddon : CitaviAddOn<MainForm>
    {
        #region Methods

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
                    MessageBox.Show(mainForm, e.ToString(), "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            base.OnHostingFormLoaded(mainForm);
        }

        #endregion
    }
}
