#l "generic-tasks.cake"
#l "apps-uwp-tasks.cake"
#l "apps-wpf-tasks.cake"
#l "components-tasks.cake"

var Target = GetBuildServerVariable("Target", "Default");

Information("Running target '{0}'", Target);
Information("Using output directory '{0}'", OutputRootDirectory);

//-------------------------------------------------------------

Task("UpdateInfo")
    .Does(() =>
{
    UpdateSolutionAssemblyInfo();
    
    UpdateInfoForComponents();
    UpdateInfoForUwpApps();
    UpdateInfoForWpfApps();
});

//-------------------------------------------------------------

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("UpdateInfo")
    .IsDependentOn("SonarBegin")
    .Does(() =>
{
    BuildComponents();
    BuildUwpApps();
    BuildWpfApps();

    if (string.IsNullOrWhiteSpace(SonarUrl))
    {
        // No need to log, we already did
        return;
    }

    SonarEnd(new SonarEndSettings 
    {
        Login = SonarUsername,
        Password = SonarPassword,
    });
});

//-------------------------------------------------------------

Task("Package")
    .IsDependentOn("CodeSign")
    .Does(() =>
{
    PackageComponents();
    PackageUwpApps();
    PackageWpfApps();
});

//-------------------------------------------------------------

Task("Default")
	.IsDependentOn("Build");

//-------------------------------------------------------------

RunTarget(Target);