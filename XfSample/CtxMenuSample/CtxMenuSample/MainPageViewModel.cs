using System.Collections.ObjectModel;

namespace CtxMenuSample
{
  public class MainPageViewModel
  {
    public ObservableCollection<ContextMenuItem> Items { get; private set; }

    public MainPageViewModel()
    {
      this.Items = new ObservableCollection<ContextMenuItem>
      {
        new ContextMenuItem { Item1Text = "Lorem", Text = "Cell 1", Type = ContextMenuItemType.Temp1 },
        new ContextMenuItem { Item1Text = "Ipsum", Text = "Cell 2", Type = ContextMenuItemType.Temp2 },
        new ContextMenuItem { Item1Text = "Dictum", Text = "Cell 3", Type = ContextMenuItemType.Temp1 },
        new ContextMenuItem { Item1Text = "Vestibulum", Text = "Cell 4", Type = ContextMenuItemType.Temp2 },
        new ContextMenuItem { Item1Text = "Hendrerit", Text = "Cell 5", Type = ContextMenuItemType.Temp1 },
        new ContextMenuItem { Item1Text = "Posuere", Text = "Cell 6", Type = ContextMenuItemType.Temp2 },
        new ContextMenuItem { Item1Text = "Bibendum", Text = "Cell 7", Type = ContextMenuItemType.Temp1 },
        new ContextMenuItem { Item1Text = "Vivamus", Text = "Cell 8", Type = ContextMenuItemType.Temp2 },
        new ContextMenuItem { Item1Text = "Enim", Text = "Cell 9", Type = ContextMenuItemType.Temp1 },
        new ContextMenuItem { Item1Text = "Quis", Text = "Cell 10", Type = ContextMenuItemType.Temp2 },
        new ContextMenuItem { Item1Text = "Phasellus", Text = "Cell 11", Type = ContextMenuItemType.Temp1 },
        new ContextMenuItem { Item1Text = "Pretium", Text = "Cell 12", Type = ContextMenuItemType.Temp2 },
        new ContextMenuItem { Item1Text = "Aliquam", Text = "Cell 13", Type = ContextMenuItemType.Temp1 },
        new ContextMenuItem { Item1Text = "Tristique", Text = "Cell 14", Type = ContextMenuItemType.Temp2 },
        new ContextMenuItem { Item1Text = "Malesuada", Text = "Cell 15", Type = ContextMenuItemType.Temp1 },
        new ContextMenuItem { Item1Text = "Dolor", Text = "Cell 16", Type = ContextMenuItemType.Temp2 },
        new ContextMenuItem { Item1Text = "Id", Text = "Cell 17", Type = ContextMenuItemType.Temp1 },
        new ContextMenuItem { Item1Text = "Orci", Text = "Cell 18", Type = ContextMenuItemType.Temp2 },
        new ContextMenuItem { Item1Text = "Diam", Text = "Cell 19", Type = ContextMenuItemType.Temp1 },
        new ContextMenuItem { Item1Text = "Nibh", Text = "Cell 20", Type = ContextMenuItemType.Temp2 },
        new ContextMenuItem { Item1Text = "Non", Text = "Cell 21", Type = ContextMenuItemType.Temp1 },
        new ContextMenuItem { Item1Text = "Aliquam", Text = "Cell 22", Type = ContextMenuItemType.Temp2 },
        new ContextMenuItem { Item1Text = "Ultrices", Text = "Cell 23", Type = ContextMenuItemType.Temp1 },
        new ContextMenuItem { Item1Text = "Vulputate", Text = "Cell 24", Type = ContextMenuItemType.Temp2 }
      };
    }
  }
}
