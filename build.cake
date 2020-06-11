// Define the required parameters
var DefaultSolutionName = "Ghk.MultiTargeting";
var DefaultCompany = "Geert van Horrik";
var DefaultRepositoryUrl = string.Format("https://github.com/{0}/{1}", DefaultCompany, DefaultSolutionName);
var StartYear = 2018;

// Note: the rest of the variables should be coming from the build server,
// see `/deployment/cake/*-variables.cake` for customization options

//=======================================================

// Components

var ComponentsToBuild = new []
{
    "Ghk.MultiTargeting" 
};

//=======================================================

// WPF apps

var WpfAppsToBuild = new []
{
    "Ghk.MultiTargeting.Example.Wpf"
};

//=======================================================

// UWP apps

var UwpAppsToBuild = new []
{
    "Ghk.MultiTargeting.Example.Uwp"
};

//=======================================================

// Now all variables are defined, include the tasks, that
// script will take care of the rest of the magic

#l "./deployment/cake/tasks.cake"
