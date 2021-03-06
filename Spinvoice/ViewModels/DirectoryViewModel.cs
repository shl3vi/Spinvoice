﻿using System.Collections.ObjectModel;
using System.Linq;
using Spinvoice.Domain.Utils;
using Spinvoice.Services;

namespace Spinvoice.ViewModels
{
    public class DirectoryViewModel : IFileSystemViewModel
    {
        public DirectoryViewModel(
            string path,
            IFileService fileService,
            ISelectedPathListener selectedPathListener)
        {
            Path = path;
            Name = System.IO.Path.GetFileName(path);

            Items = new ObservableCollection<IFileSystemViewModel>();
            Items.AddRange(fileService.GetSubDirectories(path)
                .Select(s => new DirectoryViewModel(s, fileService, selectedPathListener)));
            Items.AddRange(fileService.GetFiles(path)
                .Where(s => System.IO.Path.GetExtension(s) == ".pdf")
                .Select(s => new FileViewModel(s, selectedPathListener)));
        }

        public string Name { get; }

        public string Path { get; }

        public ObservableCollection<IFileSystemViewModel> Items { get; }

        public bool IsSelected { get; set; }
    }
}
