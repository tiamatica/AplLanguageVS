﻿using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using task = System.Threading.Tasks.Task;
using ui = Microsoft.VisualStudio.VSConstants.UICONTEXT;

namespace AplLanguageVS
{
    [Guid(PackageGuids.guidVSPackageString)]
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", Vsix.Version, IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideBindingPath()]
    [ProvideAutoLoad(_loadContext, PackageAutoLoadFlags.BackgroundLoad)]
    [ProvideUIContextRule(_loadContext,
        name: "Auto load",
        expression: "HasDot & FullyLoaded & (SingleProject | MultipleProjects)",
        termNames: new[] { "HasDot", "FullyLoaded", "SingleProject", "MultipleProjects" },
        termValues: new[] { "HierSingleSelectionName:\\.(.+)$", ui.SolutionExistsAndFullyLoaded_string, ui.SolutionHasSingleProject_string, ui.SolutionHasMultipleProjects_string })]

    public sealed class AplLanguageVSPackage : AsyncPackage
    {
        private const string _loadContext = "1501ac94-e5fa-4e6b-b780-0959421d99a3";

        protected override async task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
        }
    }
}