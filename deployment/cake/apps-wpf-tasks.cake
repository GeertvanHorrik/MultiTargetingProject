#l "apps-wpf-variables.cake"

//-------------------------------------------------------------

private bool HasWpfApps()
{
    return WpfApps != null && WpfApps.Length > 0;
}

//-------------------------------------------------------------

private void UpdateInfoForWpfApps()
{
    if (!HasWpfApps())
    {
        return;
    }

    // No specific implementation required for now    
}

//-------------------------------------------------------------

private void BuildWpfApps()
{
    if (!HasWpfApps())
    {
        return;
    }
    
    foreach (var wpfApp in WpfApps)
    {
        Information("Building WPF app '{0}'", wpfApp);

        var projectFileName = string.Format("./src/{0}/{0}.csproj", wpfApp);
        
        var msBuildSettings = new MSBuildSettings {
            Verbosity = Verbosity.Quiet, // Verbosity.Diagnostic
            ToolVersion = MSBuildToolVersion.VS2017,
            Configuration = ConfigurationName,
            MSBuildPlatform = MSBuildPlatform.x86, // Always require x86, see platform for actual target platform
            PlatformTarget = PlatformTarget.MSIL
        };

        // TODO: Enable GitLink / SourceLink, see RepositoryUrl, RepositoryBranchName, RepositoryCommitId variables

        MSBuild(projectFileName, msBuildSettings);
    }
}

//-------------------------------------------------------------

private void PackageWpfApps()
{
    if (!HasWpfApps())
    {
        return;
    }
    
    // TODO: Determine how to package (e.g. Squirrel)
}

//-------------------------------------------------------------

Task("UpdateInfoForWpfApps")
    .Does(() =>
{
    UpdateSolutionAssemblyInfo();
    UpdateInfoForWpfApps();
});

//-------------------------------------------------------------

Task("BuildWpfApps")
    .IsDependentOn("UpdateInfoForWpfApps")
    .Does(() =>
{
    BuildWpfApps();
});

//-------------------------------------------------------------

Task("PackageWpfApps")
    .IsDependentOn("BuildWpfApps")
    .Does(() =>
{
    PackageWpfApps();
});