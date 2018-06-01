# MultiTargetingProject

This is an example repository on how to target .NET 4.6, .NET 4.7 and UAP 10.0 using a single project.

This project has been written as an example for the [blog post about multi-targeting platforms with a single project](http://geertvanhorrik.com/2018/03/14/multi-targeting-net-4-6-net-4-7-uap-10-0-with-a-single-project/).

# How to build this example

1. Open powershell with the repository as working directory
2. `.\build.ps1 -target package`

# How does it work?

The scripts are extremely generic. One only has to customize 2 files:

1. `/build.cake`
2. `/deployment/cake/variables.cake` (but really, your build server should be passing in these values)

The cake magic happens in `/deployment/cake/tasks.cake`

# Project differences compared to the original template

Compared to the [original multi-targeting example](https://oren.codes/2017/01/04/multi-targeting-the-world-a-single-project-to-rule-them-all/), the following changes were made.

## Project defines

To make sure I could still use the defines we invested in (to maximize code-sharing, we use a lot of `#if` in code shared between WPF and UWP). This project creates the following defines:

* .NET 4.6 => NET; NET46
* .NET 4.7 => NET; NET47
* UAP 10.0 => UAP; NETFX_CORE
* .NET Standard 2.0 => NS; NS20; NETSTANDARD; NETSTANDARD2_0

## Include solution assembly info

The project structure adds this line to the project to include the SolutionAssemblyInfo and GlobalSuppressions files which are in the root of the solution.

	<Compile Include="..\*.cs" />

## Allow shared code-behind (e.g. MyView.xaml.cs) with a *per platform* view (e.g. MyView.xaml)

To allow sharing of code-behind of a view (for example, for custom controls), we need to to a bit of hacking. We create the view inside each platform specific view directory:

* Platforms\net\Views\MyView.xaml (+ .cs)
* Platforms\uap10.0\Views\MyView.xaml (+ .cs)

After creating the views, one will need to customize the code-behind to add a partial method:

	public partial class MyView
	{
	     public MyView()
	     {
	         InitializeComponent();
	 
	         Construct();
	     }
	 
	     partial void Construct();
	}

Next, create a partial code-behind class inside the regular views folder that contains the shared code:

* Views\MyView.xaml.cs

This view should contain the following code and allows sharing code-behind but have per-platform xaml files:

	public partial class MyView
	{
	     partial void Construct()
	     {
	         // TODO: Add shared constructor info here
	     }
	}

As an example, a dependency property is added in the shared code-behind that shows how to deal with the different platforms in shared code using defines.

# Credits

- [Multi-targeting the world: a single project to rule them all](https://oren.codes/2017/01/04/multi-targeting-the-world-a-single-project-to-rule-them-all/) (Oren Novotny - January 4, 2017)