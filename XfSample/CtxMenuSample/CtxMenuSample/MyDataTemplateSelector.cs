using Xamarin.Forms;

namespace CtxMenuSample
{
  public class MyDataTemplateSelector : DataTemplateSelector
  {
    public DataTemplate Temp1Template { get; set; }
    public DataTemplate Temp2Template { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
      return ((ContextMenuItem)item).Type == ContextMenuItemType.Temp1 ? Temp1Template : Temp2Template;
    }
  }
}