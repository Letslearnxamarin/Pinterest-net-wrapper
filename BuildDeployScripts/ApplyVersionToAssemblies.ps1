##-----------------------------------------------------------------------
## <copyright file="ApplyVersionToAssemblies.ps1">(c) Microsoft Corporation. This source is subject to the Microsoft Permissive License. See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx. All other rights reserved.</copyright>
##-----------------------------------------------------------------------
# Look for a 0.0.0.0 pattern in the build number. 
# If found use it to version the assemblies.
#
# For example, if the 'Build number format' build process parameter 
# $(BuildDefinitionName)_$(Year:yyyy).$(Month).$(DayOfMonth)$(Rev:.r)
# then your build numbers come out like this:
# "Build HelloWorld_2013.07.19.1"
# This script would then apply version 2013.07.19.1 to your assemblies.

# Enable -Verbose option
[CmdletBinding()]

# Regular expression pattern to find the version in the build number 
# and then apply it to the assemblies
$VersionRegex = "\d+\.\d+\.\d+\.\d+"

# If this script is not running on a build server, remind user to 
# set environment variables so that this script can be debugged
if(-not ($Env:Build.SourcesDirectory -and $Env:Build.BuildNumber))
{
    Write-Error "You must set the following environment variables"
    Write-Error "to test this script interactively."
    Write-Host '$Env:Build.SourcesDirectory - For example, enter something like:'
    Write-Host '$Env:Build.SourcesDirectory = "C:\code\FabrikamTFVC\HelloWorld"'
    Write-Host '$Env:Build.BuildNumber - For example, enter something like:'
    Write-Host '$Env:Build.BuildNumber = "Build HelloWorld_0000.00.00.0"'
    exit 1
}

# Make sure path to source code directory is available
if (-not $Env:Build.SourcesDirectory)
{
    Write-Error ("Build.SourcesDirectory environment variable is missing.")
    exit 1
}
elseif (-not (Test-Path $Env:Build.SourcesDirectory))
{
    Write-Error "Build.SourcesDirectory does not exist: $Env:Build.SourcesDirectory"
    exit 1
}
Write-Verbose "Build.SourcesDirectory: $Env:Build.SourcesDirectory"

# Make sure there is a build number
if (-not $Env:Build.BuildNumber)
{
    Write-Error ("Build.BuildNumber environment variable is missing.")
    exit 1
}
Write-Verbose "`nEnv:Build.SourcesDirectory:$Env:Build.SourcesDirectory`nBuild.BuildNumber: $Env:Build.BuildNumber" -Verbose

# Get and validate the version data
$VersionData = [regex]::matches($Env:Build.BuildNumber,$VersionRegex)
switch($VersionData.Count)
{
   0        
      { 
         Write-Error "Could not find version number data in Build.BuildNumber."
         exit 1
      }
   1 {}
   default 
      { 
         Write-Warning "Found more than instance of version data in Build.BuildNumber." 
         Write-Warning "Will assume first instance is version."
      }
}
$NewVersion = $VersionData[0]
Write-Verbose "Version: $NewVersion" -Verbose
Write-Host ("##vso[task.setvariable variable=ApplyVersionToAssemblies;]$NewVersion")

# Apply the version to the assembly property files
$files = gci $Env:Build.SourcesDirectory -recurse -include "*Properties*","My Project" | 
    ?{ $_.PSIsContainer } | 
    foreach { gci -Path $_.FullName -Recurse -include AssemblyInfo.* }
if($files)
{
    Write-Verbose "Will apply $NewVersion to $($files.count) files." -Verbose

    foreach ($file in $files) {
        $filecontent = Get-Content($file)
        attrib $file -r
        $filecontent -replace $VersionRegex, $NewVersion | Out-File $file
        Write-Verbose "$file.FullName - version applied"  -Verbose
    }
}
else
{
    Write-Warning "Found no files."
}

