[T4Scaffolding.Scaffolder(Description = "Functional Test")][CmdletBinding()]
param(
    [Parameter(Mandatory=$true, ValueFromPipelineByPropertyName=$true)]$TestName,        
    [string]$Project,	
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

# create the test fixture action
Scaffold MvcScaffolding.Action FunctionalTestFixtures $TestName -NoChildItems -OverrideTemplateFolders $TemplateFolders

# create the test fixture view
$path = Join-Path "Views/FunctionalTestFixtures" $TestName
Add-ProjectItemViaTemplate $path -Template "FixtureView" -Model @{
	ViewName = $TestName;	
} -SuccessMessage "Added $TestName view (render component) at '{0}'" -TemplateFolders $TemplateFolders -Force:$Force

# create the test javascript/funcunit view
$path = Join-Path "Views/FunctionalTestRunner" $TestName
Add-ProjectItemViaTemplate $path -Template "TestView" -Model @{
	ViewName = $TestName;	
} -SuccessMessage "Added $TestName view (test code) at '{0}'" -TemplateFolders $TemplateFolders -Force:$Force