var projectName = "Ghk.MultiTargeting";
var projectsToPackage = new [] { "Ghk.MultiTargeting" };
var company = "Geert van Horrik";
var startYear = 2018;
var defaultRepositoryUrl = string.Format("https://github.com/{0}/{1}", company, projectName);

#l "./deployment/cake/variables.cake"
#l "./deployment/cake/tasks.cake"
