#addin nuget:?package=Cake.Git&version=0.22.0

using Path = System.IO.Path;

var target = Argument("target", "Default");

const string WYAM = "wyam";
var OUTPUT_DIR = Path.GetFullPath("output/");

var TARGET_PROJECT = "testcentric.github.io";
var TARGET_PROJECT_URI = $"https://github.com/TestCentric/{TARGET_PROJECT}";
var PREVIEW_URI = "http://localhost#5080";

var DEPLOY_DIR_NAME = $"../{TARGET_PROJECT}.deploy";
var DEPLOY_DIR = Path.GetFullPath(DEPLOY_DIR_NAME);
var DEPLOY_BRANCH = "master";

const string USER_ID = "USER_ID";
const string USER_EMAIL = "USER_EMAIL";
const string GITHUB_ACCESS_TOKEN = "GITHUB_ACCESS_TOKEN";

string UserId;
string UserEmail;
string GitHubAccessToken;

Setup((context) =>
{
    UserId = context.EnvironmentVariable(USER_ID);
    UserEmail = context.EnvironmentVariable(USER_EMAIL);
    GitHubAccessToken = context.EnvironmentVariable(GITHUB_ACCESS_TOKEN);
});

Task("Build")
    .Does(() => StartProcess(WYAM, "build"));

Task("Preview")
    .IsDependentOn("Build")
    .Does(() => StartProcess(WYAM, "preview"));

Task("Deploy")
    .IsDependentOn("Build")
    .Does(() => 
    {
        if(FileExists("./CNAME"))
            CopyFileToDirectory("./CNAME", OUTPUT_DIR);

        if (DirectoryExists(DEPLOY_DIR))
            DeleteDirectory(DEPLOY_DIR, new DeleteDirectorySettings {
                Recursive = true,
                Force = true
            });

        Information($"Checking out {TARGET_PROJECT} in {DEPLOY_DIR_NAME}...");
        GitClone(TARGET_PROJECT_URI, DEPLOY_DIR, new GitCloneSettings()
        {
            Checkout = true,
            BranchName = DEPLOY_BRANCH
        });

        Information("Copying output files...");
        CopyDirectory(OUTPUT_DIR, DEPLOY_DIR);

        Information("Committing changes...");
        GitAddAll(DEPLOY_DIR);
        GitCommit(DEPLOY_DIR, UserId, UserEmail, "Deploy site to GitHub Pages");

        Information($"Pushing to the {DEPLOY_BRANCH} branch...");
        GitPush(DEPLOY_DIR, UserId, GitHubAccessToken, DEPLOY_BRANCH);
    });

Task("Default")
    .IsDependentOn("Build");
    
RunTarget(target);
