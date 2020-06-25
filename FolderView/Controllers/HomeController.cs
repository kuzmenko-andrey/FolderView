using FoldreView.Models;
using FoldreView.Models.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FoldreView.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string path)
        {
            // TODO: Move to DI or make class member
            using (var db = new FolderContext())
            {
                /* // TODO: 
                 * var folders = db.Folders.Include(b => b.FolderTree).ToList();
                 */

                string basicUrl = string.Empty;
                string folderName = string.Empty;
                List<Folder> subfolders = new List<Folder>();
                if (!string.IsNullOrEmpty(path))
                {
                    basicUrl += @"/" + path;
                    folderName = Path.GetFileName(path.TrimEnd(Path.DirectorySeparatorChar));

                    var joinFolders = db.Folders.Join(db.FolderTree, f => f.Id, ft => ft.AncestorId,
                        (f, ft) => new
                        {
                            Id = f.Id,
                            Name = f.Name,
                            AncestorId = ft.AncestorId,
                            DescendantId = ft.DescendantId
                        }).ToList();

                    var descendantFolders = joinFolders.FindAll(f => f.Name == folderName);
                    subfolders = db.Folders.Where(f => descendantFolders.Exists(ff => ff.DescendantId == f.Id)).ToList();
                }
                else
                {
                    subfolders.Add(db.Folders.Single(x => x.Id == 1));
                }

                List<FoldersView> folders = new List<FoldersView>();
                foreach (var folder in subfolders)
                {
                    folders.Add(new FoldersView() { Name = folder.Name, Url = basicUrl + @"/" + folder.Name });
                }
                PageView view = new PageView()
                {
                    Name = folderName,
                    Folders = folders
                };

                return View(view);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
