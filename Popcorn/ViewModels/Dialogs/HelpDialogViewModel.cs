﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.IO;
using System.Windows.Input;

namespace Popcorn.ViewModels.Dialogs
{
    public class HelpDialogViewModel : ViewModelBase
    {
        /// <summary>
        /// The close command
        /// </summary>
        private ICommand _closeCommand;

        /// <summary>
        /// Close action
        /// </summary>
        private readonly Action _closeAction;

        /// <summary>
        /// Help
        /// </summary>
        private string _help;

        /// <summary>
        /// Constructor
        /// </summary>
        public HelpDialogViewModel(Action closeAction)
        {
            _closeAction = closeAction;
            var subjectType = GetType();
            var subjectAssembly = subjectType.Assembly;
            using (var stream = subjectAssembly.GetManifestResourceStream(@"Popcorn.Markdown.Help.md"))
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        Help = reader.ReadToEnd();
                    }
                }
            }

            CloseCommand = new RelayCommand(() =>
            {
                _closeAction.Invoke();
            });
        }

        /// <summary>
        /// The close command
        /// </summary>
        public ICommand CloseCommand
        {
            get => _closeCommand;
            set { Set(() => CloseCommand, ref _closeCommand, value); }
        }

        /// <summary>
        /// Help
        /// </summary>
        public string Help
        {
            get => _help;
            set { Set(() => Help, ref _help, value); }
        }
    }
}